using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollectorManager : MonoBehaviour
{
    public Transform player;
    public GameObject prefabToSpawn;
    public SpriteRenderer spawnAreaSprite;
    public float minimumDistanceOfSeparation;
    public int maxPrefabsSpawned;
    [Range(0f,1f)] public float changeProbability;

    private List<Transform> spawnedPrefabs = new List<Transform>();
    private float spawnRadius;

    public static CollectorManager instance;

    private void Awake()
    {
        if ((instance != null && instance != this))
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Obtiene el radio del sprite circular.
        spawnRadius = spawnAreaSprite.bounds.extents.x - 100f;

        SpawnPrefabsRandomly();
    }

    void Update()
    {
        
    }

    void SpawnPrefabsRandomly()
    {
        while (spawnedPrefabs.Count < maxPrefabsSpawned)
        {
            // Genera una posici�n aleatoria dentro del �rea circular del sprite.
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = new Vector3(randomPosition.x, randomPosition.y, 0f) + spawnAreaSprite.transform.position;

            // Comprueba si la posici�n est� lo suficientemente lejos del jugador y otros objetos.
            if (IsPositionValid(spawnPosition))
            {
                // Crea el prefab en la posici�n v�lida.
                Transform newPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity).transform;
                spawnedPrefabs.Add(newPrefab);
            }
        }
    }

    bool IsPositionValid(Vector3 position)
    {
        // Comprueba si la posici�n est� lo suficientemente lejos del jugador.
        if (Vector3.Distance(position, player.position) < minimumDistanceOfSeparation)
        {
            return false;
        }

        // Comprueba si la posici�n est� lo suficientemente lejos de otros prefabs.
        foreach (Transform prefab in spawnedPrefabs)
        {
            if(prefab != null)
            {
                if (Vector3.Distance(position, prefab.position) < minimumDistanceOfSeparation)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static void ChangePrefabPositions()
    {
        if(Random.Range(0f, 1f) < instance.changeProbability)
        {
            foreach (Transform prefab in instance.spawnedPrefabs)
            {
                if (prefab != null)
                {
                    Vector3 newPosition = new Vector3(0, 0, 0);
                    bool validPositionFound = false;

                    // Intenta encontrar una posici�n v�lida hasta que se encuentre una.
                    while (!validPositionFound)
                    {
                        Vector2 randomOffset = Random.insideUnitCircle * instance.spawnRadius;
                        newPosition = new Vector3(randomOffset.x, randomOffset.y, 0f) + instance.spawnAreaSprite.transform.position;

                        // Comprueba si la nueva posici�n est� lo suficientemente lejos del jugador y otros prefabs.
                        if (instance.IsPositionValid(newPosition))
                        {
                            validPositionFound = true;
                        }
                    }

                    // Establece la nueva posici�n del prefab.
                    prefab.position = newPosition;
                }
            }
        }
    }
}