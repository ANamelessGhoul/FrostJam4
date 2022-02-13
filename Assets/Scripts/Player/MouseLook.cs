using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseLook : MonoBehaviour
{
    //default sensitivity is here
    [Header("Look")]
    [SerializeField] private float mouseSensitivity = 200f;
    [SerializeField] private Transform playerBody;

    [Header("Head bob")]
    [SerializeField] private float amplitude = 0.20f;
    [SerializeField] private float period = 2f;

    [Header("Interaction")]
    [SerializeField] private LayerMask rayMask;
    private GameObject _interactedObj;
    private float _xRotation = 0f;

    Vector3 startPos;

    private void Start()
    {
        //cursor is locked to the middle
        Cursor.lockState = CursorLockMode.Locked;
        startPos.y = transform.position.y;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        //headBOB
        float theta = Time.timeSinceLevelLoad / period;
        float distance = amplitude * Mathf.Sin(theta);
        transform.position += Vector3.up * distance * Time.deltaTime;

        
        _xRotation -= mouseY;
        //rotation of the camera is limited with these boundaries for x axis
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


        if (Input.GetMouseButtonDown(0))
        {
            if (_interactedObj)
            {
                if (_interactedObj.TryGetComponent<IInteractable>(out var interactable)) 
                {
                    PrintName(_interactedObj);
                    interactable.Interact();
                }
            }
            
        }
        
    }

    private void FixedUpdate()
    {       
        //Debug.DrawRay(transform.position, transform.forward, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out var hit, 3.0f, rayMask))
        {
            _interactedObj = hit.transform.gameObject;
        }
        else
        {
            _interactedObj = null;
        }
    }

    public void PrintName(GameObject go)
    {
        print(go.name);
    }
}
