using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SendKeyE : MonoBehaviour
{
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