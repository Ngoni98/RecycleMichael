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
    private new SpriteRenderer renderer;
    private Lean.Touch.LeanSelectable selectable;
    private Lean.Touch.LeanTranslate translate;
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
        //Check for touch, check if the touch pos is contained within the bounds of this collider
        //if so then update the transform of this object to the touch pos
        //If touch then stop the waypoints from executing

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
            Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
            bool overSprite = renderer.bounds.Contains(touchedPos);
            if (overSprite)
            {
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    // get the touch position from the screen touch to world point


                    // lerp and set the position of the current object to that of the touch, but smoothly over time.
                    transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
                }
            }
        }

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
    /// <param name="value"></param>
    /// <param name="chanceDiamond"></param>
    /// <param name="id"></param>
    /// <param name="trashType"></param>
    /// <param name="sprite"></param>
    /// <param name="waypoints"></param>
    public void Init(float value, float chanceDiamond, int itemId, 
        int trashType, Sprite sprite, Transform[] waypoints)
    {
        this.valueCash = value;
        this.chanceOfDiamond = chanceDiamond;
        this.id = itemId;
        this.trashType = trashType;
        //this.Sprite = sprite;
        this.waypoints = waypoints;

        
        transform.localScale -= new Vector3(0.5f, 0.5f, 0);

        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        col = gameObject.AddComponent<BoxCollider2D>();
        col.isTrigger = true;
        col.size -= new Vector2(0.4f, 0.45f);

        renderer = gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        renderer.sortingOrder = 0;

        //selectable = gameObject.AddComponent<Lean.Touch.LeanSelectable>();
        //selectable.DeselectOnUp = true;

        //translate = gameObject.AddComponent<Lean.Touch.LeanTranslate>();
        //translate.RequiredSelectable = selectable;

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
            UpdateCash(valueCash);
            gameObject.SetActive(false);            
        }
        else
        {
            Debug.Log("Oops");
            UpdateCash(-valueCash);
            gameObject.SetActive(false);            
        }
    }

    void UpdateCash(float amount)
    {
        if (PlayerPrefs.HasKey("Cash"))
        {
            float cash = PlayerPrefs.GetFloat("Cash");
            cash += amount;
            Text cashText = GameObject.Find("Cash Text").GetComponent<Text>();
            cashText.text = "$" + cash.ToString();
            PlayerPrefs.SetFloat("Cash", cash);
        }
        else
        {
            PlayerPrefs.SetFloat("Cash", 0f);
            Text cashText = GameObject.Find("Cash Text").GetComponent<Text>();
            cashText.text = "$" + amount.ToString();
            PlayerPrefs.SetFloat("Cash", amount);

        }
    }
}
