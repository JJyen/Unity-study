using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // �ʿ� �Ӽ�: �̵� �ӵ�
    public float speed = 5;

    GameObject player;

    // ������ ���� ������ ����� Start�� Update���� ���
    Vector3 dir;

    // ���� ���� �ּ�(�ܺο��� ���� �־��ش�)
    public GameObject explosionFactory;

    // Start is called before the first frame update
    void Start()
    {
        // 0���� 9���� 10���� �� �߿� �ϳ��� �������� �����´�.
        int randValue = UnityEngine.Random.Range(0, 10);
        // ���� 3���� ������ �÷��̾� ����
        if(randValue < 3)
        {
            // �÷��̾ ã�� target���� �ϰ� �ʹ�.
            GameObject target = GameObject.Find("Player");
            // ������ ���ϰ� �ʹ�. target-me
            dir = target.transform.position;
            // ������ ũ�⸦ 1�� �ϰ� �ʹ�.
            dir.Normalize();
        }
        // �׷��� ������ �Ʒ� ��������
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 2. �̵��ϰ� �ʹ�. ���� P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }

    // �浹 ����
    /*
    private void OnCollisionEnter(Collision other)
    {
        // �� �װ�
        Destroy(other.gameObject);
        // �� ����
        Destroy(gameObject);
    }
    */

    // 1. ���� �ٸ� ��ü�� �⵿���� ��
    private void OnCollisionEnter(Collision collision)
    {
        // ���� ǥ��
        // 1. ������ ScoreManager ��ü�� ��������.
        GameObject smObject = GameObject.Find("ScoreManager");
        // 2. ScoreManager Ŭ������ �Ӽ��� ���� �Ҵ��Ѵ�.
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        // 3. ScoreManager�� Get/Set �Լ��� ����
        sm.SetScore(sm.GetScore() + 1);

        /* 
        //ScoreManager.cs�� �̵�
        // 3. ScoreManager Ŭ������ �Ӽ��� ���� �Ҵ��Ѵ�.
        sm.currentScore++;
        // 4. ȭ�鿡 ���� ���� ǥ���ϱ�
        sm.currentScoreUI.text = "���� ���� : " + sm.currentScore;

        // 1. ���� ������ �ְ� ������ �ʰ��ߴٸ�
        if(sm.currentScore > sm.bestScore)
        {
            // 2. �ְ� ������ �����Ѵ�.
            sm.bestScore = sm.currentScore;
            // 3. �ְ� ���� UI�� ǥ��
            sm.bestScoreUI.text = "�ְ� ���� : " + sm.bestScore;
            // �ְ� ���� ����
            PlayerPrefs.SetInt("Best Score", sm.bestScore);
        }
        */

        // 2. ���� ȿ�� ���忡�� ���� ȿ���� ������ �Ѵ�.
        GameObject explosion = Instantiate(explosionFactory);
        // 3. ���� ȿ���� �߻�(��ġ)��Ű�� �ʹ�.
        explosion.transform.position = transform.position;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}