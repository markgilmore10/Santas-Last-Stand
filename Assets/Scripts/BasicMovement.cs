using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    public int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private TransitionPanel sceneTransitions;
    private int nextScene;
    
    public void Start() {
        if (SceneManager.GetActiveScene().buildIndex == 2) {
            nextScene = SceneManager.GetActiveScene().buildIndex + 3;
        } else if (SceneManager.GetActiveScene().buildIndex == 3) {
            nextScene = SceneManager.GetActiveScene().buildIndex + 2;
        } else {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        }
    }
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + movement * Time.deltaTime * 60;

        
    }

     public void TakeDamage (int damageAmount) 
    {
        health -= damageAmount;
        UpdateHealthUI(health);
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(nextScene);
        }
    }

    void UpdateHealthUI(int currentHealth) {

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

        }

    }
}
