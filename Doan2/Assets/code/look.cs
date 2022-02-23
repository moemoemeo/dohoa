using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour
{
    
    public float donhay = 80.0f;
    float quayz = 0f;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    // Update is called once per frame
    void Update()
    {
        float quayx = Input.GetAxis("Mouse X") * donhay*Time.deltaTime;
        float quayy = Input.GetAxis("Mouse Y") * donhay*Time.deltaTime;
         quayz -= quayy;
        quayz = Mathf.Clamp(quayz, -80f, 80f);
        transform.localRotation = Quaternion.Euler(quayz, 0f, 0f);
        player.Rotate(Vector3.up * quayx);
    }
}
