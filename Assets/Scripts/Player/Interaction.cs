using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    [Header("Сharacteristics")]
    [Range(0, 100)] public float healthPoint = 100;
    [Range(0, 100)] public float warmPoint = 50;
    [Range(0, 100)] public float hungryPoint = 50;
    private float maxHealthPoint = 100;
    private float maxWarmPoint = 100;
    private float maxHungryPoint = 100;
    private float minHealthPoint = 0;
    private float minWarmPoint = 0;
    private float minHungryPoint = 0;

    [Header("Interface")]
    public TextMeshProUGUI health_text;
    public TextMeshProUGUI warm_text;
    public TextMeshProUGUI hungry_text;

    private float timer = 0;
    private float maxTimer = 5;

    private float damage = 5.0f;
    private float recovery = 4.0f;

    private void Update()
    {
        SecondTimer();
        warmPoint = warmPoint <= minWarmPoint ? minWarmPoint : warmPoint;
        hungryPoint = hungryPoint <= minHungryPoint ? minHungryPoint : hungryPoint;
        hungryPoint = hungryPoint <= minHungryPoint ? minHungryPoint : hungryPoint;
        TextUGUI(health_text, warm_text, hungry_text);
    }

    public void WarmVoid(float distance)
    {
        warmPoint = warmPoint < maxWarmPoint ? warmPoint + distance : warmPoint;
        warmPoint = warmPoint > maxWarmPoint ? maxWarmPoint : warmPoint;
    }

    public void HungryVoid(float hungryRecoveryUnit)
    {
        if (maxHungryPoint - hungryPoint < hungryRecoveryUnit)
        {
            hungryPoint += (maxHungryPoint - hungryPoint);
        } else {
            hungryPoint += hungryRecoveryUnit;
        }
    }

    private void healthVoid()
    {
        if (healthPoint <= maxHealthPoint)
        {
        healthPoint = hungryPoint <= 0 || warmPoint <=0 ? healthPoint-damage : healthPoint+recovery;
        }
        healthPoint = healthPoint > maxHealthPoint ? maxHealthPoint : healthPoint;
    }

    private void SecondTimer()//таймер
    {
        timer = timer >= maxTimer ? 0 : timer;
        if (timer == 0)
        {
            hungryPoint -= 2.0f;
            warmPoint -= 2.0f;
            healthVoid();
        }
        timer += Time.deltaTime;
    }

    private void TextUGUI(TextMeshProUGUI health, TextMeshProUGUI warm, TextMeshProUGUI hungry)//вывод текста на экран
    {
        health.text = healthPoint.ToString();
        warm.text = warmPoint.ToString();
        hungry.text = hungryPoint.ToString();
    }

    private void MinMaxVoid(float minPoint, float maxPoint, float Point)
    {
        
        hungryPoint = hungryPoint <= minHungryPoint ? minHungryPoint : hungryPoint;
        hungryPoint = hungryPoint <= minHungryPoint ? minHungryPoint : hungryPoint;
    }
}
