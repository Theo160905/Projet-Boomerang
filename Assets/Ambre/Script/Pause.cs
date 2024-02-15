using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausemenu;
    private bool pauseeffective = false;
    public string scene;

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (pauseeffective == false)
            {
                pausemenu.SetActive(true);
                pauseeffective = true;
                Time.timeScale = 0;
            }

            else
            {
                pausemenu.SetActive(false);
                pauseeffective = false;
                Time.timeScale = 1;
            }
        }
    }
    
    public void OnReprendre()
    {
        pausemenu.SetActive(false);
        pauseeffective = false;
        Time.timeScale = 1;
    }

    public void OnQuitter()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}
