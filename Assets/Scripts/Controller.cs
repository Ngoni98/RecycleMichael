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
    private float deltaEng;

    public TextMeshProUGUI cashText;
    public TextMeshProUGUI diamondText;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI testText;

    public GameObject[] binLocations;
    public Transform[] leftSideWaypoints;
    public Transform[] rightSideWaypoints;
    public Sprite[] trashSprites;
    public Sprite[] binSprites;
    public Sprite sprite;

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
            Transform[] waypoints = rightSideWaypoints;
            Vector3 posOffset = new Vector3(0.0f + i, 0, 0);

            if (i > menuController.trashItems.Length / 2)
            {
                waypoints = leftSideWaypoints;
                posOffset = -posOffset;
            }
            t.name = "Trash"+i;
            t.transform.position = waypoints[0].position + posOffset;
            t.AddComponent<TrashScript>();
            
            t.GetComponent<TrashScript>().Init(menuController.trashItems[i].valueCash, menuController.trashItems[i].chanceOfDiamond,
                menuController.trashItems[i].itemId, menuController.trashItems[i].trashType, menuController.trashItems[i].sprite, waypoints);
            
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
    }

    void Update()
    {

        //deltaEng += Time.deltaTime;
        //testText.text = "Time passed: " + deltaEng.ToString();
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
