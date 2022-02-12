using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseLook : MonoBehaviour
{
    //default sensitivity is here
    public UnityEvent loopEvent;
    public float mouseSensitivity = 200f;
    public GameObject interactedObj;
    public Transform playerBody;
    public LayerMask rayMask;
    float xRotation = 0f;
    Vector3 startPos;
    public float amplitude = 0.20f;
    public float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //cursor is locked to the middle
        Cursor.lockState = CursorLockMode.Locked;
        loopEvent.Invoke();
        startPos.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        //headBOB
        float theta = Time.timeSinceLevelLoad / period;
        float distance = amplitude * Mathf.Sin(theta);
        transform.position += Vector3.up * distance * Time.deltaTime;

        
        xRotation -= mouseY;
        //rotation of the camera is limited with these boundaries for x axis
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        if (Input.GetMouseButtonDown(0))
        {
            if (interactedObj)
            {
                //Destroy(interactedObj);

                interactedObj.name = "newObj";
            }
            
        }
        
    }

    private void FixedUpdate()
    {       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, 100.0f, rayMask))
        {
            
            PrintName(hit.transform.gameObject);
            interactedObj = hit.transform.gameObject;

        }
        else
        {
            interactedObj = null;
        }
    }

    public void PrintName(GameObject go)
    {
        print(go.name);
    }
}
