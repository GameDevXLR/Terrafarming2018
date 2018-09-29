using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackManager : MonoBehaviour {

    public JetPackSO[] jetPacks;
    public KeyCode[] asignKeycode;

    public JetPackPlayer jetPackPlayer;
    public JetPackPlayerUI jetpackUI;

   

    private void Start()
    {
        SwitchJetPack(0);
    }

    private void Update()
    {
        DetectChangeJetPack();
    }

    private void DetectChangeJetPack()
    {
        int i = 0;
        int length= asignKeycode.Length;
        while (i < length && !Input.GetKeyDown(asignKeycode[i]))
        {
            i++;
        }
        if(i < length)
        {
            SwitchJetPack(i);
        }
    }

    private void SwitchJetPack(int index)
    {
        jetPackPlayer.JetPack = jetPacks[index];
        jetpackUI.SwitchJetPack();
    }
}
