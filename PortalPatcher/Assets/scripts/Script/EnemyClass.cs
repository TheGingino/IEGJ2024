using UnityEngine;

public class EnemyClass : CharacterBaseClass
{
    public virtual void EnemySound(AudioSource enemySound)
    {
        enemySound.Play();
    }

}
