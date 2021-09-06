using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private float _respawnCooldown = 5;
    [SerializeField] private LightTracker _lightTracker;
    [SerializeField] private GameObject _lightBulb;
    private float _respawnTimer = -1;

    // Start is called before the first frame update
    void Start()
    {
        setRandomLightCooldown();
        deactivateLight();
        _lightTracker.activeLights = 0;
    }

    private void setRandomLightCooldown()
    {
        _respawnCooldown = Random.Range(_respawnCooldown, _respawnCooldown * 6);
        _respawnTimer = _respawnCooldown;
    }

    private void timer()
    {
        if (_respawnTimer >= 0) _respawnTimer -= Time.deltaTime;
        if (_respawnTimer <= 0 && _lightBulb.gameObject.GetComponent<Renderer>().enabled == false) 
        {
            _lightBulb.gameObject.GetComponent<Renderer>().enabled = true;
            _lightTracker.activeLights += 1;
        }
    }

    private void deactivateLight()
    {
        setRandomLightCooldown();
        _lightBulb.gameObject.GetComponent<Renderer>().enabled = false;
        _lightTracker.activeLights -= 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _lightBulb.gameObject.GetComponent<Renderer>().enabled = false;
                _respawnTimer = _respawnCooldown;
                _lightTracker.activeLights -= 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer();
    }
}
