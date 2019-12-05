using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmTracker : MonoBehaviour
{
    [SerializeField]
    protected float bpm;

    private float secPerBeat;
    private float dspTime;
    private float songPosition;

    // Start is called before the first frame update
    void Start()
    {
        secPerBeat = 60f / bpm;
        dspTime = (float)AudioSettings.dspTime;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspTime);

        //calculate the position in beats
        // songPosInBeats = songPosition / secPerBeat;
    }
}