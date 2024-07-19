using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5; // 이동속도
    Vector3 dir;
    public GameObject explosionFactory; // 폭발 공장 주소 - 외부에서 값 설정
    
    void Start(){}

    void OnEnable(){
        // 0부터 9까지의 10개의 값 중에 하나를 랜덤으로 가져온다
        int randValue = UnityEngine.Random.Range(0,10);

        // 랜덤 값이 3보다 작으면(30% 확률로 적이 플레이어 방향으로 이동)
        if(randValue < 3){
            // 플레이어를 찾아 타겟으로
            GameObject target = GameObject.Find("Player"); //괄호 안의 이름을 가진 오브젝트를 찾아서 반환

            // 플레이어 방향 = target - me
            dir = target.transform.position - transform.position;

            // 방향의 크기는 1
            dir.Normalize();
        }else{
            // 기본 동작
            dir = Vector3.down;
        }
    }

    void Update()
    {
        //transform.position = dir*speed*Time.deltaTime; // 이동: P = P0 + vt
        transform.Translate(dir * speed * Time.deltaTime);
    }

    //1. 적이 다른 물체와 충돌하면
    private void OnCollisionEnter(Collision other){
        // 충돌 시작

        // 2. 폭발 효과 공장에서 폭발 효과 하나 생성
        GameObject explosion = Instantiate(explosionFactory);

        // 3. 폴발표과를 발생시킴
        explosion.transform.position = transform.position;

        // Destroy(): 게임 오브젝트를 파괴하는 함수
        // 적과 총알이 충돌했을 때 총알이 파괴되어 존재하지 않는 객체를 참조하는 문제를 해결하기 위해 총알 파괴X -> 비활성화
        // 1. 충돌한 물체가 총알이라면
        if(other.gameObject.name.Contains("Bullet")){
            // 2. 총돌한 물체(총알) 비활성화
            other.gameObject.SetActive(false);
        }else{
            Destroy(other.gameObject); // 플레이어..?
        }
         gameObject.SetActive(false); // 에너미 비활성화

        // 싱글턴 디자인 패턴을 사용해서 스코어 기록하기
        //ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1);

        // + get/set 프로퍼티 사용하기
        ScoreManager.Instance.Score++;

    }
    private void OnCollisionStay(Collision other){
        // 충돌 중
    }
    private void OnCollisionExit(Collision other){
        // 충돌 끝 
    }
}
