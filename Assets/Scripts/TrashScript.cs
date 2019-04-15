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

    private float speed = 0.2f;
    private int current = 0;
    public bool drag;

    public Vector3 mousePrevPos;
    public Vector3 mouseCurPos;
    public Vector3 force;
    public float topSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
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

        renderer = gameObject.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        renderer.sortingOrder = 1;

        col = gameObject.AddComponent<BoxCollider2D>();
        col.isTrigger = true;
        //col.size -= new Vector2(0.5f, 0.5f);

        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.mass = 5.0f;

        transform.localScale -= new Vector3(0.5f, 0.5f, 0);
        gameObject.layer = 9;

        drag = false;
        Debug.Log("big cock");
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("cock");
        //Check tag of collider
        if (collider.gameObject.layer == 9)
            return;
        else if (collider.name.Equals(trashType.ToString()))
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
