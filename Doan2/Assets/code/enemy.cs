using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public bool velocity;
    public bool velocity_mongmuon;
    public bool path;
    public Transform Player;
    public Transform max_map;
    public Transform min_map;


    float timer = 0.0f;
    public float maxDistance = 0.05f;
    public float maxTime = 1.0f;

    NavMeshAgent scp;
    
    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        scp = GetComponent <NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!scp.enabled)
        {
            return;
        }
        timer -= Time.deltaTime;
        //di toi vi tri nguoi choi
       /* if (!scp.hasPath)
        {
            scp.destination = Player.position;
        }
        if (timer < 0.0f)
        {
            Vector3 direction = (Player.position - scp.destination);
            direction.y = 0;
            if (direction.sqrMagnitude > maxDistance * maxDistance)
            {
                if (scp.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    scp.destination = Player.position;
                }
            }
            timer = maxTime;
        }*/
        // di loanh quanh trong pham vi
        if (!scp.hasPath)
        {
            Vector3 min = min_map.position;
            Vector3 max = max_map.position;
            Vector3 random_pos = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
            scp.destination = random_pos;
        }
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
    void OnDrawGizmos()
    {
        if (velocity)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, transform.position + scp.velocity);
        }
        if (velocity_mongmuon)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, transform.position + scp.desiredVelocity);
        }
        if (path)
        {
            var duong_scp = scp.path;
            Vector3 quaygoc = transform.position;
            foreach(var goc in duong_scp.corners)
            {
                Gizmos.DrawLine(quaygoc, goc);
                Gizmos.DrawSphere(goc, 0.1f);
                quaygoc = goc;
            }
        }

    }
    
}
