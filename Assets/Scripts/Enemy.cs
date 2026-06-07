using UnityEngine;

[RequireComponent(typeof(EntityStats))]
public class Enemy : MonoBehaviour, IDamageable
{
    private EntityStats stats;
    private Animator anim;

    void Awake()
    {
        stats = GetComponent<EntityStats>();
        anim = GetComponent<Animator>();
     }

   
    public void TakeDamage(float amount)
    {
        stats.ModifyHealth(-amount);
        Debug.Log("Enemy has been hit: " + amount + " HP");

        if (anim != null)
        {
            anim.SetTrigger("TakeHit");
        }
    }
}
