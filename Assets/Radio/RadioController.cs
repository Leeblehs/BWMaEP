using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    private AudioSource radioAudioSource;
    public Canvas radioCanvas;
    public MouseMovement mouseMovement;
    public ParticleSystem musicalNotes;
    
    private void Start()
    {
        radioAudioSource = GetComponent<AudioSource>();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F1)) 
            {
                PlayAudio();
                musicalNotes.Play();
            }

             if (Input.GetKeyDown(KeyCode.F2)) 
            {
                PauseAudio();
                musicalNotes.Stop();
            }

             if (Input.GetKeyDown(KeyCode.F3)) 
            {
                StopAudio();
                musicalNotes.Stop();
            } 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        radioCanvas.gameObject.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        radioCanvas.gameObject.SetActive(false);
    }
    public void PlayAudio()
    {
        radioAudioSource.Play();
        Debug.Log("played");
    }

    public void PauseAudio()
    {
        radioAudioSource.Pause();
    }

    public void StopAudio()
    {
        radioAudioSource.Stop();
    }








}
