using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MiniGameCollider"))
        {
            MinigameCollider controller = other.gameObject.GetComponent<MinigameCollider>();
            if (controller.direction == "Up")
            {
                gameObject.GetComponent<BallMovement>().direction = Vector3.up;
            }

            if (controller.direction == "Down")
            {
                gameObject.GetComponent<BallMovement>().direction = Vector3.down;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
