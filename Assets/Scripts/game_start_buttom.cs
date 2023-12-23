using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_start_buttom : MonoBehaviour
{
    public void change_button()
    {
        SceneManager.LoadScene("2.work");
    }
}
