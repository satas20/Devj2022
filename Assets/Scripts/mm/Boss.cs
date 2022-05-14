using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private int random;
    private float skillcounter;
    
    public float skillcd;
    // Start is called before the first frame update
    void Start()
    {
        skillcounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            
        }
    }
}
