using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public Collider2D ball;
    public PowerUpManager manager; 
    public float magnitude;
    private float timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
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
