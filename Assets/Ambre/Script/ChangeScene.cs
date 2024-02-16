using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string Scene;

    public void Onchangescene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Scene);
    }
}
