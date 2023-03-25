using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : MonoBehaviour
{
    [Header("Activation radius")]
    public float radiusAction = 10.0f;

    [Header("Player")]
    public GameObject player;
    [SerializeField] private Interaction _interaction;

    private float timer = 0;
    private float maxTimer = 2;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _interaction = player.GetComponent<Interaction>();
    }

    private void Update()
    {
        float distance = CalculationDistance();
        RadiusCheck(distance);
    }

    private float CalculationDistance()//������� ���������� �� ������, ��� ���� ����� ��������� ���� �����
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        return distance;
    }

    private void RadiusCheck(float distanse)//�������� ������ �� ������ � ���� ��������
    {
        timer = timer >= maxTimer ? 0 : timer;
        if (distanse <= radiusAction && timer == 0)
        {
            _interaction.WarmVoid(distanse);
        }
        timer += 1 * Time.deltaTime;
    }
}
