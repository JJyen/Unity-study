using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;    //PlayableDirector�� �����ϱ� ���� ���ӽ����̽�
using Cinemachine;              //ChimachineBrain�� �����ϱ� ���� ���ӽ����̽�

//���׸ӽ��� �����ϰ� �ʹ�
public class DirectorAction : MonoBehaviour
{
    PlayableDirector pd; //���� ������Ʈ

    public Camera targetCam;

    void Start()
    {
        //Director ������Ʈ�� ������ �ִ� PlayableDirector ������Ʈ�� ������ �´�.
        pd = GetComponent<PlayableDirector>();
        //Ÿ�Ӷ����� �����Ѵ�.
        pd.Play();
    }

    void Update()
    {
        //���� �������� �ð��� ��ü �ð��� ũ�ų� ������ (����ð��� �� �Ǹ�)
        if (pd.time >= pd.duration)
        {
            //���࿡ ����ī�޶� Ÿ��ī�޶�(���׸ӽſ� Ȱ���ϴ� ī�޶�)���
            //��� ���ؼ� ���׸ӽ� �극���� ��Ȱ��ȭ �ض�
            if (Camera.main == targetCam)
            {
                targetCam.GetComponent<CinemachineBrain>().enabled = false;
            }
            //���׸ӽſ� ����� ī�޶� ��Ȱ��ȭ �ض�
            targetCam.gameObject.SetActive(false);

            //Director �ڽ��� ��Ȱ��ȭ �ض�
            gameObject.SetActive(false);
        }
    }
}