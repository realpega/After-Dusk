using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftdoorAnimation : MonoBehaviour
{
    public GameObject UI_interact;
    public bool toggle = true, interactable;
    public AudioSource liftdoorOpenSound;
    public AudioSource liftdoorCloseSound;
    public Animator liftdoorAnim;
    private float c=0;

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
                c++;
                if (c%2 != 0)
                {
                    liftdoorOpenSound.Play();
                }
                else
                {
                    liftdoorCloseSound.Play();
                }

                liftdoorAnim.ResetTrigger("interact");
                liftdoorAnim.SetTrigger("interact");
            }
        }
    }
}