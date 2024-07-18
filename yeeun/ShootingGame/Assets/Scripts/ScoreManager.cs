using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 유니티 UI를 사용하기 위한 네임스페이스

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI; // 현재 점수 UI
    private int currentScore; // 현재 점수  
    public Text bestScoreUI; // 최고 점수 UI
    private int bestScore; // 최고 점수

    // currentScore에 값 넣고 화면에 표시하기
    public void SetScore(int value){
        currentScore = value;
        // 3. ScoreManager 클래스의 속성에 값 할당
        //currentScore++;
        currentScore = value;

        // 4. 화면에 현재 점수 표시하기
        currentScoreUI.text = "현재 점수: " + currentScore;


        // [최고 점수 기록하기]
        // 1. 현재 점수가 최고 점수를 초과했다면
        if(currentScore > bestScore){
            // 2. 최고 점수 갱신
            bestScore = currentScore;

            // 3. 최고 점수 UI에 표시
            bestScoreUI.text = "최고 점수: " + bestScore;

            // [최고 점수 클라이언트에 저장하기]
            PlayerPrefs.SetInt("Best Score", bestScore); // PlayerPrefs객체: 키-값 형태로 값 저장 
        }

    }

    // currentScore 값 바꾸기
    public int GetScore(){
        return currentScore;
    }


    // Start is called before the first frame update
    void Start()
    {
        // 1. 최고 점수 불러와서 bestscore에 넣기
        bestScore = PlayerPrefs.GetInt("Best Score", 0); // 0은 키에 대응하는 값이 없을 때 넣어주는 값

        // 2. 최고 점수 화면에 표시
        bestScoreUI.text = "최고 점수: " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
