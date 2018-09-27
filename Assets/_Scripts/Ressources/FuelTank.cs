using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelTank : MonoBehaviour {

    [SerializeField, HideInInspector]
    private int energy, maxEnergy;
    public Slider energyBar;

    private int currentConsommation = 0;
    private bool isConsoRunning = false;

    private List<IConsommation> ObjsUsingFuel;

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
            energy = (energy < 0) ? 0 : (energy > maxEnergy) ? maxEnergy : energy;
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

    public void Replenish()
    {
        Energy = MaxEnergy;
    }

    public int CurrentConsommation {
        get => currentConsommation;
        set
        {   
            currentConsommation = (value < 0) ? 0 : value;
        }
    }

    public void Conso(IConsommation obj)
    {
        if(Energy - obj.ConsoBoost > 0)
        {
            Energy -= obj.ConsoBoost;
        }
        FailConso(obj);
    }

    public void StartConso(IConsommation obj)
    {
        if(Energy - CurrentConsommation + obj.Conso >= 0)
        {
            CurrentConsommation += obj.Conso;
            if (!isConsoRunning)
            {
                StartCoroutine(ConsommationCoroutine());
            }
            if(!ObjsUsingFuel.Contains(obj))
                ObjsUsingFuel.Add(obj);
        }
        FailConso(obj);
    }

    public void StopConso(IConsommation obj)
    {
        CurrentConsommation -= obj.Conso;
        ObjsUsingFuel.Remove(obj);
    }


    public void FailContinueAllConso()
    {
        foreach(var obj in ObjsUsingFuel)
        {
            obj.FailConsommation();
        }
    }

    public void FailConso(IConsommation obj)
    {
        obj.FailConsommation();
    }

    IEnumerator ConsommationCoroutine()
    {
        while (energy-CurrentConsommation >= 0 && currentConsommation > 0)
        {
            Energy -= CurrentConsommation;
            yield return new WaitForSeconds(1);
        }

        if (energy - CurrentConsommation >= 0)
            FailContinueAllConso();

        isConsoRunning = false;


    }
}
