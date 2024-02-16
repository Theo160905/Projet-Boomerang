using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Boomerang : MonoBehaviour
{
    public Rigidbody rb;

    private float time = 0.75f;
    internal float currentTime = 0;

    Vector3 retour;

    private float vitesse = 17;

    [SerializeField]
    public PlayerControllerAmbre lancer;

    private bool isthrow = false;


    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (currentTime < time)
        {
            isthrow = true;
            Shoot();
        }

        if (currentTime > time)
        {
            if (currentTime < time * 2)
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
        retour = lancer.transform.position;
    }

    void Retour()
    {
        Vector3 position = transform.position;
        Vector3 position_cible = retour;
        float a = vitesse * Time.deltaTime;
        transform.Translate(Vector3.up * 3f * Time.deltaTime);
        transform.position = Vector3.MoveTowards(position, position_cible, a);
    }

    IEnumerator canrecup()
    {
        yield return new WaitForSeconds(1f);
        isthrow = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (isthrow == false)
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
            }
        }
    }
}