using UnityEngine;

public class player_interact : MonoBehaviour
{
    [SerializeField]
    private GameObject book;

    [SerializeField]
    private ParticleSystem magic;

    private Vector3 bookspawn;
    private bool bookIsSpawned;
    private bool closingPortal;
    private float ritualTimer;
    private GameObject despawningEnemy;
    private GameObject activePortal;
    private GameObject activeBook;
    private GameObject activeParticle;
    [SerializeField] AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
            {
                if (!bookIsSpawned && hit.transform.tag == "enemy" || !bookIsSpawned
&& hit.transform.tag == "portal")
                {
                    bookIsSpawned = true;
                    bookspawn = transform.position + transform.forward * 1 - transform.up * 1 / 2;

                    Instantiate(book, bookspawn, transform.rotation, gameObject.transform);
                    Instantiate(magic, bookspawn, transform.rotation, gameObject.transform);

                    activeBook = transform.GetChild(3).gameObject;
                    activeParticle = transform.GetChild(4).gameObject;

                    ritualTimer = 4;

                    audioSource.Play();

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
                ritualTimer = ritualTimer - 1 * Time.deltaTime;
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
                Destroy(activeParticle);
            }
        }

    }
}