using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.IO;


public class Setting : MonoBehaviour
{
    public InputField inp, pin_inp, count_inp, question_inp , question_inp_2;
    public Text question, question_2;
    public GameObject panel_sett , panel_pin , panel_end;
    private PhotonView photonView;
    public RawImage rawImage , rawImage_2;

 
    public void End()
    {
        panel_end.SetActive(true);
    }
    public void Off_end()
    {
        panel_end.SetActive(false);
    }

    public void PickImage()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                rawImage.texture = NativeGallery.LoadImageAtPath(path);
            }
        }, "Select a PNG image", "image/png");
    }

    public void PickImage_2()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                rawImage_2.texture = NativeGallery.LoadImageAtPath(path);
            }
        }, "Select a PNG image", "image/png");
    }

    public void Sett()
    {
        panel_pin.SetActive(true);
    }


    public void Pin ()
    {
        if (pin_inp.text == "MATRESHKA")
        {
            panel_sett.SetActive(true);
            panel_pin.SetActive(false);
        }
        else
        {
            panel_pin.SetActive(false);
        }
        
    }

    public void Off_pin()
    {
        panel_pin.SetActive(false);
    }

    public void Off_set()
    {
        question.text = question_inp.text;
        question_2.text = question_inp_2.text;
        inp.characterLimit = int.Parse(count_inp.text);
        panel_sett.SetActive(false);
    }


    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
    }

    public void Enter ()
    {
        if (inp.text.Length > 1)
        {
                Click();
                End();
                Debug.Log("Enter");   
        }
        
    }

    public void Click()
    {
            photonView.RPC("Resp", RpcTarget.MasterClient, inp.text);
        Invoke("Off_end", 3);
    }

    [PunRPC]
    public void Resp (string f_text)
    {
    }

 

}
