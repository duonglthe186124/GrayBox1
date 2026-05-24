using UnityEngine;
using UnityEngine.UI;   

public class FloatingUI : MonoBehaviour
{
    public EntityStats targetStats;
    public Image healthBarFill;
    public Image staminaBarFill;

    void OnEnable()
    {
        if (targetStats != null)
        {
            targetStats.OnHealthChanged += UpdateHealth;
            targetStats.OnStaminaChanged += UpdateStamina;
        }
    }

    void OnDisable()
    {
        if (targetStats != null)
        {
            targetStats.OnHealthChanged -= UpdateHealth;
            targetStats.OnStaminaChanged -= UpdateStamina;
        }
    }

    void UpdateHealth(float current, float max)
    {
        if (healthBarFill != null) healthBarFill.fillAmount = current / max;
    }

    void UpdateStamina(float current, float max)
    {
        if (staminaBarFill != null) staminaBarFill.fillAmount = current / max;
    }
}
