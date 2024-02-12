using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody player;
    public Camera mainCamera;

    Vector2 mousePos;
    Vector2 mouvementAxis;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        mouvementAxis = new Vector2();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


    }

    private void FixedUpdate()
    {
        Ray CameraRay = mainCamera.ScreenPointToRay(mousePos);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;
        if (groundPlane.Raycast(CameraRay, out rayLenght))
        {
            Vector3 pointToLook = CameraRay.GetPoint(rayLenght);
            Debug.DrawLine(CameraRay.origin, pointToLook, Color.yellow);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }





}
