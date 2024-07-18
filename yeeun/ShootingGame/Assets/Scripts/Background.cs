using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Material bgMaterial; // 배경 머티리얼
    public float scrollSpeed = 0.2f; // 스크롤 속도



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 1. 실행되는 동안 계속 스크롤
    void Update()
    {
        // 2. 방향, Vector2: 이차원 -> x, y 값만 가지는 벡터. offset은 x, y 값만 가지므로 Vector2 사용
        Vector2 dir = Vector2.up;

        // 3. 스크롤 => 이동, mainTextureOffset: offset 정보를 Vector2 형태로 가지고 있는 속성
        bgMaterial.mainTextureOffset += dir*scrollSpeed*Time.deltaTime;
    }
}
