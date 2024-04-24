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
    private bool closingPortal;
    private int ritualTimer;
    private GameObject despawningEnemy;
    private GameObject activePortal;
    private GameObject activeBook;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
            {
                if (!bookIsSpawned && hit.transform)
                {
                    bookIsSpawned = true;
                    bookspawn = transform.position + transform.forward * 1 - transform.up * 1 / 2;
                    Instantiate(book, bookspawn, transform.rotation);
                    activeBook = GameObject.FindWithTag("activebook");
                    ritualTimer = 200;

                    if (hit.transform.tag == "enemy")
                    {
                        closingPortal = false;
                        despawningEnemy = hit.transform.gameObject;
                    }
                    if (hit.transform.tag == "portal")
                    {
                        closingPortal = true;
                        activePortal = hit.transform.gameObject;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        if (bookIsSpawned)
        {
            if (ritualTimer > 0)
            {
                ritualTimer--;
            }
            else
            {
                if (closingPortal)
                {
                    activePortal.SetActive(false);
                }
                if (!closingPortal)
                {
                    Destroy(despawningEnemy);
                }

                bookIsSpawned = false;
                Destroy(activeBook);
            }
        }

    }
}