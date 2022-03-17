﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    [SerializeField] GameObject statsViewer;
    // Start is called before the first frame update
    [SerializeField] float rotSpeed = 1f;
    [SerializeField] GameObject ObjecttoRotate;
    [SerializeField] Camera cam;
    [SerializeField] Transform snapToTransform;
    Vector3 oldLocation;
    Quaternion oldRotation;
    [SerializeField] MovementRigidbody playerMoveRef;
    [SerializeField] MouseMovement mouseMoveRef;
    bool currentlyInteracting = false;
    ObjectStats objectStatsRef;
    
    ObjectStats currentObjectStats;
    void Start()
    {
        //AccessData();
        /*
        for(int i = 0; i > ObjectstoRotate.Length; i++)
        {
            oldLocations[i] = ObjectstoRotate[i].transform.position;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //Screenpoint from camera forward where cursor is
            if (!currentlyInteracting)
            {
                if (Physics.Raycast(ray, out hit, 1f)) // if there is a collision with ray under 100f in distance
                {
                    if (hit.transform != null && hit.collider.tag == "Interactable") //object transform exists
                    {
                        Debug.Log("Interact1");
                        setCurrentObject(hit);
                        playerMoveRef.allowMove = false;
                        mouseMoveRef.allowMouseMove = false;
                        
                        currentlyInteracting = true;
                        objectStatsRef = hit.collider.gameObject.GetComponent<ObjectStats>();
                        objectStatsRef.ShowStats();
                        
                        statsViewer.SetActive(true);

                    }
                }
            }   
        }

        if (Input.GetKeyDown(KeyCode.Escape) && currentlyInteracting)
        {
            
            GoBacktoOldLocation();
            ObjecttoRotate = null;
            playerMoveRef.allowMove = true;
            mouseMoveRef.allowMouseMove = true;

            currentlyInteracting = false;
            statsViewer.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            
        }

        // old code for swapping between items in an array

        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentObject < ObjectstoRotate.Length -1)
            {
                previousObject = currentObject;
                currentObject++;
                SnapToCamera();
               
                GoBacktoOldLocation();
                AccessData();
            }
            else
            {
                previousObject = currentObject;
                currentObject = 0;
                SnapToCamera();
                GoBacktoOldLocation();
                AccessData();
            }
            
            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentObject  > 0)
            {
                previousObject = currentObject;
                currentObject--;
                SnapToCamera();
                AccessData();
                GoBacktoOldLocation();
            }
            else
            {
                previousObject = currentObject;
                currentObject = ObjectstoRotate.Length - 1;
                SnapToCamera();
                GoBacktoOldLocation();
                AccessData();
            }
        
            
            
        }
        */
        if (currentlyInteracting)
        {
            ObjecttoRotate.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * rotSpeed * Time.deltaTime);
        }
        
        

    }

    void SnapToCamera()
    {
        //Vector3 offset = new Vector3(0, -0.5f, 0);
        ObjecttoRotate.transform.position = snapToTransform.position;
        

    }

    void GoBacktoOldLocation()
    {

        Debug.Log(oldLocation);
        ObjecttoRotate.transform.position = oldLocation;
        ObjecttoRotate.transform.rotation = oldRotation;
    }

    void AccessData()
    {
        currentObjectStats = ObjecttoRotate.GetComponent<ObjectStats>();
        currentObjectStats.ShowStats();
    }

    void setCurrentObject(RaycastHit hit)
    {
        ObjecttoRotate = hit.collider.gameObject;
        oldLocation = ObjecttoRotate.transform.position;
        oldRotation = ObjecttoRotate.transform.rotation;
        
        SnapToCamera();
        //AccessData();
    }
}
