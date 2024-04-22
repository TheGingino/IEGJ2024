using System.Collections;
using UnityEngine;

public class PortalActivation : MonoBehaviour
{
    [SerializeField] private GameObject[] portal;
    public float activationTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPortal());
    }

    IEnumerator SpawnPortal()
    {
        yield return new WaitForSeconds(3);
        portal[0].SetActive(true);
        yield return new WaitForSeconds(activationTime);
        portal[1].SetActive(true);
        yield return new WaitForSeconds(activationTime);
        portal[2].SetActive(true);
        yield return new WaitForSeconds(activationTime);
        portal[3].SetActive(true);
    }
}
