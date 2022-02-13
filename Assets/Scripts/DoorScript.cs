using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool isOpen;
    private Animator doorAnim;
    // Start is called before the first frame update
    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isOpen = GameObject.Find("Main Camera").GetComponent<MouseLook>().openDoor;
            

        if (isOpen == true)
        {
            Debug.Log("here");
            doorAnim.SetBool("isOpen", true);
        }
        else
        {
            doorAnim.SetBool("isOpen", false);
        }
    }
}
