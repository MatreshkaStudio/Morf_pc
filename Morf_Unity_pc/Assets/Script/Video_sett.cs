using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.IO;


public class Video_sett : MonoBehaviour
{




    private string videoToPlay_s;
    public int video_n = 1;
    private Sprite sprite;

    private RawImage image;
    private VideoPlayer videoPlayer;



    void Start()
    {
        switch (video_n)
        {
            case 1:
                {
                    videoToPlay_s = Path.Combine(Application.streamingAssetsPath, "Video_1.mp4");
                    break;
                }
            case 2:
                {
                    videoToPlay_s = Path.Combine(Application.streamingAssetsPath, "Video_2.webm");
                    break;
                }
        

        }


        sprite = Resources.Load <Sprite> ("video_icon");
        Application.runInBackground = true;
        image = GetComponent<RawImage>();
        videoPlayer = GetComponent<VideoPlayer>();



    }

    public void Play_video ()
    {
        if ( videoPlayer.isPlaying)
        {
            StopCoroutine(playVideo());
            videoPlayer.Stop();
            image.texture = sprite.texture;
            gameObject.transform.localScale = new Vector2(1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector2(3, 3);
            StartCoroutine(playVideo());
            videoPlayer.Play();
        }
   
    }

   

    public IEnumerator playVideo()
    {
        videoPlayer.url = videoToPlay_s;
        videoPlayer.Prepare();
        Debug.Log("+");
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        image.texture = videoPlayer.texture;

  

    }
}
