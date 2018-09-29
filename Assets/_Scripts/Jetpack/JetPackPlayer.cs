﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class JetPackPlayer : MonoBehaviour, IConsommation {


    public FuelTank reservoir;

    [SerializeField]
    private JetPackSO jetPack;

    public bool isFlying = false;

    [SerializeField]
    private PlayerController controller;

    public bool CanBoost()
    {
        return reservoir.HaveEnougthEnergy(ConsoBoost);
    }

    public bool CanFly()
    {
        return reservoir.HaveEnougthEnergy(Conso);
    }

    #region setter / getter
    public float JumpForce { get => JetPack.jumpForce; }
    public TerrainEnum Terrains { get => JetPack.Terrain;  }

    public JetPackSO JetPack {
        get => jetPack;
        set
        {
            if (isFlying)
            {
                StopConsommation();
                jetPack = value;
                StartConsommation();
            }
            else
                jetPack = value;
        }
    }

    #endregion


    #region IConsommation
    public int Conso => JetPack.consoVol;

    public int ConsoBoost => JetPack.consoBoost;


    public bool StartConsommation()
    {
        isFlying = true;
        return reservoir.StartConso(this);
    }

    public void StopConsommation()
    {
        isFlying = false;
        reservoir.StopConso(this);
    }

    public void FailConsommation()
    {
        isFlying = false;
        Debug.Log("pas assez d'énergie");
    }

    public bool BoostConso()
    {
        return reservoir.Conso(this);
    }
#endregion
}
