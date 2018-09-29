using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetPackPlayerUI : MonoBehaviour {

    public JetPackPlayer jetpack;

    public Text NameText, 
        puissanceText, 
        consoBoostText, 
        consoVolText;

    public Toggle canFly;

    public void SwitchJetPack()
    {
        Debug.Log("coucu");
        if (NameText)
        {
            NameText.text = jetpack.JetPack.name;
        }
        if (puissanceText)
        {
            puissanceText.text = jetpack.JetPack.jumpForce.ToString();
        }
        if (consoBoostText)
        {
            consoBoostText.text = jetpack.JetPack.consoBoost.ToString();
        }
        if (consoVolText)
        {
            consoVolText.text = jetpack.JetPack.consoVol.ToString();
        }

        if (canFly)
        {
            canFly.isOn = jetpack.JetPack.canVol;
        }

    }
}
