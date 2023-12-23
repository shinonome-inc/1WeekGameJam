using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static float score = 0;
    public TextMeshProUGUI scoreText;

    private int baseScorePerSecond = 10; // 1秒間に+10円加算
    private int scorePerSecond = 10; // 1秒間に+10円加算
    private int scoreTimes = 1; // 10秒ごとに scorePerSecond を+scoreTimesする
    private int lastTime = 0; // 前回の経過時間
    // private TimeManager timeManager;
    // Start is called before the first frame update
    void Start()
    {
        lastTime = 0;
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        int elapsedTime = TimeManager.GetElapsedTime();
        score += CalculateScore(elapsedTime, lastTime);
        CalcScoreTimes(elapsedTime);
        lastTime = elapsedTime;

        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // scoreText.text = $"{score}円";
        scoreText.text = $"{score} Yen";
    }

    float CalculateScore(int elapsedTime, int lastTime)
    {
        if (elapsedTime - lastTime >= 1)
        {
            // 1秒間にscorePerSecond円加算
            int delta = elapsedTime - lastTime;
            return delta * scorePerSecond;
        }
        else
        {
            return 0;
        }
    }

    void CalcScoreTimes(int elapsedTime)
    {
        // 10秒ごとに scorePerSecond を+scoreTimesする
        int elapsedTimeDiv10 = elapsedTime / 10;
        //debug
        // Debug.Log(elapsedTimeDiv10);
        scorePerSecond = baseScorePerSecond + scoreTimes * elapsedTimeDiv10;
    }

    public static void AddScore(float amount)
    {
        score += amount;
    }
}
