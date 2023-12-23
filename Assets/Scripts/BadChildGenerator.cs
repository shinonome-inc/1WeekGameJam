using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadChildGenerator : MonoBehaviour
{
    public GameObject badChildPrefab;

    public void GemerateBadChildPrefab(float x, float y)
    {
        const float scale = 0.04f;
        GameObject go = Instantiate(badChildPrefab) as GameObject;
        go.transform.position = new Vector2(x, y);
        go.transform.localScale = new Vector2(scale, scale);
    }

    void Start()
    {
        GemerateBadChildPrefab(-4.0f, 0.0f);
    }
}
