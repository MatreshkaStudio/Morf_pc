using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Vector : MonoBehaviour
{
    public List <GameObject> list = new List<GameObject>();
    public GameObject vector_mass , panel , load_ok_1 , load_ok_2 , load_ok_3 , save_ok;
    private GameObject v;
    private Save save = new Save();
    private string path_1, path_2, path_3 ;
    public GameObject vector , sett_v;
    public Move_vector move_Vector;
    private Resp_text resp_Text;
    private Settings settings;
    public GameObject video_2;
    private int tab = 0;

    int z = 0;

    [Serializable]
    public class Save
    {
        public List<Vector2> list_save = new List<Vector2>();
        public List<int> list_rot = new List<int>();
        public List<int> list_anima = new List<int>();
        public bool move_s , v_1_x , video_2_on;
        public int speed_s, font_s , color_1_s , color_2_s , color_3_s , font_size_s , text_limit_s;
        public Vector2 video_2;
    }

    void Start()
    {
        settings = GameObject.Find("Canvas").GetComponent<Settings>();
        resp_Text = GameObject.Find("Canvas").GetComponent<Resp_text>();
        v = Resources.Load<GameObject>("V");

      path_1 = Path.Combine(Application.dataPath, "Save_vector_1");
        path_2 = Path.Combine(Application.dataPath, "Save_vector_2");
        path_3 = Path.Combine(Application.dataPath, "Save_vector_3");

        Invoke("Load_vector_1", 1);



    }

    public void Load_vector_1 ()
    {
        load_ok_1.SetActive(true);
        load_ok_2.SetActive(false);
        load_ok_3.SetActive(false);

        Debug.Log("Load");
        if (list.Count != 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Destroy(vector_mass.transform.GetChild(i).gameObject);
            }

            list.Clear();
       
        }

   

        if (File.Exists(path_1))
        {
            save = JsonUtility.FromJson<Save>(File.ReadAllText(path_1));

          

            for (int i = 0; i < save.list_save.Count; i++)
            {


                GameObject newV = Instantiate(v, save.list_save[i], v.transform.rotation) as GameObject;
                newV.transform.parent = vector_mass.transform;
                newV.transform.localScale = new Vector3(1, 1, 1);
                list.Add(newV);
                Move_vector script = newV.GetComponent<Move_vector>();
                script.n = list.Count;
                script.rot = save.list_rot[i];
                script.anima = save.list_anima[i];
                move_Vector = script;
                vector = script.gameObject;
                Vector_load();
            }
            resp_Text.move_tog.isOn = save.move_s;
            resp_Text.speed.value = save.speed_s;
            resp_Text.move_circl_tog.isOn = save.v_1_x;

            resp_Text.input_size.text = save.font_size_s.ToString();
            resp_Text.input_color_1.text = save.color_1_s.ToString();
            resp_Text.input_color_2.text = save.color_2_s.ToString();
            resp_Text.input_color_3.text = save.color_3_s.ToString();
            resp_Text.font.value = save.font_s;
            resp_Text.video_tog.isOn = save.video_2_on;
            resp_Text.limit_input.text = save.text_limit_s.ToString();
            video_2.transform.position = save.video_2;
            
            resp_Text.Ok();
        }


    }

    public void Load_vector_2()
    {
        load_ok_2.SetActive(true);
        load_ok_1.SetActive(false);
        load_ok_3.SetActive(false);

        Debug.Log("Load");
        if (list.Count != 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Destroy(vector_mass.transform.GetChild(i).gameObject);
            }

            list.Clear();
           
        }

        if (File.Exists(path_2))
        {
            save = JsonUtility.FromJson<Save>(File.ReadAllText(path_2));

          

            for (int i = 0; i < save.list_save.Count; i++)
            {
                GameObject newV = Instantiate(v, save.list_save[i], v.transform.rotation) as GameObject;
                newV.transform.parent = vector_mass.transform;
                newV.transform.localScale = new Vector3(1, 1, 1);
                list.Add(newV);
                Move_vector script = newV.GetComponent<Move_vector>();
                script.n = list.Count;
                script.rot = save.list_rot[i];
                script.anima = save.list_anima[i];
                move_Vector = script;
                vector = script.gameObject;
                Vector_load();
            }
            resp_Text.move_tog.isOn = save.move_s;
            resp_Text.speed.value = save.speed_s;
            resp_Text.move_circl_tog.isOn = save.v_1_x;
            resp_Text.video_tog.isOn = save.video_2_on;
            resp_Text.input_size.text = save.font_size_s.ToString();
            resp_Text.input_color_1.text = save.color_1_s.ToString();
            resp_Text.input_color_2.text = save.color_2_s.ToString();
            resp_Text.input_color_3.text = save.color_3_s.ToString();
            resp_Text.limit_input.text = save.text_limit_s.ToString();
            resp_Text.font.value = save.font_s;
            video_2.transform.position = save.video_2;

            resp_Text.Ok();
        }

    }

    public void Load_vector_3()
    {
        load_ok_3.SetActive(true);
        load_ok_1.SetActive(false);
        load_ok_2.SetActive(false);

        Debug.Log("Load");

        if (list.Count != 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Destroy(vector_mass.transform.GetChild(i).gameObject);
            }

            list.Clear();
           
        }

        if (File.Exists(path_3))
        {
       

            save = JsonUtility.FromJson<Save>(File.ReadAllText(path_3));

            for (int i = 0; i < save.list_save.Count; i++)
            {
                GameObject newV = Instantiate(v, save.list_save[i], v.transform.rotation) as GameObject;
                newV.transform.parent = vector_mass.transform;
                newV.transform.localScale = new Vector3(1, 1, 1);
                list.Add(newV);
                Move_vector script = newV.GetComponent<Move_vector>();
                script.n = list.Count;
                script.rot = save.list_rot[i];
                script.anima = save.list_anima[i];
                move_Vector = script;
                vector = script.gameObject;
                Vector_load();
            }

            resp_Text.move_tog.isOn = save.move_s;
            resp_Text.speed.value = save.speed_s;
            resp_Text.move_circl_tog.isOn = save.v_1_x;
            resp_Text.video_tog.isOn = save.video_2_on;
            resp_Text.input_size.text = save.font_size_s.ToString();
            resp_Text.input_color_1.text = save.color_1_s.ToString();
            resp_Text.input_color_2.text = save.color_2_s.ToString();
            resp_Text.input_color_3.text = save.color_3_s.ToString();
            resp_Text.limit_input.text = save.text_limit_s.ToString();
            resp_Text.font.value = save.font_s;
            video_2.transform.position = save.video_2;

            resp_Text.Ok();
        }
    }

    public void Save_vector_1 ()
    {
         save.list_save.Clear();
        save.list_rot.Clear();
        save.list_anima.Clear();

        for (int i = 0; i < list.Count; i++)
        {
            save.list_save.Add(list[i].transform.position);
            Move_vector script = list[i].GetComponent<Move_vector>();
            save.list_rot.Add(script.rot);
            save.list_anima.Add(script.anima);
        }

        save.move_s = resp_Text.move_tog.isOn;
        save.speed_s = resp_Text.speed.value;
        save.v_1_x = resp_Text.move_circl_tog.isOn;
        
        save.video_2_on = resp_Text.video_tog.isOn;
        save.color_1_s = int.Parse(resp_Text.input_color_1.text);
    save.color_2_s = int.Parse(resp_Text.input_color_2.text);
    save.color_3_s = int.Parse(resp_Text.input_color_3.text);
    save.font_size_s = int.Parse(resp_Text.input_size.text);
        save.text_limit_s = int.Parse(resp_Text.limit_input.text);
        save.font_s = resp_Text.font.value;
        save.video_2 = video_2.transform.position;



        File.WriteAllText(path_1, JsonUtility.ToJson(save));

 
        Debug.Log("Save");
        save_ok.SetActive(true);
        Invoke("Save_ok_false", 1);
    }

    public void Save_vector_2()
    {
        save.list_save.Clear();
        save.list_rot.Clear();
        save.list_anima.Clear();

        for (int i = 0; i < list.Count; i++)
        {
            save.list_save.Add(list[i].transform.position);
            Move_vector script = list[i].GetComponent<Move_vector>();
            save.list_rot.Add(script.rot);
            save.list_anima.Add(script.anima);
        }
        save.move_s = resp_Text.move_tog.isOn;
        save.speed_s = resp_Text.speed.value;
        save.v_1_x = resp_Text.move_circl_tog.isOn;
        save.video_2_on = resp_Text.video_tog.isOn;
        save.color_1_s = int.Parse(resp_Text.input_color_1.text);
        save.color_2_s = int.Parse(resp_Text.input_color_2.text);
        save.color_3_s = int.Parse(resp_Text.input_color_3.text);
        save.font_size_s = int.Parse(resp_Text.input_size.text);
        save.text_limit_s = int.Parse(resp_Text.limit_input.text);
        save.font_s = resp_Text.font.value;
        save.video_2 = video_2.transform.position;

        File.WriteAllText(path_2, JsonUtility.ToJson(save));


        Debug.Log("Save");
        save_ok.SetActive(true);
        Invoke("Save_ok_false", 1);
    }

    public void Save_vector_3()
    {
        save.list_save.Clear();
        save.list_rot.Clear();
        save.list_anima.Clear();

        for (int i = 0; i < list.Count; i++)
        {
            save.list_save.Add(list[i].transform.position);
            Move_vector script = list[i].GetComponent<Move_vector>();
            save.list_rot.Add(script.rot);
            save.list_anima.Add(script.anima);
        }
        save.move_s = resp_Text.move_tog.isOn;
        save.speed_s = resp_Text.speed.value;
        save.v_1_x = resp_Text.move_circl_tog.isOn;
        save.video_2_on = resp_Text.video_tog.isOn;
        save.color_1_s = int.Parse(resp_Text.input_color_1.text);
        save.color_2_s = int.Parse(resp_Text.input_color_2.text);
        save.color_3_s = int.Parse(resp_Text.input_color_3.text);
        save.font_size_s = int.Parse(resp_Text.input_size.text);
        save.text_limit_s = int.Parse(resp_Text.limit_input.text);
        save.font_s = resp_Text.font.value;
        save.video_2 = video_2.transform.position;

        File.WriteAllText(path_3, JsonUtility.ToJson(save));


        Debug.Log("Save");

        save_ok.SetActive(true);
        Invoke("Save_ok_false", 1);
    }

    private void Save_ok_false()
    {
        save_ok.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) )
        {
            Vector_off();
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (tab == 0)
            {
                panel.SetActive(false);
                tab = 1;
            }
            else
            {
                panel.SetActive(true);
                tab = 0;

            }
         
        }

     

    }

 

    public void Vector_off ()
    {
        panel.SetActive(false);
        vector_mass.SetActive(false);
        settings.Stop_v();
    }

    public void Vector_on()
    {
        panel.SetActive(true);
        vector_mass.SetActive(true);
        settings.Start_V();
    }

    public void Vector_add ()
    {
     
        GameObject newV = Instantiate(v, transform.position, v.transform.rotation) as GameObject;
        newV.transform.parent = vector_mass.transform;
        newV.transform.localScale = new Vector3(1, 1, 1);
        list.Add(newV);
        newV.GetComponent<Move_vector>().n = list.Count;
    }

    public void Vector_del()
    {
        if(list.Count > 0)
        {
            list.Remove(list[list.Count - 1]);
            Destroy(vector_mass.transform.GetChild(vector_mass.transform.childCount - 1).gameObject);

        }

    }

    private void Vector_load ()
    {

        if (move_Vector.rot == 1)
        {
            z = 0;
        }
        if (move_Vector.rot == 2)
        {
            z = 45;
        }
        if (move_Vector.rot == 3)
        {
            z = 90;
        }
        if (move_Vector.rot == 4)
        {
            z = 135;
        }
        if (move_Vector.rot == 5)
        {
            z = 180;

        }
        if (move_Vector.rot == 6)
        {
            z = 225;
        }
        if (move_Vector.rot == 7)
        {
            z = 270;
        }
        if (move_Vector.rot == 8)
        {
            z = 315;
        }
        if (move_Vector.rot == 9)
        {
            z = 0;
            move_Vector.rot = 1;
        }


        vector.transform.rotation = Quaternion.Euler(0, 0, z);
    }

    public void Vector_q()
    {
        move_Vector.rot += 1;

        if (move_Vector.rot == 1)
        {
            z = 0;
        }
        if (move_Vector.rot == 2)
        {
            z = 45;
        }
        if (move_Vector.rot == 3)
        {
            z = 90;
        }
        if (move_Vector.rot == 4)
        {
            z = 135;
        }
        if (move_Vector.rot == 5)
        {
            z = 180;
           
        }
        if (move_Vector.rot == 6)
        {
            z = 225;
        }
        if (move_Vector.rot == 7)
        {
            z = 270;
        }
        if (move_Vector.rot == 8)
        {
            z = 315;
        }
        if (move_Vector.rot == 9)
        {
            z = 0;
            move_Vector.rot = 1;
        }




        vector.transform.rotation = Quaternion.Euler(0, 0, z);

      
    }

    public void Anima()
    {
        move_Vector.anima += 1;
        if (move_Vector.anima == 7)
        {
            move_Vector.anima = 1;
        }
    }
}
