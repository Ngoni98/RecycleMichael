using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{
    private float cash;
    private int diamonds;
    private int energy;
    private int maxEnergy;

    //UI objects
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI diamondText;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI testText;


    public GameObject[] binLocations; //Objects where the bins will be placed
    public Transform[] leftSideWaypoints; //The transforms used when moving the trash on the conveyer
    public Transform[] rightSideWaypoints;
    public Sprite[] trashSprites; //All the available trash sprites
    public Sprite[] binSprites; //All the available bin sprites

    void Start()
    {
        if (PlayerPrefs.HasKey("Cash"))
            cashText.text = "CASH: $" + PlayerPrefs.GetFloat("Cash");
        
        if (PlayerPrefs.HasKey("Diamonds"))
            diamondText.text = "DIAMONDS: " + PlayerPrefs.GetInt("Diamonds");
        
        if (PlayerPrefs.HasKey("Energy"))
            energyText.text = "ENERGY: " + PlayerPrefs.GetInt("Energy");
        

        //Get a reference to the MenuController object so we can access the Trash[] and Bin[] arrays
        GameObject mainMenuController = GameObject.Find("Main Menu Controller");
        MenuController menuController = mainMenuController.GetComponent<MenuController>();
        GameObject test = new GameObject("Test trash");

        //Loop for instantiating the trash items
        for (int i = 0; i< menuController.trashItems.Length; i++)
        {
            GameObject t = Instantiate(test);
            Transform[] waypoints = rightSideWaypoints;
            Vector3 posOffset = new Vector3(0.0f + i, 0, 0);

            //Make half of the trash move along one conveyer and the other half move along the other
            if (i > menuController.trashItems.Length / 2)
            {
                waypoints = leftSideWaypoints;
                posOffset = -posOffset;
            }

            t.name = "Trash"+i;
            t.transform.position = waypoints[0].position + posOffset;
            t.AddComponent<TrashScript>();

            //Initialise the trash object with all of the properties from the Trash class
            t.GetComponent<TrashScript>().Init(menuController.trashItems[i].valueCash, menuController.trashItems[i].chanceOfDiamond,
                menuController.trashItems[i].itemId, menuController.trashItems[i].trashType, menuController.trashItems[i].sprite, waypoints);
            
        }

        //Loop for instantiating the Bins at their locations
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
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
