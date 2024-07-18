using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 5; //이동속도

    void Update(){
        Vector3 dir = Vector3.up; //방향 구하기
        transform.position += dir*speed*Time.deltaTime; //이동하기
    }
}
