using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static void StartGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public static void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
