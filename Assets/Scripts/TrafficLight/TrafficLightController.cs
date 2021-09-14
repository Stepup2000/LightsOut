using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public List<TrafficLight> trafficLightTargets;

    [SerializeField] private float _lightSpawnCooldown = 10;
    [SerializeField] private float _loseConditionAddition = 2;

    // Start is called before the first frame update
    private void Start()
    {
        trafficLightTargets = FindObjectsOfType<TrafficLight>().ToList();
        InvokeRepeating("turnRandomLightOn", _lightSpawnCooldown, _lightSpawnCooldown);
    }

    private void turnRandomLightOn()
    {
        {
            List<TrafficLight> idleTrafficLights = trafficLightTargets.FindAll((light) => !light.lightState);
            if (idleTrafficLights.Count > 0)
            {
                int randomNumber = Random.Range(0, idleTrafficLights.Count);
                idleTrafficLights[randomNumber].SwitchLight();
            }
        }
    }

    private void WinAndLoseCondition()
    {
        List<TrafficLight> idleTrafficLights = trafficLightTargets.FindAll((light) => !light.lightState);
        if (idleTrafficLights.Count >= trafficLightTargets.Count - _loseConditionAddition)
        {
            //Win Condition
        }

        if (idleTrafficLights.Count <= 0)
        {
            //Win Condition
        }
    }


}
