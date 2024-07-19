using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 영역 내에서 다른 물체를 감지할 경우
    private void OnTriggerEnter(Collider other){
        // 해당 물체 파괴 및 자원 반환
        //Destroy(other.gameObject);

        // 1. 충돌한 물체가 총알이거나 적이면
        if(other.gameObject.name.Contains("Bullet") ||
            other.gameObject.name.Contains("Enemy")){
                // 2. 충돌한 물체 비활성화
                other.gameObject.SetActive(false);
            }
    }
}
