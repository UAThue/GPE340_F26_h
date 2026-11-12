using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public UnityEvent OnHeal;
    public UnityEvent OnTakeDamage;

    /// <summary>
    /// Heal the pawn for a given amount of health
    /// </summary>
    /// <param name="amount">The amount of health to heal</param>
    public void Heal (float amount)
    {
        // Add to health without going over Max
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        // Do whatever our designers have added to the heal
        OnHeal.Invoke();
    }

    /// <summary>
    /// Returns the percentage (0 to 1) of health this pawn has
    /// </summary>
    /// <returns>Percent of Health (0 to 1)</returns>
    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Causes the pawn to take damage for a given amount
    /// </summary>
    /// <param name="amount">Amount of damage to take</param>
    public void TakeDamage ( float amount )
    {
        // Subtract from health without going under 0
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        // Also do anything our designers have added when taking damage!
        OnTakeDamage.Invoke();
    }
}
