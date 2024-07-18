using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 유니티 UI를 사용하기 위한 네임스페이스

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI; // 현재 점수 UI
    public int currentScore; // 현재 점수  
    public Text bestScoreUI; // 최고 점수 UI
    public int bestScore; // 최고 점수


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
