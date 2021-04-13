using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{

    public GameObject cam, lvl;
    public Transform spawn;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Parallax")
        {
            Instantiate(lvl, spawn.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Couratine()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(lvl);
    }
}
