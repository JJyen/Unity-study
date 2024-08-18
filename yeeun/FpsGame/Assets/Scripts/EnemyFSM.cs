using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Damaged,
        Die
    }

    EnemyState m_State; // 에너미 상태 변수
    public float findDistance = 8f; // 플레이어 발견 범위
    Transform player; // 플레이어 트랜스폼
    public float attackDistance = 2f; // 공경 가능 범위
    public float moveSpeed = 5f; // 이동 속도
    CharacterController cc; // 캐릭터 컨트롤러 컴포넌트
    float currentTime = 0; // 누적 시간
    float attackDelay = 2f; // 공격 딜레이 시간
    public int attackPower = 3; // 에너미의 공격력

    // 초기 위치 및 회전 값 저장 변수
    Vector3 originPos;
    Quaternion originRot;
    public float moveDistance = 20f; // 이동 가능 범위
    public int hp = 15; // 에너미의 체력
    int maxHp = 15; // 에너미 최대 체력
    public Slider hpSlider; // 에너미 hp Slider 변수
    Animator anim; // 애니메이터 변수


    void Idle()
    {
        // 플레이어와의 거리가 액션 시작 범위 이내라면 Move 상태로 전환
        if(Vector3.Distance(transform.position, player.position) < findDistance){
            m_State = EnemyState.Move;
            print("상태 전환: Idle -> Move");
        }

        // 이동 애니메이션으로 전환
        anim.SetTrigger("IdleToMove");
    }

    void Move()
    {
        // 현재 위치가 초기 위치에서 이동 가능 범위를 넘어간다면
        if(Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            // 현재 상태를 Return으로 전환
            m_State = EnemyState.Return;
            print("상태 전환: Move -> Return");
        }
        //플레이어와의 거리가 공격 범위 밖이라면 플레이어를 향해 이동
        else if(Vector3.Distance(transform.position, player.position)>attackDistance)
        {
            // 이동 방향 설정
            Vector3 dir = (player.position - transform.position).normalized;

            // 캐릭터 컨트롤러 이용해서 이동하기
            cc.Move(dir*moveSpeed*Time.deltaTime);

            // 플레이어쪽으로 뱡향 전환
            transform.forward = dir;
        }
        else // 아니면 현재 상태를 Attack으로 변경
        {
            m_State = EnemyState.Attack;
            print("상태 전환: Move -> Attack");

            // 공격 대기 애니메이션 플레이
            anim.SetTrigger("MoveToAttackDelay");
        }
    }

    void Attack()
    {
        // 플레이어가 공격  범위 이내에 있다면 플레이어 공격
        if(Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            // 일정 시간마다 플레이어 공격
            currentTime += Time.deltaTime;
            
            if(currentTime > attackDelay){
                //player.GetComponent<PlayerMove>().DamageAction(attackPower);
                print("공격");
                currentTime = 0;

                // 공격 애니메이션 플레이
                anim.SetTrigger("StartAttack");
            }
        }
        else // 아니면 현재 상태를 Move로 전환(재추격)
        {
            m_State = EnemyState.Move;
            print("상태 전환: Attack -> Move");
            currentTime = 0;
            
            // // 누적 시간을 공격 딜레이 시간만큼 미리 진행시켜 놓음
            // currentTime = attackDelay; ??

            // 이동 애니메이션 플레이
            anim.SetTrigger("AttackToMove");
        }
    }

    // 플레이어 스크립트이 데미지 처리 함수 실행
    public void AttackAction()
    {
        player.GetComponent<PlayerMove>().DamageAction(attackPower);
    }

    void Return()
    {
        // 초기 위치에서의 거리가 0.1f 이상히라면 초기 위치쪽으로 이동
        if(Vector3.Distance(transform.position, originPos) > 0.1f)
        {
            Vector3 dir = (originPos - transform.position).normalized;
            cc.Move(dir*moveSpeed*Time.deltaTime);

            // 복귀 지점으로 방향 전환
            transform.forward = dir;
        }
        else // 아니면 자신의 위치를 초기 위치롤 조정하고 현태 상태를 Idle로 전환
        {
            transform.position = originPos;
            transform.rotation = originRot;

            // hp 회복
            hp = maxHp;
            m_State = EnemyState.Idle;
            print("상태 전환: Return -> Idle");

            // 대기 애니메이션으로 전환하는 트랜지션 호출
            anim.SetTrigger("MoveToIdle");
        }
    }

    public void HitEnemy(int hitPower)
    {
        // 이미 피격 상태이거나 사망 상태 또는 복귀 상태라면 아무런 처리도 하지 않고 함수 종료
        if (m_State == EnemyState.Damaged || m_State == EnemyState.Die || m_State == EnemyState.Return)
        {
            return;
        }

        // 플레이어의 공격력만큼 에너미의 체력 감소
        hp -= hitPower;

        // 에너미의 체력이 0보다 크면 Damaged 상태로 전환
        if(hp > 0){
            m_State = EnemyState.Damaged;
            print("상태 전환: Any State -> Damaged");

            // 피격 애니메이션 플레이
            anim.SetTrigger("Damaged");
            Damaged();
        }
        else // 아니면 Die 상태로 전환
        {
            m_State = EnemyState.Die;
            print("상태 전환: Any State -> Die");

            // 죽음 애니메이션 플레이
            anim.SetTrigger("Die");
            Die();
        }
    }

    void Damaged()
    {
        // 피격 상태를 처리하기 위한 코루틴 실행
        StartCoroutine(DamageProcess());
    }

    private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }

    // 데미지 처리용 코루틴 함수
    IEnumerable DamageProcess()
    {
        // 피격 모션 시간만큼 기다림
        yield return new WaitForSeconds(1.0f);

        // 현재 상태를 Move 상태로 전환
        m_State = EnemyState.Move;
        print("상태 전환: Damaged -> Move");
    }

    void Die()
    {
        // 진행중인 피격 코루틴 중지
        StopAllCoroutines();

        // 죽음 상태를 처리하기 위한 코루틴 실행
        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        // 캐릭터 컨트롤러 컴포넌트 비활성화
        cc.enabled = false;

        // 2초 동안 기다린 뒤에 본인 제거
        yield return new WaitForSeconds(2f);
        print("소멸!");
        Destroy(gameObject);
    }

    void Start()
    {
        m_State = EnemyState.Idle;

        player = GameObject.Find("Player").transform; // 플레이어의 트랜스폼 컨포넌트

        cc = GetComponent<CharacterController>(); // 캐릭터 컨트롤러 컴포넌트 받아오기


        // 자신의 초기 위치 및 회전 값 저장
        originPos = transform.position;
        originRot = transform.rotation;

        anim = transform.GetComponentInChildren<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        switch(m_State){
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                //Damaged();
                break;
            case EnemyState.Die:
                //Die();
                break;
        }

        // 현재 hp(%)를 hp 슬라이더의 value에 반영'
        hpSlider.value = (float)hp / (float)maxHp;
    }
    
}
