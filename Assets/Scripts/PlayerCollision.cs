using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //The purpose of this script is for player trigger collision
    
    bool inDeskArea = false;
    [SerializeField] DeskTrigger deskTriggerRef; //meeded to access code in the desk trigger script if we collide with it.
    
    
    private void OnTriggerEnter(Collider other) 
    {
        switch (other.gameObject.tag) //choose an option based on tag
        {
            case "DeskTrigger": //if tag is "DeskTrigger"
                if (!inDeskArea)
                {
                    deskTriggerRef.inArea = true;
                    inDeskArea = true;
                }
                break;

                //These two cases below aren't used but show how easily new functionality can be added.
            case "Death":
                //Add code to restart level or open a different level here for example
                break;
            case "Checkpoint":
                //Add code to set the player respawn point here
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag) //choose an option based on tag
        {
            case "DeskTrigger": //if tag is "DeskTrigger"
                if (inDeskArea)
                {
                    deskTriggerRef.inArea = false;
                    inDeskArea = false;
                }
                break;

           
        }
    }
}
