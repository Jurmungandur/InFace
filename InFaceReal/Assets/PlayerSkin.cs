using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour {

    public GameObject player;
    public GameObject playerTail;
    Camera viewCamera;

    void Start()
    {
        viewCamera = Camera.main;
    }

    void FixedUpdate()
    {
        bool pAim = player.GetComponent<PlayerController>().aiming;
        float mouseDist = Vector3.Distance(player.transform.position, player.GetComponent<PlayerController>().MousePosition());
        if (mouseDist > 4)
        {
            mouseDist = 4;
        }
        mouseDist /= 10;
        Debug.Log(mouseDist);

        if (pAim == false)
        {
            transform.position = player.transform.position;
            transform.rotation = player.transform.rotation;
        }
        else
        {
            transform.position = Lerp(player.transform.position, playerTail.transform.position, mouseDist);
            transform.rotation = player.transform.rotation;
        }
    }

    public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
        return a + (b - a) * t;
    }
}
