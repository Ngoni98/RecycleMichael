using UnityEngine;

public class Trash 
{
    private GameObject go;
    private readonly float valueCash;
    public float chanceOfDiamond;
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
    }

    public void SetSprite()
    {
        go = new GameObject("Trash " + id);

        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        renderer.sprite = Sprite;

        CircleCollider2D collider =  go.AddComponent<CircleCollider2D>();

        Rigidbody rigidbody = go.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }


    //Don't think this will work without inheriting monobehaviour
    // https://answers.unity.com/questions/1089794/oncollisionenter-from-non-monobehaviour-script.html
    public void OnTriggerEnter(Collider collider)
    {
        ////Check tag of collider
        //if (collider.tag.Equals(trashType.ToString()))
        //{
        //    go.SetActive(false);
        //    Controller.UpdateCash(valueCash);
        //}
        //else
        //{
        //    go.SetActive(false);
        //    Controller.UpdateCash(-valueCash);
        //} 
        Debug.Log("cock");
    }

    public GameObject GetObject()
    {
        GameObject go = new GameObject("Trash " + id);

        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        renderer.sprite = Sprite;

        CircleCollider2D collider = go.AddComponent<CircleCollider2D>();

        Rigidbody rigidbody = go.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
        return go;
    }
}
