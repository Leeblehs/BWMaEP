using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    bool inDeskArea;
    [SerializeField] DeskTrigger deskTriggerRef;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "DeskTrigger":
                if (!inDeskArea)
                {
                    deskTriggerRef.inArea = true;
                    inDeskArea = true;
                }
                break;
            case "Death":
                break;
            case "Checkpoint":
                break;
        }
    }
}
