using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; //총알 공장(Bullet 파일이 할당되어 있음)
    public GameObject firePosition; //총구

    public int poolSize = 10; // 탄창에 넣을 수 있는 총알의 갯수
    GameObject[] bulletObjectPool; // 오브젝트 풀 배열 => 탄창

    // 1. 태어날 때
    void Start()
    {
        // 2. 탄창을 총알 담을 수 있는 크기로 만든다.
        bulletObjectPool = new GameObject[poolSize];

        // 3. 탄창에 넣을 총알 갯수만큼 반복해서
        for(int i=0; i<poolSize; i++){
            // 4. 총알 공장에서 총알을 생성
            GameObject bullet = Instantiate(bulletFactory);
            
            // 5. 총알을 오브젝트 풀에 넣는다.
            bulletObjectPool[i] = bullet;
            // 플레이어가 버튼을 누르기 전까지 총알 객체 비활성화
            bullet.SetActive(false); // SetActive(false/ture): 게임오브젝트에서 제공하는 활성/비활성 설정 함수
        }
    }

    void Update()
    {
        // 1. 사용자가 버튼을 누르면
        if(Input.GetButtonDown("Fire1")){
            // // 2. 공장에서 총알 생산
            // GameObject bullet = Instantiate(bulletFactory); // Instantiate(): 동적으로 오브젝트를 생성하는 함수
            
            // // 3. 총알 발사
            // // 생성된 총알이 알아서 이동하도록 해두었기 때문에 위치만 총구에 있도록 설정해주면 됨
            // bullet.transform.position = firePosition.transform.position;

            // 2. 탄창 안에 있는 총알들 중
            for(int i=0; i<poolSize; i++){
                // 3. 총알이 비활성화 상태라면
                GameObject bullet = bulletObjectPool[i];
                if(bullet.activeSelf == false){ //activeSelf(): 객체의 활성화 여부를 판단하는 함수
                    // 4. 총알 활성화 후 발사
                    bullet.SetActive(true);
                    bullet.transform.position = firePosition.transform.position;

                    // 총알을 발사했으므로 비활성화 총알 검색 중단
                    break;
                }
            }
        }
    }
}
