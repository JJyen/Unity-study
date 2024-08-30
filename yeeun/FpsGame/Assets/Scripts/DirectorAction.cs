using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class DirectorAction : MonoBehaviour
{
    PlayableDirector pd; // 감독 오브젝트
    public Camera targetCam;

    // 첫 번쨰 프레임 업데이트 전에 시작이 호출됨
    void Start()
    {
        // Director 오브젝트가 갖고 있는 PlayableDirector  컴포넌트를 가져온다.
        pd = GetComponent<PlayableDirector>();

        // 타임라인 실행
        pd.Play();
    }

    // 프레임당 한 번 업데이트가 호출됨
    void Update()
    {
        // 현재 진행중인 시간이 전체 시간과 크거나 같으면
        if(pd.time >= pd.duration)
        {
            // 메인 카메라가 타깃 카메라(씨네머신에 활용하는 카메라)라면
            // 제어를 위해 씨네머신 브레인 비활성화
            if(Camera.main ==targetCam)
            {
                targetCam.GetComponent<CinemachineBrain>().enabled = false;
            }

            // 씨네머신에 사용한 카메라도 비활성화
            targetCam.gameObject.SetActive(false);

            // Director 본인 비활성화
            gameObject.SetActive(false);

        }
    }
}
