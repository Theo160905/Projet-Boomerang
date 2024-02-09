using System.Collections;
using UnityEngine;

public class UseBoomerang : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    private GameObject player;
    private Vector3 startPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = player.transform.position;
    }

    public void ThrowBoommerang()
    {
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        rb.AddForce(Vector3.forward * 10f, ForceMode.Impulse);
        Debug.Log("Lancé");
        StartCoroutine(ReturnToPlayer());
    }

    private IEnumerator ReturnToPlayer()
    {
        yield return new WaitForSeconds(2f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.Translate(startPosition);
        Debug.Log("Retour au joueur");
    }
}