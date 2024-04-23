using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerClass : CharacterBaseClass
{
    [SerializeField] private UI_Health lives;
    [SerializeField] private int damageTake;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //lives.DecreaseLives(1);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            TakeDamage(damageTake);
            lives.DecreaseLives(damageTake);
            if (health <= 0)
            {
                SceneManager.LoadScene("MainMap");
            }
        }
    }
}
