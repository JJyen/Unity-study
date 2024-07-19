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
    }

    void OnEnable()
    {
        // 0 ���� 9(10-1)���� �� �߿� �ϳ��� �������� �����ͼ�
        int randValue = UnityEngine.Random.Range(0, 10);
        // ���� 3���� ������ �÷��̾� ����
        if(randValue < 3)
        {
            // �÷��̾ ã�Ƽ� target���� �ϰ� �ʹ�.
            GameObject target = GameObject.Find("Player");
            // ������ ���ϰ� �ʹ�
            dir = target.transform.position - transform.position;
            // ������ ũ�⸦ 1�� �ϰ� �ʹ�.
            dir.Normalize();
        }
        // �׷��� ������ �Ʒ� �������� ���ϰ� �ʹ�
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
        // 1. ���ʹ̸� ���� ������ ���� ������ ǥ���ϰ� �ʹ�
        ScoreManager.Instance.Score++;
        // 2. ���� ȿ�� ���忡�� ���� ȿ���� ������ �Ѵ�.
        GameObject explosion = Instantiate(explosionFactory);
        // 3. ���� ȿ���� �߻�(��ġ)��Ű�� �ʹ�.
        explosion.transform.position = transform.position;

        // 1. ���� �ε��� ��ü�� Bullet�̶��
        if(collision.gameObject.name.Contains("Bullet"))
        {
            // 2. �ε��� ��ü�� ��Ȱ��ȭ
            collision.gameObject.SetActive(false);

            // PlayerFire Ŭ���� ������
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            // ����Ʈ�� �Ѿ� ����
            player.bulletObjectPool.Add(collision.gameObject);
        }
        // 3. �׷��� ������ ����
        else
        {
            Destroy(collision.gameObject);
        }
        //Destroy(gameObject);
        gameObject.SetActive(false);

        // EnemyManager Ŭ���� ��������
        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>();
        //����Ʈ�� �Ѿ� ����
        manager.enemyObjectPool.Add(collision.gameObject);
    }
    
}