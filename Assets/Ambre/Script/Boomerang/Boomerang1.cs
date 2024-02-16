using UnityEngine;

public class Boomerang1 : MonoBehaviour
{
    private float time = 0.75f;
    internal float currentTime = 0;

    Vector3 retour;

    private float vitesse = 17;

    public PlayerControllerAmbre lancer;

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (currentTime < time)
        {
            Shoot();
        }

        if (currentTime > time)
        {
            if (currentTime < time * 2)
            {
                Retour();
            }
        }
    }

    void Shoot()
    {
        transform.Translate(Vector3.forward * vitesse * Time.deltaTime);
        retour = lancer.transform.position;
    }

    void Retour()
    {
        Vector3 position = transform.position;
        Vector3 position_cible = retour;
        float a = vitesse * Time.deltaTime;
        transform.position = Vector3.MoveTowards(position, position_cible, a);
    }
    void OnCollisionEnter(Collision other)
    {
        if (currentTime < 2)
        {
            if (other.gameObject.tag == "Player")
            {
                var block = GameObject.FindWithTag("Player");
                Destroy(block);
            }

            if (other.gameObject.tag == "Player2")
            {
                var black = GameObject.FindWithTag("Player2");
                Destroy(black);
            }

            if (other.gameObject.tag == "Player3")
            {
                var blick = GameObject.FindWithTag("Player3");
                Destroy(blick);
            }

            if (currentTime > 1)
            {
                if (other.gameObject.tag == "Player1")
                {
                    lancer.lancer = true;
                    Destroy(gameObject);
                }
            }
        }
        if (currentTime > 1)
        {
            if (other.gameObject.tag == "Player1")
            {
                lancer.lancer = true;
                Destroy(gameObject);
            }
        }
    }
}