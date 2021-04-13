using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMOvement : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;
    public float vishe = 0.1f;
    public GameObject play;
    public float smoothing;
    public AudioSource explosion;
    public player cube;


    private void Update()
    {
        pos = player.position;
        pos.z = -10f;
        //pos.y = 0.5f;

        transform.position = Vector3.Lerp(transform.position, pos, smoothing * Time.deltaTime);
    }


}
