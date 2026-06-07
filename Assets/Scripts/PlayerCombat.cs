using UnityEngine;
using System;

[RequireComponent(typeof(EntityStats))]
public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.8f;
    public float attackDamage = 20f;
    public float staminaCostPerAttack = 25f;
    public LayerMask enemyLayers;

    private EntityStats stats;
    public event Action OnAttack;

    void Awake()
    {
        stats = GetComponent<EntityStats>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) 
        {
            Attack();
        }
    }

    void Attack()
    {
        if (!stats.UseStamina(staminaCostPerAttack)) return;

        OnAttack?.Invoke();

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            
            IDamageable damageable = enemy.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(attackDamage);
            }
        }
    }

    
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
