using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluedrumLight : MonoBehaviour
{
    public GameObject bluedrumLightObj;

    private bool lightIsOn = false;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!lightIsOn)
            {
                bluedrumLightObj.SetActive(true);
                lightIsOn = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lightIsOn)
            {
                bluedrumLightObj.SetActive(false);
                lightIsOn = false;
            }
        }
    }
}