using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class reel : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private AudioSource bgmAudioSource;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        Canvas canvas = Object.FindFirstObjectByType<Canvas>();
        if (canvas != null)
        {
            bgmAudioSource = canvas.GetComponent<AudioSource>();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!videoPlayer.isPlaying)
            {
                videoPlayer.Play();

                if (bgmAudioSource != null && bgmAudioSource.isPlaying)
                {
                    bgmAudioSource.Pause();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();

                if (bgmAudioSource != null)
                {
                    bgmAudioSource.UnPause();
                }
            }
        }
    }
}
