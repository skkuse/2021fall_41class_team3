
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class selectMusic : UdonSharpBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;


    public override void Interact()
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
