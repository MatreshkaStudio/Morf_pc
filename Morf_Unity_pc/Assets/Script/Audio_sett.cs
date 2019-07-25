using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.IO;

public class Audio_sett : MonoBehaviour
{


    
    private AudioSource audioSource;
    private string path;
    public int audio_n = 1;
    WWW www;


    void Start()
    {
        audioSource = GameObject.Find("Canvas").GetComponent<AudioSource>();

        switch (audio_n)
        {
            case 1:
                {
                    path = Path.Combine(Application.streamingAssetsPath, "Audio_1.ogg");
                    break;
                }
            case 2:
                {
                    path = Path.Combine(Application.streamingAssetsPath, "Audio_2.ogg");
                    break;
                }
        }

        www = new WWW(path);

    }
    public void Play_audio ()
    {
      audioSource.clip = www.GetAudioClip(false, true, AudioType.OGGVORBIS);
      audioSource.Play();

    }

    public void Stop_audio ()
    {
        audioSource.Stop();
    }


    private void Update()
    {
      
    }





}
