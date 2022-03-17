using System.Collections;
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
    
    [SerializeField] MovementRigidbody playerMoveRef;
    [SerializeField] MouseMovement mouseMoveRef;
    bool currentlyInteracting = false;
    ObjectStats objectStatsRef;
    Vector3 oldLocation;
    Quaternion oldRotation;
    
    ObjectStats currentObjectStats;
    string interactableTag = "Interactable"; 
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
            if (!currentlyInteracting) //Will only call if currently interacting is true
            {
                if (Physics.Raycast(ray, out hit, 1f)) // if there is a collision with ray under 100f in distance
                {
                    if (hit.transform != null && hit.collider.tag == interactableTag) //object transform exists and has the right tag
                    {
                       
                        setCurrentObject(hit); //calls the function with the input being the object we hit with the raycast
                        
                        //Disable player movement so that they can't move while inspecting an object
                        playerMoveRef.allowMove = false;
                        mouseMoveRef.allowMouseMove = false;
                        
                        currentlyInteracting = true; //Setting to true stops this code from running once the player is interacting
                       

                        AccessData(hit);
                        statsViewer.SetActive(true);

                    }
                }
            }   
        }

        if (Input.GetKeyDown(KeyCode.Escape) && currentlyInteracting) //Put the item back if escape is pressed
        {
            
            GoBacktoOldLocation();
            ObjecttoRotate = null; //removes reference to object
            playerMoveRef.allowMove = true; //allows the player to move aain
            mouseMoveRef.allowMouseMove = true; //allows mouse movement again

            currentlyInteracting = false; 
            statsViewer.SetActive(false); //Removes the ui that displays object info
        }

        #region Old Swap Code

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

        #endregion //This code was used to switch between multiple objects with Q and E, but only one object can be interacted with at a time in the current setup so became redundant

        if (currentlyInteracting)
        {
            ObjecttoRotate.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * rotSpeed * Time.deltaTime);
        }
        
        

    }

    void SnapToCamera()
    {
        //Vector3 offset = new Vector3(0, -0.5f, 0); // a small offset for testing purposes
        ObjecttoRotate.transform.position = snapToTransform.position;
        

    }

    void GoBacktoOldLocation()
    {

        ObjecttoRotate.transform.position = oldLocation;
        ObjecttoRotate.transform.rotation = oldRotation;
    }

    void AccessData(RaycastHit hit)
    {
        objectStatsRef = hit.collider.gameObject.GetComponent<ObjectStats>(); //gets object stats component
        objectStatsRef.ShowStats(); //calls the show stats function
    }

    void setCurrentObject(RaycastHit hit)
    {
        ObjecttoRotate = hit.collider.gameObject;
        oldLocation = ObjecttoRotate.transform.position;
        oldRotation = ObjecttoRotate.transform.rotation;
        SnapToCamera();
        
    }
}
