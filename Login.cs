using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Login : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField userName;
    public InputField password;
    public Button submit;

    public void LoginUser()
    {
        ClientLibrary.authUser(userName.text, password.text);
    }

}
