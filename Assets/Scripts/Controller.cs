using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public static float cash;
    public static int diamonds;
    public static int energy;

    public Text cashText;
    public GameObject[] bins;
    public GameObject[] binLocations;
    public Transform[] leftSideWaypoints;
    public Sprite[] trashSprites;
    public Sprite[] binSprites;

    public Sprite sprite;
    //public static Trash t;
    //public GameObject test;

    //Create an object
    //Add rigidbodies and renderer
    //Add trash script
    //Add properties from trash class to the script

    void Start()
    {
        cashText.text = "$" + PlayerPrefs.GetFloat("Cash");
        GameObject test = new GameObject("Test trash");

        GameObject t = Instantiate(test);
        t.name = "Trash0";
        t.transform.position = new Vector3(-0.5f, 1, 0);
        t.AddComponent<TrashScript>();
        t.GetComponent<TrashScript>().Init(1.50f, 0.05f, 0, 0, trashSprites[0], leftSideWaypoints);

        GameObject t1 = Instantiate(test);
        t1.name = "Trash1";
        t1.transform.position = new Vector3(0.5f, 1, 0);
        t1.AddComponent<TrashScript>();
        t1.GetComponent<TrashScript>().Init(1.50f, 0.05f, 1, 0, trashSprites[1], leftSideWaypoints);



        //t.AddComponent<Drag>();
        //sprite = sprites[0];
        //GameObject t = Instantiate(trash, trash.transform.position, Quaternion.identity) as GameObject;
        //Trash test = new Trash(sprite, 3.0f, 0.1f, 1, 0);
        //t = test.GetObject();

        // GameObject trash = new Trash(sprite, 3.0f, 0.1f, 1, 0).GetObject();


        //trash.AddComponent<TrashBehaviour>();
        //trash.GetComponent<TrashBehaviour>().target = leftSideWaypoints;
        //trash.GetComponent<TrashBehaviour>().trashSprite = sprite;


        //TrashBehaviour.SetProperties(leftSideWaypoints, sprites[0]);

        //sprite = sprites[0];
        //t = new Trash(sprite, 3.0f, 0.1f, 1, 0);
        //trash = t.GetObject();
        //trash.AddComponent<Drag>();
        //trash.AddComponent<ConveyorMovement>();
        //ConveyorMovement.SetWaypoints(leftSideWaypoints);
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

    void UpdateCash(float amount)
    {
        cash = PlayerPrefs.GetFloat("Cash");
        cash += amount;
        cashText.text = "$" + cash.ToString();
        PlayerPrefs.SetFloat("Cash", cash);
    }
     void UpdateDiamonds(int amount)
    {

    }
}
