using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject firePosition; // 발사 위치
    public GameObject bombFactory; // 투척 무기 오브젝트
    public float throwPower = 15f; // 투척 파워
    public GameObject bulletEffect; // 피격 이펙트 오브젝트
    ParticleSystem ps; // 피격 이펙트 파티클 시스템
    public int weaponPower = 5; // 발사 무기 공격력

    // Start is called before the first frame update
    void Start() 
    {
        // 피격 이펙트 오브젝트에서 파티클 시스템 컴포넌트 가져오기
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 오르쪽 버튼을 누르면 시선이 바라보는 방향으로 수류탄 던지기

        // 1. 마우스 오르쪽 버튼 입력 받기  // 좌측: 0, 우측: 1, 휠: 2
        if(Input.GetMouseButton(1)){
            // 수류탄 오브젝트를 생성한 후 수류탄의 생성 위치를 발사 위치로 함
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            // 수류탄 오브젝트의 Rigidbody 컴포넌트 가져오기
            Rigidbody rb = bomb.GetComponent<Rigidbody>();

            // 카메라의 정면 방향으로 수류탄에 물리적인 힘을 가함
            rb.AddForce(Camera.main.transform.forward*throwPower, ForceMode.Impulse); //AddForce(발사 방향 및 힘, 던지는 방식(순간적 힘 + 질량O)) 
        }

        // 마우스 왼쪽을 누르면 시선이 바라보는 방향으로 총알 발사
        // 마우스 왼쪽 버튼 입력 받기
        if(Input.GetMouseButtonDown(0)){
            // 레이 생성 후 발사될 우치와 진행 방향 설정
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            // 레이가 부딪힌 대상의 정보를 저장할 변수를 생성
            RaycastHit hitInfo = new RaycastHit();

            // 레이 발사 후 부딪힌 물체가 있으면 피격 이펙트 표시
            if(Physics.Raycast(ray, out hitInfo)){
                // 레이에 부딪힌 대상의 레이어가 "Enemy"라면  데미지 함수 실행
                if(hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                //  피격 이펙트의 위치를 레이가 부딪힌 지점으로 이동
                bulletEffect.transform.position = hitInfo.point;

                // 피격 이펙트의 위치를 레이가 부딫힌 지점으로 이동
                bulletEffect.transform.forward = hitInfo.normal;

                // 피격 이펙트 플레이
                ps.Play();
            }
        }

    }
}
