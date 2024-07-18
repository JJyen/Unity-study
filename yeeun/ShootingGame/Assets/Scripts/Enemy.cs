using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5; // 이동속도
    Vector3 dir;
    public GameObject explosionFactory; // 폭발 공장 주소 - 외부에서 값 설정
    void Start()
    {
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

        // 2. 폭발 효과 고앙에서 폭발 효과 하나 생성
        GameObject explosion = Instantiate(explosionFactory);

        // 3. 폴발표과를 발생시킴
        explosion.transform.position = transform.position;

        // Destroy(): 게임 오브젝트를 파괴하는 함수
        Destroy(other.gameObject); // 총알 파괴
        Destroy(gameObject); // 적 파괴

        // [스코어 기록하기]
        // 1. 씬에서 ScoreManager 객체를 찾아옴
        GameObject smObject = GameObject.Find("ScoreManager");

        // 2. ScoreManager 게임 오브젝트에서 ScoreManager 컴포넌트(ScoreManager 스크립트)를 가져옴
        ScoreManager sm = smObject.GetComponent<ScoreManager>();

        // 3. ScoreManager 클래스의 속성에 값 할당
        sm.currentScore++;

        // 4. 화면에 현재 점수 표시하기
        sm.currentScoreUI.text = "현재 점수: " + sm.currentScore;


        // [최고 점수 기록하기]
        // 1. 현재 점수가 최고 점수를 초과했다면
        if(sm.currentScore > sm.bestScore){
            // 2. 최고 점수 갱신
            sm.bestScore = sm.currentScore;

            // 3. 최고 점수 UI에 표시
            sm.bestScoreUI.text = "최고 점수: " + sm.bestScore;

            // [최고 점수 클라이언트에 저장하기]
            PlayerPrefs.SetInt("Best Score", sm.bestScore); // PlayerPrefs객체: 키-값 형태로 값 저장 
        }


    }
    private void OnCollisionStay(Collision other){
        // 충돌 중
    }
    private void OnCollisionExit(Collision other){
        // 충돌 끝 
    }
}
