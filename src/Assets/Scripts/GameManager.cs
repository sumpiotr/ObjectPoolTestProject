using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private Transform bulletsContainer;

    [SerializeField]
    private Transform enemiesContainer;

    public GameObject player;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Texture2D cursorTexture;

    public FixedSizePool bulletPool;
    public FixedSizePool enemyPool;

    public float enemiesSpeed;
    private uint score;

    private uint pointsToNextLevel;
    private float spawnRate;
    float enemySizeX;

    public static GameManager gameManager = null;

    void Start()
    {
        if (gameManager != null)
        {
            Destroy(gameObject);
            return;
        }
        gameManager = this;
        bulletPool = new FixedSizePool(10, bulletPrefab, bulletsContainer);
        enemyPool = new FixedSizePool(5, enemyPrefab, enemiesContainer);
        enemiesSpeed = 4f;
        score = 0;
        pointsToNextLevel = 1000;
        spawnRate = 1;
        enemySizeX = enemyPrefab.GetComponent<SpriteRenderer>().bounds.extents.x;
        StartCoroutine("SpawnEnemyCoroutine");
        Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2, cursorTexture.height / 2), CursorMode.ForceSoftware);
    }

    private void SpawnEnemy() 
    {
        Camera camera = Camera.main;
        enemyPool.SpawnObject(new Vector2(Random.Range(camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - enemySizeX, camera.ScreenToWorldPoint(new Vector2(0, 0)).x + enemySizeX), camera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y));
    }

    private IEnumerator SpawnEnemyCoroutine() 
    {
        yield return new WaitForSeconds(spawnRate);
        SpawnEnemy();
        StartCoroutine("SpawnEnemyCoroutine");
    }

    public void AddPoints(uint points) 
    {
        score += points;
        scoreText.text = $"SCORE: {score}";
        if(score > pointsToNextLevel) 
        {
            pointsToNextLevel += pointsToNextLevel + 500;
            enemiesSpeed += 0.3f;
            spawnRate = spawnRate > 0.5 ? spawnRate - 0.1f : spawnRate;
        }
    }


    public void End() 
    {
        PointsInfo.info.points = score;
        PointsInfo.info.endScene = true;
        SceneManager.LoadScene(0);
    }
}
