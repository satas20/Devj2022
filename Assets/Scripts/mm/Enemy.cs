using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject target;
    private bool detected;
    private float distance;
    private Vector2 targetpos;
    private float timeBetweenShots;
    private Rigidbody2D rb;
    private Vector2 chargeDir;
    private Vector2 chargePos;


    public int type;
    public float bulletSpeed;
    public float coolDown;
    public GameObject bulletPrefab;
    public float atackDistance;
    public float moveSpeed;

    public float chargespeed;
    public float chargelenght;
    private bool isCharging;
    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShots = 0;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        timeBetweenShots += Time.deltaTime;
        if (detected) 
        {
            EnemyLogic();
        }
        else{
            idle();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) 
        {
            
            target = collision.gameObject;
            targetpos = target.GetComponent<Transform>().position;
            detected = true;
            chargeDir = new Vector2(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y).normalized;
            chargePos = targetpos+(chargeDir*chargelenght);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            detected = false;
           
        }
    }
    private void EnemyLogic() 
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
     
        if (distance > atackDistance)
        {
            move();
        }
        else if (distance <= atackDistance && timeBetweenShots > coolDown)
        {
            if (type == 1 )
            {
                if (isCharging) 
                {
                    charging();
                }
                
            }
            else if (type == 2) { shoot(); }
            else if (type == 3) { jump(); }
        }
    }
    private void idle()
    {
        
    }
    private void charging() 
    {
        transform.position = Vector2.MoveTowards(transform.position, chargePos, chargespeed * Time.deltaTime);
        if (transform.position.Equals(chargePos)) {
            isCharging = false;
        }

    }
    private void move() 
    {
        
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }
    
    private void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        timeBetweenShots = 0;
        Vector2 direction = new Vector2(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y).normalized; 
        bullet.GetComponent<Rigidbody2D>().AddForce(-direction*bulletSpeed,ForceMode2D.Impulse);
        
    }
    
    private void jump() 
    {
    
    }
   
}
