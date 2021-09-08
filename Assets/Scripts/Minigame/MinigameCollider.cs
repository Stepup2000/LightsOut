using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameCollider : MonoBehaviour
{
    public string direction = "Down";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void changeColor()
    {
        Renderer myRenderer = GetComponent<Renderer>();
        if (direction == "Down") myRenderer.material.color = new Color(1.0f, 0.5f, 0.0f);
        if (direction == "Up") myRenderer.material.color = Color.blue;
        if (direction == null) myRenderer.material.color = Color.gray;

    }

    // Update is called once per frame
    void Update()
    {
        changeColor();
    }
}
