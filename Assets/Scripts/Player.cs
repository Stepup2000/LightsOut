using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<GameObject> _minigameElements;

    private void Start()
    {
        SwitchMinigame(false);
    }

    public void SwitchMinigame(bool onOrOff)
    {
        for (int i = 0; i < _minigameElements.Count; i++)
        {
            _minigameElements[i].gameObject.SetActive(onOrOff);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
