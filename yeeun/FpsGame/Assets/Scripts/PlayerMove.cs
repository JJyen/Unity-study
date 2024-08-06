using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;

    void Update()
    {
        //  W, A, S, D 키 사용
        // 1. 사용자 입력받기
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 2. 방향 설정
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized; // 벡터 정규화

        // 2.1 메인 카메라 기준으로 상대좌표 설정
        dir = Camera.main.transform.TransformDirection(dir); // TransformDirection(Vector3 direction): 게임 오브젝트를 기준으로 상대 방향 벡터로 변환

        // 3. 이동 속도에 맞춰서 이동
        // p = p0 + vt
        transform.position += dir*moveSpeed*Time.deltaTime;



    }
}
