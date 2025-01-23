using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    public GameObject UI_interact;
    public GameObject key;
    public GameObject keyPlayer;
    public GameObject keyImage;
    public bool toggle = true, interactable;

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
                keyPlayer.SetActive(true);
                keyImage.SetActive(true);
                key.SetActive(false);
                UI_interact.SetActive(false);
            }
        }
    }
}