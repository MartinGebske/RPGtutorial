using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class EnemyHealthBar : MonoBehaviour
{

    RawImage enemyHealthBarRawImage;
    Enemy enemy;

    // Use this for initialization
    void Start()
    {
        enemy = FindObjectOfType<Enemy>();
        enemyHealthBarRawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = -(enemy.healthAsPercentage / 2f) - 0.5f;
        enemyHealthBarRawImage.uvRect = new Rect(xValue, 0f, 0.5f, 1f);
    }
}
