using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{
    //variables that control the speed and rotation speed 
    public float speed = .03f;
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

        speed = .03f;

        transform.Translate(0, 0, t);
        transform.Rotate(0, r, 0);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
    
    void OnCollisionEnter(Collision collision) {

        
        for(int i = 0; i < 5; ++i) {
            for(int j = 0; j < 10; j++) {
                if(i == 4 && j == 3) {
                    break;
                }
                if(collision.gameObject.name == "Wall0" + i + j) {
                    speed = 0.01f;
                }
            }
        }
    }
}
