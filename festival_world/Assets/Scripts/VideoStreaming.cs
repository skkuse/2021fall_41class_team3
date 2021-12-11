
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
    private AudioSource mainAudioSource;

    [SerializeField]
    private VRCAVProVideoPlayer targetVideoPlayer;

    [SerializeField]
    private GameObject videoControlCV;

    private Slider mainVolumeSlider;
    private Toggle loopToggle;

    private void Start()
    {
        mainVolumeSlider = GetComponentInChildren<Slider>();
        loopToggle = GetComponentInChildren<Toggle>();
    }

    public void ToggleMute()
    {
        miniAudioSource.mute = !miniAudioSource.mute;
    }
    public void SetVolume()
    {
        mainAudioSource.volume = mainVolumeSlider.value;
        Debug.Log(mainAudioSource.volume);
    }

    public void PlayOrStop()
    {
        if (!targetVideoPlayer.IsPlaying) targetVideoPlayer.Play();      
        else targetVideoPlayer.Pause();

        Debug.Log(targetVideoPlayer.IsPlaying);
    }
    public void TurnOffVideoControlCV()
    {
        videoControlCV.SetActive(false);
    }
}
