using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.IO;

public class New_text : MonoBehaviour
{
    public int move_vector;
    public Text text_t;
    private Vector vector;
    private GameObject canvas;
    private PhotonView photonView;
    private Resp_text resp;
    private Vector2 move;
    public float add , add_2;
    private bool stop;
    public float speed , speed_save;
    private bool n_2;
    private Move_vector m_Vector;
   public bool no_circl;
    private int count_text;

    public RawImage image;
  private Animator animator;

    void Start()
    {
        speed_save = speed;
        resp = GameObject.Find("Canvas").GetComponent<Resp_text>();
        photonView = GetComponent<PhotonView>();
        canvas = GameObject.Find("Canvas");
        text_t = GetComponent<Text>();
        vector = GameObject.Find("Canvas").GetComponent<Vector>();
        transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        m_Vector = vector.list[move_vector].GetComponent<Move_vector>();
        animator = GetComponent<Animator>();
        count_text = resp.text_count;

      

        if (resp.move == false)
        {
            if (m_Vector.anima == 1)
            {
                move = vector.list[move_vector].transform.position;
                Add();
                transform.position = move;
            }

            if (m_Vector.anima == 2)
            {
                Invoke("Up", 1);
                move = vector.list[move_vector].transform.position;
                Add();
                transform.position = move;
            }
            if (m_Vector.anima == 3)
            {
                Invoke("Go_2_1", 10 - add / 7);
                Invoke("Up", 10 - add / 7);
                move = vector.list[move_vector].transform.position;
                Add();
                transform.position = move;
            }
            if (m_Vector.anima == 4)
            {
                speed = 20;
                move = vector.list[move_vector].transform.position;
            }
            if (m_Vector.anima == 5)
            {
                move_vector = count_text - 1;
                move = vector.list[move_vector].transform.position;
                transform.position = move;
            }
            if (m_Vector.anima == 6)
            {
                speed = speed * 2;
                move = vector.list[move_vector].transform.position;
                transform.position = new Vector2(-10, 0);
                text_t.enabled = false;
                if ( add == 0)
                {
                    animator.enabled = false;
                    image.enabled = true;
             
                }
               
                
            }
        }
        else
        {
            if(m_Vector.anima == 1)
            {
                move = vector.list[0].transform.position;
                transform.position = move;
            }
            if (m_Vector.anima == 2)
            {
                move = vector.list[0].transform.position;

                transform.position = move;
            }
          
            if (m_Vector.anima == 3)
            {
                move_vector = count_text - 1;
                move = vector.list[move_vector].transform.position;
                transform.position = vector.list[0].transform.position;
            }

        }


    }


