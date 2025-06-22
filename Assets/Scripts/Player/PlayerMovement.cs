using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // PROPERTIES
    [SerializeField] float _moveSpeed = 5f;

    // VARIABLES
    Rigidbody2D _rb;
    Vector2 _moveInput;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = _moveInput * _moveSpeed;
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}
