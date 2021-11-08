using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerMover _playerMover;
    private const string _animationJumpName = "isGrounded";
    private const string _animationWinDance = "DanceWin";

    public event UnityAction LevelFinished;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        AnimateInAir();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out BonusPlatform platform))
        {
            _animator.SetTrigger(_animationWinDance);
            LevelFinished?.Invoke();
        }
    }

    private void AnimateInAir()
    {
        if (_playerMover.IsGrounded)
            _animator.SetBool(_animationJumpName, true);
        else
            _animator.SetBool(_animationJumpName, false);
    }
}
