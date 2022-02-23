using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pausee : MonoBehaviour
{
    void Start()
    {
        resume();
    }
    public static bool Pausemenu = false;
    public GameObject pauseUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausemenu)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        Pausemenu = false;
    }
   public void pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        Pausemenu = true;
    }
    public void Menu()
    {
        
        SceneManager.LoadScene("startmenu"); 
    }
    public void Quit()
    {
        Application.Quit();
    }
}
