using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackPlayer : MonoBehaviour, IConsommation {

    public bool canFly;
    public float jumpForce;
    public FuelTank reservoir;
    [SerializeField, HideInInspector]
    private TerrainEnum terrains;

    [SerializeField]
    private int consoBoost, consoVol;

    public TerrainEnum Terrains { get => terrains; set => terrains = value; }
    

    #region IConsommation
    public int Conso => consoVol;

    public int ConsoBoost => ConsoBoost;

    public void StartConsommation()
    {
        reservoir.StartConso(this);
    }

    public void StopConsommation()
    {
        reservoir.StopConso(this);
    }

    public void FailConsommation()
    {
        Debug.Log("pas assez d'énergie");
    }

    public void BoostConso()
    {
        reservoir.Conso(this);
    }
    #endregion
}
