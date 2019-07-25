using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine.UI;
using System.IO;

public class Resp_text : MonoBehaviour
{
    public InputField field , input_size, input_color_1, input_color_2, input_color_3 ,limit_input;
    public GameObject video , video_main;
    public Toggle move_tog, move_circl_tog , video_tog;
    private New_text new_Text;
    private GameObject new_t , new_text_list;
    private Font font_1, font_2, font_3, font_4, font_5;
    public int text_count , text_count_2;
    private Vector vector;
    private PhotonView photonView;
    private bool resp;
    public bool move , target ;
    public Dropdown speed , font;
    public Video_script video_Script;
    public int text_limit = 30;
    private float time_resp;
    private string mat , path;
    private List<String> list_mat = new List<String>();
    private string[] mat_mass = new string[1000];

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        font_1 = Resources.Load<Font>("Font_1");
        font_2 = Resources.Load<Font>("Font_2");
        font_3 = Resources.Load<Font>("Font_3");
        font_4 = Resources.Load<Font>("Font_4");
        font_5 = Resources.Load<Font>("Font_5");
        new_t = Resources.Load<GameObject>("New_text");
        new_Text = new_t.GetComponent<New_text>();
        vector = GameObject.Find("Canvas").GetComponent<Vector>();
        new_text_list = GameObject.Find("New_text_list");

        path = Path.Combine(Application.streamingAssetsPath, "Mat.txt");
        WWW www = new WWW(path);
        mat = www.text;
        

       mat_mass = mat.Split(new [] { ',' , ' ' }, StringSplitOptions.RemoveEmptyEntries);
      
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Del();
        }

        move = move_tog.isOn;
        target = move_circl_tog.isOn;

        if (Input.GetKey(KeyCode.Space))
        {
            Resp("Тест");
        }

        float add = 0;
        float add_s = 0;

        if (speed.value == 0)
        {
            add_s = 5;
        }
        if (speed.value == 1)
        {
            add_s = 10;
        }
        if (speed.value == 2)
        {
            add_s = 15;
        }

       
        if (new_Text.text_t.fontSize < 50)
        {
            add = 1;
        }
        if (new_Text.text_t.fontSize > 49 && new_Text.text_t.fontSize < 100)
        {
            add = 2;
        }
        if (new_Text.text_t.fontSize > 99 && new_Text.text_t.fontSize < 150)
        {
            add = 3;
        }
        if (new_Text.text_t.fontSize > 149 && new_Text.text_t.fontSize < 200)
        {
            add = 4;
        }
        if (new_Text.text_t.fontSize > 199 && new_Text.text_t.fontSize < 250)
        {
            add = 5;
        }
        if (new_Text.text_t.fontSize > 249 && new_Text.text_t.fontSize < 300)
        {
            add = 6;
        }
        if (new_Text.text_t.fontSize > 299)
        {
            add = 7f;
        }

        time_resp = add / add_s;
    }


    public void Video_on ()
    {
        video.SetActive(true);
        if (video_main.activeSelf == true)
        {
            video_Script.StartCoroutine(video_Script.playVideo());
        }
      
    }

    public void Video_off()
    {
        video.SetActive(false);
    }

    public void Ok ()
    {
        int color_1 = int.Parse(input_color_1.text);
        int color_2 = int.Parse(input_color_2.text);
        int color_3 = int.Parse(input_color_3.text);
        new_Text.text_t.color = new Color(color_1, color_2, color_3, 255);
        new_Text.text_t.fontSize = int.Parse(input_size.text);
         text_limit = int.Parse(limit_input.text);
        if (font.value == 0)
        {
            new_Text.text_t.font = font_1;
        }
        if (font.value == 1)
        {
            new_Text.text_t.font = font_2;
        }
        if (font.value == 2)
        {
            new_Text.text_t.font = font_3;
        }
        if (font.value == 3)
        {
            new_Text.text_t.font = font_4;
        }
        if (font.value == 4)
        {
            new_Text.text_t.font = font_5;
        }

        if (video_tog.isOn == true)
        {
            Video_on();
        }
        else
        {
            Video_off();
        }

    }
  

   


  
    public void Del()
    {
        text_count = 0;
        text_count_2 = 0;
    }




    [PunRPC]
    public void Resp(string f_text)
    {
        bool mat_b = false;

        string test = f_text.ToLower();

        Debug.Log(test);
        for (int w = 0; w < mat_mass.Length; w++)
        {
            if (test == mat_mass[w])
            {
                mat_b = true;
                break;
            }

        }

        if (mat_b == false)
        {
            if (target == true)
            {
                if (move == true)
                {
                    if (text_count + f_text.Length <= vector.list.Count && resp == false)
                    {
                        StartCoroutine("Respawn", f_text);
                        if (video.activeSelf == true)
                        {
                            video_Script.Video_Play();
                        }
                        resp = true;
                    }

                }
                else
                {
                    if (text_count + f_text.Length <= vector.list.Count && resp == false)
                    {
                        StartCoroutine("Respawn", f_text);
                        if (video.activeSelf == true)
                        {
                            video_Script.Video_Play();
                        }
                        resp = true;
                    }
                }
            }
            else
            {
                if (move == true)
                {
                    if (text_count + f_text.Length < text_limit && resp == false)
                    {
                        StartCoroutine("Respawn", f_text);
                        text_count_2++;
                        if (video.activeSelf == true)
                        {
                            video_Script.Video_Play();
                        }
                        resp = true;
                    }

                }
                else
                {
                    if (text_count_2 < vector.list.Count && resp == false)
                    {
                        StartCoroutine("Respawn", f_text);
                        text_count_2++;
                        if (video.activeSelf == true)
                        {
                            video_Script.Video_Play();
                        }
                        resp = true;

                    }
                }
            }



        }
    }
    


    public IEnumerator Respawn(string f_text)
    {
        int i = 0;

        while (true)
        {
            yield return new WaitForSeconds(time_resp);


    
                if (i < f_text.Length)
            {
                string a = f_text.Substring(i, 1);
                if (i == 0)
                {
                    a.ToUpper();
                }
                new_Text.text_t.text = a;
                new_Text.add = i;
                new_Text.add_2 = f_text.Length - i;

                if (speed.value == 0)
                {
                    new_Text.speed = 0.5f;
                }
                if (speed.value == 1)
                {
                    new_Text.speed = 1;
                }
                if (speed.value == 2)
                {
                    new_Text.speed = 1.5f;
                }

                text_count++;

                if (move == false)
                {
                    if (target == true)
                    {
                        new_Text.move_vector = text_count -1 ;
                    }
                    else
                    {
                        new_Text.move_vector = text_count_2 - 1;
                    }
                  
                   
                    GameObject newV = Instantiate(new_t, transform.position, new_t.transform.rotation) as GameObject;
                    newV.transform.parent = new_text_list.transform;
                }
                else
                {
                    if (target == true)
                    {
                        new_Text.move_vector = text_count - 1;
                    }
                 else
                    {
                        new_Text.move_vector = 0;
                    }

                    GameObject newV = Instantiate(new_t, transform.position, new_t.transform.rotation) as GameObject;
                    newV.transform.parent = new_text_list.transform;
                }

               
                i++;
             
                Debug.Log(text_count);

            }
            else
            {
                if (video.activeSelf == true)
                {
                    video_Script.Video_Stop();
                }
                
                StopCoroutine("Respawn");
                resp = false;
               
            }
               
            }





        }

    }

