using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject pausemenu;
    private bool pauseeffective = false;

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
    
    // C'est au cas où
    public void OnReprendre()
    {
        pausemenu.SetActive(false);
        pauseeffective = false;
        Time.timeScale = 1;
    }
}
