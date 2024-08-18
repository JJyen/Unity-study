using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f; // 이동 속도

    CharacterController cc; // 캐릭터 컨트롤러 변수
    float gravity = -20f; // 중력 변수
    float yVelocity = 0; // 수직 속력 변수
    public float jumpPower = 10f; // 점프력 변수
    public bool isJumping = false; // 점프상태 변수
    public int hp = 20; // 플레이어 체력 변수

    int maxHp = 20; // 최대 체력 변수
    public Slider hpSlider; // hp 슬라이더 변수
    public GameObject hitEffect;


    // 플레이어 피격 함수
    public void DamageAction(int damage)
    {
        // 에너미의 공격력만큼 플레이어의 체력 깎기
        hp -= damage;

        // 플레이어의 체력이 0보다 크면 피격 효과를 출력
        if(hp > 0)
        {
            // 피격 이펙트 코루틴 시작
            StartCoroutine(PlayHitEffect());
        }
    }

    // 피격 효과 코루틴 함수
    IEnumerator PlayHitEffect()
    {
        // 1. 피격 UI 활성화
        hitEffect.SetActive(true);

        // 2. 0.3초간 대기
        yield return new WaitForSeconds(0.3f);

        // 3. 피격 UI 비활성
        hitEffect.SetActive(false);
    }

    void Start(){
        cc = GetComponent<CharacterController>(); // 캐릭터 컨트롤러 컴포넌트 받아오기 Q. 해당 스크립트가 할당된 객체의 컨.컴 받아오는 거??
    }

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

        // 2.2 플레이어가 바닥에 있는 상태라면
        if(cc.collisionFlags == CollisionFlags.Below){
            // 이전 상태가 점프 상태였다면
            if(isJumping){
                isJumping = false;

                // 수직 속도 0 => 구조물에서 떨어질 때 순간이동 효과 방지
                yVelocity = 0;
            }
        }

        // 2.3 space를 입력하고, 이전 상태가 점프X인 상태라면
        if(Input.GetButtonDown("Jump") && !isJumping){
            // 플레이어 점프상태로
            yVelocity = jumpPower;
            isJumping = true;
        } 

        // 2.3 캐릭터 수직 속도에 중력 값 적용
        yVelocity += gravity*Time.deltaTime;
        dir.y = yVelocity;

        // 3. 이동 속도에 맞춰서 이동
        // p = p0 + vt
        //transform.position += dir*moveSpeed*Time.deltaTime;
        cc.Move(dir*moveSpeed*Time.deltaTime);

        // 4. 현재 플레이어 hp(%)를 hp 슬라이더를 value에 반영
        hpSlider.value = (float)hp / (float)maxHp;


    }
}
