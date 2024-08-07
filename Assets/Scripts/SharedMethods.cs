using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SharedMethods : MonoBehaviour
{
    public static SharedMethods Instance { get; private set; }
    // Pop-up elements
    public GameObject popUpPanel;
    public TextMeshProUGUI popUpText;
    public Button closeButton;

    private void Start()
    {
        popUpPanel.SetActive(false);
        closeButton.onClick.AddListener(HidePopUp);
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this instance persistent
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsValidEmail(string email)
    {
        // Simple email validation
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public bool IsValidPassword(string password)
    {
        // Simple password validation (at least 6 characters for this example)
        return password.Length >= 6;
    }

    public void ShowPopUp(string message)
    {
        popUpText.text = message;
        popUpPanel.SetActive(true);
    }

    public void HidePopUp()
    {
        popUpPanel.SetActive(false);
    }
}
