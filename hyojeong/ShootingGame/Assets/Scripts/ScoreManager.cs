using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//����Ƽ UI�� ����ϱ� ���� ���ӽ����̽�
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // ���� ���� UI
    public Text currentScoreUI;
    // ���� ����
    private int currentScore;

    // �ְ� ���� UI
    public Text bestScoreUI;
    // �ְ� ����
    private int bestScore;

    // Start is called before the first frame update
    void Start()
    {
        // 1. �ְ� ������ �ҷ��� bestScore�� �־��ֱ�
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        // 2. �ְ� ������ ȭ�鿡 ǥ���ϱ�
        bestScoreUI.text = "�ְ� ���� : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //currentScore�� ���� �ְ� ȭ�鿡 ǥ���ϱ�
    public void SetScore(int value)
    {
        // 3. ScoreManager Ŭ������ �Ӽ��� ���� �Ҵ��Ѵ�.
        currentScore++;
        // 4. ȭ�鿡 ���� ���� ǥ���ϱ�
        currentScoreUI.text = "���� ���� : " + currentScore;

        // 1. ���� ������ �ְ� ������ �ʰ��ߴٸ�
        if (currentScore > bestScore)
        {
            // 2. �ְ� ������ �����Ѵ�.
            bestScore = currentScore;
            // 3. �ְ� ���� UI�� ǥ��
            bestScoreUI.text = "�ְ� ���� : " + bestScore;
            // �ְ� ���� ����
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }

    // �̱��� ��ü
    public static ScoreManager Instance = null;

    //currentScore �� ��������
    public int GetScore()
    {
        return currentScore;
    }

    // �̱��� ��ü�� ���� ������ ������ �ڱ� �ڽ��� �Ҵ�
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            // 3. ScoreManager Ŭ������ �Ӽ��� ���� �Ҵ��Ѵ�.
            currentScore = value;
            // 4. ȭ�鿡 ���� ���� ǥ���ϱ�
            currentScoreUI.text = "���� ���� : " + currentScore;

            // 1. ���� ������ �ְ� ������ �ʰ��ߴٸ�
            if (currentScore > bestScore)
            {
                // 2. �ְ� ������ �����Ѵ�.
                bestScore = currentScore;
                // 3. �ְ� ���� UI�� ǥ��
                bestScoreUI.text = "�ְ� ���� : " + bestScore;
                // �ְ� ���� ����
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }
}
