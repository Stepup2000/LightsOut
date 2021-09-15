using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public List<TrafficLight> trafficLightTargets;

    [SerializeField] private float _lightSpawnCooldown = 120;
    [SerializeField] private int _activeLightsStartingAmount = 12;
    private float _happinessScore = 50;

    // Start is called before the first frame update
    private void Start()
    {
        trafficLightTargets = FindObjectsOfType<TrafficLight>().ToList();
        InvokeRepeating("turnRandomLightOn", _lightSpawnCooldown, _lightSpawnCooldown);
        for (int i = 1; i < _activeLightsStartingAmount; i++)
        {
           turnRandomLightOn();
        }
    }

    private void turnRandomLightOn()
    {
        List<TrafficLight> idleTrafficLights = trafficLightTargets.FindAll((light) => !light.lightState);
        if (idleTrafficLights.Count > 0)
        {
            int randomNumber = Random.Range(0, idleTrafficLights.Count);
            idleTrafficLights[randomNumber].SwitchLight();
        }
    }

    private void ChangeScore()
    {
        List<TrafficLight> idleTrafficLights = trafficLightTargets.FindAll((light) => !light.lightState);
        float halfOfStreetlightAmount = trafficLightTargets.Count / 2;
        if (idleTrafficLights.Count < halfOfStreetlightAmount)
        {
            float score = 1 +((halfOfStreetlightAmount - idleTrafficLights.Count) / 10);
            _happinessScore += score;
            Debug.Log(score);
        }

        if (idleTrafficLights.Count > halfOfStreetlightAmount)
        {
            float score = -1 + ((halfOfStreetlightAmount - idleTrafficLights.Count) / 10);
            _happinessScore += score;
            Debug.Log(score);
        }
    }

    private void WinAndLoseCondition()
    {
        List<TrafficLight> idleTrafficLights = trafficLightTargets.FindAll((light) => !light.lightState);
        if (_happinessScore >= 100)
        {
            //Win Condition
            Debug.Log("Win");
        }

        if (_happinessScore <= 0)
        {
            //Win Condition
            Debug.Log("Lose");
        }
    }

    private void Update()
    {
        //WinAndLoseCondition();
        ChangeScore();
    }
}
