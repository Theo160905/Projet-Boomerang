using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Déplacement : MonoBehaviour
{
    public float speed;
    
    public Vector2 Value;

    private int valeur;
    public GameObject Boomerang;

    public void OnInputPlayer(InputAction.CallbackContext _context)
    {
        Value = _context.ReadValue<Vector2>();
    }

    public void Onshoot(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            Instantiate(Boomerang, transform.position, transform.rotation);

            Debug.Log("je tire");
        }
    }

    private void Update()
    {
        Vector3 mouvement = new Vector3(Value.x, 0, Value.y);
        mouvement.Normalize();
        transform.Translate(speed * mouvement * Time.deltaTime);
    }
}
