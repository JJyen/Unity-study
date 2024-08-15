using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    // 에너미 상태 상수
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Damaged,
        Die
    }

    // 에너미 상태 변수
    EnemyState m_State;

    void Start()
    {
        // 최초의 에너미 상태는 대기 상태(Idle)로 한다.
        m_State = EnemyState.Idle;
    }

    void Update()
    {
        // 현재 상태를 체크하여 해당 상태별로 정해진 기능을 수행하게 하고 싶다.
        switch (m_State)
        {
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
    }
}
