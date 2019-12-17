using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RhythmTracker : MonoBehaviour
{
    [SerializeField]
    protected float bpm;
    [SerializeField]
    protected int beatsShownInAdvance;
    [SerializeField]
    protected GameObject[] targetPrefabs;
    [SerializeField]
    protected Transform[] spawnPositions;
    [SerializeField]
    protected Transform[] despawnPositions;

    public Score score;

    private float secPerBeat;
    private float songPosition;
    public float songPositionInBeats;
    private float dspSongTime;                                                      //10                                               //20                                                        //30                                                   //40                                               //50                                              //60                               //67
    private float[] beats = new float[] { 4f, 8f, 12f, 16f, 18f, 20f, 22f, 24f, 26f, 28f, 30f, 32f, 34f, 35f, 36f, 37f, 38f, 39f, 40f, 40.5f, 41f, 41.5f, 42f, 42.5f, 43f, 43.5f, 44f, 44.5f, 45f, 45.5f, 46f, 46.5f, 47f, 48f, 49f, 49.5f, 50f, 51f, 52f, 53f, 54f, 55f, 56f, 57f, 58f, 59f, 60f, 61f, 62f, 63f, 64f, 65f, 67f, 68f, 69f, 70f, 71f, 72f, 73f, 74f, 75f, 76f, 78f, 79f, 80f, 81f, 82f };
    //                                                                10                            20                            30                            40                            50                           60
    private int[] spawnLanes = new int[] { 0, 1, 2, 3, 2, 1, 0, 1, 1, 3, 3, 2, 2, 0, 1, 0, 1, 0, 2, 2, 2, 2, 1, 1, 1, 1, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 0, 0, 0, 0, 3, 3, 3, 3, 1, 1, 1, 1, 2, 2, 2, 2, 0, 3, 0, 3, 1, 2, 1, 2, 0, 3, 0, 3, 2, 2 };
    private int nextIndex = 0;

    private bool isPlaying = false;

    private AudioSource musicSource;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f / bpm;
        dspSongTime = (float)AudioSettings.dspTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            songPosition = (float)(AudioSettings.dspTime - startTime);

            //calculate the position in beats
            songPositionInBeats = songPosition / secPerBeat;

            if (nextIndex < beats.Length && beats[nextIndex] < songPositionInBeats + beatsShownInAdvance)
            {
                int spawnLane = spawnLanes[nextIndex];
                GameObject targetObject = Instantiate(targetPrefabs[spawnLane], spawnPositions[spawnLane].position, spawnPositions[spawnLane].rotation);
                Target target = targetObject.GetComponent<Target>();

                target.beatsShownInAdvance = beatsShownInAdvance;
                target.rhythm = this;
                target.beatOfThisNote = beats[nextIndex];
                target.spawnPosition = spawnPositions[spawnLane];
                target.despawnPosition = despawnPositions[spawnLane];
                target.score = score;
                nextIndex++;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                musicSource.Play();
                isPlaying = true;
                startTime = (float)AudioSettings.dspTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}