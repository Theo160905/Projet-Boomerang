using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject pausemenu;
    private bool _pauseeffective = false;

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_pauseeffective == false)
            {
                pausemenu.SetActive(true);
                _pauseeffective = true;
                Time.timeScale = 0;
            }

            else
            {
                pausemenu.SetActive(false);
                _pauseeffective = false;
                Time.timeScale = 1;
            }
        }
    }
    
    // C'est au cas où
    public void OnReprendre()
    {
        pausemenu.SetActive(false);
        _pauseeffective = false;
        Time.timeScale = 1;
    }
}
