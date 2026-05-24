using UnityEngine;

[RequireComponent(typeof(EntityStats))]
public class Enemy : MonoBehaviour, IDamageable
{
    private EntityStats stats;

    void Awake()
    {
        stats = GetComponent<EntityStats>();
    }

   
    public void TakeDamage(float amount)
    {
        stats.ModifyHealth(-amount);
        Debug.Log("Enemy has been hit: " + amount + " HP");
    }
}
