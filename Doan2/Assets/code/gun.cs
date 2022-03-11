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
    public int max_ammo = 10;
    private int curent_ammo;
    public float reloadtimes= 2f;
    private bool isreload;
    

    // Start is called before the first frame update
    void Start()
    {
        if(curent_ammo == -1)
        {
            curent_ammo = max_ammo;
        }
    }

    // Update is called once per frame
    void Update()

    {
        if (isreload)
        {
            return;
        }
        if (curent_ammo <=0)
        {
            StartCoroutine(Reload());
            return;
        }


            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        

    }
    void Shoot()
    {
        muzzle_flash.Play();
        curent_ammo --;
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
    IEnumerator Reload()
    {
        isreload = true;
        yield return new WaitForSeconds(reloadtimes);
        curent_ammo = max_ammo;
        isreload= false;
    }
    
}
