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
    [Range(-360,360)]
    public float currentXRotation = 0;
    [Range(-360,360)]
    public float currentYRotation = -90;

    void Start(){
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.localRotation = Quaternion.Euler(currentXRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, currentYRotation, 0);
        configureRotation();
    }

    void configureRotation(){
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //Not inverse Rotation
        currentXRotation -= mouseY * rotateXSpeed * Time.deltaTime;
        currentYRotation += mouseX * rotateYSpeed * Time.deltaTime;

        currentXRotation = Mathf.Clamp(currentXRotation, rotateYMin, rotateYMax);
        
    }
}
