using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Register1 : MonoBehaviour
{
    //public ClientLibrary dBase;
    public InputField userName;
    public InputField password;
    public InputField confirmPassword;
    public Button submitButton;



    public void register()
    {
        Debug.Log("username is " + userName.text);
        Debug.Log("password is " + password.text);
        Debug.Log("confirm password is " + confirmPassword.text);

    }

    /*    public void CallRegister()
        {
           dBase.regUser(userName.text,password.text);
        }
*/


    public void VerifyPassword()
    {

        submitButton.interactable = password.text.Equals(confirmPassword.text);
    }
}
