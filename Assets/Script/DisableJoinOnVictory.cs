using UnityEngine;
using UnityEngine.InputSystem;

public class DisableJoinOnVictory : MonoBehaviour
{
    [SerializeField]
    private PlayerInputManager _playerInputManager;

    private void Start()
    {
        VictoryManager.Instance.OnVictory += OnVictory;
    }

    private void OnVictory()
    {
        _playerInputManager.DisableJoining();
        Time.timeScale = 0f;
    }
}
