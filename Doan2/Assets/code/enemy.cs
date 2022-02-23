using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDam(float khoang)
    {
        health -= khoang;
        if(health <= 0f)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
