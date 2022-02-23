using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_scp : MonoBehaviour
{
    public GameObject scp;
    public int x_pos;
    public int z_pos;
    public int scp_count;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Scp_spawn());
    }

    // Update is called once per frame
    IEnumerator Scp_spawn()
    {
        while(scp_count < 1)
        {
            x_pos = Random.Range(1, -1000);
            z_pos = Random.Range(1, -1299);
            Instantiate(scp, new Vector3(x_pos, 10, z_pos), Quaternion.identity);
            yield return new WaitForSeconds(2f);
            scp_count += 1;
        }
    } 
}
