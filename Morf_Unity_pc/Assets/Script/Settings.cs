using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.IO;
using UnityEditor;

public class Settings : MonoBehaviour
{
    public AudioClip audioClip_1;
    public GameObject play , setting , video_2_obj ;
    public Video_script video_Script , video_Script_2;
    private bool start;
    private string videoClip_1_path;
    private string videoClip_2_path;
    private string audioClip_1_path;
    public string font_path;


    void Start()
    {
        font_path = Path.Combine(Application.streamingAssetsPath, "Text.ttf");
        videoClip_1_path = Path.Combine(Application.streamingAssetsPath, "Video_1.mp4");
        videoClip_2_path = Path.Combine(Application.streamingAssetsPath, "Video_2.webm");
        audioClip_1_path = Path.Combine(Application.streamingAssetsPath, "Audio_1.ogg");


        WWW www_1 = new WWW(audioClip_1_path);
        audioClip_1 = www_1.GetAudioClip(false, true, AudioType.OGGVORBIS);




       

        Video_1();
        Video_2();
        Audio_1();

     

    }

 
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Stop_v();
        }
    }

    public void Stop_v()
    {
        play.SetActive(false);
        setting.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Video_1 ()
    {
        video_Script.videoToPlay_s = videoClip_1_path;
    }

    public void Video_2()
    {
        video_Script_2.videoToPlay_s = videoClip_2_path;
    }

    public void Audio_1()
    {
        video_Script.clipToPlay = audioClip_1;
    }


    public void Start_V ()
    {
   
        play.SetActive(true);
  
        setting.SetActive(false);

        if (start == true)
        {
            video_Script.StartCoroutine(video_Script.playVideo());
            if (video_2_obj.activeSelf == true)
            {
                video_Script_2.StartCoroutine(video_Script_2.playVideo());
            }
     
            video_Script.Video_Play();
            //video_Script_2.Video_Play();
        }

     
        start = true;
    }


}
