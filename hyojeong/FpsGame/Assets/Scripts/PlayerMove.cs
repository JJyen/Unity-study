using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 이동 속도 변수
    public float moveSpeed = 7f;

    // 캐릭터 콘트롤러 변수
    CharacterController cc;

    // 중력 변수
    float gravity = -20f;

    // 수직 속력 변수
    float yVelocity = 0;

    // 점프력 변수
    public float jumpPower = 10f;

    // 점프 상태 변수
    public bool isJumping = false;

    private void Start()
    {
        // 캐릭터 콘트롤러 컴포넌트 받아오기
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        // wase 키를 누르면 입력하면 캐릭터를 그 방향으로 이동시키고 싶다.
        // spacebar 키를 누르면 캐릭터를 수직으로 점프시키고 싶다.

        // 1. 사용자의 입력을 받는다.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 2. 이동 방향을 설정한다.
        Vector3 dir = new Vector3(h, v);
        dir = dir.normalized;

        // 2-1. 메인 카메라를 기준으로 방향을 변환한다.
        dir = Camera.main.transform.TransformDirection(dir);

        // 2-2. 만일, 점프 중이었고, 다시 바닥에 착지했다면
        if(cc.collisionFlags == CollisionFlags.Below)
        {
            // 만일, 점프 중이었다면
            if( isJumping)
            {
                // 점프 전 상태로 초기화한다.
                isJumping = false;
                // 캐릭터 수직 속도를 0으로 만든다.
                yVelocity = 0;
            }
        }

        // 2-3. 만일, 스페이스바를 눌렀고, 점프를 하지 않은 상태라면
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            // 캐릭터 수직 속도에 점프력을 적용한다.
            yVelocity = jumpPower;
            isJumping = true;
        }

        // 2-3. 캐릭터 수직 속도에 중력 값을 적용한다.
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        // 3. 이동 속도에 맞춰 이동한다.
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}
