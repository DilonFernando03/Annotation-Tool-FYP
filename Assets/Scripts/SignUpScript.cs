using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignUpScript : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField firstNameInput;
    public TMP_InputField lastNameInput;
    public Button signUpButton;

    // Start is called before the first frame update
    void Start()
    {
        signUpButton.onClick.AddListener(OnSignupButtonClicked);
    }

    void OnSignupButtonClicked()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        if (SharedMethods.Instance.IsValidEmail(email) && SharedMethods.Instance.IsValidPassword(password))
        {
            SharedMethods.Instance.ShowPopUp("Invalid email or password.");
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
            SharedMethods.Instance.ShowPopUp("Please enter a valid email and password.");
            /*
            messageText.text = "Please enter a valid email and password.";
            */
        }
    }

}
