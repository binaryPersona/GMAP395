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
    // public float songPositionInBeats;
    public RhythmTracker rhythm;
    public ParticleSystem poof;
    public Score score;

    private bool hit = false;

    void Update()
    {
        if (!hit)
        {
            transform.position = Vector3.Lerp(spawnPosition.position, despawnPosition.position, (beatsShownInAdvance - (beatOfThisNote - rhythm.songPositionInBeats)) / beatsShownInAdvance);
            if (transform.position == despawnPosition.position)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Damaged!");

        if (currentHealth <= 0 && hit == false)
        {
            hit = true;
            StartCoroutine(DestroyWithPoof());
            int points = (int)(beatsShownInAdvance - (beatOfThisNote - rhythm.songPositionInBeats));
            score.AddScore(points);
        }
    }

    private IEnumerator DestroyWithPoof()
    {
        Destroy(gameObject, despawnTime);
        GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(despawnTime - 0.05f);
        Instantiate(poof, transform.position, transform.rotation);
    }
}