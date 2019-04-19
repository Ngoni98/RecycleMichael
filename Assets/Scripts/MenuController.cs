using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public Trash[] trashItems; //Array of trash used to create the trash gameobjects in the gameplay scene
    public Bin[] bins; //Array of bins used to create the bin gameobjects in the gameplay scene
    public Sprite[] itemSprites; //Array of all the available sprites that can be ussed for trash
    public Sprite[] contractSprites; //The sprites that will be used for the selected contract
    public GameObject[] binPositions; //This array holds the object that is used to determine what type of bin is at what position
    private int[] binTypes; // Used to identify which type of bin is at what position

    //Trash class is used in the game scene to instantiate the trash objects
    public class Trash
    {
        public float valueCash;
        public float chanceOfDiamond;
        public int itemId;
        public int trashType;
        public Sprite sprite;

        public Trash(float value, float chance, int id, int type, Sprite _sprite)
        {
            valueCash = value;
            chanceOfDiamond = chance;
            itemId = id;
            trashType = type;
            sprite = _sprite;
        }
    }

    //Bin class is used in the game scene to instantiate the bins
    public class Bin
    {
        public int maxCapacity;
        public int binType;
        public int binId;

        public Bin(int max, int type, int id)
        {
            maxCapacity = max;
            binType = type;
            binId = id;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject); //Don't destroy this object in the next scene as we need access to the Trash and
                                            //Bin arrays

        //Set player prefs
        if (!PlayerPrefs.HasKey("Cash"))
            PlayerPrefs.SetFloat("Cash", 0.0f);
        if (!PlayerPrefs.HasKey("Diamonds"))
            PlayerPrefs.SetInt("Diamonds", 0);
        if (!PlayerPrefs.HasKey("Energy"))
            PlayerPrefs.SetInt("Energy", 100);
        

    }

    #region Contract methods
    /// <summary>
    /// Creates an array of trash items for a free contract
    /// Currently it is hard coded what will go into the array
    /// </summary>
    public void FreeContract()
    {
        trashItems = new Trash[8];
        contractSprites = new Sprite[8];
        //Use itemSprites 0-5, 12, and 13
        //These sprites correspond to the paper and plastic items
        for (int i = 0; i < 6; i++)
            contractSprites[i] = itemSprites[i];
        contractSprites[6] = itemSprites[12];
        contractSprites[7] = itemSprites[13];

        //Create the Trash items
        for (int i = 0; i < 3; i++)
        {
            //Plastic items 3
            Trash t = new Trash(1.50f, 0.05f, i, 0, contractSprites[i]);
            trashItems[i] = t;
        }
        for(int i = 3; i < 8; i++)
        {
            //Paper items 6
            Trash t = new Trash(1.50f, 0.05f, i, 1, contractSprites[i]);
            trashItems[i] = t;
        }
        Debug.Log("Free contract selected");
    }
    /// <summary>
    /// Contract for $10
    /// Creates twice as much as the free contract
    /// </summary>
    public void TenContract()
    {
        trashItems = new Trash[16];
        contractSprites = new Sprite[8];
        float cash = PlayerPrefs.GetFloat("Cash");
        cash -= 10.0f;
        PlayerPrefs.SetFloat("Cash", cash);

        //Use itemSprites 0-5, 12, and 13
        //These sprites correspond to the paper and plastic items
        for (int i = 0; i < 6; i++)
            contractSprites[i] = itemSprites[i];
        contractSprites[6] = itemSprites[12];
        contractSprites[7] = itemSprites[13];

        //Create the Trash items
        for (int i = 0; i < 3; i++)
        {
            //Plastic items 3
            Trash t = new Trash(1.50f, 0.05f, i, 0, contractSprites[i]);
            trashItems[i] = t;
        }
        for (int i = 3; i < 8; i++)
        {
            //Paper items 6
            Trash t = new Trash(1.50f, 0.05f, i, 1, contractSprites[i]);
            trashItems[i] = t;
        }
        for (int i = 0; i < 3; i++)
        {
            //Plastic items 3
            Trash t = new Trash(1.50f, 0.05f, i+8, 0, contractSprites[i]);
            trashItems[i+8] = t;
        }
        for (int i = 3; i < 8; i++)
        {
            //Paper items 6
            Trash t = new Trash(1.50f, 0.05f, i+8, 1, contractSprites[i]);
            trashItems[i+8] = t;
        }
        Debug.Log("$10 contract selected");
    }
    #endregion

    /// <summary>
    /// Fills the binTypes array with the type of bin at which position
    /// At array element 0 is the position 1 on the main menu.
    /// GetBinPositions then fills the array with the type of bin
    /// </summary>
    void GetBinPositions()
    {
        binTypes = new int[binPositions.Length];

        //For each object in the binPositions array
        //The name of the object is the position
        //The name of the child is the bin type
        //So fill the binTypes array with the correct positions and types
        foreach (var f in binPositions)
        {
            int binPos;
            int.TryParse(f.gameObject.name, out binPos);
            
            if (f.transform.childCount > 1)
            {
                int type;
                int.TryParse(f.transform.GetChild(1).name, out type);
                binTypes[binPos] = type;
                Debug.Log("At position " + binPos + " there is a bin of type " + type);
            }
            else
            {
                Debug.Log("Need to choose a bin for position " + binPos);
                return;
            }
        }
    }

    /// <summary>
    /// Gets the type of bin from the binTypes array
    /// Then gets the max capacity for that type of bin and creates a Bin object
    /// and puts it in the Bin array
    /// </summary>
    void FillBinArray()
    {
        bins = new Bin[binTypes.Length];

        for(int i = 0; i < binTypes.Length; i++)
        {
            if (binTypes[i] == null)
            {
                Debug.Log("No bin chosen");
                return;
            }
            else
            {
                int type = binTypes[i];
                if (PlayerPrefs.HasKey("Max" + type))
                {
                    //Using PlayerPrefs to store the max capacity of the bin type
                    //So in the future, the player can upgrade their bins
                    Bin bin = new Bin(PlayerPrefs.GetInt("Max" + type), type, i);
                    bins[i] = bin;
                }
                else
                {
                    int max = 5;
                    PlayerPrefs.SetInt("Max" + type, max);
                    Bin bin = new Bin(max, type, i);
                    bins[i] = bin;
                }
            }
        }
    }

    public void StartGame()
    {
        //Both these functions require checks to make sure the user has chosen their bins 
        //properly. Currently there is no check in place
        GetBinPositions();
        FillBinArray();

        if(bins[0] != null && trashItems[0] != null)
        {
            //Change scene
            SceneManager.LoadScene(1, LoadSceneMode.Single);
            Debug.Log("Change scene success");
        }
        else
        {
            Debug.Log("Need to select a contract and set bin positions");
        }
    }

}
