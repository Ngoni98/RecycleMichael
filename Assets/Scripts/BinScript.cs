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
        gameObject.name = binType.ToString();
    }

    public void Init(int maxCapacity, int binType, int id, Sprite Sprite)
    {
        this.maxCapacity = maxCapacity;
        this.binType = binType;
        this.id = id;

        renderer = gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = Sprite;
        renderer.sortingOrder = 2;

        col = gameObject.AddComponent<BoxCollider2D>();
        transform.localScale -= new Vector3(0.8f, 0.8f, 0);
        col.offset = new Vector2(0.0f, -0.46f);
        col.size = new Vector2(1.85f, 0.31f);
    }


}
