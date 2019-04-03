using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    private int capacity;
    private int maxCapacity;
    private int binType;
    public Sprite Sprite;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Sprite;
    }

    public void EmptyBin()
    {

    }



}
