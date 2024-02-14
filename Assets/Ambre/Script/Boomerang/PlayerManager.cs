using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    private float temps1;
    private float temps2;
    private float temps3;
    private float temps4;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            Debug.Log("get one");
        }
        else
        {
            Debug.Log("not there");
            temps1 += Time.deltaTime;

            if (temps1 > 5)
            {
                Instantiate(player, transform.position, transform.rotation);
                temps1 = 0;
            }
        }

        if (GameObject.FindWithTag("Player1") != null)
        {
            Debug.Log("get one");
        }
        else
        {
            Debug.Log("not there");
            temps2 += Time.deltaTime;

            if (temps2 > 5)
            {
                Instantiate(player1, transform.position, transform.rotation);
                temps2 = 0;
            }
        }

        if (GameObject.FindWithTag("Player2") != null)
        {
            Debug.Log("get one");
        }
        else
        {
            Debug.Log("not there");
            temps3 += Time.deltaTime;

            if (temps3 > 5)
            {
                Instantiate(player2, transform.position, transform.rotation);
                temps3 = 0;
            }
        }

        if (GameObject.FindWithTag("Player3") != null)
        {
            Debug.Log("get one");
        }
        else
        {
            Debug.Log("not there");
            temps4 += Time.deltaTime;

            if (temps4 > 5)
            {
                Instantiate(player3, transform.position, transform.rotation);
                temps4 = 0;
            }
        }
    }
}
