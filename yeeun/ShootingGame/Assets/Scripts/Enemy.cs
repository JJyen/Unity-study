using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5; // 이동속도

    void Update()
    {
        Vector3 dir = Vector3.down; // 방향

        transform.position = dir*speed*Time.deltaTime; // 이동: P = P0 + vt
    }

    private void OnCollisionEnter(Collision other){
        // 충돌 시작

        // Destroy(): 게임 오브젝트를 파괴하는 함수
        Destroy(other.gameObject); // 총알 파괴
        Destroy(gameObject); // 적 파괴
    }
    private void OnCollisionStay(Collision other){
        // 충돌 중
    }
    private void OnCollisionExit(Collision other){
        // 충돌 끝
    }
}
