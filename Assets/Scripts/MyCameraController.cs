using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{

    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3();

        if (Input.GetKey(KeyCode.UpArrow)) {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            direction += Vector3.right;
        }

        if (Input.GetKey(KeyCode.U)) {
            direction += Vector3.down;
        }
        if (Input.GetKey(KeyCode.O)) {
            direction += Vector3.up;

        }
            direction *= (speed * Time.deltaTime);

            gameObject.transform.position += direction;
        
    }
}
