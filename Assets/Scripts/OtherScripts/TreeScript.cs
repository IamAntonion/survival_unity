using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class TreeScript : MonoBehaviour
{
    [Header("Apple")]
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject[] appleArray;
    private int _totalApple = 3;
    private bool _activeApple = false;

    private float timer = 0;
    private float maxTimer = 10;

    private void Start()
    {
        appleArray = new GameObject[_totalApple];
    }

    private void Update()
    {
        timer = timer >= maxTimer ? 0 : timer;
        if (timer == 0)
        {
            for (int i = 0; i < _totalApple; i++)
            {
                if (appleArray[i] == null && !_activeApple)
                {
                    Vector3 pos = new Vector3(transform.position.x + Random.Range(-0.5f, +0.5f), transform.position.y - 0.1f, transform.position.z + Random.Range(-0.5f, +0.5f));
                    appleArray[i] = Instantiate(applePrefab, pos, Quaternion.identity);
                    _activeApple = true;
                }
            }
            _activeApple = false;
        }
        timer += Time.deltaTime;
    }
}
