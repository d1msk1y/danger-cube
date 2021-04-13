using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class diecubes : MonoBehaviour
{
    public AudioSource explosion;
    public GameObject cube, lvl;
    private player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "destroyer")
        {
            Destroy(cube);
            Destroy(lvl);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            explosion.Play();
        }
    }
}
