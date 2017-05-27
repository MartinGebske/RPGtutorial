using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageble {

    [SerializeField] int enemyLayer = 9;

    [SerializeField]
    float damagePerHit = 10f;
    [SerializeField]
    float minTimeBetweenHits = 0.5f;

    [SerializeField]
    float maxHealthPoints = 100;

    [SerializeField]
    float maxAttackRange = 2;

    public float healthAsPercentage { get { return currentHealthPoints / maxHealthPoints; } }

    GameObject currentTarget;

    CameraRaycaster cameraRaycaster;

    float currentHealthPoints = 100;

    float lastHitTime = 0f;


    private void Start()
    {
        cameraRaycaster = FindObjectOfType<CameraRaycaster>();
        cameraRaycaster.notifyMouseClickObservers += OnMouseClick;
        currentHealthPoints = maxHealthPoints;
    }

    void OnMouseClick(RaycastHit rayCastHit, int layerHit)
    {
        if(layerHit == enemyLayer)
        {
            var enemy = rayCastHit.collider.gameObject;


            if((enemy.transform.position - transform.position).magnitude > maxAttackRange)
            {
                return;
            }

            currentTarget = enemy;

            var enemyComponent = enemy.GetComponent<Enemy>();
            if(Time.time - lastHitTime > minTimeBetweenHits)
            {
                enemyComponent.TakeDamage(damagePerHit);
                lastHitTime = Time.time;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealthPoints = Mathf.Clamp(currentHealthPoints - damage, 0f, maxHealthPoints);
    }
}
