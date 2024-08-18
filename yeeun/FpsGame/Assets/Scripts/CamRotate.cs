using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 200f; // 회전 속도

    float mx =0; // 회전 값
    float my =0;

    // Update is called once per frame
    void Update()
    {
        // 1. 마우스 입력 받기
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        // // 2. 마우스 입력 값 이용해서 회전 방향 결정하기
        // Vector3 dir = new Vector3(-mouse_Y, mouse_X, 0);

        // // 3. 물체 회전
        // transform.eulerAngles += dir*rotSpeed*Time.deltaTime;

        // // 4. x축 회전 값 -90~90으로 제한
        // Vector3 rot = transform.eulerAngles;
        // rot.x = Mathf.Clamp(rot.x, -90f, 90f);
        // transform.eulerAngles = rot;

        // 1.1 마우스 입력 값 누적 ???
        mx +=  mouse_X*rotSpeed*Time.deltaTime;
        my += mouse_Y*rotSpeed*Time.deltaTime;

        // 1.2 x축 회전 값 -90~90으로 제한
        // Clamp(float value, float min, float max)
        // value: 제한 하려는 값
        // min: 허용 최솟값
        // max: 허용 최댓값 
        my = Mathf.Clamp(my, -90f, 90f);

        // 2. 회전
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
