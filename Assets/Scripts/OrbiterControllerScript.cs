using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbiterControllerScript : MonoBehaviour
{
    [Tooltip("The object this object will be psuedo-childed to")]
    public GameObject orbiterParent;

    [Range(-10.0f, 10.0f)]
    public float orbitRate;

    private float phase;
    private float dist = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = orbiterParent.transform.position;
        phase = Random.Range(0.0f, 6.28f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate() {
        Vector3 offset = new Vector3();
        phase += orbitRate * Time.deltaTime / 10.0f;
        offset.x = Mathf.Cos(phase);
        offset.y = Mathf.Sin(phase);
        offset *= dist;

        gameObject.transform.position = (orbiterParent.transform.position + offset);
    }
}
