using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region variables
    public static GameController instance;
    public GameObject platformPrefab;
    public Transform platforms;
    public static int multiplier = 1;
    int lastSpawnPoint = 0;
    int next = 10;

    #endregion

    public GameOverScreen GameOverScreen;
    int maxPlatform = 0;

    public void GameOver() {
        GameOverScreen.Setup(maxPlatform);
    }


    private void Awake() {
        instance = this;
    }
    void Start()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms() {
        for (int i = 0; i < 20; i++) {
            GameObject go = Instantiate(platformPrefab, platforms);
            go.transform.localPosition = new Vector3(Random.Range(-5f, 5f), i * 3, 0);
            go.GetComponent<SpriteRenderer>().size = new Vector2(Random.Range(3f, 5f), 0.82f);
            go.name = "P" + i.ToString();
        }
        lastSpawnPoint = 20;
    }
    void Spawn10More() {
        for (int i = lastSpawnPoint; i < lastSpawnPoint + 10; i++) {
            GameObject go = Instantiate(platformPrefab, platforms);
            go.transform.localPosition = new Vector3(Random.Range(-5f, 5f), i * 3, 0);
            go.GetComponent<SpriteRenderer>().size = new Vector2(Random.Range(3f, 5f), 0.82f);
            go.name = "P" + i.ToString();
        }
        lastSpawnPoint += 10;
    }
    public void TouchedPlatform(string name) {
        int platform = int.Parse(name.Substring(1));
        if (platform + 1 > maxPlatform) {
            maxPlatform = platform + 1;
            //score.text = maxPlatform.ToString();
        }
        if (platform >= next) {
            next += 10;
            Spawn10More();
        }
    }


    
}
