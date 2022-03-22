using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public Text pourcentageText;
    public GameObject HealthObject;
    public HealthBar healthBar;
    public bool IsAlive = true;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (currentHealth < 1)
        {
            IsAlive = false;
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        pourcentageText.text = currentHealth + "%";
        healthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        pourcentageText.text = "100%";
    }
}
