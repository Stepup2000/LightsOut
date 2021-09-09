using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField]
    public Vector3 direction = Vector3.right;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetSpeed(float pSpeed)
    {
        _speed = pSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * _speed);
    }
}
