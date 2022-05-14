using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NPC : MonoBehaviour
{

    public GameObject TextBox;
    public GameObject TextBox2;
    public GameObject bgBox;

    private Collider2D getCollider;


    private void Awake()
    {
        TextBox.SetActive(false);
        bgBox.SetActive(false);
    }

    private void Start()
    {
        getCollider = GetComponent<Collider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            TextBox.SetActive(true);
            bgBox.SetActive(true);
        }
        else
        {
            return;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TextBox.SetActive(false);
    }
}
