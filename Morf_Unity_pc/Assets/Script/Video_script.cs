using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Video_script : MonoBehaviour
{

    


    public AudioClip clipToPlay;

    public string videoToPlay_s;

    private RawImage image;
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;





    void Start()
    {
        Application.runInBackground = true;
        image = GetComponent<RawImage>();
        videoPlayer = GetComponent<VideoPlayer>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(playVideo());
    }

 

  public  IEnumerator playVideo()
    {
   
        if (clipToPlay != null)
        {
            audioSource.clip = clipToPlay;
        }
    
        videoPlayer.url = videoToPlay_s;
        videoPlayer.Prepare();
        Debug.Log("+");
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        image.texture = videoPlayer.texture;

      
            videoPlayer.Play();
            if (clipToPlay != null)
            {
                audioSource.Play();
            }
           
        
    

  
    }

    public void Video_Play ()
    {
        videoPlayer.playbackSpeed = 1;
        if (clipToPlay != null)
        {
            audioSource.pitch = 1;
        }
    }

    public void Video_Stop()
    {
        videoPlayer.playbackSpeed = 0;
        if (clipToPlay != null)
        {
            audioSource.pitch = 0;
        }

    }



}