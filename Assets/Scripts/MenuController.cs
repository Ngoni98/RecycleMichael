using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public Trash[] trashItems; //Array of trash used to create the trash gameobjects in the gameplay scene
    public Bin[] bins; //Array of bins used to create the bin gameobjects in the gameplay scene
    public int[] binPos = new int[5];
    public Sprite[] itemSprites;
    public Sprite[] freeSprites;

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
        DontDestroyOnLoad(this.gameObject);
    }


    /// <summary>
    /// On clicking free contract, takes the bin info at the position and fills the array.
    /// Creates an array of trash items for a free contract
    /// </summary>
    void FreeContract()
    {
        
        for (int i=0;i<5;i++)
            freeSprites[i] = itemSprites[i];
        freeSprites[5] = itemSprites[12];
        freeSprites[6] = itemSprites[13];

        for (int i = 0; i < 3; i++)
        {
            Trash t = new Trash(1.50f, 0.05f, i, 0, freeSprites[i]);
            trashItems[i] = t;
        }
        for(int i = 3; i < 6; i++)
        {
            Trash t = new Trash(1.50f, 0.05f, i, 1, freeSprites[i]);
            trashItems[i] = t;
        }
    }
    /// <summary>
    /// Use the drop event descriptor from the dummy control unit to find what
    /// bins are at what positions, create classes for each and store them in the Bin array
    /// </summary>
    void GetBinPositions()
    {

    }


    public static void SetPos(int pos, int binType)
    {
        
    }

}
