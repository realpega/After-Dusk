using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class jumpScript : MonoBehaviour
{
    //public float jumpSpeed = 8.0f;
    //public float gravity = 20.0f;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        Input.GetKeyDown(KeyCode.E);
    }
}
