using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    public float timeCreated = 0.0f;//should be porivate w set method but w/e
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {

        timeCreated = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        if (speed!=0){
            gameObject.transform.position += (gameObject.transform.right * speed * Time.deltaTime );
        }

        if(Time.timeSinceLevelLoad - timeCreated > 4.0f) {
            Destroy(gameObject);
        }
    }
}
