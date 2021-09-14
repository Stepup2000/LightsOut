using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private List<GameObject> _minigameElements;
    private List<TrafficLight> trafficLightTargets;
    [SerializeField] private float maxRange = 5;
    [SerializeField] private Text _pressE;

    private void Start()
    {
        SwitchMinigame(false);
        trafficLightTargets = FindObjectsOfType<TrafficLight>().ToList();
        InvokeRepeating("CheckForClosestLight", 1f, 1f);
    }

    public void SwitchMinigame(bool onOrOff)
    {
        for (int i = 0; i < _minigameElements.Count; i++)
        {
            _minigameElements[i].gameObject.SetActive(onOrOff);
            
        }
    }

    private void CheckForClosestLight()
    {
        List<TrafficLight> idleTrafficLights = trafficLightTargets.FindAll((light) => light.lightState);
        TrafficLight closestStreetLight = null;
        float smallestDistance = 1000;
        for (int i = 0; i < idleTrafficLights.Count; i++)
        {
            float distanceToTarget = Vector3.Distance(transform.position, idleTrafficLights[i].transform.position);
            if ( distanceToTarget < smallestDistance)
            {
                closestStreetLight = idleTrafficLights[i];
                smallestDistance = distanceToTarget;
            }
        }
        checkForInteractionText(closestStreetLight);
    }

    private void checkForInteractionText(TrafficLight closestStreetLight)
    {
        if (closestStreetLight != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, closestStreetLight.transform.position);
            if (distanceToTarget < maxRange) _pressE.text = "Press E to interact";
            else _pressE.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
