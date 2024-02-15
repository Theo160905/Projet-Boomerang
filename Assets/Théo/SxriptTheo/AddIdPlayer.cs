using UnityEngine;
using UnityEngine.InputSystem;

public class AddIdPlayer : MonoBehaviour
{
    private int nb_joueur = 0;

    //Aide de prof + Lyta
    public void OnPlayerJoined(PlayerInput input)
    {
        nb_joueur++;
        input.gameObject.GetComponent<PlayerControllerAmbre>().id = nb_joueur;
    }
}
