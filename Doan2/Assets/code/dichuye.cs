using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dichuye : MonoBehaviour
{
    public CharacterController controller;

    public int count=0;
    public float tocdo = 12f;
    public float trongluc = -9.8f;
    public float lucnhay = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
       
    }
    void Update()
    {
        if (count == 3)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("wwin");
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isGrounded)
        {
            if (Input.GetKey("z"))
            {
                tocdo = 30f;
            }
            else
            {
                tocdo = 12f;
            }
        }
        
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * tocdo * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(lucnhay * -2f * trongluc);
        }

        velocity.y += trongluc * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}