using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskTrigger : MonoBehaviour
{
    [SerializeField] GameObject UIRef;
    [SerializeField] GameObject[] otherUI;
    [SerializeField] GameObject newCamera;
    [SerializeField] GameObject playerCam;
    [SerializeField] MovementRigidbody playerCodeRef;
    public bool inArea;
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inArea)
        {
            Debug.Log("Pressed E in area of " + gameObject.name);
            UIRef.SetActive(true);
            playerCam.SetActive(false);
            newCamera.SetActive(true);
            playerCodeRef.allowMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            foreach (GameObject othersToDisable in otherUI)
            {
                othersToDisable.SetActive(false);
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape) && inArea)
        {
            UIRef.SetActive(false);
            playerCam.SetActive(true);
            newCamera.SetActive(false);
            
            playerCodeRef.allowMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }



    }

    


}
