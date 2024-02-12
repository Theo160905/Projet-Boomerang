using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boomerang : MonoBehaviour
{
    private float time = 0.75f;
    internal float currentTime = 0;

    Vector3 retour;

    private float vitesse = 20;

    public PlayerController lancer;

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (currentTime < time)
        {
            Shoot();
        }

        if (currentTime > time)
        {
            if (currentTime < time*2)
            {
                Retour();
            }
        }
    }

    // Update is called once per frame
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
    void OnCollisionEnter(Collision collider)
    {
        if (currentTime > 2)
        {
            lancer.lancer = true;
            Destroy(gameObject);
        }
    }
}

