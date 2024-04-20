using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [Header("Sound_Obj")]
    public GameObject[] sound_Obj;
    
    [Header("Sound_Array")]
    public AudioClip[] card_Sounds;

    [Header("UI_Sound_Array")]
    public AudioClip[] ui_Sounds;

    public EffectSoundOnActive[] card_Sound;

    private void Awake()
    {
        for (int i = 0; i < sound_Obj.Length; i++)
        {
            card_Sound[i] = sound_Obj[i].GetComponent<EffectSoundOnActive>();
        }
    }

}
