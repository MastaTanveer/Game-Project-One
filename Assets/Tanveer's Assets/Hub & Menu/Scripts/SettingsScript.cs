using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsScript : MonoBehaviour
{
    public AudioMixer audioMix;

    

    public void setVolume (float volume)
    {
        audioMix.SetFloat("MasterVolume", volume);
    }

    List<int> widths = new List<int>() { 1920, 1280, 960, 568 };
    List<int> heights = new List<int>() { 1080, 800, 540, 320 };

    public void SetResolution (int ResIndex)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[ResIndex];
        int height = heights[ResIndex];
        Screen.SetResolution(width, height, fullscreen);
    }

    public void SetFullscreen(bool full)
    {
        Screen.fullScreen = full;
    }
}
