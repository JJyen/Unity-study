using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destoryTime = 1.5f; // 제거될 시간 변수
    float currentTime = 0; // 경과 시간 측정용 변수

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 경과 시간이 제거될 시간을 초과하면 본인 제거
        if(currentTime > destoryTime){
            Destroy(gameObject);
        }
        currentTime += Time.deltaTime; // 경과 시간 누적
    }
}
