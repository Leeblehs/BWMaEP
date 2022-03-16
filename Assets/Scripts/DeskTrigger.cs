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
    public bool inTask = false;
    public bool inArea = false;
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inArea)
        {
            for (int i = 0; i == otherUI.Length; i++)
            {
                if (inTask)
                {
                    if (i == 1)
                    {
                        continue;
                    }

                    otherUI[i].SetActive(false);

                }
                otherUI[i].SetActive(false);


            }
            if (!inTask)
            {
                UIRef.SetActive(true);
            }
           
            
            
            playerCam.SetActive(false);
            newCamera.SetActive(true);
            playerCodeRef.allowMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            




        }

        if (Input.GetKeyDown(KeyCode.Escape) && inArea)
        {
            Debug.Log("InTask: " + inTask);
            ReturnPlayerControl();
            

        }
        
        



    }

    public void ReturnPlayerControl()
    {
        UIRef.SetActive(false);
        
        
        playerCam.SetActive(true);
        newCamera.SetActive(false);






        for (int i = 0; i == otherUI.Length; i++)
        {
            if (inTask)
            {
                if (i == 1)
                {
                    continue;
                }

                otherUI[i].SetActive(false);

            }
            otherUI[i].SetActive(false);


        }
        playerCodeRef.allowMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    




}
