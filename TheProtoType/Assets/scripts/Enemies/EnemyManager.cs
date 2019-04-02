using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public GameObject Gaurd;                // The enemy prefab to be spawned can be changed in game
    public float spawnTime = 5f;            // How long between each spawn can be changed in teh game inspector
    public Transform[] spawnPoints;         


    void Start()
    {
       
        InvokeRepeating("Spawn", spawnTime, spawnTime);  // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time
    }


    void Spawn()
    {
        

        
        int spawnPointIndex = Random.Range(0, spawnPoints.Length); // wil randomly choose a spawn point

        
        Instantiate(Gaurd, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation); // will create teh gaurd in that point
    }
}