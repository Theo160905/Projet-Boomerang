using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerAmbre : MonoBehaviour
{
    private List<Vector3> _spawnpoint = new List<Vector3>
    { 
        new Vector3(-18.72f, 4.03f, -6.57f),
        new Vector3(-20.04f, 4.03f, -21.1f),
        new Vector3(-6.78f, 4.03f, -0.33f),
        new Vector3(15.41f, 4.03f, -7.9f),
        new Vector3(13.35f, 4.03f, -21.55f),
        new Vector3(-4.95f, 4.03f, -20.7f),
    };

    public Rigidbody _rb;
    public GameObject _Boomerang;
    public Transform _Générateur;
    
    private float _speed = 8.5f;
    private Vector2 _Value;    
    private float _rotationspeed = 720;
    
    [HideInInspector]
    public bool lancer = true;

    [HideInInspector]
    public int id = 0;

    void Start()
    {
        var nb = Random.Range(0, _spawnpoint.Count);
        Vector3 randomPoint = _spawnpoint[nb];

        this.gameObject.transform.position = randomPoint;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _Value = context.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (lancer == true)
        {
            if (context.performed)
            {
                lancer = false;
                GameObject go = Instantiate(_Boomerang, _Générateur.position, transform.rotation);
                go.GetComponent<Boomerang>().lancer = this;
                lancer = false;
            }
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector3.zero;
        Vector3 mouvement = new Vector3(_Value.x, 0, _Value.y);
        mouvement.Normalize();
        transform.Translate(_speed * mouvement * Time.deltaTime, Space.World);

        if (mouvement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(mouvement, Vector2.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationspeed * Time.deltaTime);
        }
    }
}