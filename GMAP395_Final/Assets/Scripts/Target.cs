using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    [SerializeField]
    protected int currentHealth = 1;
    [SerializeField]
    protected float despawnTime = 1.2f;

    public void Damage (int damageAmount) {
        currentHealth -= damageAmount;

        if (currentHealth <= 0) {
            StartCoroutine (Destroy ());
        }
    }

    private IEnumerator Destroy () {
        yield return despawnTime;
        gameObject.SetActive (false);
    }
}