using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmTracker : MonoBehaviour
{
    [SerializeField]
    protected float bpm;
    [SerializeField]
    protected int beatsShownInAdvance;
    [SerializeField]
    protected GameObject targetPrefab;
    [SerializeField]
    protected Transform spawnPosition;
    [SerializeField]
    protected Transform despawnPosition;

    private float secPerBeat;
    private float songPosition;
    private float songPositionInBeats;
    private float dspSongTime;
    private float[] beats = new float[] { 2f, 4f, 6f, 8f, 10f, 12f, 14f, 16f, 18f, 20f, 50f };
    private int nextIndex = 0;

    private AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f / bpm;
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        //calculate the position in beats
        songPositionInBeats = songPosition / secPerBeat;

        if (nextIndex < beats.Length && beats[nextIndex] < songPositionInBeats + beatsShownInAdvance)
        {
            GameObject targetObject = Instantiate(targetPrefab, spawnPosition.position, spawnPosition.rotation);
            Target target = targetObject.GetComponent<Target>();
            target.beatsShownInAdvance = beatsShownInAdvance;
            target.songPositionInBeats = songPositionInBeats;
            target.beatOfThisNote = beats[nextIndex];
            target.spawnPosition = spawnPosition;
            target.despawnPosition = despawnPosition;
            nextIndex++;
        }
    }
}