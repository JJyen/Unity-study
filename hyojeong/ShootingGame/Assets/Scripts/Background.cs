using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // ��� ��Ƽ����
    public Material bgMaterial;
    // ��ũ�� �ӵ�
    public float scrollSpeed = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // 1. ����ִ� ���� ��� �ϰ� �ʹ�.
    void Update()
    {
        // 2. ������ �ʿ��ϴ�
        Vector2 direction = Vector2.up;

        // 3. ��ũ�� �ϰ� �ʹ�. P = P0 + vt
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
