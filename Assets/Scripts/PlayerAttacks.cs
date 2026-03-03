using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public Animator Animator;
    public Transform AtkPoint;
    public float range = 1;
    public LayerMask enemyLayer;
    public int defaultDamage = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DefaultAttack()
    {
        Debug.Log("Attack Triggered");
        Animator.SetBool("Attacking", true);
        
    }

    void DealDefaultDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(AtkPoint.position, range, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<BaseEnemyHealth>().TakeDamage(defaultDamage);

        }
    }

    public void FinishAttack()
    {
        Animator.SetBool("Attacking", false);
    }
}
