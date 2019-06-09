using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{

    public Camera cam;
    public bool flipOnCrossover;
    //public float maxLength;

    private Vector3 mouseWorldspace;
    private Vector3 gameObjectFlatPos;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(cam != null) {
            var mousePos = Input.mousePosition; //screen pixel coords
            mouseWorldspace = cam.ScreenToWorldPoint(mousePos); //mouse pos in worldSpace
            
            mouseWorldspace.z = 0.0f; //flatten to 2D

            gameObjectFlatPos = gameObject.transform.position; //Sprite position
            gameObjectFlatPos.z = 0.0f;//flatten to 2D

            Vector3 differenceToRotate = (mouseWorldspace - gameObjectFlatPos);
            if (flipOnCrossover && differenceToRotate.x < 0) {//optional rotational behavior ie will it turn upside down or flip
                differenceToRotate.x *= -1.0f;
                differenceToRotate.y *= -1.0f;
            }

                gameObject.transform.right = differenceToRotate.normalized;//Don't need overcomplicated stuff in 2D, directly set the local x vector to be the pointing vector from sprite to mouse



        }
    }

   public Vector3 getRotation() {
        if (mouseWorldspace.x > gameObjectFlatPos.x) return gameObject.transform.right;
        else return -1 * gameObject.transform.right;
    }
    
}
