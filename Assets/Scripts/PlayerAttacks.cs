using System.Collections;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DefaultAttack()
    {
        Animator.SetBool("Attacking", true);
        
    }

    public void HeavyAttack()
    {

        if (Shop.heavyOwned > 0)
        {
            Animator.SetBool("HeavyAttacking", true);
            Shop.heavyOwned--;
        }

    }

    public void HealthMove()
    {
        if (Shop.healthOwned > 0)
        {
            ServerHealth.SetHealth();
            Shop.healthOwned--;
        }
        
        
    }
    public void FreezeMove()
    {

        if (Shop.freezeOwned > 0)
        {
            StartCoroutine(FreezeMobs(5f));
            Shop.freezeOwned--;
        }
        

    }

    public void EarthQuakeMove()
    {
        if (Shop.quakeOwned > 0)
        {
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

    public void RangedMove()
    {

        if (Shop.rangeOwned > 0)
        {
            shootDirection();
            fireAttack();
            Shop.rangeOwned--;
        }


    }



    void DealDefaultDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(AtkPoint.position, range, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<DefaultEnemy>().TakeDamage(defaultDamage);

        }
    }

    void DealHeavyDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(AtkPoint.position, range, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<DefaultEnemy>().TakeDamage(heavyDamage);

        }
    }

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
    public void fireAttack()
    {
        RangedAttack rangedMove = Instantiate(rangedAttackPrefab, RangedPoint.position, Quaternion.identity).GetComponent<RangedAttack>();
        rangedMove.attackDirection = attackDirection;
    }

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


    

    public void FinishAttack()
    {
        Animator.SetBool("Attacking", false);
    }

    public void FinishHeavyAttack()
    {
        Animator.SetBool("HeavyAttacking", false);
    }
}
