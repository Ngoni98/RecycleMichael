using UnityEngine;

public class Trash
{
    GameObject go;
    private readonly float valueCash;
    private readonly float chanceOfDiamond;
    private readonly int id;
    private readonly int trashType;
    private readonly Sprite Sprite;

    public Trash(Sprite sprite, float value, float chance, 
        int trashType, int id)
    {
        this.Sprite = sprite;
        this.valueCash = value;
        this.chanceOfDiamond = chance;
        this.trashType = trashType;
        this.id = id;
        SetSprite();
    }

    void SetSprite()
    {
        go = new GameObject("Trash " + id);
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        renderer.sprite = Sprite;
    }


    //Don't think this will work without inheriting monobehaviour
    // https://answers.unity.com/questions/1089794/oncollisionenter-from-non-monobehaviour-script.html
    void OnTriggerEnter(Collider collider)
    {
        //Check tag of collider
        if (collider.tag.Equals(trashType.ToString()))
        {
            go.SetActive(false);
            Controller.UpdateCash(valueCash);
        }
        else
        {
            go.SetActive(false);
            Controller.UpdateCash(-valueCash);
        }
    }
}
