
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using System.Collections;
using System.Collections.Generic;

namespace changesky
{
    public class ChangeSkyScript : UdonSharpBehaviour
    {
        public AudioClip[] day_clips;
        public AudioClip[] night_clips;
        public AudioSource audioSource;

        public Material daysky;
        public Material nightsky;
        public GameObject skymode;
        private bool skymodeActive;

        public GameObject day_particle;
        public GameObject night_particle;
        public ParticleSystem firework;
        public ParticleSystem firework2;

        private bool _isActive;
        private float _timerCount;
        public float timer = 5;


        private AudioClip day_GetRandomClip()
        {
            return day_clips[Random.Range(0, day_clips.Length)];
        }

        private AudioClip night_GetRandomClip()
        {
            return night_clips[Random.Range(0, night_clips.Length)];
        }

        private void Update()
        {
            if (_isActive) {
                if (_timerCount >= timer)
                {
                    skymodeActive = skymode.activeSelf;
                    if (skymodeActive == true)
                    {
                        RenderSettings.skybox = nightsky;
                        skymode.SetActive(false);
                        day_particle.SetActive(false);
                        night_particle.SetActive(true);
                        firework.Play();
                        firework2.Play();
                        audioSource.clip = night_GetRandomClip();
                        audioSource.Play();
                    }
                    else
                    {
                        RenderSettings.skybox = daysky;
                        skymode.SetActive(true);
                        night_particle.SetActive(false);
                        firework.Stop();
                        firework2.Stop();
                        day_particle.SetActive(true);
                        audioSource.clip = day_GetRandomClip();
                        audioSource.Play();
                    }
                    _timerCount = 0;
                    _isActive = false;
                }
                else {
                    _timerCount += Time.deltaTime;
                }
            }
            skymodeActive = skymode.activeSelf;
            if (!audioSource.isPlaying) {
                if (skymodeActive == true)
                {
                    audioSource.clip = day_GetRandomClip();
                    audioSource.Play();
                }
                else {
                    audioSource.clip = night_GetRandomClip();
                    audioSource.Play();
                }
            }
        }

        public override void Interact()
        {
            _isActive = true;
            /*
            skymodeActive = skymode.activeSelf;
            if (skymodeActive == true)  
            {
                RenderSettings.skybox = nightsky;
                skymode.SetActive(false);
                day_particle.SetActive(false);
                night_particle.SetActive(true);
                firework.Play();
                firework2.Play();
                audioSource.clip = night_GetRandomClip();
                audioSource.Play();
            }
            else
            {
                RenderSettings.skybox = daysky;
                skymode.SetActive(true);
                night_particle.SetActive(false);
                firework.Stop();
                firework2.Stop();
                day_particle.SetActive(true);
                audioSource.clip = day_GetRandomClip();
                audioSource.Play();
            }
            */

        }

    }

 

}
