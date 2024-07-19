using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // �Ѿ��� ������ ����
    public GameObject bulletFactory;
    // źâ�� ���� �� �ִ� �Ѿ��� ����
    public int poolSize = 10;
    // ������Ʈ Ǯ �迭
    public List<GameObject> bulletObjectPool;
    // �ѱ�
    public GameObject firePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        // 2. źâ�� �Ѿ� ���� �� �ִ� ũ��� ����� �ش�.
        bulletObjectPool = new List<GameObject>();
        // 3. źâ�� ���� �Ѿ� ������ŭ �ݺ���
        for(int i = 0; i < poolSize; i++)
        {
            // 4. �Ѿ� ���忡�� �Ѿ��� �����Ѵ�.
            GameObject bullet = Instantiate(bulletFactory);
            // 5. �Ѿ��� ������Ʈ Ǯ�� �ְ� �ʹ�.
            bulletObjectPool.Add(bullet);
            // ��Ȱ��ȭ
            bullet.SetActive(false);
        }

        // ����Ǵ� �÷����� �ȵ���̵��� ��� ���̽�ƽ�� Ȱ��ȭ ��Ų��
        #if UNITY_ANDROID
            GameObject.Find("Joystick canvas XYBZ").SetActive(true);
        #elif UNITY_EDITOR || UNITY_STANDALONE
            GameObject.Find("Joystick canvas XYBZ").SetActive(false);
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        // ����Ƽ �����Ϳ� PCȯ���϶� ����
#if UNITY_EDITOR || UNITY_STANDALONE
        // ��ǥ: ����ڰ� �߻� ��ư�� ������ �Ѿ��� �߻��ϰ� �ʹ�.
        // ���� 1: ����ڰ� �߻� ��ư�� ������
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
#endif
    }

    public void Fire()
    {
        // 2. źâ �ȿ� �Ѿ��� �ִٸ�
        if (bulletObjectPool.Count > 0)
        {
            // 3. ��Ȱ��ȭ�� �Ѿ��� �ϳ� �����´�.
            GameObject bullet = bulletObjectPool[0];
            // 4. �Ѿ��� �߻��ϰ� �ʹ�(Ȱ��ȭ ��Ų��)
            bullet.SetActive(true);
            // ������Ʈ Ǯ���� �Ѿ� ����
            bulletObjectPool.Remove(bullet);

            // �Ѿ��� ��ġ��Ű��
            bullet.transform.position = transform.position;
        }
    }
}
