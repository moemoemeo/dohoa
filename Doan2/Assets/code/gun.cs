using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 5f;
    public float range = 200f;
    public Camera cam;
    public ParticleSystem muzzle_flash;
    public GameObject effet_hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
    void Shoot()
    {
        muzzle_flash.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        { 
            enemy ene = hit.transform.GetComponent<enemy>();
            if (ene != null)
            {
                ene.TakeDam(damage);
            }
            GameObject hit_effet= Instantiate(effet_hit, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(hit_effet, 2f);
        }


    }
}
