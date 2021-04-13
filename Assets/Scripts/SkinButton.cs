using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{

    public float needToReach;
    private float totalCoins,bestScore;
    public float customState, states;
    public Text needToReachTxt;
    public GameObject camera,ramka;
    public Button button;
    public int scoreInt;
    public string idState;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(idState))
            states = PlayerPrefs.GetFloat(idState);

        if (PlayerPrefs.HasKey("TotalCoins"))
            totalCoins = PlayerPrefs.GetFloat("TotalCoins");
        
        if (PlayerPrefs.HasKey("SaveScore"))
            bestScore = PlayerPrefs.GetFloat("SaveScore");
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreInt = (int)bestScore;
        needToReachTxt.text = string.Format("{0}/{1}",scoreInt , needToReach);
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
        CheckBestScore();
    }

    public void Buy()
    {
        states = customState;

        camera.gameObject.GetComponent<MeinMenu>().skinStates = customState;

        PlayerPrefs.SetFloat(idState, states);
    } 



    public void CheckState()
    {
        if (camera.gameObject.GetComponent<MeinMenu>().skinStates == customState)
        {
            button.enabled = false;
            ramka.SetActive(true);
        }
        else if (camera.gameObject.GetComponent<MeinMenu>().skinStates != customState)
        {
            button.enabled = true;
            ramka.SetActive(false);
        }
    }


    public void CheckBestScore()
    {
        if (needToReach <= bestScore)
        {
            button.interactable = true;
            needToReachTxt.gameObject.SetActive(false);
        }
        else
        {
            button.interactable = false;
        }

    }

}
