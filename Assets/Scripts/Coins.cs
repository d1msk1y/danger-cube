using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public float coinsCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //coinsCount += 1;
            Destroy(gameObject);
        }
        if(collision.tag == "destroyer")
        {
            Destroy(gameObject);
        }
    }

}
