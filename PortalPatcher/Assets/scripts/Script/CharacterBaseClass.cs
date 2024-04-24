using UnityEngine;

public abstract class CharacterBaseClass : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    public int health;

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
    }

    public virtual void Heal(int healAmount)
    {
        health += healAmount;
    }
}
