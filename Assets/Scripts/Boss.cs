using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : Enemy {

    public float stopDistance;
    public GameObject bossProjectile;
    public Transform shotPoint;
    float attackTime;
    Animator animation;
    private int nextScene;

    public override void Start()
    {
        base.Start();
        animation = GetComponent<Animator>();
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;

    }

    private void Update()
    {
        if (player != null)
        {
            transform.right = player.position - transform.position;

            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            if (Time.time >= attackTime)
            {
                attackTime = Time.time + timeBetweenAttacks;
                animation.SetTrigger("attack");
            }

        }
    }

    public override void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(nextScene);
        }

    }

    public void RangedAttack () {

        if (player != null)
        {

            Vector2 direction = player.position - shotPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
            shotPoint.rotation = rotation;

            Instantiate(bossProjectile, shotPoint.position, shotPoint.rotation);

        }

    }

}