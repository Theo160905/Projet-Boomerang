using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boomerang : MonoBehaviour
{
    private float time;

    public Transform retour;

    private float vitesse = 20;

    public PlayerController lancer;

    void FixedUpdate()
    {
        time += 1 * Time.deltaTime;
        if (time < 0.75f)
        {
            Shoot();
        }

        if (time > 0.75f)
        {
            if (time < 1.5f)
            {
                Retour();
            }
        }
    }

    // Update is called once per frame
    void Shoot()
    {
        transform.Translate(Vector3.forward * vitesse * Time.deltaTime);
    }

    void Retour()
    {
        Vector3 position = transform.position;
        Vector3 position_cible = retour.position;
        float a = vitesse * Time.deltaTime;
        transform.position = Vector3.MoveTowards(position, position_cible, a);
    }
    void OnCollisionEnter(Collision Player)
    {
        if (time > 2)
        {
            lancer.lancer = true;
            Destroy(gameObject);
        }
    }
}

