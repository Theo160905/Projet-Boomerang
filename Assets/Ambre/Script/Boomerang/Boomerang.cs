using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Boomerang : MonoBehaviour
{
    public Rigidbody rb;

    private float _time = 0.75f;
    internal float _currentTime = 0;

    Vector3 _retour;

    private float vitesse = 17;

    [SerializeField]
    public PlayerControllerAmbre lancer;

    private bool _isthrow = false;


    void FixedUpdate()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime < _time)
        {
            _isthrow = true;
            Shoot();
        }

        if (_currentTime > _time)
        {
            if (_currentTime < _time * 2)
            {
                Retour();
                StartCoroutine(canrecup());
            }
        }
    }

    void Shoot()
    {

        transform.Translate(Vector3.up*3f*Time.deltaTime);
        transform.Translate(Vector3.forward * vitesse * Time.deltaTime);
        _retour = lancer.transform.position;
    }

    void Retour()
    {
        Vector3 position = transform.position;
        Vector3 position_cible = _retour;
        float a = vitesse * Time.deltaTime;
        transform.Translate(Vector3.up * 3f * Time.deltaTime);
        transform.position = Vector3.MoveTowards(position, position_cible, a);
    }

    IEnumerator canrecup()
    {
        yield return new WaitForSeconds(1f);
        _isthrow = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (_isthrow == false)
        {
            if (other.gameObject.tag == "Player"  )
            {
                Destroy(gameObject);
                var a = other.gameObject.GetComponent<PlayerControllerAmbre>().lancer = true;
                
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var a = other.gameObject.GetComponent<PlayerControllerAmbre>().id;

                if (a != lancer.id)
                {
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                    var b = other.gameObject.GetComponent<PlayerControllerAmbre>().lancer = true;
                }
            }
            else
            {

            }
        }
    }
}