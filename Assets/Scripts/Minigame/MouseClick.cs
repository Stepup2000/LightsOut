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
}
