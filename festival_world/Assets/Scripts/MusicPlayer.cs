using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] day_clips;
    public AudioClip[] night_clips;
    private AudioSource audioSource;
    public GameObject skymode;
    private bool skymodeActive;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;
    }

    private AudioClip day_GetRandomClip() {
        return day_clips[Random.Range(0, day_clips.Length)];
    }

    private AudioClip night_GetRandomClip()
    {
        return night_clips[Random.Range(0, night_clips.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        skymodeActive = skymode.activeSelf;
        if (skymodeActive == true)
        {
            if (!audioSource.isPlaying)
            {
                Debug.Log("Audio Stopped change to random day music");
                audioSource.clip = day_GetRandomClip();
                audioSource.Play();
            }
        }
        else {
            if (!audioSource.isPlaying)
            {
                Debug.Log("Audio Stopped change to random night music");
                audioSource.clip = night_GetRandomClip();
                audioSource.Play();
            }
        }
        
    }

    public void btnUpdate() {
        skymodeActive = skymode.activeSelf;
        if (skymodeActive == true)
        {
                audioSource.clip = night_GetRandomClip();
                audioSource.Play();
        }
        else
        {
                audioSource.clip = day_GetRandomClip();
                audioSource.Play();
        }

    }
}
