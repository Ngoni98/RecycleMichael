using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashScript : MonoBehaviour
{
    private float valueCash;
    private float chanceOfDiamond;
    private int id;
    private int trashType;
    private Sprite Sprite;
    private Transform[] waypoints;

    private BoxCollider2D col;
    private Rigidbody2D rb;
    private Vector3 move;

    private float speed = 0.5f;
    private int current = 0;
    public bool drag;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (drag == false)
        //{
        //    if (transform.position != waypoints[current].position)
        //    {
        //        Vector3 pos = Vector3.MoveTowards(transform.position, waypoints[current].position, speed * Time.deltaTime);
        //        rb.MovePosition(pos);
        //    }
        //    else
        //        current = (current + 1) % waypoints.Length;
        //}
    }

    //void OnMouseDrag()
    //{
    //    //Debug.Log("Drag");
        
    //    move.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
    //    move.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
    //    move.z = -1;


    //    //float mouseX = Input.mousePosition.x;
    //    //float mouseY = Input.mousePosition.y;

    //    //Vector3 mousePos = new Vector3(mouseX, mouseY, 0.0f);
    //    //Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

    //    drag = true;
    //    gameObject.transform.position = move;
        
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

        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        col = gameObject.AddComponent<BoxCollider2D>();
        col.isTrigger = true;
        col.size += new Vector2(0.1f, 0.05f);
        SpriteRenderer renderer = gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        renderer.sortingOrder = 1;
        //gameObject.AddComponent<Lean.Touch.LeanSelectable>().DeselectOnUp = true;
        gameObject.AddComponent<Lean.Touch.LeanTranslate>();
        transform.localScale -= new Vector3(0.5f, 0.5f, 0);
        drag = false;
        Debug.Log("big cock");
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("cock");
        //Check tag of collider
        if (collider.name.Equals(trashType.ToString()))
        {
            Debug.Log("COCK");
            gameObject.SetActive(false);

            UpdateCash(valueCash);
        }
        else
        {
            gameObject.SetActive(false);
            UpdateCash(-valueCash);
        }
    }

    void UpdateCash(float amount)
    {
        float cash = PlayerPrefs.GetFloat("Cash");
        cash += amount;
        //Text cashText = FindObjectOfType<Text>();
        Controller.cashText.text = "$" + cash.ToString();
        PlayerPrefs.SetFloat("Cash", cash);
    }
}
