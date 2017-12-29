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
        Vector3 TheMousePosition = viewCamera.ScreenToWorldPoint(Input.mousePosition); //Get Mouse Position
        Debug.Log(TheMousePosition);

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
            if (Input.GetMouseButtonUp(0))
            {
                aiming = false;
            }
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
}
