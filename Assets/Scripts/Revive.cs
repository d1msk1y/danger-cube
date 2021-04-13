using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Revive : MonoBehaviour
{

    //public Vector2 pos;
    public GameObject player,cubeSpawner;
    public Transform spawnPos;
    public ParticleSystem reviveExplosion;
    public Text score;
    public player playerC;

    private void Start()
    {
        //pos = spawnPos.position;
    }
    public void RevivePlayer()
    {
        //StartCoroutine(Stop());
        //        GameObject[] enemies = GameObject.FindGameObjectsWithTag("cube");
        //Instantiate(player, spawnPos.position, Quaternion.identity);
        player.SetActive(true);
        score.gameObject.SetActive(true);
        player.transform.position = new Vector2(player.transform.position.x, 3);
        cubeSpawner.SetActive(true);

        var objs = GameObject.FindGameObjectsWithTag("cube"); // возвращает МАССИВ!
        for (int i = 0; i < objs.Length; i++)
            Destroy(objs[i]);
        Instantiate(reviveExplosion, transform.position, Quaternion.identity);
        if (playerC.score >= 35)
        {
            playerC.speed = 20f;
        }
    }
    public IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0;
    }
}
