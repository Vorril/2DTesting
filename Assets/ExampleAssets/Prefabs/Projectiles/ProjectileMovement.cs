using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed!=0){
            gameObject.transform.position += (gameObject.transform.right * speed * Time.deltaTime );
        }
    }
}
