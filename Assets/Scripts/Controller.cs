using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{
    private float cash;
    private int diamonds;
    private int energy;
    private int maxEnergy;
    private float deltaEng;

    public TextMeshProUGUI cashText;
    public TextMeshProUGUI diamondText;
    public TextMeshProUGUI energyText;

    public TextMeshProUGUI testText;
    //public Text cashText;
    //public Text testText;
    public GameObject[] bins;
    public GameObject[] binLocations;
    public Transform[] leftSideWaypoints;
    public Transform[] rightSideWaypoints;
    public Sprite[] trashSprites;
    public Sprite[] binSprites;
    public Sprite sprite;

    //public class Trash
    //{
    //    public float valueCash;
    //    public float chanceOfDiamond;
    //    public int itemId;
    //    public int trashType;
    //    public Sprite sprite;
    //}

    void Start()
    {
        if (PlayerPrefs.HasKey("Cash"))
        {
            cashText.text = "CASH: $" + PlayerPrefs.GetFloat("Cash");
        }
        if (PlayerPrefs.HasKey("Diamonds"))
        {
            diamondText.text = "DIAMONDS: " + PlayerPrefs.GetInt("Diamonds");
        }
        if (PlayerPrefs.HasKey("Energy"))
        {
            energyText.text = "ENERGY: " + PlayerPrefs.GetInt("Energy");
        }

        

        GameObject mainMenuController = GameObject.Find("Main Menu Controller");
        MenuController menuController = mainMenuController.GetComponent<MenuController>();
        GameObject test = new GameObject("Test trash");

        for (int i = 0; i< menuController.trashItems.Length; i++)
        {
            GameObject t = Instantiate(test);
            t.name = "Trash"+i;
            t.transform.position = rightSideWaypoints[0].position + new Vector3(0.0f + i, 0, 0);
            t.AddComponent<TrashScript>();
            
            t.GetComponent<TrashScript>().Init(menuController.trashItems[i].valueCash, menuController.trashItems[i].chanceOfDiamond,
                menuController.trashItems[i].itemId, menuController.trashItems[i].trashType, menuController.trashItems[i].sprite, rightSideWaypoints);
            
        }

        for(int i=0; i < menuController.bins.Length; i++)
        {
            GameObject b = Instantiate(test);
            b.name = "Bin" + i;
            b.transform.position = binLocations[i].transform.position;
            b.AddComponent<BinScript>();
            int type = menuController.bins[i].binType;
            b.GetComponent<BinScript>().Init(menuController.bins[i].maxCapacity, 
                type, menuController.bins[i].binId, binSprites[type]);
        }
        
       


        

        //GameObject b = Instantiate(test);
        //b.transform.position = binLocations[0].transform.position;
        //b.AddComponent<BinScript>();
        //b.GetComponent<BinScript>().Init(5, 0, 0, binSprites[0]);

        //GameObject t = Instantiate(test);
        //t.name = "Trash0";
        //t.transform.position = rightSideWaypoints[0].position;
        //t.AddComponent<TrashScript>();
        //t.GetComponent<TrashScript>().Init(1.50f, 0.1f, 0, 0, trashSprites[0], rightSideWaypoints);

        //GameObject t1 = Instantiate(test);
        //t1.name = "Trash1";
        //t1.transform.position = leftSideWaypoints[0].position;
        //t1.AddComponent<TrashScript>();
        //t1.GetComponent<TrashScript>().Init(1.50f, 0.1f, 1, 0, trashSprites[1], leftSideWaypoints);       
    }

    void Update()
    {

        //deltaEng += Time.deltaTime;
        //testText.text = "Time passed: " + deltaEng.ToString();
        
    }

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

    //void UpdateCash(float amount)
    //{
    //    cash = PlayerPrefs.GetFloat("Cash");
    //    cash += amount;
    //    cashText.text = "$" + cash.ToString();
    //    PlayerPrefs.SetFloat("Cash", cash);
    //}
     void UpdateDiamonds(int amount)
    {

    }
}
