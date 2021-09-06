using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightTracker : MonoBehaviour
{
    public int activeLights = 0;
    [SerializeField] int activeLightLimit = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void gameOverCheck()
    {
        if (activeLights >= activeLightLimit)
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameOverCheck();
    }
}
