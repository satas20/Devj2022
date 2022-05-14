using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private int random;
    private float skillcounter;
    private bool onTrigger;

    private bool isCharging;

    public float skillcd;
    // Start is called before the first frame update
    void Start()
    {
        skillcounter = 0;
    }

    // Update is called once per frame
    void Update()
    {

        skillcounter -= Time.deltaTime;

        if (skillcounter < 0 && onTrigger)
        {
            random = Random.Range(0,3);
            if (random == 0) {
                
            }
            else if (random == 1){
            }
            else if (random == 2){
            
            }
        }
    }



    private void charge()
    {
        if (isCharging)
        {
            transform.position = Vector2.MoveTowards(transform.position, chargepos, chargeSpeed * Time.deltaTime);

        }
        if (transform.position.Equals(chargepos)) { isCharging = false; }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            onTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            onTrigger = false;      
        }
    }
}
