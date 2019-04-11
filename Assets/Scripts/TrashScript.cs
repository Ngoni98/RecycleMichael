using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    private float valueCash;
    private float chanceOfDiamond;
    private int id;
    private int trashType;
    private Sprite Sprite;
    private Transform[] waypoints;

    private float speed = 0.5f;
    private int current = 0;
    public bool drag;

    // Start is called before the first frame update
    void Start()
    {
        drag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!drag)
        {
            if (transform.position != waypoints[current].position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, waypoints[current].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
            }
            else
                current = (current + 1) % waypoints.Length;
        }
    }

    //void OnMouseDrag()
    //{
    //    drag = !drag;
    //    Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //    Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //    transform.position = objPosition;
    //}

    //void OnMouseUp()
    //{
    //    if (drag)
    //        drag = !drag;
    //}

    /// <summary>
    /// Initializes the trash object
    /// </summary>
    /// <param name="valueCash"></param>
    /// <param name="chanceOfDiamond"></param>
    /// <param name="id"></param>
    /// <param name="trashType"></param>
    /// <param name="sprite"></param>
    /// <param name="waypoints"></param>
    public void Init(float valueCash, float chanceOfDiamond, int id, 
        int trashType, Sprite sprite, Transform[] waypoints)
    {
        this.valueCash = valueCash;
        this.chanceOfDiamond = chanceOfDiamond;
        this.id = id;
        this.trashType = trashType;
        //this.Sprite = sprite;
        this.waypoints = waypoints;

        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        SpriteRenderer renderer = gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        renderer.sortingOrder = 1;
        transform.localScale -= new Vector3(0.5f, 0.5f, 0);
        Debug.Log("big cock");
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("cock");
        //Check tag of collider
        if (collider.tag.Equals(trashType.ToString()))
        {
            Debug.Log("COCK");
            gameObject.SetActive(false);
            Controller.UpdateCash(valueCash);
        }
        else
        {
            gameObject.SetActive(false);
            Controller.UpdateCash(-valueCash);
        }
    }
}
