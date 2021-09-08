using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllable : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    Player _player;
    int _speed;
    float _rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _speed = _player.speed;
        _rotationSpeed = _player.rotationSpeed;
    }


    //Move forward/backwards
    private void XZMovement()
    {
        if (Input.GetKey("w"))
        {
            _rigidbody.AddForce(transform.forward * _speed * Time.deltaTime, ForceMode.Acceleration);
        }

        if (Input.GetKey("s"))
        {
            _rigidbody.AddForce(-transform.forward * _speed * Time.deltaTime, ForceMode.Acceleration);
        }
    }

    //Move up/down
    private void YMovement()
    {
        if (Input.GetKey("space"))
        {
            Vector3 Movement = new Vector3(0, 1, 0);
            _rigidbody.AddForce(Movement * _speed * Time.deltaTime, ForceMode.Acceleration);
        }

        if (Input.GetKey("left shift"))
        {
            Vector3 Movement = new Vector3(0, -1, 0);
            _rigidbody.AddForce(Movement * _speed * Time.deltaTime, ForceMode.Acceleration);
        }
    }

    //Rotate UFO right/left
    private void rotate()
    {
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -_rotationSpeed * Time.deltaTime, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        XZMovement();
        YMovement();
        rotate();
    }
}
