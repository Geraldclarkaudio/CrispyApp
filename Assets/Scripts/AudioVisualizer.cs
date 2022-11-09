using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVisualizer : MonoBehaviour
{
    public VisualizerObject[] visualizerObjects;
    public Color visualizerColor = Color.gray;
    [Space(15)]
    public AudioClip audioClip;
    public bool loop = true;
    AudioSource audioSource;
    public float updateSensitivity = 0.5f;
    public float minimunHeight = 10.0f;
    public float maxHeight = 425f;
    [Space (15), Range(64, 8192)]
    public int visualizerSimples = 64;

    // Start is called before the first frame update
    void Start()
    {
        visualizerObjects = GetComponentsInChildren<VisualizerObject>();
        audioSource = GetComponent<AudioSource>();

        if (!audioClip)
        {
            Debug.Log("No Audio Clip");
        }
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

        float[] spectrumData = audioSource.GetSpectrumData(visualizerSimples, 0, FFTWindow.Rectangular);
        
        for(int i = 0; i <visualizerObjects.Length; i++)
        {
            Vector2 newSize = visualizerObjects[i].GetComponent<RectTransform>().rect.size;

            newSize.y = Mathf.Clamp(Mathf.Lerp(newSize.y, minimunHeight + (spectrumData[i] * (maxHeight - minimunHeight) * 5.0f), updateSensitivity), minimunHeight,maxHeight); 
            visualizerObjects[i].GetComponent<RectTransform>().sizeDelta = newSize;
            visualizerObjects[i].GetComponent<Image>().color = visualizerColor;
        }
    }

    public void StopAudio()//use for window changing and pause button
    {
        audioSource.Stop();
    }

    public void PlayAudio()
    {
        if (!audioClip)
        {
            Debug.Log("No Audio Clip");
        }
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
