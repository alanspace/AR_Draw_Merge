using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldsChecker : MonoBehaviour
{
    public Button loginButton;
    public Button registerButton;
    public Button forgotPasswordButton;

    public InputField emailInput;
    public InputField passwordInput;

    public void OnInputUpdate() {
        forgotPasswordButton.interactable = IsEmailValid;
        bool isEverythingValid = IsEmailValid && IsPasswordValid;
        loginButton.interactable = isEverythingValid;
        registerButton.interactable = isEverythingValid;
    }

    bool IsEmailValid {
        get {
            if (emailInput.text.Length >= 5 && emailInput.text.Contains("@"))
                return true;
            return false;
        }
    }

    bool IsPasswordValid {
        get {
            if (passwordInput.text.Length >= 6 && passwordInput.text.Length <= 20)
                return true;
            return false;
        }
    }
}
