using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    //Encapsulator
    //Variables
    [SerializeField] private int _maxHealth = 100;

    public int MaxHealth => _maxHealth;

    [HideInInspector] public int CurrentHealth { get; private set; }

    public bool IsDead => CurrentHealth <= 0;

    public UnityEvent<int> OnDamaged;
    public UnityEvent OnDied;

    //setters
    public void TakeDamage(int amount)
    {
        if (IsDead) return;

        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0);
        OnDamaged?.Invoke(amount);

        if (IsDead)
        {
            OnDied?.Invoke();
            //Handle Death :).
        }
    }

    public void Heal(int amount)
    {
        if (IsDead) return;
        {
            CurrentHealth = Mathf.Min(CurrentHealth + amount, _maxHealth);
        }
    }
}
