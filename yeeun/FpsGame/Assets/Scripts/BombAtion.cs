using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAtion : MonoBehaviour
{
    public GameObject bombEffect;

    //충돌 시 호출되는 이벤트 함수
    private void OnCollisionEnter(Collision collision){
        // 이펙트 프리팹 생성
        GameObject eff = Instantiate(bombEffect);

        // 에펙트 프리팹의 위치를 수류탄 오브젝트 자신의 위치와 동일하게
        eff.transform.position = transform.position;

        // 본인 제거
        Destroy(gameObject);
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
