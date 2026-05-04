using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //sets variables
    public Slider healthBar;
    public Gradient Gradient;
    public Image image;

    //sets the healthbars max
    public void MaxHealthBar(int health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;

        image.color = Gradient.Evaluate(1f);
    }

    //changes the health bars colour as it goes down
    public void ChangeHealthBar(int health)
    {
        healthBar.value = health;

        image.color= Gradient.Evaluate(healthBar.normalizedValue);
    }
}
