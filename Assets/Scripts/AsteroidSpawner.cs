using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid AsteroidPrefab;
    public float SpawnRate = 3.0f;
    public int SpawnAmount = 2;
    public float SpawnDistance = 16.0f;
    public float AsteroidTrajectoryVariance = 15.0f;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.SpawnRate, this.SpawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < this.SpawnAmount; i++)
        {

            Vector3 spawnDirection = Random.insideUnitCircle.normalized * SpawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.AsteroidTrajectoryVariance, this.AsteroidTrajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.AsteroidPrefab, spawnPoint, rotation);
            asteroid.AsteroidSize = Random.Range(asteroid.MinSize, asteroid.MaxSize);
            asteroid.setTrajectory(rotation * -spawnDirection);
        }
    }

}
