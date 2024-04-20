using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObj_2 : MonoBehaviour
{
    public GameObject reward_page1;
    public GameObject reward_page2;

    public void ActiveObj()
    {

        HandingManager.Instance.battle.sound_Etc.soundClip = HandingManager.Instance.battle.card_Sounds[2];
        HandingManager.Instance.battle.sound_Etc_Obj.SetActive(true);

        Time.timeScale = 0;

        reward_page1.SetActive(false);
        reward_page2.SetActive(true);
    }
}

