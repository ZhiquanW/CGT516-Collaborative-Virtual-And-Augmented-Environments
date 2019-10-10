using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioLowPassFilter))]
public class SoundEffect : MonoBehaviour
{
    private float sampling_frequency = 48000;

    //for noise part
    [Range(0f, 1f)]
    public static float gainNoise = 0.0f;

    //for tonal part
    public float frequency = 440f;
    public static float gainSignal = 0.0f;
    private float increment;
    private float phase;

    System.Random rand = new System.Random();

    void Awake()
    {
        sampling_frequency = AudioSettings.outputSampleRate;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        float tonalPart = 0;
        float noisePart = 0;

        // update increment in case frequency has changed
        increment = frequency * 2f * Mathf.PI / sampling_frequency;

        for (int i = 0; i < data.Length; i++)
        {
            //noise
            noisePart = gainNoise * (float)(rand.NextDouble() * 2.0 - 1.0);

            phase = phase + increment;
            if (phase > 2 * Mathf.PI) phase = 0;

            //tone
            tonalPart = (1f - gainNoise) * (float)(gainSignal * Mathf.Sin(phase));

            //together
            data[i] = noisePart + tonalPart;

            // if we have stereo, we copy the mono data to each channel
            if (channels == 2)
            {
                data[i + 1] = data[i];
                i++;
            }
        }
    }
}
