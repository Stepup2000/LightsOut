using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public List<TrafficLight> trafficLightTargets;

    [SerializeField] private float _lightSpawnCooldown = 90;
    [SerializeField] private int _activeLightsStartingAmount = 12;
    public float happinessScore = 100;
    private float _maxScore = 200;

    // Start is called before the first frame update
    private void Start()
    {
        trafficLightTargets = FindObjectsOfType<TrafficLight>().ToList();
        InvokeRepeating("turnRandomLightOn", _lightSpawnCooldown, _lightSpawnCooldown);
        InvokeRepeating("ChangeScore", 1, 1);
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
            happinessScore -= score*0.5f;
            Debug.Log(happinessScore);
        }

        if (idleTrafficLights.Count > halfOfStreetlightAmount)
        {
            float score = -1 + ((halfOfStreetlightAmount - idleTrafficLights.Count) / 10);
            happinessScore -= score * 0.5f;
            Debug.Log(happinessScore);
        }
    }

    private void WinAndLoseCondition()
    {
        List<TrafficLight> idleTrafficLights = trafficLightTargets.FindAll((light) => !light.lightState);
        if (happinessScore >= _maxScore)
        {
            //Win Condition
            Debug.Log("Win");
        }

        if (happinessScore <= 0)
        {
            //Win Condition
            Debug.Log("Lose");
        }
    }

    private void Update()
    {
        WinAndLoseCondition();
    }
}
