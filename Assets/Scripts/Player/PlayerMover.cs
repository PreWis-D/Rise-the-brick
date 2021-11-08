using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GameObject _moneyEffect;
    [SerializeField] private PlayerAnimator _animator;


    private bool _isLevelFinished = false;
    private float _speedFall = -1f;
    private float _speed = 4f;
    private Quaternion _targetRotationAfterFinished = Quaternion.Euler(0, Mathf.LerpAngle(0, 180f, 3), 0);
    private Vector3 _velocity;
    private Rigidbody _body;

    public bool IsGrounded { get; private set; } = true;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _animator.LevelFinished += OnEndLevel;
    }

    private void FixedUpdate()
    {
        if (_isLevelFinished == false)
            Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlatformStateChanger platform))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        this.transform.parent = null;
    }

    private void Move()
    {
        _velocity = transform.forward * _speed * Time.deltaTime;
        _body.MovePosition(_body.position + _velocity);

        if (_body.velocity.y < _speedFall)
            IsGrounded = false;
        else
            IsGrounded = true;
    }

    private void OnEndLevel()
    {
        Rotate();
        _isLevelFinished = true;
        _animator.LevelFinished -= OnEndLevel;
    }

    private void Rotate()
    {
        transform.localRotation = _targetRotationAfterFinished;
        _moneyEffect.SetActive(true);
    }
}
