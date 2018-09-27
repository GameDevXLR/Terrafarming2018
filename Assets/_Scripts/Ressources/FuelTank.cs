using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelTank : MonoBehaviour {

    [SerializeField, HideInInspector]
    private int energy, maxEnergy;

    public Slider energyBar;

    public int currentConsommation = 0;

    public int Energy
    {
        get => energy;
        set
        {
            energy = value;
            if (energyBar)
            {
                energyBar.value = energy;
            }

            if (energy < 0) Energy = 0;
            if (energy > maxEnergy) Energy = maxEnergy;
        }
    }

    public int MaxEnergy
    {
        get => maxEnergy;
        set
        {
            maxEnergy = value;
            if (energyBar)
                energyBar.maxValue = maxEnergy;
            if (energy > maxEnergy)
                Energy = maxEnergy;
        }
    }


    IEnumerator ConsommationCoroutine()
    {
        while (energy-currentConsommation >= 0)
        {
            Energy -= currentConsommation;
            yield return new WaitForSeconds(1);

        }
    }
}
