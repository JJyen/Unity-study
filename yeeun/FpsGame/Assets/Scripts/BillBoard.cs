using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        
    }

    void Update()
    {
        // 본인의 방향을 카메라의 방향과 일치시킴
        transform.forward = target.forward;
    }
}
