using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;
    public int spawnInterval;
    public float despawn;
    private float timer;
    public float magnitude;
    public GameObject rightPaddle;
    public GameObject leftPaddle;

    public List<GameObject> powerUpTemplateList;

    public List<GameObject> powerUpList;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }

        // if()
        // {

        // }
    }


    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);

    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
    public IEnumerator PowerUp (float duration, GameObject paddle)
    {
    Debug.Log("Power up started");
    paddle.GetComponent<PaddleController>().ActivatePUSpeedPaddle(paddle);
    yield return new WaitForSeconds(duration);
    paddle.GetComponent<PaddleController>().DeactivatePUSpeedPaddle(paddle);
    Debug.Log("Power up ended");
    }

    public IEnumerator PowerUpExpand (float duration, GameObject paddle)
    {
    Debug.Log("Power up started");
    paddle.GetComponent<PaddleController>().ActivatePUScaleUp(paddle);
    yield return new WaitForSeconds(duration);
    paddle.GetComponent<PaddleController>().DeactivatePUScaleUp(paddle);
    Debug.Log("Power up ended");
    }

    public void StartTimer(bool isRight)
    {
        if(isRight)
        {
            StartCoroutine(PowerUp(5, rightPaddle));
        }
        else
        {
            StartCoroutine(PowerUp(5, leftPaddle));
        }
    }
    public void StartTimerExpand(bool isRight)
    {
        if(isRight)
        {
            StartCoroutine(PowerUpExpand(5, rightPaddle));
        }
        else
        {
            StartCoroutine(PowerUpExpand(5, leftPaddle));
        }
    }
}
