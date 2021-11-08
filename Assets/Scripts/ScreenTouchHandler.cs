using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenTouchHandler : MonoBehaviour
{
    public event UnityAction Touched;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
            Touched?.Invoke();
    }
}
