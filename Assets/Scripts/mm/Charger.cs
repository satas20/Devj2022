using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{

    public float moveSpeed;
    public float chargeSpeed;
    public float chargeLenght;

    public float cooldown;
    private float chargeCounter;

    private float distance;
    private GameObject target;
    private bool isCharging;

    private bool inRange;
    private Vector2 chargedir;
    private Vector2 chargepos;
    private void Start()
    {
        isCharging = false;
        chargeCounter = 0;

    }
    private void Update()
    {
        chargeCounter -= Time.deltaTime;
        //distance = Vector2.Distance(transform.position, target.transform.position);
    }
    private void FixedUpdate()
    {


        if (inRange&&chargeCounter<0) 
        {
            if (!isCharging){
                chargedir = new Vector2(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y).normalized;
                chargepos = new Vector2(target.transform.position.x + (chargeLenght * chargedir.x), target.transform.position.y + (chargeLenght * chargedir.y));
                isCharging = true;
                chargeCounter = cooldown;
            }
        }
        charge();
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
        if (collision.gameObject.CompareTag("player"))
        {
            target = collision.gameObject;
          //  isCharging = true;
            inRange = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            inRange = false;
        }
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCharging = false;
    }




}
