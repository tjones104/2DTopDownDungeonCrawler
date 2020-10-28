using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int currentHealth = 60;
    public int maximumHealth = 60;

    public float damage;

    public RectTransform frameRT;
    public RectTransform fillRT;
    public Image fillImage;

    public void TakeTenDamage()
    {
        if (currentHealth >= 0)
        {
            currentHealth -= 10;
            SetFill((float)currentHealth/maximumHealth);
        }
    }

    public void SetFill(float percentage)
    {
        if(currentHealth > 20)
        {
            damage = (Mathf.Ceil(percentage / 0.05f) * 0.05f);
            fillImage.DOFillAmount(damage, .7f);
        }
        else
        {
            damage = (Mathf.Ceil(percentage / 0.05f) * 0.05f);
            fillImage.DOFillAmount(damage - 0.05f, .7f);
        }
    }
}
