using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class BadChildGenerator : MonoBehaviour
{
    public GameObject badChildPrefab;

    public void GemerateBadChild()
    {
        float x = CoordinateUtil.RandomPosX();
        float y = CoordinateUtil.RandomPosY();
        const float scale = 1.0f;
        GameObject go = Instantiate(badChildPrefab) as GameObject;
        go.transform.position = new Vector2(x, y);
        go.transform.localScale = new Vector2(scale, scale);
    }

    void Start()
    {
        GemerateBadChild();
    }
}
