using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] musicPanels;
    [SerializeField]
    private GameObject[] naturePanels;
    [SerializeField]
    private GameObject[] noisePanels;

    [SerializeField]
    private int currentPanel;
    private int i;

    public void MusicNextButton()
    {
        if(currentPanel < musicPanels.Length -1)
        {
            i++;
            musicPanels[i].SetActive(true);
        }
        else if(currentPanel >= musicPanels.Length - 1)
        {
            i = 0;
            musicPanels[i].SetActive(true);
        }
    }

    public void NatureNextButton()
    {
        if (currentPanel < naturePanels.Length - 1)
        {
            i++;
            naturePanels[i].SetActive(true);
        }
        else if (currentPanel >= naturePanels.Length - 1)
        {
            i = 0;
            naturePanels[i].SetActive(true);
        }
    }

    public void NoiseNextButton()
    {
        if (currentPanel < noisePanels.Length - 1)
        {
            i++;
            noisePanels[i].SetActive(true);
        }
        else if (currentPanel >= noisePanels.Length - 1)
        {
            i = 0;
            noisePanels[i].SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        currentPanel = i;   
    }
}
