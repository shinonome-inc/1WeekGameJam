using System; // DateTime 型を使うために必要
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    private static DateTime StartTime; // DateTime 型で StartTime を保持
    public TextMeshProUGUI timeText; // TextMeshProUGUI 型で timeText を保持

    // Start is called before the first frame update
    void Start()
    {
        StartTime = DateTime.Now; // 現在時刻を StartTime に代入
        UpdateTimeText(); // UpdateTimeText メソッドを呼び出す
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeText(); // UpdateTimeText メソッドを呼び出す
    }

    void UpdateTimeText()
    {
        // 現在時刻と StartTime の差分を計算
        TimeSpan diff = DateTime.Now - StartTime;
        // 差分を文字列 `○分○秒経過` に変換
        // string diffString = $"{diff.Minutes}分{diff.Seconds}秒経過";
        string diffString = $"{diff.Minutes} min {diff.Seconds} sec elapsed";
        // Text コンポーネントを取得して、テキストを更新
        timeText.text = diffString;
    }

    // 経過時間を取得するメソッド
    public static int GetElapsedTime()
    {
        // 現在時刻と StartTime の差分を計算
        TimeSpan diff = DateTime.Now - StartTime;
        // 差分を秒数に変換して返す
        return (int)diff.TotalSeconds;
    }
}
