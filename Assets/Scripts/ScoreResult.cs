using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreResult : MonoBehaviour
{
    public TextMeshProUGUI scoreResultText;

    // Start is called before the first frame update
    void Start()
    {
        float score = ScoreManager.score;
        DisplayScoreResult(score);
    }

    // Update is called once per frame
    void Update()
    {
        float score = ScoreManager.score;
        DisplayScoreResult(score);
    }

    void DisplayScoreResult(float score)
    {
        // scoreResultText.text = $"支給額：{score}円";
        scoreResultText.text = $"Saraly: ¥{string.Format("{0:#,0}", score)}";
    }
}
