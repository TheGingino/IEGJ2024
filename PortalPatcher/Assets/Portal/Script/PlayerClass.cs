using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerClass : CharacterBaseClass
{
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            TakeDamage(2);
            if (health <= 0)
            {
                SceneManager.LoadScene("MainMap");
            }
        }
    }
}
