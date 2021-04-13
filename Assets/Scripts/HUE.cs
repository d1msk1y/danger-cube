using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HUE : MonoBehaviour
{
    public PostProcessVolume postproc;
    private ColorGrading Shift;
    private MeinMenu meinMenu;
    public float states, skinStates;
    [SerializeField]
    private SpriteRenderer player;
    [SerializeField]
    private Sprite[] skins;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Hue"))
        {
            states = PlayerPrefs.GetFloat("Hue");
        }

        if (PlayerPrefs.HasKey("SkinState"))
        {
            skinStates = PlayerPrefs.GetFloat("SkinState");
        }

        //player = GetComponent<SpriteRenderer>();


        if (skinStates == 7)
        {
            player.sprite = skins[0];
        }
        else if (skinStates == 8)
        {
            player.sprite = skins[1];
        }
        else if (skinStates == 9)
        {
            player.sprite = skins[2];
        }
        else if (skinStates == 10)
        {
            player.sprite = skins[3];
        }
        else if (skinStates == 11)
        {
            player.sprite = skins[4];
        }
        else if (skinStates == 12)
        {
            player.sprite = skins[5];
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        postproc = GetComponent<PostProcessVolume>();
        postproc.profile.TryGetSettings(out Shift);
        if (states == 1)
        {
            Shift.hueShift.value = 0;
        }
        else if (states == 2)
        {
            Shift.hueShift.value = 35;
        }
        else if (states == 3)
        {
            Shift.hueShift.value = 120;
        }
        else if (states == 4)
        {
            Shift.hueShift.value = 180;
        }
        else if (states == 5)
        {
            Shift.hueShift.value = -50;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (states == 6)
        {
            Gradient();
        }
    }

    public void Gradient()
    {
        Shift.hueShift.value += 10 * Time.deltaTime;
    }
}