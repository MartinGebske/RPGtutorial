using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float projectileSpeed;
    float damageCaused;

    public void SetDamage(float damage)
    {
        damageCaused = damage;
    }

    void OnTriggerEnter(Collider collider)
    {
        Component damagableComponent = collider.gameObject.GetComponent(typeof(IDamageble));
        if (damagableComponent)
        {
            (damagableComponent as IDamageble).TakeDamage(damageCaused);
        }
    }
}
