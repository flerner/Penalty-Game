using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputName : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;
    private void Awake()
    {
        PauseMenu.GameIsPaused = true;
    }
  
    public void OnSubmitButton()
    {
        if (inputField != null && inputField.text != "")
        {
            GameManager.AddInputName(inputField.text);
            Debug.Log(inputField.text);
            this.gameObject.SetActive(false);
            PauseMenu.GameIsPaused = false;
        }
    }
}
