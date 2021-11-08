using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;

    public int Count { get; private set; } = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out PlayerMover player))
        {
            ActivateParticle();
            this.gameObject.SetActive(false);
        }
    }

    private void ActivateParticle()
    {
        Instantiate(_deathEffect, transform.position, Quaternion.identity);
    }
}
