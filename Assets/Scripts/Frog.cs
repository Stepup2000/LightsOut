using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSytemHearts;
    [SerializeField] ParticleSystem particleSytemAngryFace;
    private TrafficLight _closestTrafficLight;
    public bool happy;

    // Start is called before the first frame update
    void Start()
    {
        CheckForClosestLight();
        particleSytemHearts.gameObject.GetComponent<ParticleSystem>().Stop();
        particleSytemAngryFace.gameObject.GetComponent<ParticleSystem>().Stop();
    }

    private void changeMood()
    {
        if (_closestTrafficLight != null) happy = !_closestTrafficLight.lightState;
    }

    private void EmitParticles()
    {
        if (happy == true)
        {
            particleSytemAngryFace.gameObject.GetComponent<ParticleSystem>().Stop();
            ParticleSystem particleSystem = particleSytemHearts.gameObject.GetComponent<ParticleSystem>();
            particleSystem.Play();
            Debug.Log("Stop");
        }

        if (happy == false)
        {
            particleSytemHearts.gameObject.GetComponent<ParticleSystem>().Stop();
            ParticleSystem particleSystem = particleSytemAngryFace.gameObject.GetComponent<ParticleSystem>();
            particleSystem.Play();
            Debug.Log("Play");
        }

    }

    private void CheckForClosestLight()
    {
        List<TrafficLight> allTrafficLights = FindObjectsOfType<TrafficLight>().ToList();
        TrafficLight closestStreetLight = null;
        float smallestDistance = 1000;
        for (int i = 0; i < allTrafficLights.Count; i++)
        {
            float distanceToTarget = Vector3.Distance(transform.position, allTrafficLights[i].transform.position);
            if (distanceToTarget < smallestDistance)
            {
                closestStreetLight = allTrafficLights[i];
                smallestDistance = distanceToTarget;
            }
        }
        _closestTrafficLight = closestStreetLight;
    }

    // Update is called once per frame
    void Update()
    {
        changeMood();
        EmitParticles();
    }
}
