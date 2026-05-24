using System;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 15f;

    // Các event để UI đăng ký lắng nghe
    public event Action<float, float> OnHealthChanged;
    public event Action<float, float> OnStaminaChanged;

    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    void Update()
    {
        RegenStamina();
    }

    public void ModifyHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0) Die();
    }

    public bool UseStamina(float amount)
    {
        if (currentStamina >= amount)
        {
            currentStamina -= amount;
            OnStaminaChanged?.Invoke(currentStamina, maxStamina);
            return true; // Đủ stamina và đã trừ
        }
        return false; // Không đủ stamina
    }

    private void RegenStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Min(currentStamina, maxStamina);
            OnStaminaChanged?.Invoke(currentStamina, maxStamina);
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject); // Tạm thời xóa object khi chết
    }
}
