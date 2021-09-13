using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private MinigameController minigameController;
    // Start is called before the first frame update

    private void Start()
    {
        SetMiniGameControllerTarget();
    }

    private void SetMiniGameControllerTarget()
    {
        GameObject[] allBalls;
        allBalls = GameObject.FindGameObjectsWithTag("MinigameController");
        if (allBalls.Length > 0)
        {
            minigameController = GameObject.FindGameObjectsWithTag("MinigameController")[0].GetComponent<MinigameController>();
        }
        else Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BallTrasher"))
        {
            minigameController.AddRequiredLightsPenalty();
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("MiniGameCollider"))
        {
            MinigameCollider collider = other.gameObject.GetComponent<MinigameCollider>();
            if (collider.direction == "Up")
            {
                gameObject.GetComponent<BallMovement>().direction = Vector3.up;
            }

            if (collider.direction == "Down")
            {
                gameObject.GetComponent<BallMovement>().direction = Vector3.down;
            }
            collider.direction = null;
        }

        BallColor ballColorComponent = GetComponent<BallColor>();
        Color currentColor = ballColorComponent.myColor;

        if (other.gameObject.CompareTag("BlueBallCollector"))
        {
            if (currentColor == Color.blue)
            {
                minigameController.LowerRequiredLights();
                Destroy(gameObject);
            }

            Color orange = new Color(1.0f, 0.5f, 0.0f);
            if (currentColor == orange)
            {
                minigameController.AddRequiredLightsPenalty();
                Destroy(gameObject);
            }
        }

        if (other.gameObject.CompareTag("OrangeBallCollector"))
        {
            if (currentColor == Color.blue)
            {
                minigameController.AddRequiredLightsPenalty();
                Destroy(gameObject);
            }

            Color orange = new Color(1.0f, 0.5f, 0.0f);
            if (currentColor == orange)
            {
                minigameController.LowerRequiredLights();
                Destroy(gameObject);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (minigameController.gameObject.activeSelf == false) Destroy(gameObject);
    }
}
