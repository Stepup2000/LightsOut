using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    [SerializeField] private int _lightsRequiredStartingAmount = 30;
    [SerializeField] private int _lightsRequired = 30;
    [SerializeField] private int _lightsRequiredPenalty = 2;

    [SerializeField] private float _ballSpawnCooldown = 1;
    [SerializeField] private float _ballSpeed = 1;

    [SerializeField] private BallMovement _ballInstance;
    [SerializeField] private GameObject _ballSpawnLocator;

    private Vector3 _ballSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBall", _ballSpawnCooldown, _ballSpawnCooldown);
        _ballSpawnPoint = _ballSpawnLocator.transform.position;
    }

    private void SpawnBall()
    {
        var ball = Instantiate<BallMovement>(_ballInstance, _ballSpawnPoint, Quaternion.identity);
        ball.SetSpeed(_ballSpeed);
    }

    public void LowerRequiredLights()
    {
        _lightsRequired -= 1;
    }

    public void AddRequiredLightsPenalty()
    {
        _lightsRequired += _lightsRequiredPenalty;
    }

    // Update is called once per frame
    void Update()
    {

    }
}