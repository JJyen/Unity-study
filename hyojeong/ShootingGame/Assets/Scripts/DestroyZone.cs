using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // ���� �ȿ� �ٸ� ��ü�� ������ ���
    private void OnTriggerEnter(Collider other)
    {
        // �� ��ü�� ���ְ� �ʹ�.
        //Destroy(other.gameObject);
        
        // 1. ���� �ε��� ��ü�� Bullet�̰ų� Enemy�̶��
        if(other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        {
            // 2. �ε��� ��ü�� ��Ȱ��ȭ
            other.gameObject.SetActive(false);

            // 3. �ε��� ��ü�� �Ѿ��� ��� �Ѿ� ����Ʈ�� ����
            if(other.gameObject.name.Contains("Bullet"))
            {
                // PlayerFire Ŭ���� ������
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
                // ����Ʈ�� �Ѿ� ����
                player.bulletObjectPool.Add(other.gameObject);
            }
            else if (other.gameObject.name.Contains("Enemy"))
            {
                GameObject emObject = GameObject.Find("EnemyManager");
                EnemyManager manager = emObject.GetComponent<EnemyManager>();
                //����Ʈ�� �Ѿ� ����
                manager.enemyObjectPool.Add(other.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
