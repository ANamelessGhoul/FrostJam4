using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    //Default movement speed
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.forward;

        //If the W key is pressed player moves forward
        if (Input.GetKey(KeyCode.W))
        {
            controller.Move(move * Time.deltaTime * speed);
        }

    }
}
