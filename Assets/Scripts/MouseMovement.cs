using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [Header("Mouse Rotation Components")]
    [Range(-360,0)]
    public float rotateYMin = -90f;
    [Range(0,360)]
    public float rotateYMax = 90f;
    [Range(0,360)]
    public float rotateXSpeed = 90f;
    [Range(0,360)]
    public float rotateYSpeed = 90f;

    [SerializeField] private float xRotation;
    [SerializeField] private float yRotation;

    public bool allowMouseMove = true;

    void Start(){
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        configureRotation();
        
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void configureRotation(){
        if (allowMouseMove)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            //Not inverse Rotation
            xRotation -= mouseY * rotateXSpeed * Time.deltaTime;
            yRotation += mouseX * rotateYSpeed * Time.deltaTime;

            xRotation = Mathf.Clamp(xRotation, rotateYMin, rotateYMax);
        }
        
        
    }
}
