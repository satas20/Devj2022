using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public Vector2 lastCheckPointPos;
    private GameObject player ;
    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()  
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            player.transform.position = lastCheckPointPos;
        }
    }
}
