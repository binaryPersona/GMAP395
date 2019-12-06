using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField]
    protected int baseDamage = 1;
    [SerializeField]
    protected float fireRate = 0.25f;
    [SerializeField]
    protected float range = 50f;
    [SerializeField]
    protected float hitForce = 100f;
    [SerializeField]
    protected Transform gunMuzzle;

    private Camera fpsCam;
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;

    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        // gunAudio = GetComponent<AudioSource> ();
        fpsCam = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            laserLine.SetPosition(0, gunMuzzle.position);
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, range))
            {
                laserLine.SetPosition(1, hit.point);
                Target health = hit.collider.GetComponent<Target>();
                //TODO: add varying damage based off of beat
                if (health != null)
                {
                    health.Damage(baseDamage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * range));
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        // gunAudio.Play ();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}