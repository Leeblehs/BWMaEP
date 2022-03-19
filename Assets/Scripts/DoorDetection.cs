using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetection : MonoBehaviour
{
    public bool isAutomatic;
    public Animator doorAnimation;
    public AudioSource doorSound;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && isAutomatic){
            doorAnimation.SetBool("Open", true);
            doorSound.Play();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player"){
            doorAnimation.SetBool("Open", false);
            doorSound.Play();
        }    
    } 
}
