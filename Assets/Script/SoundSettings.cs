using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{

    public float currentVolume;
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float vol)
    {
        currentVolume = vol;
        Debug.Log("ss = " + currentVolume);
    }

}
