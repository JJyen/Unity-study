using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // �Ѿ��� ������ ����
    public GameObject bulletFactory;
    //�ѱ�
    public GameObject firePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ��ǥ: ����ڰ� �߻� ��ư�� ������ �Ѿ��� �߻��ϰ� �ʹ�.
        // ���� 1: ����ڰ� �߻� ��ư�� ������
        if(Input.GetButtonDown("Fire1"))
        {
            // 2: �Ѿ� ���忡�� �Ѿ��� �����
            GameObject bullet = Instantiate(bulletFactory);
            // 3: �Ѿ��� �߻��Ѵ�.
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
