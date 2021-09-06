using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public TrafficLight[] trafficLightTargets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool checkActiveLights()
    {
        bool found = false;
        if (trafficLightTargets.Length != 0)
        {
            int trafficLightCount = trafficLightTargets.Length;
            for (int i = 0; i < trafficLightCount; i++)
            {
                if (trafficLightTargets[i].lightState == false)
                {
                    {
                        found = true;
                    }
                }
            }
        }
        return found;
    }

    // Update is called once per frame
    void Update()
    {
        checkActiveLights();
    }
}
