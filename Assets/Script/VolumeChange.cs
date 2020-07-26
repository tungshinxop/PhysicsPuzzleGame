using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

//Date modified: 21/11/2019
//Purpose: change value of slider
//use the value of the slider to change volume by exposed parameters 
//of the audio mixer called 'volume'
//This script is held in OptionMenu in hierarchy

public class VolumeChange : MonoBehaviour
{
    //Create a Slider variable to hold the slider object.
    public Slider slider;
    private SoundSettings ss;
    public AudioMixer audioMixer;


    private void Start()
    {
        ss = GameObject.Find("SoundManager").GetComponent<SoundSettings>();
    }

    //Create a function
    //that active when a slider being used 
    public void SetVolume(float volume)
    {
        volume = slider.value;
        //Printing the value of the slider by using slider.value
        //Debug.Log(slider.value);
        audioMixer.SetFloat("volume", volume);
        ss.SetVolume(volume);
    }
}
