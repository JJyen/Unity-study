using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 싱글톤 변수
    public static GameManager gm;
    
    private void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }
    }

    // 게임 상태 상수
    public enum GameState
    {
        Ready,
        Run,
        GameOver,
        Pause, // 일시정지
    }

    // 현재의 게임 상태 변수
    public GameState gState;

    // 게임 상태 UI 오브젝트 변수
    public GameObject gameLabel;

    // 게임 상태 UI 텍스트 컴포넌트 변수
    Text gameText;

    // PlayerMove 클래스 변수
    PlayerMove player;

    // 옵션 화면 UI 오브젝틑 변수
    public GameObject gameOption;

    void Start()
    {
        // 초기 게임 상태는 준비 상태로 설정한다.
        gState = GameState.Ready;

        // 게임 상태 UI 오브젝트에서 Text 컴포넌트를 가져온다.
        gameText = gameLabel.GetComponent<Text>();

        // 상태 텍스트의 내용을 "Ready..."로 한다.
        gameText.text = "Ready...";

        // 상태 텍스트의 색상을 주황색으로 한다.
        gameText.color = new Color32(255, 185, 0, 255);

        // 게임 준비 -> 게임 중 상태로 전환하기
        StartCoroutine(ReadyToStart());

        // 플레이어 오브젝트를 찾은 뒤, 플레이어의 PlayerMove 컴포넌트 받아오기
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    IEnumerator ReadyToStart()
    {
        // 2초간 대기한다.
        yield return new WaitForSeconds(2f);

        // 상태 텍스트의 내용을 "Go!"로 한다.
        gameText.text = "Go!";

        // 0.5초간 대기한다.
        yield return new WaitForSeconds(0.5f);

        // 상태 텍스트를 비활성화한다.
        gameLabel.SetActive(false);

        // 상태를 "게임 중" 상태로 변경한다.
        gState = GameState.Run;
    }

    void Update()
    {
        // 만일, 플레이어의 hp가 0 이하라면...
        if(player.hp <= 0)
        {
            // 플레이어 애니메이션을 멈춘다.
            player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);
            // 상태 텍스트를 활성화한다.
            gameLabel.SetActive(true);

            // 상태 텍스트의 내용을 "Game Over"로 한다.
            gameText.text = "Game Over";

            // 상태 텍스트의 색상을 붉은색으로 한다.
            gameText.color = new Color32(255, 0, 0, 255);

            // 상태 텍스트의 자식 오브젝트의 트랜스폼 컴포넌트를 가져온다.
            Transform buttons = gameText.transform.GetChild(0);

            // 버튼 오브젝트 활성화
            buttons.gameObject.SetActive(true);

            // 상태를 "게임 오버" 상태로 변경한다.
            gState = GameState.GameOver;
        }
    }

    // 옵션 화면 켜기
    public void OpenOptionWindow()
    {
        // 옵션 창 활성화
        gameOption.SetActive(true);

        // 게임 속도 0배속으로 전환
        Time.timeScale = 0f; // timeScale: 게임 전체의 프레임 진행 시간 배율

        // 게임 상태를 일시 정지 상태롤 변경
        gState = GameState.Pause;
    }

    public void CloseOptionWindow()
    {
        // 옵션 창 비활성화
        gameOption.SetActive(false);

        // 게임 속도 1배속(정상화)으로 전환
        Time.timeScale = 1f;

        // 게임 상태를 게임 중 으로 전환
        gState = GameState.Run;
    }
    
    // 다시하기 옵션
    public void ReStartGame()
    {
        // 게임 속도 1배속으로 전환
        Time.timeScale = 1f;

        // 현재 씬 번호 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // 게임 종료 옵션
    public void QuitGame()
    {
        // 애플리케이션 종료
        Application.Quit();
    }
}