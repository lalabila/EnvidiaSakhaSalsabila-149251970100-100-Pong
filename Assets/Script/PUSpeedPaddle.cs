using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedPaddle : MonoBehaviour
{
    public Collider2D ball;
    public BallController ballCon;
    public GameObject rightPaddle;
    public GameObject leftPaddle;
    public PowerUpManager manager;
    private float timer;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider == ball)
        {
            manager.StartTimer(ballCon.isRight);
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
