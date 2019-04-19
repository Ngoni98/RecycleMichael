using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour
{
    public int capacity;
    public int maxCapacity;
    public int binType;
    public int id;
    public Sprite Sprite;
    private new SpriteRenderer renderer;
    private BoxCollider2D col;

    void Start()
    {
        //This makes it easier when checking for collisions with trash objects
        gameObject.name = binType.ToString();
    }

    /// <summary>
    /// Initialise the bin
    /// </summary>
    /// <param name="maxCapacity"></param> The max capacity of the bin
    /// <param name="binType"></param> The type of the bin
    /// <param name="id"></param> The object id
    /// <param name="Sprite"></param> The sprite for the sprite renderer
    public void Init(int maxCapacity, int binType, int id, Sprite Sprite)
    {
        this.maxCapacity = maxCapacity;
        this.binType = binType;
        this.id = id;

        //Sprite renderer
        renderer = gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = Sprite;
        renderer.sortingOrder = 2;

        //Collider2D
        col = gameObject.AddComponent<BoxCollider2D>();
        col.offset = new Vector2(0.0f, -0.46f);
        col.size = new Vector2(1.85f, 0.31f);

        //Scales everything to fit the screen
        transform.localScale -= new Vector3(0.8f, 0.8f, 0);
    }


}
