using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    BasicMovement playerScript;
    Vector2 targetPosition;

    public float speed;
    public int damage;
    
    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BasicMovement>();
        targetPosition = playerScript.transform.position;
    }


    private void Update()
    {
         
        if (Vector2.Distance(transform.position, targetPosition) > .1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        } else {
            Destroy(gameObject);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }

    }

}
