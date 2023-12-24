using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tilescript : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource seAudioSource;
    [SerializeField] private Transform emptySpace = null;
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        seAudioSource = GetComponent<AudioSource>();
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 3)
                {
                    seAudioSource.PlayOneShot(sound1);
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    emptySpace.position = hit.transform.position;
                    hit.transform.position = lastEmptySpacePosition;
                }
            }
        }
    }
}
