using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PowerUpTimer : MonoBehaviour
{
    public float Duration;
    public Action OnDeactivate;

    void Update()
    {
        Timer();
    }

    public void Timer()
    {
        if (Duration >= 5)
        {
            OnDeactivate();
            Destroy(this);
        }
        Duration += Time.deltaTime;
    }
}
