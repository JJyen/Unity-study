using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 총알을 생산할 공장
    public GameObject bulletFactory;
    // 탄창에 넣을 수 있는 총알의 개수
    public int poolSize = 10;
    // 오브젝트 풀 배열
    public List<GameObject> bulletObjectPool;
    // 총구
    public GameObject firePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        // 2. 탄창을 총알 담을 수 있는 크기로 만들어 준다.
        bulletObjectPool = new List<GameObject>();
        // 3. 탄창에 넣을 총알 개수만큼 반복해
        for(int i = 0; i < poolSize; i++)
        {
            // 4. 총알 공장에서 총알을 생성한다.
            GameObject bullet = Instantiate(bulletFactory);
            // 5. 총알을 오브젝트 풀에 넣고 싶다.
            bulletObjectPool.Add(bullet);
            // 비활성화
            bullet.SetActive(false);
        }

        // 실행되는 플랫폼이 안드로이드일 경우 조이스틱을 활성화 시킨다
        #if UNITY_ANDROID
            GameObject.Find("Joystick canvas XYBZ").SetActive(true);
        #elif UNITY_EDITOR || UNITY_STANDALONE
            GameObject.Find("Joystick canvas XYBZ").SetActive(false);
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        // 유니티 데이터와 PC환경일때 동작
#if UNITY_EDITOR || UNITY_STANDALONE
        // 목표: 사용자가 발사 버튼을 누르면 총알을 발사하고 싶다.
        // 순서 1: 사용자가 발사 버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
#endif
    }

    public void Fire()
    {
        // 2. 탄창 안에 총알이 있다면
        if (bulletObjectPool.Count > 0)
        {
            // 3. 비활성화된 총알을 하나 가져온다.
            GameObject bullet = bulletObjectPool[0];
            // 4. 총알을 발사하고 싶다(활성화 시킨다)
            bullet.SetActive(true);
            // 오브젝트 풀에서 총알 제거
            bulletObjectPool.Remove(bullet);

            // 총알을 위치시키기
            bullet.transform.position = transform.position;
        }
    }
}
