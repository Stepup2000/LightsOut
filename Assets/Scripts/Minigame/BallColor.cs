using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColor : MonoBehaviour
{
    public Color myColor;
    // Start is called before the first frame update
    void Start()
    {
        pickRandomColor();
        ChangeColor();
    }

    private void pickRandomColor()
    {
        int number = Random.Range(1, 3);
        switch (number)
        {
            case 1:
                myColor = Color.blue;
                break;

            case 2:
                myColor = new Color(1.0f, 0.5f, 0.0f);
                break;
        }
    }

    private void ChangeColor()
    {
        Renderer myRenderer = gameObject.GetComponent<Renderer>();
        myRenderer.material.color = myColor;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
