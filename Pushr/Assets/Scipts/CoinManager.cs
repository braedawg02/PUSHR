using UnityEngine;
using UnityEngine.EventSystems;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;  // Drag your coin prefab here in the inspector
    public Transform spawnArea;    // Set the parent tray area
    public float moveSpeed = 1f;   // Movement speed
    public float minX = -1f;       // Minimum spawn position
    public float maxX = 1f;        // Maximum spawn position

    private bool movingLeft = false;
    private bool movingRight = false;

    private void Update()
    {
        // Move while holding down the button
        if (movingLeft)
        {
            MoveLeft();
        }
        if (movingRight)
        {
            MoveRight();
        }
    }

    public void MoveLeft()
    {
        Vector3 position = spawnArea.position;
        position.x = Mathf.Max(minX, position.x - moveSpeed * Time.deltaTime);
        spawnArea.position = position;
    }

    public void MoveRight()
    {
        Vector3 position = spawnArea.position;
        position.x = Mathf.Min(maxX, position.x + moveSpeed * Time.deltaTime);
        spawnArea.position = position;
    }

    // Called when the left button is pressed
    public void StartMovingLeft()
    {
        movingLeft = true;
    }

    // Called when the left button is released
    public void StopMovingLeft()
    {
        movingLeft = false;
    }

    // Called when the right button is pressed
    public void StartMovingRight()
    {
        movingRight = true;
    }

    // Called when the right button is released
    public void StopMovingRight()
    {
        movingRight = false;
    }

    public void SpawnCoin()
    {
        Instantiate(coinPrefab, spawnArea.position, Quaternion.Euler(91, 0, 0));
    }

    public void PauseGame()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;  // Toggles pause
    }
}
