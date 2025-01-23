using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bigdoorAnimation_m : MonoBehaviour
{
    public GameObject UI_interact_m;
    public Animator doorAnim;
    private Button interactButton;
    public bool toggle = true;
    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;
    public bool interactable;

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
            if (Mathf.Approximately(transform.eulerAngles.y, 90))
            {
                doorOpenSound.Play();
            }
            else if (Mathf.Approximately(transform.eulerAngles.y, 0) || Mathf.Approximately(transform.eulerAngles.y, 180))
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