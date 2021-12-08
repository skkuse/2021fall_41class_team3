
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Video.Components.AVPro;
using VRC.SDKBase;
using VRC.Udon;

public class VideoStreaming : UdonSharpBehaviour
{
    [SerializeField]
    private GameObject[] miniScreenSystems;

    [SerializeField]
    private GameObject mainSpeaker;
    private AudioSource[] mainAudioSources;

    [SerializeField]
    private VRCAVProVideoPlayer targetVideoPlayer;

    [SerializeField]
    private GameObject videoControlCV;

    private Slider mainVolumeSlider;

    [UdonSynced]
    private float volume = 0.5f;

    [UdonSynced]
    private bool playVideo = true;

    private void Start()
    {
        mainVolumeSlider = videoControlCV.GetComponentInChildren<Slider>();
    }

    public void ToggleMute()
    {
        foreach (var mini in miniScreenSystems)
        {
            AudioSource miniAudioSource = mini.GetComponentInChildren<AudioSource>();
            Toggle muteToggle = mini.GetComponentInChildren<Toggle>();
            miniAudioSource.mute = muteToggle.isOn;
        }
    }
    public void SetVolume()
    {
        volume = mainVolumeSlider.value;
        Networking.SetOwner(Networking.LocalPlayer, this.gameObject);

        Debug.Log(volume);
        mainAudioSources = mainSpeaker.GetComponentsInChildren<AudioSource>();
        foreach (var source in mainAudioSources)
            source.volume = volume;

    }

    public override void OnDeserialization()
    {
        Debug.Log(volume);
        mainAudioSources = mainSpeaker.GetComponentsInChildren<AudioSource>();
        foreach (var source in mainAudioSources)
            source.volume = volume;

        if (playVideo && !targetVideoPlayer.IsPlaying) targetVideoPlayer.Play();
        else if (!playVideo && targetVideoPlayer.IsPlaying) targetVideoPlayer.Pause();

        Debug.Log("PlayOrStop");
        Debug.Log(targetVideoPlayer.IsPlaying);
    }

    public void PlayOrStop()
    {
        playVideo = !targetVideoPlayer.IsPlaying;
        Networking.SetOwner(Networking.LocalPlayer, this.gameObject);

        if (playVideo) targetVideoPlayer.Play();
        else targetVideoPlayer.Pause();

        Debug.Log("PlayOrStop");
        Debug.Log(targetVideoPlayer.IsPlaying);
    }

}

