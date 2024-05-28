using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public float difficulty = 0.4f;
    public float difficultyIncreaseSPeed = 0.01f;
    public Transform startPosition;
    public GameObject balloonGreen;


    // timer
    private float waveTimer = 0;
    private float nextWave = 2;

    // Udate

    private void Update()
    {
       
        if(waveTimer < Time.time)
        {
            difficulty += difficultyIncreaseSPeed;
            waveTimer = Time.time + nextWave + 12.5f;

            var balloon = Instantiate(balloonGreen, startPosition.position, balloonGreen.transform.rotation);
            balloon.GetComponent<BalloonScript>().health += (int)System.Math.Round(difficulty);
            balloon.GetComponent<BalloonScript>().health += (int)System.Math.Round(difficulty);
        }
    } 
}
