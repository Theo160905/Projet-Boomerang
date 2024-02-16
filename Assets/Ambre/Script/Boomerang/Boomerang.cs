using System.Collections;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public Rigidbody rb;

    private float _time = 0.75f;
    internal float currentTime = 0;
    private float _vitesse = 17;
    Vector3 retour;

    [SerializeField]
    public PlayerControllerAmbre lancer;

    //Cette variable sert à savoir si le boomerange est entrain d'être lancer ou pas 
    private bool _isthrow = false;


    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (currentTime < _time)
        {
            _isthrow = true;
            Pars();
        }

        if (currentTime > _time)
        {
            if (currentTime < _time * 2)
            {
                Retour();
                StartCoroutine(Canrecup());
            }
        }
    }

    //Envoi le Boomerang vers l'avant
    void Pars()
    {
        transform.Translate(Vector3.up*3f*Time.deltaTime);
        transform.Translate(Vector3.forward * _vitesse * Time.deltaTime);
        retour = lancer.transform.position;
    }

    //Fais en sorte que le Boomerang revienne vers le joueur
    void Retour()
    {
        Vector3 position = transform.position;
        Vector3 position_cible = retour;
        float a = _vitesse * Time.deltaTime;
        transform.Translate(Vector3.up * 3f * Time.deltaTime);
        transform.position = Vector3.MoveTowards(position, position_cible, a);
    }
    //Fais en sorte que le joueur doit attendre avant de pouvoir récupéré le boomerang
    IEnumerator Canrecup()
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
                    lancer.GetComponent<PlayerScore>().AddPoint();
                }
                else
                {
                    Destroy(gameObject);
                    var b = other.gameObject.GetComponent<PlayerControllerAmbre>().lancer = true;
                }
            }
        }
    }
}