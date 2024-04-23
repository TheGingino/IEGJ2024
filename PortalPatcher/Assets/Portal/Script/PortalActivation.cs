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
        for (int i = 0; i < portal.Length; i++)
        {
            yield return new WaitForSeconds(activationTime);
            portal[i].SetActive(true);
        }
    }
}
