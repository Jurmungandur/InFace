using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool shootReady = false;

    private float height = 1;
    private float width = 1;

    private Vector3 targetPos;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        targetPos = transform.position;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (shootReady == false)
        {
            targetPos = transform.position;
        }
        if (targetPos.y > transform.position.y)
        {
            transform.Translate(new Vector3(0, 0.01f, 0)); 
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
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
    }
}
