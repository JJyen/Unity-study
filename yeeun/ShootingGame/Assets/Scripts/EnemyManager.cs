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

    void Start()
    {
        // 태어날 때 적의 생성 시간 설정
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    void Update()
    {
        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime;

        //2. 현재 시간이 일정 시간을 초과하면
        if(currentTime > createTime){
            // 3. 적 공장에서 적을 생성
            GameObject enemy = Instantiate(enemyFactory);

            // 4. 내 위치로 이동하도록 함
            enemy.transform.position = transform.position;

            currentTime = 0; // 현재 시간 초기화

            // 적을 생성한 후 적의 생성 시간 다시 설정
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }
    }
}
