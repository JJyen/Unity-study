using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 필요 속성: 이동 속도
    public float speed = 5;

    GameObject player;

    // 방향을 전역 변수로 만들어 Start와 Update에서 사용
    Vector3 dir;

    // 폭발 공장 주소(외부에서 값을 넣어준다)
    public GameObject explosionFactory;

    // Start is called before the first frame update
    void Start()
    {
        // 0부터 9까지 10개의 값 중에 하나를 랜덤으로 가져온다.
        int randValue = UnityEngine.Random.Range(0, 10);
        // 만약 3보다 작으면 플레이어 방향
        if(randValue < 3)
        {
            // 플레이어를 찾아 target으로 하고 싶다.
            GameObject target = GameObject.Find("Player");
            // 방향을 구하고 싶다. target-me
            dir = target.transform.position;
            // 방향을 크기를 1로 하고 싶다.
            dir.Normalize();
        }
        // 그렇지 않으면 아래 방향으로
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 2. 이동하고 싶다. 공식 P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }

    // 충돌 시작
    /*
    private void OnCollisionEnter(Collision other)
    {
        // 너 죽고
        Destroy(other.gameObject);
        // 나 죽자
        Destroy(gameObject);
    }
    */

    // 1. 적이 다른 물체와 출동했을 때
    private void OnCollisionEnter(Collision collision)
    {
        // 점수 표시
        // 1. 씬에서 ScoreManager 객체를 가져오자.
        GameObject smObject = GameObject.Find("ScoreManager");
        // 2. ScoreManager 클래스의 속성에 값을 할당한다.
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        // 3. ScoreManager의 Get/Set 함수로 수정
        sm.SetScore(sm.GetScore() + 1);

        /* 
        //ScoreManager.cs로 이동
        // 3. ScoreManager 클래스의 속성에 값을 할당한다.
        sm.currentScore++;
        // 4. 화면에 현재 점수 표시하기
        sm.currentScoreUI.text = "현재 점수 : " + sm.currentScore;

        // 1. 현재 점수가 최고 점수를 초과했다면
        if(sm.currentScore > sm.bestScore)
        {
            // 2. 최고 점수를 갱신한다.
            sm.bestScore = sm.currentScore;
            // 3. 최고 점수 UI에 표시
            sm.bestScoreUI.text = "최고 점수 : " + sm.bestScore;
            // 최고 점수 저장
            PlayerPrefs.SetInt("Best Score", sm.bestScore);
        }
        */

        // 2. 폭발 효과 공장에서 폭발 효과를 만들어야 한다.
        GameObject explosion = Instantiate(explosionFactory);
        // 3. 폭발 효과를 발생(위치)시키고 싶다.
        explosion.transform.position = transform.position;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}