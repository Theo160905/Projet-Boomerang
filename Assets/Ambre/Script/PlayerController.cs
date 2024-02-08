using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    public Vector2 Value;
    public GameObject Boomerang;

    public float rotationspeed;

    public void OnMove(InputAction.CallbackContext context)
    {
        Value = context.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(Boomerang, transform.position, transform.rotation);
        }
    }

    private void Update()
    {
        Vector3 mouvement = new Vector3(Value.x, 0, Value.y);
        mouvement.Normalize();
        transform.Translate(speed * mouvement * Time.deltaTime, Space.World);

        if (mouvement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(mouvement, Vector2.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationspeed * Time.deltaTime);
        }
    }
}
