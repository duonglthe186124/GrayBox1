using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private PlayerCombat combat;

    

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        combat = GetComponent<PlayerCombat>();
       
    }


    void OnEnable()
    {
        combat.OnAttack += PlayAttackAnimation;
    }

    void OnDisable()
    {
        
        combat.OnAttack -= PlayAttackAnimation;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = rb.linearVelocity.x;

        if (Mathf.Abs(moveX) < 0.1f)
        {
            moveX = 0f;
        }


        animator.SetFloat("MoveX", moveX);
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }   
}
