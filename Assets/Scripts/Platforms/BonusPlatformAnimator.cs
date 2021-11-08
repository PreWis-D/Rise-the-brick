using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPlatformAnimator : MonoBehaviour
{
    [SerializeField] private BonusPlatform _bonusPlatform;
    [SerializeField] private GameObject _glass;
 
    private Coroutine _animateInJob;
    private float _duration = 2.0f;

    private void Start()
    {
        _glass.SetActive(false);
    }

    private void OnEnable()
    {
        _bonusPlatform.Reached += OnAnimate;
    }

    private void OnDisable()
    {
        _bonusPlatform.Reached -= OnAnimate;
    }

    private void OnAnimate()
    {
        if (_animateInJob != null)
            StopAnimate();

        StartAnimate();
    }

    private IEnumerator Animate(float duration)
    {
            _glass.SetActive(true);

            yield return new WaitForSeconds(duration);

            _glass.SetActive(false);
    }

    private void StartAnimate()
    {
        _animateInJob = StartCoroutine(Animate(_duration));
    }

    private void StopAnimate()
    {
        StopCoroutine(_animateInJob);
    }
}
