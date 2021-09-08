using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    [SerializeField] private int _lightsRequiredStartingAmount;
    [SerializeField] private int _lightsRequired;
    [SerializeField] private int _lightsRequiredPenalty;
    [SerializeField] private int _ballSpawnCooldown;
    [SerializeField] private int _ballSpeed;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
