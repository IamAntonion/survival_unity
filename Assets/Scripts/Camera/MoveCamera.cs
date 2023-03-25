using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("�����")]
    public Transform playerTransform;

    [Header("��������� ������")]

    [SerializeField] private Vector3 offset = new Vector3(0f, 5f, -5f);//��������� ������
    [SerializeField] private float speedCamera = 2.0f;//�������� ����������� ������

    private void Update()
    {
        Vector3 newCamPosition = new Vector3(playerTransform.position.x + offset.x, offset.y, playerTransform.position.z + offset.z);
        transform.position = Vector3.Lerp(transform.position, newCamPosition, speedCamera * Time.deltaTime);
    }
}
