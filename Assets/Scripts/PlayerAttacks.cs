using System.Collections;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    //sets variables
    public Animator Animator;
    public Transform AtkPoint;
    public Transform RangedPoint;
    public ServerHealth ServerHealth;
    public EnemySpawner EnemySpawner;
    public float range = 1;
    public LayerMask enemyLayer;
    public int defaultDamage = 1;
    public int heavyDamage = 3;
    public Shop Shop;
    public GameObject rangedAttackPrefab;
    public Vector2 attackDirection = Vector2.right;
    public RangedAttack RangedAttack;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Shop = FindObjectOfType<Shop>();
    }

    //sets the attacking animation to run
    public void DefaultAttack()
    {
        Animator.SetBool("Attacking", true);
        
    }

    //sets the attacking animation to run and takes one of the heavy owned when used
    public void HeavyAttack()
    {

        if (Shop.heavyOwned > 0)
        {
            Animator.SetBool("HeavyAttacking", true);
            Shop.heavyOwned--;
        }

    }

    //uses the health move and takes one from the users total
    public void HealthMove()
    {
        if (Shop.healthOwned > 0)
        {
            ServerHealth.SetHealth();
            Shop.healthOwned--;
        }
        
        
    }

    //uses the freeze move
    public void FreezeMove()
    {

        if (Shop.freezeOwned > 0)
        {
            StartCoroutine(FreezeMobs(5f));
            Shop.freezeOwned--;
        }
        

    }

    //uses the quake move
    public void EarthQuakeMove()
    {
        if (Shop.quakeOwned > 0)
        {
            //deals 3 damage to all spawned enmies
            foreach (GameObject newEnemy in EnemySpawner.spawnedEnemies)
            {
                if (newEnemy != null)
                {
                    newEnemy.GetComponent<DefaultEnemy>().TakeDamage(3);

                }
            }

            Shop.quakeOwned--;
        }

    }

    //uses the range move
    public void RangedMove()
    {

        if (Shop.rangeOwned > 0)
        {
            shootDirection();
            fireAttack();
            Shop.rangeOwned--;
        }


    }

    //deals damage to the enemy closest to the player
    void DealDefaultDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(AtkPoint.position, range, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<DefaultEnemy>().TakeDamage(defaultDamage);

        }
    }

    //deals heavy damage to the enemy closest to the player
    void DealHeavyDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(AtkPoint.position, range, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<DefaultEnemy>().TakeDamage(heavyDamage);

        }
    }

    //freezes enemies for a period of time
    IEnumerator FreezeMobs (float seconds)
    {
        foreach(GameObject newEnemy in EnemySpawner.spawnedEnemies)
        {
            if(newEnemy != null)
            {
                newEnemy.GetComponent<DefaultEnemy>().Freeze();
            }
        }

        yield return new WaitForSeconds(seconds);

        foreach (GameObject newEnemy in EnemySpawner.spawnedEnemies)
        {
            if (newEnemy != null)
            {
                newEnemy.GetComponent<DefaultEnemy>().UnFreeze();
            }
        }

    }
    //sets the direction of the attack and then fires the bullet 
    public void fireAttack()
    {
        RangedAttack rangedMove = Instantiate(rangedAttackPrefab, RangedPoint.position, Quaternion.identity).GetComponent<RangedAttack>();
        rangedMove.attackDirection = attackDirection;
    }

    //stores the shoot direction
    public void shootDirection()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        if (Horizontal != 0 || Vertical != 0)
        {
            attackDirection = new Vector2(Horizontal, Vertical).normalized;
            
        }
        else
        {
            
        }
    }

    //stops animations
    public void FinishAttack()
    {
        Animator.SetBool("Attacking", false);
    }

    public void FinishHeavyAttack()
    {
        Animator.SetBool("HeavyAttacking", false);
    }
}
