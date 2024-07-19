using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // ������Ʈ Ǯ ũ��
    public int poolSize = 10;
    // ������Ʈ Ǯ �迭
    public List<GameObject> enemyObjectPool;
    // SpawnPoint��
    public Transform[] spawnPoints;

    // �ּ� �ð�
    public float minTime = 0.5f;
    // �ִ� �ð�
    public float maxTime = 1.5f;

    // ���� �ð�
    float currentTime;
    // ���� �ð�
    public float creatTime = 1;
    // �� ����
    public GameObject enemyFactory;

    // Start is called before the first frame update
    void Start()
    {
        // �¾ �� ���� ���� �ð��� �����ϰ�
        creatTime = UnityEngine.Random.Range(minTime, maxTime);

        // 2. ������Ʈ Ǯ�� ���ʹ̵��� ���� �� �ִ� ũ��� ������ش�.
        enemyObjectPool = new List<GameObject>();
        // 3. ������Ʈ Ǯ�� ���� ���ʹ� ������ŭ �ݺ���
        for(int i = 0; i < poolSize; i++)
        {
            // 4. ���ʹ� ���忡�� ���ʹ̸� �����Ѵ�.
            GameObject enemy = Instantiate(enemyFactory);
            // 5. ���ʹ̸� ������Ʈ Ǯ�� �ְ� �ʹ�.
            enemyObjectPool.Add(enemy);
            // ��Ȱ��ȭ��Ű��.
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        // 1. ���� �ð��� �Ǿ����ϱ�
        if (currentTime > creatTime)
        {
            // 2. ������Ʈ Ǯ�� ���ʹ̰� �ִٸ�
            if(enemyObjectPool.Count > 0)
            {
                // ������Ʈ Ǯ���� ���ʹ̸� ������ ����ϵ��� �Ѵ�.
                GameObject enemy = enemyObjectPool[0];
                // ������Ʈ Ǯ���� ���ʹ� ����
                enemyObjectPool.Remove(enemy);
                // �������� �ε��� ����
                int index = UnityEngine.Random.Range(0, spawnPoints.Length);
                // ���ʹ� ��ġ��Ű��
                enemy.transform.position = spawnPoints[index].position;
                // 4. ���ʹ̸� Ȱ��ȭ�ϰ� �ʹ�.
                enemy.SetActive(true);
            }

            creatTime = UnityEngine.Random.Range(minTime, maxTime);
            currentTime = 0;
        }
    }
}
