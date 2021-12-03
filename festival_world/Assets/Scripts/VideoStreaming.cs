
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Video.Components.AVPro;
using VRC.SDKBase;
using VRC.Udon;

public class VideoStreaming : UdonSharpBehaviour
{
    [SerializeField]
    private AudioSource miniAudioSource;

    [SerializeField]
    private AudioSource[] mainAudioSource;

    [SerializeField]
    private VRCAVProVideoPlayer targetVideoPlayer;

    [SerializeField]
    private GameObject videoControlCV;

    private Slider mainVolumeSlider;

    private void Start()
    {
        mainVolumeSlider = videoControlCV.GetComponentInChildren<Slider>();
    }

    public void ToggleMute()
    {
        miniAudioSource.mute = !miniAudioSource.mute;
    }
    public void SetVolume()
    {
        foreach(var source in mainAudioSource)
            source.volume = mainVolumeSlider.value;
        Debug.Log(mainVolumeSlider.value);
    }

    public void PlayOrStop()
    {
        if (!targetVideoPlayer.IsPlaying) targetVideoPlayer.Play();      
        else targetVideoPlayer.Pause();

        Debug.Log("PlayOrStop");
        Debug.Log(targetVideoPlayer.IsPlaying);
    }
}
