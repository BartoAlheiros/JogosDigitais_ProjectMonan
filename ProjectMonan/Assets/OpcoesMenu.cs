using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OpcoesMenu : MonoBehaviour
{
    public AudioMixer AudioMixer;

    public void SetVolume(float volume)
    {
        AudioMixer.SetFloat("MasterVol", volume);
    }
}
