using UnityEngine;
using UnityEngine.InputSystem;

public class AddIdPlayer : MonoBehaviour
{
    private int _NbJoueur = 0;

    //Aide de prof + Lyta
    //Ce script sert à faire sapwn un joueur lorsque qu'il appuie sur une bouton
    //Cependant le joueur ne pourra pas avoir le meme identifiant
    public void OnPlayerJoined(PlayerInput input)
    {
        _NbJoueur++;
        input.gameObject.GetComponent<PlayerControllerAmbre>().id = _NbJoueur;
    }
}
