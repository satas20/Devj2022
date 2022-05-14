using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float moveSpeed;
    public GameObject area;

    public float cooldown;
    public float areacooldown;
    private float jumpCounter;
    private float areacounter;

    private float distance;
    private GameObject target;
    private bool isJumping;

    private bool inRange;
    private GameObject areas;
    private void Start()
    {
        isJumping = false;
        jumpCounter = 0;
        areacounter = 0;
    }
    private void Update()
    {
        jumpCounter -= Time.deltaTime;

        if (inRange&&jumpCounter<0){
            isJumping = true;
            areas =Instantiate(area, target.transform.position,Quaternion.identity);
            areacounter = areacooldown;
            jumpCounter = cooldown;
        }
        if (isJumping == true) 
        {
            areacounter -= Time.deltaTime;
        }

        if (areacounter<=0&&isJumping)
        {
           
            jump();
            Destroy(areas);
            isJumping = false;
        }
    }
    private void FixedUpdate()
    {


       
    }
    private void jump()
    {
        transform.position = areas.transform.position;

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
    


}
