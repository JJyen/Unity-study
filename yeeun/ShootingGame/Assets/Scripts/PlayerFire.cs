using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; //총알 공장(Bullet 파일이 할당되어 있음)
    public GameObject firePosition; //총구

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 사용자가 버튼을 누르면
        if(Input.GetButtonDown("Fire1")){
            // 2. 공장에서 총알 생산
            GameObject bullet = Instantiate(bulletFactory); // Instantiate(): 동적으로 오브젝트를 생성하는 함수
            
            // 3. 총알 발사
            // 생성된 총알이 알아서 이동하도록 해두었기 때문에 위치만 총구에 있도록 설정해주면 됨
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
