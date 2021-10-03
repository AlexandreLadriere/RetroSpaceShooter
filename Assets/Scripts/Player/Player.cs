using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    private Vector3 _direction;
    private Vector2 _moveForward = new Vector2(1, 1);
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _speedRotate = 5f;

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
        if (_direction.x == -1) {
            transform.Rotate(Vector3.forward);
        }
        if (_direction.x == 1) {
            transform.Rotate(Vector3.back);
        }
    }
}
