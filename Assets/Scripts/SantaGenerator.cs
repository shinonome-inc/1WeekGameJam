using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaGenerator : MonoBehaviour
{
    public GameObject santaPrefab;
    public void GemerateGoodChild()
    {
        float x = 0;
        float y = 0;
        const float scale = 1.0f;
        GameObject go = Instantiate(santaPrefab) as GameObject;
        go.transform.position = new Vector2(x, y);
        go.transform.localScale = new Vector2(scale, scale);
    }

    void Start()
    {
        GemerateGoodChild();
    }
}
