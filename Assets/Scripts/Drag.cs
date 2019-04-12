using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    float deltaX, deltaY;

    Rigidbody rb;

    bool moveAllowed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if(GetComponent<BoxCollider>() == Physics2D.OverlapPoint(touchPos))
                    {
                        //GetComponent<TrashScript>().drag = true;
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;

                        moveAllowed = true;


                    }
                    break;

                case TouchPhase.Moved:
                    if(GetComponent<BoxCollider>() == Physics2D.OverlapPoint(touchPos) && moveAllowed)
                    {
                        rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    }
                    break;
                case TouchPhase.Ended:
                    moveAllowed = false;
                    rb.useGravity = true;
                    break;
            }
        }
    }
    
    //if(col == Physics2D.OverlapCircle(mousePos, 0.2f))
    //    {
    //        Debug.Log("Overlap");
    //        drag = true;
    //        rb.gravityScale = 1.0f;
    //        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
    //Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //transform.position = objPosition;
    //    }

}
