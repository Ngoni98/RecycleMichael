using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static float cash;
    public static int diamonds;
    public static int energy;
    private Bin[] bins;
    public GameObject[] binLocations;

    void StartContract()
    {
        //Begin the game 
    }

    void GenerateFacility(GameObject[] locations, Bin[] bins)
    {
        //Place bins at chosen locations
    }

    void UpgradeBin(Bin bin)
    {

    }
    
    void BuyBin(Bin[] bins)
    {

    }

    void UpdateEnergy(int amount)
    {

    }

    public static void UpdateCash(float amount)
    {
        cash += amount;
    }
     void UpdateDiamonds(int amount)
    {

    }
}
