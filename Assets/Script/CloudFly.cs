using UnityEngine;

public class CloudFly : MonoBehaviour
{
    public Rigidbody m_cloud;
    public float speed = 20.0f;



    private void Update()
    {
        m_cloud.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
