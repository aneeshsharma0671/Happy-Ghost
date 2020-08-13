using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public GameObject enemy;
    public GameObject player ;
    public GameObject Spiderblood;
    public Transform body;
    public float damage = 10f;
    private float dazedtime;
    public float startdazedtime;

    private void Start()
    {
        player =  GameObject.Find("ghost");
    }
    private void Update()
    {
        if(health <= 0f)
        {
            Destroy(enemy);
        }
        if(dazedtime<=0)
        {
            enemy.GetComponent<SpiderMovement>().runspeed = 20;
        }else
        {
            enemy.GetComponent<SpiderMovement>().runspeed = 0;
            dazedtime -= Time.deltaTime;
        }
    }
    public void TakeDamage(int Damage)
    {
        dazedtime = startdazedtime;
        // hurt sound
        GameObject a = Instantiate(Spiderblood) as GameObject;
        a.transform.position = body.position;
        Destroy(a,2f);
        health -= Damage;
        Debug.Log("Damage Taken!");
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            player.GetComponent<Player>().TakeDamage(damage);
            Debug.Log("collide");
        }
    }
}
