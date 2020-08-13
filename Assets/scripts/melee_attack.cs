using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_attack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackpos;
    public LayerMask whatIsEnemy;
    public float attackRangex;
    public float attackRangeY;
    public int damage;
    public Animator anim;
    public GameObject trails;
    public Transform trailposition;

    private void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject a = Instantiate(trails, trailposition) as GameObject;
                Destroy(a, 0.5f);
                anim.SetTrigger("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackpos.position, new Vector2(attackRangex,attackRangeY),0, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackpos.position,new Vector3(attackRangex,attackRangeY,1)) ;
    }

}
