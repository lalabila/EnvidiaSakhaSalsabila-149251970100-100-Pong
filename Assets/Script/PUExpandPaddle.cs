using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUExpandPaddle : MonoBehaviour
{
    public Collider2D ball;
    public BallController ballCon;
    public PowerUpManager manager;
    private float timer;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider == ball)
        {
            manager.StartTimerExpand(ballCon.isRight);
            manager.RemovePowerUp(gameObject);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > manager.despawn)
        {
            manager.RemovePowerUp(gameObject);
        }
        
    }
}
