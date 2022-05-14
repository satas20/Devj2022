using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class ui : MonoBehaviour
{
    private float dashcooldown;
    public static float gametimer;
    private float hitcd;
    public TMP_Text dashtext;
    public TMP_Text hittext;
    public TMP_Text timertext;
    private void Awake()
    {
        gametimer = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gametimer += Time.deltaTime;
        dashcooldown -= Time.deltaTime;
        hitcd -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Z)){
            hitcd = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            dashcooldown = 5;
        }
        
        if (dashcooldown > 0) 
        {
            dashtext.text = dashcooldown.ToString("F1");

        }
        if (hitcd > 0)
        {
            hittext.text = hitcd.ToString("F1");
        }
        timertext.text = (int)gametimer / 60 + ":"+((int)gametimer%60).ToString();

    }
}
