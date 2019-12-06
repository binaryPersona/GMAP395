using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    protected int currentHealth = 1;
    [SerializeField]
    protected float despawnTime = 1.2f;
    [SerializeField]
    public Transform spawnPosition;
    [SerializeField]
    public Transform despawnPosition;

    public int beatsShownInAdvance;
    public float beatOfThisNote;
    public float songPositionInBeats;

    void Update()
    {
        Debug.Log((beatsShownInAdvance - (beatOfThisNote - songPositionInBeats)) / beatsShownInAdvance);
        transform.position = Vector3.Lerp(spawnPosition.position, despawnPosition.position, (beatsShownInAdvance - (beatOfThisNote - songPositionInBeats)) / beatsShownInAdvance);
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {
        yield return despawnTime;
        gameObject.SetActive(false);
    }
}