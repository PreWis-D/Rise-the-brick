using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollisionChecker : MonoBehaviour
{
    private bool _isReached = false;

    public bool IsReached => _isReached;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlayerMover player))
            _isReached = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _isReached = false;
    }
}
