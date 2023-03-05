using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HomeManager : MonoBehaviour
{
    private float fingerPosX0;
    private float fingerPosX1;
    public float posTh = 0.5f;

    public AudioSource audioSource;
    public AudioClip forestSound;
    public AudioClip oceanSound;
    public AudioReverbZone reverbZone;
    public TextMeshProUGUI soundType;
    private bool isForest = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) fingerPosX0 = Input.mousePosition.x;
        if (Input.GetMouseButtonUp(0))
        {
            fingerPosX1 = Input.mousePosition.x;

            if (Mathf.Abs(fingerPosX0 - fingerPosX1) < posTh) PlayOrStopSound();
            else
            {
                isForest = !isForest;
                soundType.text = isForest ? "Forest" : "Ocean";
                reverbZone.reverbPreset = isForest ? AudioReverbPreset.Mountains : AudioReverbPreset.Underwater;

                if (audioSource.isPlaying)
                {
                    audioSource.clip = isForest ? forestSound : oceanSound;
                    audioSource.Play();
                }
            }
        }
    }

    public void PlayOrStopSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = isForest ? forestSound : oceanSound;
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
