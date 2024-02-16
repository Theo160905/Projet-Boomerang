using System.Collections;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public Rigidbody rb;
    internal float currentTime = 0;
    Vector3 retour;

    private float _vitesse = 17;
    private bool isthrow = false; // Pour savoir si le boomerang est lancé ou pas
    private float _time = 0.75f;

    [SerializeField]
    public PlayerControllerScript lancer;

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (currentTime < _time)
        {
            isthrow = true;
            Shoot();
        }

        if (currentTime > _time)
        {
            if (currentTime < _time * 2)
            {
                Retour();
                StartCoroutine(CanRecup());
            }
        }
    }

    void Shoot()
    {
        transform.Translate(Vector3.up*3f*Time.deltaTime);
        transform.Translate(Vector3.forward * _vitesse * Time.deltaTime);
        retour = lancer.transform.position;
    }

    void Retour()
    {
        Vector3 position = transform.position;
        Vector3 position_cible = retour;
        float a = _vitesse * Time.deltaTime;
        transform.Translate(Vector3.up * 3f * Time.deltaTime);
        transform.position = Vector3.MoveTowards(position, position_cible, a);
    }

    IEnumerator CanRecup()
    {
        yield return new WaitForSeconds(1f);
        isthrow = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (isthrow == false)
        {
            //N'importe quel joueur peut recuperer le boomerang qui touche
            if (other.gameObject.tag == "Player"  )
            {
                Destroy(gameObject);
                var a = other.gameObject.GetComponent<PlayerControllerScript>().lancer = true;
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var a = other.gameObject.GetComponent<PlayerControllerScript>().id;

                //Elimine les joueurs qui ne sont pas le joueur qui lance le boomerang
                if (a != lancer.id)
                {
                    Destroy(other.gameObject);
                    lancer.GetComponent<PlayerScore>().AddPoint();
                }
                //Fais en sorte que le lanceur peut récupérer le boomerang en plein vol
                else
                {
                    Destroy(gameObject);
                    var b = other.gameObject.GetComponent<PlayerControllerScript>().lancer = true;
                }
            }
            //si le boomerang touceh un obstacle il revient
            else if (other.gameObject.CompareTag("Obstacle"))
            {
                Retour();
            }
        }
    }
}