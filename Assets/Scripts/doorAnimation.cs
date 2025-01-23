using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAnimation : MonoBehaviour
{
    public GameObject UI_interact;
    public bool toggle = true, interactable;
    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;
    public Animator doorAnim;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI_interact.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI_interact.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                if (Mathf.Approximately(transform.eulerAngles.y, 0))
                {
                    doorOpenSound.Play();
                }
                else if (Mathf.Approximately(transform.eulerAngles.y, 90))
                {
                    doorCloseSound.Play();
                }
                else
                {
                    doorOpenSound.Play();
                }
                doorAnim.ResetTrigger("interact");
                doorAnim.SetTrigger("interact");
            }
        }
    }
}