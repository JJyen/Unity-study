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

                // 3. 총돌한 물체가 총알일 경우 총알 리스트에 삽입
                if(other.gameObject.name.Contains("Bullet")){
                    // PlayerFire 클래스 가져오기
                    PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

                    // 리스트에 총알 삽입
                    player.bulletObjectPool.Add(other.gameObject);

                } else if(other.gameObject.name.Contains("Enemy")){
                    // EnemyManager 클래스 가져오기
                    EnemyManager player = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();

                    // 리스트에 에너미 삽입
                    player.enemyObjectPool.Add(other.gameObject);

                }
            }
    }
}
