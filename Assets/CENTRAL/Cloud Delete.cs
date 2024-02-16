using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDelete : MonoBehaviour
{
    public GameObject m_delete;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cloud")
        {
            Destroy(other.gameObject);
        }
    }
}
