using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PopulateProfile : MonoBehaviour
{
    Profile Profile;
    public TextMeshProUGUI name ;
    public TextMeshProUGUI total;
    public TextMeshProUGUI wins;
    public TextMeshProUGUI loses;
    private int totalinteger;

    // Start is called before the first frame update
    void Start() {
        Profile = ClientLibrary.getProfile(userInfo.userName); ;
        name.text = Profile.Username;
        wins.text = "Wins: " +  Profile.Wins.ToString() ;
        loses.text = "Losses: " + Profile.Losses.ToString();
        totalinteger = Profile.Wins + Profile.Losses;
        total.text = "Total: " + totalinteger.ToString();

    }




}
