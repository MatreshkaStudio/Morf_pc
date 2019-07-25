using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_video : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(mousePos.x, mousePos.y), 1000 * Time.deltaTime); ;
    }
}
