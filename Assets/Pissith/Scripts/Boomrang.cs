using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    bool isRecup;
    bool isThrow;
    Transform player;

    void Start()
    {
        // Get the player transform
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (isRecup)
        {
            if (isThrow)
            {
                transform.position += player.forward * 10 * Time.deltaTime;
            }
        }

    }
}
