using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;

    public static VideoManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        //videoPlayer = GetComponent<VideoPlayer>();
    }

    public void PlayVideo(VideoClip _videoClip)
    {
        videoPlayer.clip = _videoClip;
        videoPlayer.Play();
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
    }
    public void ChangeVideoVoice()
    {
        if (videoPlayer.gameObject.GetComponent<AudioSource>().volume >= 0.1f)
        {
            videoPlayer.gameObject.GetComponent<AudioSource>().volume = 0.05f;
            return;
        }
        if (videoPlayer.gameObject.GetComponent<AudioSource>().volume < 0.1f)
        {
            videoPlayer.gameObject.GetComponent<AudioSource>().volume = 1f;
        }
    }

}
