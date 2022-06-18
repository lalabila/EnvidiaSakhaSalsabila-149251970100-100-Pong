using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;
    public PowerUpManager manager;
    private Rigidbody2D rig;
    public bool isRight;
        
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
        Direction();
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
        rig.velocity = speed;
        manager.RemoveAllPowerUp();
        Direction();
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Right Paddle")
        {
            isRight = true;
        }
        else    
        {
            isRight = false;
        }
    }
    public void Direction()
    {
        int direction;
        direction = Random.Range(0, 2);
        if(direction == 0)
        {
            rig.velocity = new Vector2(4f, -2f);
        }
        else
        {
            rig.velocity = new Vector2(-4f, 2f);
        }
    }
}
