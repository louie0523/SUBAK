using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public BoxCollider2D BoxCollider2D;


    private void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(GameManager.instance.isEnd)
        {
            return;
        }
        if(collision.gameObject.CompareTag("Fruit"))
        {
            Fruit fruit = collision.gameObject.GetComponent<Fruit>();
            if(fruit != null)
            {
                if(fruit.hasLanded)
                {
                    GameManager.instance.EndGame();
                    Debug.Log("∞‘¿” ≥°!");
                }
            }
        }
    }
}
