using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catBGM : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource catbgm;

    private bool catBGM_playing = false;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!catBGM_playing)
            {
                bgm.Pause();
                catbgm.Play();
                catBGM_playing = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (catBGM_playing)
            {
                catbgm.Stop();
                bgm.UnPause();
                catBGM_playing = false;
            }
        }
    }
}