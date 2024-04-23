using UnityEngine;

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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(2);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
