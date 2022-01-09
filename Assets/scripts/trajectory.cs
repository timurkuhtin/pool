using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trajectory : MonoBehaviour
{
    public GameObject ballpref;
    private LineRenderer lineRenderer;
    private Dictionary<Rigidbody, objectData> saveObject = new Dictionary<Rigidbody, objectData>();
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        foreach(var rb in FindObjectsOfType<Rigidbody>())
        {
            saveObject.Add(rb, new objectData());
        }
    }
    public void showtrajectory(Vector3 origin, Vector3 speed) 
    {
        foreach (var objects in saveObject)
        {
            objects.Value.position = objects.Key.transform.position;
            objects.Value.rotation = objects.Key.transform.rotation;
            objects.Value.velosity = objects.Key.velocity;
            objects.Value.angularVelosity = objects.Key.angularVelocity;
        }
        GameObject ball1 = Instantiate(ballpref, origin, Quaternion.identity);
        ball1.GetComponent<Rigidbody>().AddForce(speed, ForceMode.Impulse);
        Physics.autoSimulation = false;
        Vector3[] point = new Vector3[100];
        point[0] = ball1.transform.position;
        for (int i = 1; i < point.Length; i++)
        {
            Physics.Simulate(10f);
            point[i] = ball1.transform.position;
            
        }
        lineRenderer.SetPositions(point);
        Physics.autoSimulation = true;
        foreach (var objects in saveObject)
        {
             objects.Key.transform.position = objects.Value.position;
             objects.Key.transform.rotation = objects.Value.rotation;
             objects.Key.velocity = objects.Value.velosity;
             objects.Key.angularVelocity = objects.Value.angularVelosity;
        }
        Destroy(ball1.gameObject);
    }
}

public class objectData
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 velosity;
    public Vector3 angularVelosity;
}