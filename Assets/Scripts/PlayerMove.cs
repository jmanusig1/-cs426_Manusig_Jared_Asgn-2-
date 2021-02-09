using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{
    //variables that control the speed and rotation speed 
    public float speed = .1f;
    public float rotationSpeed = .3f; 


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        //variables for translation adn rotation 
        var r = Input.GetAxis("Horizontal") * rotationSpeed;
        var t = Input.GetAxis("Vertical") * speed;

        transform.Translate(0, 0, t);
        transform.Rotate(0, r, 0);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
