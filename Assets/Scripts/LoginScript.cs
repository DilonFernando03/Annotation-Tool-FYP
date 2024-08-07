using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    public  TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public Button loginButton;

    // Pop-up elements
    public GameObject popUpPanel;
    public TextMeshProUGUI popUpText;
    public Button closeButton;

    // Start is called before the first frame update
    void Start()
    {
        popUpPanel.SetActive(false);
        loginButton.onClick.AddListener(OnLoginButtonClicked);
        closeButton.onClick.AddListener(HidePopUp);
    }

    void OnLoginButtonClicked()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        if (IsValidEmail(email) && IsValidPassword(password))
        {
            ShowPopUp("Invalid email or password.");
            /*
            if (email == correctEmail && password == correctPassword)
            {
                messageText.text = "Login successful!";
                // Proceed to the next scene or perform other actions upon successful login
            }
            else
            {
                messageText.text = "Invalid email or password.";
            }
            */
        }
        else
        {
            ShowPopUp("Please enter a valid email and password.");
            /*
            messageText.text = "Please enter a valid email and password.";
            */
        }
    }

    bool IsValidEmail(string email)
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

    bool IsValidPassword(string password)
    {
        // Simple password validation (at least 6 characters for this example)
        return password.Length >= 6;
    }

    void ShowPopUp(string message)
    {
        popUpText.text = message;
        popUpPanel.SetActive(true);
    }

    void HidePopUp()
    {
        popUpPanel.SetActive(false);
    }
}
