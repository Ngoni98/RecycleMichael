using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private Vector3 move;

    private float speed = 0.5f;
    private int current = 0;
    public bool drag;

    public Vector3 mousePrevPos;
    public Vector3 mouseCurPos;
    public Vector3 force;
    public float topSpeed = 5;

    //Update is used to move the object along the waypoints until the item is being
    //dragged by the player
    void Update()
    {
        if (drag == false)
        {
            if (transform.position != waypoints[current].position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, waypoints[current].position, speed * Time.deltaTime);
                rb.MovePosition(pos);
            }
            else
                current = (current + 1) % waypoints.Length;
        }
    }

    //OnMouse functions can be used to accept touch input on a 
    //mobile device
    //Gets the mouse position and changes the objects world postion
    #region Drag
    void OnMouseDown()
    {
        drag = true;
        mousePrevPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.08f);
    }

    void OnMouseDrag()
    {
        rb.gravityScale = 5.0f;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.08f);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;

        force = mousePosition - mousePrevPos;
        mousePrevPos = mousePosition;
        
    }

    public void OnMouseUp()
    {
        //Makes sure there isn't a ludicrous speed
        if (rb.velocity.magnitude > topSpeed)
            force = rb.velocity.normalized * topSpeed;
    }
   
    public void FixedUpdate()
    {
        rb.velocity = force;
    }
    #endregion

    /// <summary>
    /// Initializes the trash object
    /// </summary>
    /// <param name="value"></param> Value of the object
    /// <param name="chanceDiamond"></param>  Chance of the object rewarding a diamond
    /// <param name="id"></param> The object id
    /// <param name="trashType"></param> The type of trash; Paper, Plastic etc
    /// <param name="sprite"></param> The sprite used for the sprite renderer
    /// <param name="waypoints"></param> The transforms the object will move to
    public void Init(float value, float chanceDiamond, int itemId, 
        int trashType, Sprite sprite, Transform[] waypoints)
    {
        this.valueCash = value;
        this.chanceOfDiamond = chanceDiamond;
        this.id = itemId;
        this.trashType = trashType;
        this.waypoints = waypoints;

        //Sprite renderer
        renderer = gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        renderer.sortingOrder = 1;

        //Collider2D
        col = gameObject.AddComponent<BoxCollider2D>();
        col.isTrigger = true;

        //Rigidbody2D
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.mass = 5.0f;

        //After all components have been added, scale it down
        //and set it's layer
        transform.localScale -= new Vector3(0.5f, 0.5f, 0);
        gameObject.layer = 9;

        drag = false;
        Debug.Log("Initialised"+itemId);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        //Check tag of collider
        //Ignore if collision is with other trash
        if (collider.gameObject.layer == 9)
            return;
        //The bins name is an int to make it easier to
        //check if they're the same type
        else if (collider.name.Equals(trashType.ToString()))
        {
            Debug.Log("Successful bin");
            UpdateCash(valueCash);
            UpdateDiamonds(chanceOfDiamond);
            gameObject.SetActive(false);            
        }
        else if(collider.tag == "Killzone")
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Wrong bin");
            UpdateCash(-valueCash);
            gameObject.SetActive(false);            
        }
    }

    /// <summary>
    /// Check if the chance is successful
    /// If so then give the player a diamond
    /// </summary>
    /// <param name="chance"></param> Percentage chance of getting a diamond
    void UpdateDiamonds(float chance)
    {
        if (Random.value > (1 - chance))
        {
            if (PlayerPrefs.HasKey("Diamonds"))
            {
                int diamonds = PlayerPrefs.GetInt("Diamonds");
                diamonds++;
                TextMeshProUGUI diamondText = GameObject.Find("Diamond Text").GetComponent<TextMeshProUGUI>();
                diamondText.text = "DIAMONDS: " + diamonds.ToString();
                PlayerPrefs.SetInt("Diamonds", diamonds);
            }
            else
            {   
                PlayerPrefs.SetInt("Diamonds", 1);
                TextMeshProUGUI diamondText = GameObject.Find("Diamond Text").GetComponent<TextMeshProUGUI>();
                diamondText.text = "DIAMONDS: 1";
            }
        }
        
    }

    /// <summary>
    /// Updates the players cash when they put trash into a bin
    /// </summary>
    /// <param name="amount"></param> The amount to change the players cash by
    void UpdateCash(float amount)
    {
        if (PlayerPrefs.HasKey("Cash"))
        {
            float cash = PlayerPrefs.GetFloat("Cash");
            cash += amount;
            TextMeshProUGUI cashText = GameObject.Find("Cash Text").GetComponent<TextMeshProUGUI>();
            cashText.text = "CASH: $" + cash.ToString();
            PlayerPrefs.SetFloat("Cash", cash);
        }
        else
        {
            PlayerPrefs.SetFloat("Cash", amount);
            TextMeshProUGUI cashText = GameObject.Find("Cash Text").GetComponent<TextMeshProUGUI>();
            cashText.text = "CASH: $" + amount.ToString();

        }
    }
}
