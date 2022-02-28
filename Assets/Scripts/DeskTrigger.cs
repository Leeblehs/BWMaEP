using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskTrigger : MonoBehaviour
{
    [SerializeField] GameObject UIRef;
    [SerializeField] GameObject[] otherUI;
    [SerializeField] GameObject newCamera;
    [SerializeField] CameraControl playerCodeRef;
    public bool inArea;
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inArea)
        {
            Debug.Log("Pressed E in area of " + gameObject.name);
            UIRef.SetActive(true);
            playerCodeRef.SwitchCam(newCamera);
            playerCodeRef.allowMove = false;
            
            foreach(GameObject othersToDisable in otherUI)
            {
                othersToDisable.SetActive(false);
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape) && inArea)
        {
            UIRef.SetActive(false);
            playerCodeRef.ResetCam(newCamera);
            playerCodeRef.allowMove = false;
            playerCodeRef.allowMove = true;

        }



    }

    


}
