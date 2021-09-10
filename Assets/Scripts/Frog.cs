using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField] private TrafficLight trafficLight;
    [SerializeField] ParticleSystem particleSytemHearts;
    [SerializeField] ParticleSystem particleSytemAngryFace;
    private bool happy;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void changeMood()
    {
        happy = !trafficLight.lightState;
    }

    private void EmitParticles()
    {
        if (happy == true)
        {
            particleSytemHearts.gameObject.GetComponent<ParticleSystem>().Play();
            particleSytemAngryFace.Stop();
        }

        if (happy == false)
        {
            particleSytemHearts.gameObject.GetComponent<ParticleSystem>().Stop();
            particleSytemAngryFace.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        changeMood();
        EmitParticles();
        Debug.Log(happy);
    }
}