    public void Add()
    {
        float add_del = 0;
        if (text_t.fontSize < 50)
        {
            add_del = 4;
        }
        if (text_t.fontSize > 49 && text_t.fontSize < 100)
        {
            add_del = 3.3f;
        }
        if (text_t.fontSize > 99 && text_t.fontSize < 150)
        {
            add_del = 2.7f;
        }
        if (text_t.fontSize > 149 && text_t.fontSize < 200)
        {
            add_del = 2.1f;
        }
        if ( text_t.fontSize > 199 && text_t.fontSize < 250)
        {
            add_del = 1.6f;
        }
        if (text_t.fontSize > 249 && text_t.fontSize < 300)
        {
            add_del = 1f;
        }
        if (text_t.fontSize > 299)
        {
            add_del = 0.9f;
        }

        if (m_Vector.rot == 1)
        {
            move.x += add / add_del;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (m_Vector.rot == 2)
        {
            move.x += add / add_del;
            move.y += add / add_del;
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        if (m_Vector.rot == 3)
        {
            move.y += add / add_del;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (m_Vector.rot == 4)
        {
            move.x -= add / add_del;
            move.y += add / add_del;
            transform.rotation = Quaternion.Euler(0, 0, 135);
        }
        if (m_Vector.rot == 5)
        {
            move.x -= add / add_del;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (m_Vector.rot == 6)
        {
            move.x -= add / add_del;
            move.y -= add / add_del;
            transform.rotation = Quaternion.Euler(0, 0, 225);
        }
        if (m_Vector.rot == 7)
        {
            move.y -= add / add_del;
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        if (m_Vector.rot == 8)
        {
            move.x += add / add_del;
            move.y -= add / add_del;
            transform.rotation = Quaternion.Euler(0, 0, 315);
        }

        Debug.Log(move.x);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) || resp.text_count == 0)
        {
            Destroy(gameObject);
        }

    


        if (resp.move == true)
        {
            if (Vector2.Distance(transform.position, move) < 0.1f)
            {
                if (m_Vector.anima == 1 )
                {
                        Go();
                }
                if (m_Vector.anima == 2)
                {
                    Circl_go();
                }
                 if (m_Vector.anima == 3)
                {
                    Go_add();
                }
            }
        }



        if (Vector2.Distance(transform.position, move) < 0.5f)
        {
            if (m_Vector.anima == 4)
            {
                if (stop == false)
                {
                    stop = true;
                    Add();
                }
            }
            if (m_Vector.anima == 6)
            {
                if (stop == false)
                {
                    stop = true;
                    if (add == 0)
                    {
                        animator.enabled = true;
                        animator.Play("Anima_6");
                    }
                    Invoke("Anima_6", 2);


                }
            }
        }

     
        transform.position = Vector3.MoveTowards(transform.position, move, speed * Time.fixedDeltaTime);
    }

   private void Anima_6 ()
    {
        image.enabled = false;
        text_t.enabled = true;
        Add();
        if (add != 0)
        {
            Invoke("Up_start", 1);
            speed = 0.5f;
        }
    }

    private void Go_add()
    {
            if (move_vector == count_text - 1)
            {
                speed = 0;
            }
            else
            {
                move_vector++;
            }

        move = vector.list[move_vector].transform.position;
    }

    private void Speed ()
    {
        speed = speed_save;
    }

    private void Go()
    {

        if (no_circl == false)
        {
            if ((move_vector == vector.list.Count - 1))
            {
                no_circl = true;
                Invoke("Speed", add_2 / (speed*2));
                speed = 0;
              
            }
            else
            {
            

                move_vector++;
            }
        }
        else
        {
            if (move_vector == 0)
                {
                no_circl = false;
                Invoke("Speed", add /(speed *2));
                speed = 0;
             
            }
            else
                {
                 move_vector--;
                }
        }


        move = vector.list[move_vector].transform.position;
    }
    

    private void Circl_go()
    {
            
                if (move_vector == vector.list.Count - 1)
                {
                    move_vector = 0;
                }
                else
                {
                    move_vector++;
                }

            move = vector.list[move_vector].transform.position;
        }
    

    private void Go_2_1()
    {
        text_t.enabled = true;
  
        Invoke("Go_2_2", 5 );
    

        if (m_Vector.rot == 1)
        {
            move.x -= 3;
         
        }
        if (m_Vector.rot == 3)
        {
            move.y -= 3;
        }
        if (m_Vector.rot == 5)
        {
            move.x += 3;
        }
        if (m_Vector.rot == 7)
        {
            move.y += 3;
        }
    }

    private void Go_2_2 ()
    {
       

        text_t.enabled = false;
        if (m_Vector.rot == 1)
        {
            move.x += 6f;
        }
        if (m_Vector.rot == 3)
        {
            move.y += 6f;
        }
        if (m_Vector.rot == 5)
        {
            move.x -= 6f;
        }
        if (m_Vector.rot == 7)
        {
            move.y -= 6f;
        }
        Invoke("Go_2_3", 10 );
    }

    private void Go_2_3()
    {
   
        text_t.enabled = true;
        if (m_Vector.rot == 1)
        {
            move.x -= 3;
        }
        if (m_Vector.rot == 3)
        {
            move.y -= 3;
        }
        if (m_Vector.rot == 5)
        {
            move.x += 3;
        }
        if (m_Vector.rot == 7)
        {
            move.y += 3;
        }
        Invoke("Go_2_1", 10 );
    }

    private void Up ()
    {

        if (m_Vector.rot == 1)
        {
          move.y += 0.5f;
        }
      
          
        if (m_Vector.rot == 2)
        {
            move.y += 0.5f;
        }
        if (m_Vector.rot == 3)
        {
            move.x += 0.5f;
        }
        if (m_Vector.rot == 4)
        {
            move.x += 0.5f;
            move.y += 0.5f;
        }
        if (m_Vector.rot == 5)
        {
            move.y -= 0.5f;
        }
        if (m_Vector.rot == 6)
        {
            move.y -= 0.5f;
        }
        if (m_Vector.rot == 7)
        {
            move.x -= 0.5f;
        }
        if (m_Vector.rot == 8)
        {
            move.x -= 0.5f;
            move.y -= 0.5f;
        }

        Invoke("Down", 1);
    }

    private void  Down()
    {
        if (m_Vector.rot == 1)
          {
           move.y -= 0.5f;
          }
   
        if (m_Vector.rot == 2)
        {
            move.y -= 0.5f;
        }
        if (m_Vector.rot == 3)
        {
            move.x -= 0.5f;
        }
        if (m_Vector.rot == 4)
        {
            move.x -= 0.5f;
            move.y -= 0.5f;
        }
        if (m_Vector.rot == 5)
        {
            move.y += 0.5f;
        }
        if (m_Vector.rot == 6)
        {
            move.y += 0.5f;
        }
        if (m_Vector.rot == 7)
        {
            move.x += 0.5f;
        }
        if (m_Vector.rot == 8)
        {
            move.x += 0.5f;
            move.y += 0.5f;
        }
        Invoke("Up", 1);
    }


    private void Up_start()
    {


        if (m_Vector.rot == 7)
        {
            move.x -= 0.3f;
         
        }


        Invoke("Up_2", 1);
    }

    private void Up_2()
    {

       
        if (m_Vector.rot == 7)
        {
            move.x += 0.6f;
        }
     

        Invoke("Down_2", 1);
    }

    private void Down_2()
    {
        
        if (m_Vector.rot == 7)
        {
            move.x -= 0.6f;
        }
   
        Invoke("Up_2", 1);
    }

    
}
