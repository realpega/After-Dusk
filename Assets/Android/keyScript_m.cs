using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyScript_m : MonoBehaviour
{
    public GameObject UI_interact_m;
    public GameObject key;
    public GameObject keyPlayer;
    public GameObject keyImage;
    private Button interactButton;
    public bool toggle = true, interactable;

    void Start()
    {
        if (Application.isMobilePlatform)
        {
            UI_interact_m.SetActive(false);
            interactButton = UI_interact_m.GetComponent<Button>();
            if (interactButton != null)
            {
                interactButton.onClick.AddListener(OnInteractButtonClicked);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Application.isMobilePlatform && other.CompareTag("Player"))
        {
            UI_interact_m.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (Application.isMobilePlatform && other.CompareTag("Player"))
        {
            UI_interact_m.SetActive(false);
            interactable = false;
        }
    }
    void OnInteractButtonClicked()
    {
        if (interactable)
        {
            toggle = !toggle;
            keyPlayer.SetActive(true);
            keyImage.SetActive(true);
            key.SetActive(false);
            UI_interact_m.SetActive(false);
        }
    }
}