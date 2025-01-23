using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safebox : MonoBehaviour
{
    public GameObject UI_interact;
    public GameObject key;
    public GameObject keyPlayer;
    public GameObject keyImage;
    public bool toggle = true, interactable;
    public Animator safeboxAnim;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("safekey"))
        {
            UI_interact.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("safekey"))
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
                safeboxAnim.ResetTrigger("interact");
                safeboxAnim.SetTrigger("interact");
                keyPlayer.SetActive(false);
                keyImage.SetActive(false);
                key.SetActive(false);
                UI_interact.SetActive(false);
            }
        }
    }
}