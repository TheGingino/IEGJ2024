using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy, spawn, portal;
    public float spawnTime, spawnDelay;


    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {

        spawnDelay -= Time.deltaTime;

        if (spawnDelay <= 0)
        {
            spawnDelay = spawnTime;
            Instantiate(enemy, spawn.transform.position, Quaternion.identity);
        }
    }
}
