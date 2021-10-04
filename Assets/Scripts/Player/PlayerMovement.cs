using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 _direction;
    private float _speed = 4f;
    private float _speedRotate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Direction(InputAction.CallbackContext context) {
        Vector2 _inputVector = context.ReadValue<Vector2>();
        _direction = new Vector3(_inputVector.x, _inputVector.y, 0);
    }

    void Movement() {
        transform.position += transform.up * Time.deltaTime * _speed;
        if (_direction.x < 0) {
            transform.Rotate(Vector3.forward * _speedRotate);
        }
        if (_direction.x > 0) {
            transform.Rotate(Vector3.back * _speedRotate);
        }
    }
}
