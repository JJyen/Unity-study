using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // 목표가 될 트랜스폼 컴포넌트(Player > CamPosition)
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        // 카메라 위치 -> 목표 트랜스폼 컴포넌트
        transform.position = target.position;
    }
}

