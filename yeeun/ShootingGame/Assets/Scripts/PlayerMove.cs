using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //print("h: " + h + "v: " + v);

        //Vector3 dir = Vector3.right*h + Vector3.up*v;
        Vector3 dir = new Vector3(h,v,0);
        
        //transform.Translate(dir*speed*Time.deltaTime);
        // =>> P = P0 + vt
        //transform.position += dir*speed*Time.deltaTime;
        transform.position = transform.position + dir*speed*Time.deltaTime;
    }
}
