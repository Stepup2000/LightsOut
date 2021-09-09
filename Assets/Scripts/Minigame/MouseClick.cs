using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private MinigameCollider minigameCollider;
    [SerializeField] private string _direction;
    
    // Start is called before the first frame update

    private void OnMouseDown()
    {
        minigameCollider.direction = _direction;
    }

    private void OnDisable()
    {
        gameObject.SetActive(false);
    }

    private void getMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Camera.main);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Select stage    
                if (hit.transform.name == transform.name)
                {
                    NewMethod();
                }
            }
        }
    }

    public void NewMethod()
    {
        minigameCollider.direction = _direction;
    }

    private void Update()
    {
        getMouseClick();
    }
}
