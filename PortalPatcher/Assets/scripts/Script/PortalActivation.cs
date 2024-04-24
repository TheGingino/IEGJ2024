using System.Collections;
using UnityEngine;

public class PortalActivation : MonoBehaviour
{
    [SerializeField] private GameObject[] portal;
    public float activationTime;
    public float spawnTime, spawnDelay;

    Vector3 spawnPosition;

    private void Start()
    {
        spawnDelay = spawnTime;
    }
    private void Update()
    {
        StartCoroutine(SpawnPortal());
        spawnDelay -= Time.deltaTime;
    }

    IEnumerator SpawnPortal()
    {
        spawnPosition = new Vector3(Random.Range(-20, 20), 1, Random.Range(-20, 20));

        for (int i = 0; i < portal.Length; i++)
        {
            if (spawnDelay <= 0)
            {
                spawnDelay = spawnTime;
                yield return new WaitForSeconds(activationTime);
                Instantiate(portal[i], spawnPosition, Quaternion.identity);
            }
        }
    }
}
