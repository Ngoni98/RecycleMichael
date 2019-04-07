using UnityEngine;

public class Bin
{
    private int capacity;
    private int maxCapacity;
    private int binType;
    private int id;
    public Sprite Sprite;

    public Bin(Sprite sprite, int type, int maxCapacity, int id)
    {
        this.Sprite = sprite;
        this.binType = type;
        this.maxCapacity = maxCapacity;
        SetSprite();
    }

    void SetSprite()
    {
        GameObject go = new GameObject("Bin " + id);
        go.tag = binType.ToString();
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        renderer.sprite = Sprite;
    }

    public void EmptyBin()
    {
        capacity = 0;
    }



}
