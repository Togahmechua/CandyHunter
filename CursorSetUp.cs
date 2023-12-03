using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSetUp : MonoBehaviour
{
    public string punchtag;
    public string handtag;
    public GameObject punch;
    public GameObject hand;
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 newMousePos = new Vector2(transform.position.x, mousePos.y);
        transform.position = newMousePos;
        ChangeCursor();
    }

    private void ChangeCursor()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.GetComponent<SpriteRenderer>().sprite = punch.GetComponent<SpriteRenderer>().sprite;
            this.gameObject.tag = punchtag;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            this.GetComponent<SpriteRenderer>().sprite = hand.GetComponent<SpriteRenderer>().sprite;
            this.gameObject.tag = handtag;
        }
    }
}
