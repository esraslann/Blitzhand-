using UnityEngine;

public class PoroSpawner : MonoBehaviour
{
    public GameObject spritePrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public int numberOfSpritesToSpawn = 10;
    public float spawnInterval = 1f;

    private float timer = 0f;

    void Update()
    {
        // Zamanlayýcýyý güncelle
        timer += Time.deltaTime;

        // Belirli aralýklarla spawn iþlemini gerçekleþtir
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnSprites();
        }
    }

    void SpawnSprites()
    {
        Vector3 spawnPosition = GetRandomPositionBetween(spawnPoint1.position, spawnPoint2.position);
        SpawnSprite(spawnPosition);
    }

    Vector3 GetRandomPositionBetween(Vector3 position1, Vector3 position2)
    {
        float randomX = Random.Range(position1.x, position2.x);
        float randomY = Random.Range(position1.y, position2.y);
        float randomZ = Random.Range(position1.z, position2.z);

        return new Vector3(randomX, randomY, randomZ);
    }

    void SpawnSprite(Vector3 position)
    {
        GameObject newSpriteObject = Instantiate(spritePrefab, position, Quaternion.identity);
    }
}