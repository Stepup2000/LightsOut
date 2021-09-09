using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    [SerializeField] private MinigameController _minigameControllerPrefab;
    public bool lightState = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey("space"))
            {
                Vector3 positionOffset = new Vector3(0, 2, 0);
                var minigameController = Instantiate<MinigameController>(_minigameControllerPrefab, other.transform.position + positionOffset, Quaternion.identity);
                minigameController.SetTrafficLightTarget(this);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
