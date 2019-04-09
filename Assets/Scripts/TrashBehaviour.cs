using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBehaviour : MonoBehaviour
{

    
    public float speed;
    private int current = 0;

    public Sprite trashSprite;
    public Transform[] target;
    //private Trash t;
    private GameObject trash;

    void Start()
    {
        GameObject trash = new Trash(trashSprite, 3.0f, 0.1f, 1, 0).GetObject();
        //trash = t.GetObject();
    }

    void Update()
    {
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
            current = (current + 1) % target.Length;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    void OnTriggerEnter(Collider col)
    {
        //trash.OnTriggerEnter(col);
    }
}
