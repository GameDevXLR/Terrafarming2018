using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackManager : MonoBehaviour {

    public JetPackSO[] jetPacks;

    public JetPackPlayer jetPackPlayer;

   

    private void Start()
    {
        InGameManager.instance.playerController.JetPack.JetPack = jetPacks[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            InGameManager.instance.playerController.JetPack.JetPack = jetPacks[0];
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            InGameManager.instance.playerController.JetPack.JetPack = jetPacks[1];
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            InGameManager.instance.playerController.JetPack.JetPack = jetPacks[2];
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            InGameManager.instance.playerController.JetPack.JetPack = jetPacks[3];
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            InGameManager.instance.playerController.JetPack.JetPack = jetPacks[4];
        }
    }
}
