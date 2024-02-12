using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Baamerang : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    private float time;

    public Transform retour;

    private float vitesse = 20;
    public Vector3 GetObjectCoordinates(GameObject targetObject)
    {
        return targetObject.transform.position;
    }

    void FixedUpdate()
    {
        time += 1 * Time.deltaTime;
        if (time < 0.75f)
        {
            Shoot();
        }

        if (time == 0.75f)
        {
            
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
        //rb.AddForce(Vector3.forward * vitesse, ForceMode.Impulse);
        //Vector3 position = transform.position;
        //Vector3 position_cible = direction.position;
        //float a = vitesse * Time.deltaTime;
        //rb.AddForce(Vector3.forward * 10f, ForceMode.Impulse);
    }

    void Retour()
    {
        Vector3 position = transform.position;
        Vector3 position_cible = retour.position;
        float a = vitesse * Time.deltaTime;
        transform.position = Vector3.MoveTowards(position, position_cible, a);
    }
}

