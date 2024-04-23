using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class player_interact : MonoBehaviour
{
    [SerializeField]
    private GameObject book;

    private Vector3 bookspawn;
    private bool bookIsSpawned;
    private int ritualTimer;
    private GameObject despawningEnemy;
    private GameObject activeBook;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 100f))
            {
                if (hit.transform.tag == "enemy" && !bookIsSpawned)
                {
                    despawningEnemy = hit.transform.gameObject;
                    bookIsSpawned = true;
                    bookspawn = transform.position + transform.forward * 1 - transform.up * 1 / 2;
                    Instantiate(book, bookspawn, transform.rotation);
                    activeBook = GameObject.FindWithTag("activebook");
                    ritualTimer =   200;
                }
                
            }
        }
        if (bookIsSpawned == true)
        {
            if (ritualTimer > 0)
            {
                ritualTimer--;
            }
            else
            {
                bookIsSpawned = false;
                Destroy(despawningEnemy);
                Destroy(activeBook);
            }
        }

    }
}