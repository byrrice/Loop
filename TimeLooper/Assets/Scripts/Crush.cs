using Gamekit2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damager))]
public class Crush : MonoBehaviour {

    Damager damager;

    private void Start()
    {
        damager = gameObject.GetComponent<Damager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable targetDamageable = collision.gameObject.GetComponent<Damageable>();
        if(targetDamageable != null)
        {
            targetDamageable.SetHealth(0);
            targetDamageable.OnDie.Invoke(damager, targetDamageable);
        }
    }
}
