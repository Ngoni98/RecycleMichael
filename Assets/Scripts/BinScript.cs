using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour
{
    private int capacity;
    public int maxCapacity;
    public int binType;
    public int id;
    public Sprite Sprite;

    void Start()
    {
        gameObject.name = binType.ToString();
    }

    public void Init(int maxCapacity, int binType, int id, Sprite Sprite)
    {
        this.maxCapacity = maxCapacity;
        this.binType = binType;
        this.id = id;

        SpriteRenderer renderer = gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = Sprite;
        renderer.sortingOrder = 1;
    }


}
