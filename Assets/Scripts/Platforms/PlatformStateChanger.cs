using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformStateChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private ScreenTouchHandler _touchHandler;
    [SerializeField] private PlatformCollisionChecker _cheker;
    [SerializeField] private float _height;

    private void OnEnable()
    {
        _touchHandler.Touched += OnPlatformStretched;
    }

    private void OnDisable()
    {
        _touchHandler.Touched -= OnPlatformStretched;
    }

    private void OnPlatformStretched()
    {
        if (_cheker.IsReached)
        {
            transform.localScale += new Vector3(0, _height * Time.deltaTime, 0);

            if (_audioSource.isPlaying == false)
                _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }
}
