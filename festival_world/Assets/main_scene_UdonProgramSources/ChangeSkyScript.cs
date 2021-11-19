
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
        public Material daysky;
        public Material nightsky;
        public GameObject skymode;
        private bool skymodeActive;

        public GameObject day_particle;
        public GameObject night_particle;
        public ParticleSystem firework;
        public ParticleSystem firework2;

      
        public override void Interact()
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
            }
            else
            {
                RenderSettings.skybox = daysky;
                skymode.SetActive(true);
                night_particle.SetActive(false);
                firework.Stop();
                firework2.Stop();
                day_particle.SetActive(true);
            }

        }

    }

}
