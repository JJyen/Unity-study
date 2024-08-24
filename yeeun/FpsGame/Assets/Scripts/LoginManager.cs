using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 사용자 데이터를 새로 저장하거나 저장된 데이터를 읽어 사용자의 입력과 일치하는지 검사
public class LoginManager : MonoBehaviour
{
    // 사용자 아이디 변수
    public InputField id;

    // 사용자 비밀번호 변수
    public InputField password;

    // 검사 텍스트 변수
    public Text notify;
    
    void Start()
    {
        // 검색 텍스트 창을 비운다.
        notify.text = "";
    }

    void Update()
    {
        
    }

    // 입력 완료 확인 함수
    bool CheckInput(string id, string password)
    {
        // 아이디와 비밀번호 입력란이 하나라도 비어 있으면 사용자 정보 입력을 요구한다.
        if(id == "" || password == "")
        {
            notify.text = "아이디 또는 비밀번호를 입력해주세요.";
            return false;
        }
        // 입력이 비어 있지 안흐면 true 반환
        else
        {
            return true;
        }
    }

    // 아이디, 비밀번호 저장 함수
    public void SaveUserData()
    {
        // 입력 검사에 문제가 있으면 함수 종료
        if(!CheckInput(id.text, password.text))
        {
            return;
        }
        
        // 사용자의 아이디는 키(Key), 비밀번호는 값(Value)가 된다.
        PlayerPrefs.SetString(id.text, password.text);

        // 시스템에 저장되어 있는 아이디가 존재하지 않으면
        if(!PlayerPrefs.HasKey(id.text))
        {
            // 사용자의 아이딛를 키, 비밀번호를 값으로 설정해서 저장
            PlayerPrefs.SetString(id.text, password.text);
            notify.text = "아이디 생성이 완료되었습니다.";
        } 
        // 그렇지 않으면, 이미 존재한다는 메시지 출력
        else
        {
            notify.text = "이미 존재하는 아이디입니다.";
        }
    }

    //  로그인 함수
    public void CheckUserDate()
    {
        // 입력 검사에 문제가 있으면 함수 종료
        if(!CheckInput(id.text, password.text))
        {
            return;
        }

        // 사용자가 입력한 아이디를 키로 사용해서 시스템에 저장된 값을 불러온다.
        string pass = PlayerPrefs.GetString(id.text);

        // 사용자가 입력한 비밀번호와 시스템에서 불러온 값을 비교해서 동일하다면
        if(password.text == pass)
        {
            // 다음 씬(1번 씬 - 메인) 로드
            SceneManager.LoadScene(1);
        }
        // 두 데이터이 값이 다르면, 사용자 정보 불일치 메시지를 남긴다.
        else
        {
            notify.text = "입력하신 아이디와 비밀번호가 일치하지 않습니다.";
        }
    }
}
