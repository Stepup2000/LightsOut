using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    private MinigameController _minigameController;
    public bool lightState = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && Input.GetKey("space") && lightState == true)
        {
            Debug.Log(gameObject.name);
            Player myPlayer = other.gameObject.GetComponent<Player>();
            myPlayer.SwitchMinigame(true);
            _minigameController = GameObject.FindGameObjectsWithTag("MinigameController")[0].GetComponent<MinigameController>();
            _minigameController.SetTrafficLightTarget(this);
        }
    }

    public void SwitchLight()
    {
        lightState = !lightState;
    }

    private void emitLight()
    {
        GetComponent<Light>().enabled = lightState;
    }

    // Update is called once per frame
    void Update()
    {
        emitLight();
    }
}
