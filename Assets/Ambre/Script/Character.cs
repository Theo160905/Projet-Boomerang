using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public new string name;

    public GameObject character;

    InputMaster input;

    Vector2 currentMovement;
    bool movementPressed;
    void Awake()
    {
        input = new InputMaster();

        input.Player.Movement.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0;
            movementPressed = currentMovement.y != 0;

        };
    }
}
