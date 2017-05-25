using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy : MonoBehaviour {

    [SerializeField]
    float maxHealthPoints = 100;
    [SerializeField]
    float attackRadius = 5;
    AICharacterControl aiCharacterControl = null;
    GameObject player = null;

    private float currentHealthPoints = 100;

    public float healthAsPercentage
    {
        get { return currentHealthPoints / maxHealthPoints; }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        aiCharacterControl = GetComponent<AICharacterControl>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if(distanceToPlayer <= attackRadius)
        {
            aiCharacterControl.SetTarget(player.transform);
        }
        else
        {
            aiCharacterControl.SetTarget(transform);
        }
    }
}
