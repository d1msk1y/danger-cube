using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatorCubeMainMenu : MonoBehaviour
{
    public float speed, highScore;
    public Text highScoreText;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            highScore = PlayerPrefs.GetFloat("SaveScore");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = highScore.ToString("HIGH SCORE: 0");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime );
    }
}
