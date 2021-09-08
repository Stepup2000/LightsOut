using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private int _speed;
    public Vector3 direction = Vector3.right;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetSpeed(int pSpeed)
    {
        _speed = pSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * _speed);
    }
}
