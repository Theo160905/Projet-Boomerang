using UnityEngine;
using UnityEngine.InputSystem;

public class AddIdPlayer : MonoBehaviour
{
    private int _joueur = 0;

    //Aide de prof + Lyta
    public void OnPlayerJoined(PlayerInput input)
    {
        _joueur++;
        input.gameObject.GetComponent<PlayerControllerAmbre>().id = _joueur;
    }
}
