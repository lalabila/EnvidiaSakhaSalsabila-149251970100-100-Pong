using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;
    private float timer;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        rig.velocity = movement;
    }

    public void ActivatePUScaleUp(GameObject gameObject)
    {
        gameObject.transform.localScale += new Vector3(0, gameObject.transform.localScale.y, 0);
    }
    public void DeactivatePUScaleUp(GameObject gameObject)
    {
        gameObject.transform.localScale -= new Vector3(0, gameObject.transform.localScale.y/2, 0);
    }

    public void ActivatePUSpeedPaddle(GameObject gameObject)
    {
        speed *= 2;
    }
    public void DeactivatePUSpeedPaddle(GameObject gameObject)
    {
        speed /= 2;
    }
}
