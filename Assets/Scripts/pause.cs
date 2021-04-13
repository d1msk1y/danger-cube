using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class pause : MonoBehaviour
{

    public PostProcessVolume postproc;
    public ColorGrading Shift;

    private void Start()
    {
        postproc = GetComponent<PostProcessVolume>();
        postproc.profile.TryGetSettings(out Shift);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        //Shift.saturation.value = -20;
    }

    public void Continue()
    {
        Time.timeScale = 1;
        Shift.saturation.value = 15;
    }
}
