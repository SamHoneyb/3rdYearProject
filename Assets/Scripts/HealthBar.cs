using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthBar;
    public Gradient Gradient;
    public Image image;

    public void MaxHealthBar(int health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;

        image.color = Gradient.Evaluate(1f);
    }

    public void ChangeHealthBar(int health)
    {
        healthBar.value = health;

        image.color= Gradient.Evaluate(healthBar.normalizedValue);
    }
}
