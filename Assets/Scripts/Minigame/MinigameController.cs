using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameController : MonoBehaviour
{
    [SerializeField] private int _lightsRequiredStartingAmount = 15;
    [SerializeField] private int _lightsRequiredMaximumAmount = 30;
    [SerializeField] private int _lightsRequiredPenalty = 2;

    [SerializeField] private float _ballSpawnCooldown = 1;
    [SerializeField] private float _ballSpeed = 1;

    [SerializeField] private BallMovement _ballInstance;
    [SerializeField] private GameObject _ballSpawnLocator;
    
    [SerializeField] private Text _displayRequiredLightsAmount;

    private int _lightsRequired;

    private Vector3 _ballSpawnPoint;

    private TrafficLight _targetTrafficLight;
    private Player _myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBall", _ballSpawnCooldown, _ballSpawnCooldown);
        SetTargets();
    }

    private void SetTargets()
    {
        _ballSpawnPoint = _ballSpawnLocator.transform.position;
        _lightsRequired = _lightsRequiredStartingAmount;
        _myPlayer = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();
    }

    private void OnDisable()
    {
        _lightsRequired = _lightsRequiredStartingAmount;
    }

    private void SpawnBall()
    {
        var ball = Instantiate<BallMovement>(_ballInstance, _ballSpawnPoint, Quaternion.identity);
        ball.SetSpeed(_ballSpeed);
    }

    public void SetTrafficLightTarget(TrafficLight pTrafficLight)
    {
        _targetTrafficLight = pTrafficLight;
    }

    public void LowerRequiredLights()
    {
        _lightsRequired -= 1;
    }

    public void AddRequiredLightsPenalty()
    {
        if ((_lightsRequired + _lightsRequiredPenalty) < _lightsRequiredMaximumAmount)
        {
            _lightsRequired += _lightsRequiredPenalty;
        }
        else
        {
            _lightsRequired = _lightsRequiredMaximumAmount;
        }
    }

    private void checkForCompletion()
    {
        if (_lightsRequired <= 0 && _targetTrafficLight != null)
        {
            _targetTrafficLight.SwitchLight();
            _myPlayer.SwitchMinigame(false);
        }
    }

    private void DisplayRequiredLightsText()
    {
        _displayRequiredLightsAmount.text = "Lights required: " + _lightsRequired;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayRequiredLightsText();
        checkForCompletion();
    }
}