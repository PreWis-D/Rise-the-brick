using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BonusPlatform : MonoBehaviour
{
    [SerializeField] private int _multiplier;

    public event UnityAction<int> Multiplied;
    public event UnityAction Reached;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlayerMover player))
        {
            Reached?.Invoke();
            Multiplied?.Invoke(_multiplier);
        }
    }
}
