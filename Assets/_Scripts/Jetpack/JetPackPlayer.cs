using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackPlayer : MonoBehaviour {

    public bool canFly;
    public float jumpForce;
    [SerializeField, HideInInspector]
    private TerrainEnum terrains;

    public int consommationJump, consommationVol;

    public TerrainEnum Terrains { get => terrains; set => terrains = value; }


}
