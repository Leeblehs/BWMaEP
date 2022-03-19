using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskTrigger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject UIRef;
    [SerializeField] GameObject[] otherUI;
    [SerializeField] GameObject newCamera;
    [SerializeField] GameObject playerCam;
    [SerializeField] MovementRigidbody playerCodeRef;
    
    //Both of these variables need to be public but don't need to be edited in the inspector
    [HideInInspector] public bool inTask = false;
    [HideInInspector] public bool inArea = false;
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inArea)
        {
            RemoveUI();
            if (!inTask)
            {
                //if not currently in a task, set the task choice ui to be active
                UIRef.SetActive(true);
            }
           
            //Switches camera
            playerCam.SetActive(false);
            newCamera.SetActive(true);

            //Stops player movement, unlocks mouse movement and makes it visible (to allow button presses on the screen).
            playerCodeRef.allowMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            




        }

        //Simply closes the ui if escape is pressed at any point (unless a quiz task is started)
        if (Input.GetKeyDown(KeyCode.Escape) && inArea)
        {
            ReturnPlayerControl();

        }
        
        



    }

    public void ReturnPlayerControl()
    {
        UIRef.SetActive(false);

        //Resets camera back to player
        playerCam.SetActive(true);
        newCamera.SetActive(false);

        //Calls the remove ui function
        RemoveUI();

        //Returns movement to the player, while also hiding and locking the mouse cursor
        playerCodeRef.allowMove = true;
        inArea = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void RemoveUI()
    {

        for (int i = 0; i == otherUI.Length; i++)
        {
            if (inTask)
            {
                if (i == 1) //if in task is true and is currently on the quiz screen (otherUI[1]) it will skip removing the ui from the desk panel so players can move around and find info for questions
                {
                    continue;
                }

                otherUI[i].SetActive(false);

            }
            otherUI[i].SetActive(false);


        }
    }




}
