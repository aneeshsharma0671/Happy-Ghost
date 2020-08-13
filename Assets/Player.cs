using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform axe;
    public Transform body;
    private float direction;
    public float health = 100f;
    public Transform healthbar;



    public void TakeDamage(float damage)
    {
        direction = body.position.x - axe.position.x;
        GetComponent<Rigidbody2D>().AddForce(new Vector2 (direction*100,10),ForceMode2D.Impulse);
        health -= damage;
        healthbar.localScale -= new Vector3 (0.1f,0,0);
        if(health < 0f)
        {
            Destroy(gameObject);
        }
        Debug.Log(health);
    }
}
