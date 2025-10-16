using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Events;

public class SanityManager : MonoBehaviour
{
    //public PostProcessProfile profile;
    //Vignette vignette;
    Slider sanitySlider; 
    public int fullSanity;
    public int difficulty;
    float percent;
    private AudioClip lowSanityClip;

    public UnityEvent onInsane;
    
    void Start()
    {
        //profile.TryGetSettings(out vignette);
        sanitySlider = GetComponent<Slider>();
        sanitySlider.maxValue = fullSanity;
        sanitySlider.value = fullSanity;
        //vignette.Intensity.value = 0;

        StartCoroutine(LoseSanity());
    }

    void Update()
    {
        /*
        if(sanitySlider.value => 25f)
        {
            SoundFXManager.instance.PlaySoundFXClip(lowSanityClip, transform, 1f);

        }
        */

    }

   

       IEnumerator LoseSanity()
        {
            while(sanitySlider.value > 0)
            {

                sanitySlider.value -= 0.001f * difficulty;
                float newValue = (sanitySlider.value - sanitySlider.maxValue) * -1;
                percent = newValue / sanitySlider.maxValue;
                //vignette.intensity.value = percent;

                yield return null;
            }
            onInsane.Invoke();
        }

    public void AffectSanity(float value)
    {

        sanitySlider.value += value;

    }


}
