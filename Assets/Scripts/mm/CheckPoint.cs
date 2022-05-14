using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private levelManager lm;
    // Start is called before the first frame update
    void Start()
    {
        lm = GameObject.FindGameObjectWithTag("lm").GetComponent<levelManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) 
        {
            lm.lastCheckPointPos = gameObject.transform.position;
            Debug.Log("player detected");
        }
    }
}
