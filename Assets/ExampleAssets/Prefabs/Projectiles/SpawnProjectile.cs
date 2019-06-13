using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{

    //public GameObject firePoint;// only required for if you want it to spawn from something else other than what you attach this script to
    public List<GameObject> vfxList = new List<GameObject>();
    public RotateToMouse rotateToMouse;

    private GameObject effectToSpawn;


    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfxList[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {//doesnt ghost
            spawnVFX();
        }
    }

    void spawnVFX() {
        GameObject vfx; // i guess the way instantite() works this doesnt go out of scope

        //if(firePoint != null) {
            vfx = Instantiate(effectToSpawn, gameObject.transform.position, Quaternion.identity);//firePoint.transform.position, Quaternion.identity);
        //}
        vfx.transform.right = rotateToMouse.getRotation();

        ProjectileMovement projectile = vfx.GetComponent<ProjectileMovement>();
        projectile.timeCreated = Time.timeSinceLevelLoad;

       // Destroy(vfx, 2.0f);
    }
}
