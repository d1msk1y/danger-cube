using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradButton : MonoBehaviour
{
    public Button upgradeBerserk;
    public float bestScore, needToReach, upgradPhase;
    public Text needToReachTxt;
    public int scoreint;
    public Button button;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
            bestScore = PlayerPrefs.GetFloat("SaveScore");
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreint = (int)bestScore;
        needToReachTxt.text = string.Format("{0}/{1}", scoreint, needToReach);
        UpgradeBerserc();

        if (bestScore < needToReach)
            button.interactable = false;
        else
            button.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeBerserc()
    {
        if (bestScore > needToReach)
            upgradPhase += 1;

    }

}
