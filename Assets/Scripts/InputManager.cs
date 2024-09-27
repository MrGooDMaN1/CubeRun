using System;
using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action<float> OnOneFingerScreenTouched;
    public static event Action OnTwoFingerScreenTouched;

    private void Update()
    {
        if (Input.touchCount == 1)
            OnOneFingerScreenTouched?.Invoke(Input.GetTouch(0).position.x);

        if (Input.touchCount == 2)
            OnTwoFingerScreenTouched?.Invoke();
    }
}
