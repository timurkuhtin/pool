using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnballs : MonoBehaviour
{
    public GameObject ball;
    private GameObject ballinst;
    private Rigidbody rb;
    public void spawn()
    {
        ballinst = Instantiate(ball, new Vector3(0, (float)0.785, 0), Quaternion.identity) as GameObject;
        ballinst = Instantiate(ball, new Vector3((float)7.63, (float)0.785, 0), Quaternion.identity) as GameObject;
        ballinst = Instantiate(ball, new Vector3((float)8.33, (float)0.785, (float)0.35), Quaternion.identity) as GameObject;
        ballinst = Instantiate(ball, new Vector3((float)8.33, (float)0.785, (float)-0.35), Quaternion.identity) as GameObject;
        ballinst = Instantiate(ball, new Vector3((float)9.03, (float)0.785, (float)0), Quaternion.identity) as GameObject;
        ballinst = Instantiate(ball, new Vector3((float)9.03, (float)0.785, (float)-0.7), Quaternion.identity) as GameObject;
        ballinst = Instantiate(ball, new Vector3((float)9.03, (float)0.785, (float)0.7), Quaternion.identity) as GameObject;
        ballinst = Instantiate(ball, new Vector3((float)9.73, (float)0.785, (float)0.35), Quaternion.identity) as GameObject;
        ballinst = Instantiate(ball, new Vector3((float)9.73, (float)0.785, (float)-0.35), Quaternion.identity) as GameObject;
        ballinst = Instantiate(ball, new Vector3((float)9.73, (float)0.785, (float)1.05), Quaternion.identity) as GameObject;
        ballinst = Instantiate(ball, new Vector3((float)9.73, (float)0.785, (float)-1.05), Quaternion.identity) as GameObject;
        rb = ball.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("boll1(Clone)") == null)
        {
            SceneManager.LoadScene("main");
        }
    }
}
