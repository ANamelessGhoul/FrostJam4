using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 60;
    [SerializeField] private float movementSpeed = 3;
    [SerializeField] private Vector3 forwardVector;
    private Transform _cameraTransform;
    private void Awake()
    {
        _cameraTransform = transform.GetChild(0);
    }

    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(0, mouseX * Time.deltaTime * mouseSensitivity, 0) );
        _cameraTransform.Rotate(new Vector3(-mouseY * Time.deltaTime * mouseSensitivity, 0, 0));

        var forward = Input.GetKey(KeyCode.W) ? 1 : 0;

        forwardVector = transform.InverseTransformDirection(_cameraTransform.forward);

        transform.Translate(forwardVector * (forward * Time.deltaTime * movementSpeed));
    }
}
