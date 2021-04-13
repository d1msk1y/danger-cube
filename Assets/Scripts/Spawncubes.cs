using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawncubes : MonoBehaviour
{
    [SerializeField]
    public GameObject cubes, coins;
    float randomX;
    Vector2 whereToSpawn;
    [SerializeField]
    private float spawnRate = 2f;
    float nextSpawn = 0.0f;
    public Transform[] positions;
    private int random;


    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randomX = Random.Range(transform.position.y , 6);
            whereToSpawn = new Vector2(randomX, transform.position.y);//где спавнится
            random = Random.Range(0, positions.Length);//берет рандомную позицию
            Instantiate(cubes, positions[random].position, Quaternion.identity);//Спавн кубов
        }

    }
}
