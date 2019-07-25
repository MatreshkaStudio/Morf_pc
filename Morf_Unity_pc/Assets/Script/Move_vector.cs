using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move_vector : MonoBehaviour
{
    private Vector vector;
    public int rot ;
    private Move_vector script;
    private Text n_t , anima_t;
    public int n;
    public int anima;


    void Start()
    {
        vector = GameObject.Find("Canvas").GetComponent<Vector>();
        script = gameObject.GetComponent<Move_vector>();
        n_t = transform.GetChild(0).GetComponent<Text>();
        anima_t = transform.GetChild(1).GetComponent<Text>();
        n_t.text = "" + n;

        vector.vector = gameObject;
        vector.move_Vector = script;
    }


    void Update()
    {
        anima_t.text = "" + anima;
    }

    public void OnMouseEnter()
    {
        vector.vector = gameObject;
        vector.move_Vector = script; 
    }

    public void OnMouseDrag()
    {
        vector.vector = gameObject;
        vector.move_Vector = script;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(mousePos.x, mousePos.y), 1000 * Time.deltaTime); ;
    }


}
