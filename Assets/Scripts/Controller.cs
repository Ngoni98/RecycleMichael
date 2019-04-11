using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static float cash;
    public static int diamonds;
    public static int energy;

    public GameObject[] bins;
    public GameObject[] binLocations;
    public Transform[] leftSideWaypoints;
    public Sprite[] trashSprites;
    public Sprite[] binSprites;

    public Sprite sprite;
    //public static Trash t;
    public GameObject trash;

    //Create an object
    //Add rigidbodies and renderer
    //Add trash script
    //Add properties from trash class to the script

    void Start()
    {

        GameObject t = new GameObject("Test trash");
        t.transform.position = trash.transform.position;
        t.AddComponent<TrashScript>();
        t.GetComponent<TrashScript>().Init(1.0f, 0.05f, 1, 1, sprite, leftSideWaypoints);
        t.AddComponent<Drag>();
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

    public static void UpdateCash(float amount)
    {
        cash += amount;
    }
     void UpdateDiamonds(int amount)
    {

    }
}
