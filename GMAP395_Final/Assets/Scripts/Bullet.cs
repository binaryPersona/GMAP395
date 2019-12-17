using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    [SerializeField]
    protected float hitForce = 100f;

    // Use this for initialization
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("boom!");
        Target health = collision.gameObject.GetComponent<Target>();
        //TODO: add varying damage based off of beat
        if (health != null)
        {
            health.Damage(damage);
        }
        // if (collision.gameObject.GetComponent<Rigidbody>() != null)
        // {
        //     collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * hitForce);
        // }
        Destroy(gameObject, 0f);
    }
}
