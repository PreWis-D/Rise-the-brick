using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMaterialSetter : MonoBehaviour
{
    [SerializeField] private PlatformCollisionChecker _cheker;
    [SerializeField] private Material[] _materials;

    private int _defaultMaterialNumber = 0;
    private int _goldMaterialNumber = 1;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        _renderer.enabled = true;
        _renderer.sharedMaterial = _materials[_defaultMaterialNumber];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlayerMover player))
            _renderer.sharedMaterial = _materials[_goldMaterialNumber];
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlayerMover player))
            _renderer.sharedMaterial = _materials[_defaultMaterialNumber];
    }
}
