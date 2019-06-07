using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovementScript : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;
        float y = 0;
        bool horz = false;
        bool vert = false;
     

        if (Input.GetKey(KeyCode.D)) {
            x += moveSpeed;
            horz = true;
         };

        if (Input.GetKey(KeyCode.A)) {
            x -= moveSpeed;
            horz = true;
        };
        if (Input.GetKey(KeyCode.W)) {
            y += moveSpeed;
            vert = true;
        };
        if (Input.GetKey(KeyCode.S))  {
            y -= moveSpeed;
            vert = true;
        };

        if(horz && vert){
            x /= 1.41f;
            y /= 1.41f;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);

    }

}