using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public Rigidbody m_cloud;
    private void Start()
    {
        StartCoroutine(Cloudspawn());
    }

   

    IEnumerator Cloudspawn()
    {
        while (true)
        {
            int i = 1;
            Instantiate(m_cloud, new Vector3(i * (Random.Range(1.0f,10.0f)), (Random.Range(-2.0f, 10.0f)), -83f), Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

 

}
