using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    // Start is called before the first frame update
    public void Vaogame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Thoatgame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    
}
