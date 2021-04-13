using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MeinMenu : MonoBehaviour
{
    public float totalShopCoins;
    public Text shopCoins,customCoins, berserkPhase, costTxt;
    public float berserk, cost;
    public float states, skinStates;
    //public string state;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Berserk"))
        {
            berserk = PlayerPrefs.GetFloat("Berserk");
        }

        if (PlayerPrefs.HasKey("TotalCoins"))
        {
            totalShopCoins = PlayerPrefs.GetFloat("TotalCoins");
        }

        if (PlayerPrefs.HasKey("CostShop"))
        {
            cost = PlayerPrefs.GetFloat("CostShop");
        }
        if (PlayerPrefs.HasKey("Hue"))
        {
            states = PlayerPrefs.GetFloat("Hue");
        }
       if (PlayerPrefs.HasKey("SkinState"))
       {
            skinStates = PlayerPrefs.GetFloat("SkinState");
       }

    }
    // Start is called before the first frame update
    void Start()
    {
        if (berserk > 2)
            costTxt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Resetberserc();
        }

       // if (berserk > 2 || totalShopCoins < cost)
        //{
        //    upgradeBerserk.interactable = false;
       // }
        //berserkPhase.text = berserk.ToString("BERSERK 0/3");
    }

    public void loadLVL()
    {
        StartCoroutine(loadVlv());
    }

    public void loadmenu() 
    {
        StartCoroutine(loadMain()); 
    }

    public void Resetberserc()
    {
        PlayerPrefs.DeleteKey("Berserk");
        PlayerPrefs.DeleteKey("CostShop");
        PlayerPrefs.DeleteKey("Cost");
        PlayerPrefs.DeleteKey("Hue");
        PlayerPrefs.DeleteKey("SkinState");
    }

    IEnumerator loadVlv()
    {
        yield return new WaitForSeconds(0.5f);      
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator loadMain()
    {
        yield return new WaitForSeconds(0.5f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
