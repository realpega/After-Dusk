using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class liftdoorAnimation_web : MonoBehaviour
{
    public GameObject UI_interact_m;
    public Animator liftdoorAnim;
    private Button interactButton;
    public bool toggle = true;
    public AudioSource liftdoorOpenSound;
    public AudioSource liftdoorCloseSound;
    public bool interactable;
    private float c = 0;

    void Start()
    {
        UI_interact_m.SetActive(false);
        interactButton = UI_interact_m.GetComponent<Button>();
        if (interactButton != null)
        {
            interactButton.onClick.AddListener(OnInteractButtonClicked);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI_interact_m.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
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
            c++;
            if (c % 2 != 0)
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