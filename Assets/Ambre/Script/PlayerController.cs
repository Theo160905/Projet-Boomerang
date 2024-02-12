using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Transform[] spawnpoint;

    public float speed;

    public Rigidbody rb;
    public Vector2 Value;
    public GameObject Boomerang;

    public float rotationspeed;
    public Transform Générateur;

    public bool lancer = true;

    void Start()
    {
        Transform randomPoint = spawnpoint[Random.Range(0, spawnpoint.Length)];

        this.gameObject.transform.position = randomPoint.position;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Value = context.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (lancer == true)
        {
            if (context.performed)
            {
                GameObject go = Instantiate(Boomerang, Générateur.position, transform.rotation);
                go.GetComponent<Boomerang>().lancer = this;
                lancer = false;
            }
        }
    }

    private void Update()
    {
        rb.velocity = Vector3.zero;
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
