using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_boll : MonoBehaviour
{
    public Vector3 direction;
    public float hit_power;
    public Rigidbody rb;
    public trajectory trajectory;
    int f = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnTriggerEnter(Collider wall)
    {
        if (wall.gameObject.name == "board_top")
        {          
            rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, rb.velocity.z);
        }
        if (wall.gameObject.name == "board")
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -rb.velocity.z);
        }
        if (wall.gameObject.name == "hole")
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision wall)
    {
        if (wall.gameObject.name == "boll1(Clone)")
        {
            if ((rb.gameObject.transform.position.x > wall.gameObject.transform.position.x) && (rb.gameObject.transform.position.z > wall.gameObject.transform.position.z))
            {
                direction = new Vector3((rb.gameObject.transform.position.x - wall.gameObject.transform.position.x) * hit_power / 10, 0, (rb.gameObject.transform.position.z - wall.gameObject.transform.position.z) * hit_power / 10);
                rb.AddForce(direction, ForceMode.Impulse);
            }
        }
    }
    public void GetDirection()
    {
        if (((-185 + Input.mousePosition.y) > rb.worldCenterOfMass.x * 10) && ((111 - Input.mousePosition.x) > rb.worldCenterOfMass.z * 10))
        {
            //print(1);
            direction = new Vector3(-(-185 + Input.mousePosition.y - rb.worldCenterOfMass.x * 10) * hit_power / 10, 0, -(111 - Input.mousePosition.x - rb.worldCenterOfMass.z * 10) * hit_power / 10);
        }
        else if (((-185 + Input.mousePosition.y) > rb.worldCenterOfMass.x * 10) && ((111 - Input.mousePosition.x) < rb.worldCenterOfMass.z * 10))
        {
            //print(2);
            direction = new Vector3(-(-185 + Input.mousePosition.y - rb.worldCenterOfMass.x * 10) * hit_power / 10, 0, -(111 - Input.mousePosition.x - rb.worldCenterOfMass.z * 10) * hit_power / 10);
        }
        else if (((-185 + Input.mousePosition.y) < rb.worldCenterOfMass.x * 10) && ((111 - Input.mousePosition.x) > rb.worldCenterOfMass.z * 10))
        {
            //print(3);
            direction = new Vector3((-(-185 + Input.mousePosition.y - rb.worldCenterOfMass.x * 10) * hit_power / 10), 0, (-(111 - Input.mousePosition.x - rb.worldCenterOfMass.z * 10) * hit_power / 10));
        }
        else if (((-185 + Input.mousePosition.y) < rb.worldCenterOfMass.x * 10) && ((111 - Input.mousePosition.x) < rb.worldCenterOfMass.z * 10))
        {
            //print(4);
            direction = new Vector3(-(-185 + Input.mousePosition.y - rb.worldCenterOfMass.x * 10) * hit_power / 10, 0, -(111 - Input.mousePosition.x - rb.worldCenterOfMass.z * 10) * hit_power / 10);
        }
    }
    private void Update()
    {
        if (f == 1)
        {
            GetDirection();
            //trajectory.showtrajectory(rb.worldCenterOfMass, direction);
        }
    }
    private void FixedUpdate()
    {
        
        if ((Math.Abs(rb.velocity.x)<1)&& (Math.Abs(rb.velocity.z) < 1))
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if ((Math.Abs(-185 + Input.mousePosition.y - rb.worldCenterOfMass.x * 10) < 10)&& (Math.Abs(111 - Input.mousePosition.x - rb.worldCenterOfMass.z * 10) < 10))
            {
                if ((Math.Abs(rb.velocity.x) < 1) && (Math.Abs(rb.velocity.z) < 1))
                {
                    f = 1;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (f == 1)
            {
                GetDirection();
                rb.AddForce(direction, ForceMode.Impulse);
            }
            f = 0;
        }        
    }
}
