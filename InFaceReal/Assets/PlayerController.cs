using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool shootReady = false;
    private bool aiming = false;

    private float height = 1;
    private float width = 1;

    Camera viewCamera;

    private Vector3 targetPos;
    Rigidbody rb;


	void Start () {
        targetPos = transform.position;
        rb = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
	}
	

	void Update () {
        if (shootReady == false) //Ready the player to shoot.
        {
            targetPos = transform.position;
        }
        if (targetPos.y > transform.position.y)
        {
            transform.Translate(new Vector3(0, 0.01f, 0)); 
        }


        if (aiming == true) //Aim the player
        {
            if (Input.GetMouseButtonUp(0)) //If the player relises the left mousebutton
            {
                aiming = false;
            }
            Vector3 lookPoint = new Vector3(MousePosition().x, MousePosition().y, transform.position.z);
            transform.LookAt(-lookPoint);
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1)) //Get Input to ready up
        {
                if (shootReady == false)
                {
                    shootReady = true;
                    targetPos = new Vector3(transform.position.x, transform.position.y + height / 2, transform.position.z);
                    rb.useGravity = false;
                }
                else
                {
                    shootReady = false;
                    rb.useGravity = true;
                }
        }


        if (shootReady == true) //Get Input to start aiming
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (aiming == false)
                {
                    aiming = true;
                }
            }
        }
    }

    Vector3 MousePosition()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane backdrop = new Plane(Vector3.forward, Vector3.zero);
        float rayDistance;

        if (backdrop.Raycast(ray, out rayDistance))
        {
            Vector3 TheMousePosition = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point, Color.red);
            return TheMousePosition;
        }
        return new Vector3(0, 0, 0);
    }
}
