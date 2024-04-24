using UnityEngine;

public class WalkingEnemy : EnemyClass
{
    //public FollowingPlayer followPlayer;
    [SerializeField] private AudioSource enemySound;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        //followPlayer.FollowPlayer();
        //EnemySound(enemySound);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(1);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
