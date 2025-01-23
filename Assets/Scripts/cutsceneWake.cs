using System.Collections;
using UnityEngine;

public class cutsceneWake : MonoBehaviour
{
    private Animator playerAnimator;
    public GameObject inventory;
    public GameObject jump;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        StartCoroutine(DisableAnimator());
        
    }

    private IEnumerator DisableAnimator()
    {
        yield return new WaitForSeconds(9.5f);

        if (playerAnimator != null)
        {
            playerAnimator.enabled = false;
            inventory.SetActive(true);
            jump.SetActive(true);
        }
    }
}