using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    float minTime = 1; // 최소 시간
    float maxTime = 5; // 최대 시간
    float currentTime; // 현재 시간
    public float createTime = 1; // 일정 시간
    public GameObject enemyFactory; // 적 공장
    public int poolSize = 10; // 오브젝트 풀 크기
    GameObject[] enemyObjectPool; // 오브젝트 풀 배열
    public Transform[] spawnPoints; // SpawnPoints

    // 1. 태어날 때
    void Start()
    {
        // 태어날 때 적의 생성 시간 설정
        createTime = Random.Range(minTime, maxTime);

        // 2. 오브젝트 풀을 에너미들을 담을 수  있는 크기로 만든다.
        enemyObjectPool = new GameObject[poolSize];

        // 3. 오브젝트 풀에 넣을 에너미 갯수만큼 반복
        for(int i=0; i<poolSize; i++){
            //4. 에너미 공장에서 에너미 생성
            GameObject enemy = Instantiate(enemyFactory);

            // 5. 에너미 오브젝트 풀에 넣기
            enemyObjectPool[i] = enemy;
            // 비활성화
            enemy.SetActive(false);
        }
    }

    void Update()
    {
        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime;

        //2. 현재 시간이 일정 시간을 초과하면
        if(currentTime > createTime){

            // 에너미 풀의 에너미들 중
            for(int i=0; i < poolSize; i++){
                GameObject enemy = enemyObjectPool[i];
                
                // 비활성화 에너미가 있다면
                if(enemy.activeSelf == false){
                    // 에너미 활성화
                    enemy.SetActive(true);

                    // 랜덤으로 스폰포인트 인덱스 선택
                    int index = Random.Range(0, spawnPoints.Length);

                    // 에너미 이동
                    enemy.transform.position = spawnPoints[index].position;

                    // 비활성화 에너미 검색 중단
                    break;
                }
            }
           
            // 적을 생성한 후 적의 생성 시간 다시 설정
            createTime = Random.Range(minTime, maxTime);

            currentTime = 0; // 현재 시간 초기화
        }
    }
}
