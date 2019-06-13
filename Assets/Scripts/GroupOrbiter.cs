using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOrbiter : MonoBehaviour
{
    
    public GameObject defaultOrbiterType;
    //public GameObject emptyRotationParent;
    private GameObject emptyRotationParent;

    [Range(-10.0f, 10.0f)]
    public float speed;

    [Range(-10.0f, 10.0f)]
    public float distance;

    [Range(0, Mathf.PI/2)]
    public float tiltMax;

    private List<GameObject> orbiters;
    private float theta = 0.0f;

    private Vector3 orbitNormal;

    // Start is called before the first frame update
    void Start()
    {
        orbiters = new List<GameObject>();
        emptyRotationParent = new GameObject("Rotation Parent");

        //Test child
        AddOrbiter(defaultOrbiterType);
        AddOrbiter(defaultOrbiterType);
        AddOrbiter(defaultOrbiterType);
        AddOrbiter(defaultOrbiterType);
        AddOrbiter(defaultOrbiterType);


        emptyRotationParent.transform.rotation = Quaternion.Euler(30.0f, tiltMax * 60, 30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //emptyRotationParent.transform.rotation = Quaternion.Euler(30.0f, tiltMax*60, 30.0f);

    }

    void LateUpdate() {
        emptyRotationParent.transform.position = gameObject.transform.position;

        recalculateOrbits();



    }

    public void AddOrbiter( GameObject orbiterType) {//not sure about ref call maybe unnec
        orbiters.Add(Instantiate(orbiterType, emptyRotationParent.transform, false));//Instantiate a new orbiter of the passed type, add it to the list, and parent it all in one 

        SpriteRenderer parentSprite = gameObject.GetComponent<SpriteRenderer>(); //Getcomponent is magic but whatever this guarantees sprites zDepth Correctly
        SpriteRenderer newSprite = orbiters[orbiters.Count - 1].GetComponent<SpriteRenderer>();
        newSprite.sortingOrder = parentSprite.sortingOrder; 
        
       
    }

    private void recalculateOrbits() {
        theta += Time.deltaTime * speed/4.0f;
        if (theta > 2 * Mathf.PI) theta -= 2 * Mathf.PI;

        for (int i=0; i<orbiters.Count; i++) {
            float xpos = distance * Mathf.Cos(theta);
            float ypos = distance * Mathf.Sin(theta);
            orbiters[i].transform.localPosition = new Vector3(xpos, ypos, 0.0f);
            orbiters[i].transform.rotation = Quaternion.identity; //Probably the easiest way to do this, we want 2D sprites and rotation skewed them. Just reseting, doesnt seem to cause any global/local issues

            theta += 2 * Mathf.PI / orbiters.Count;// evenly space, could implement differently
        }
    }

    
}
