using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Add_Gold_Event : MonoBehaviour
{
    public GameObject add_Gold_Btn;
    int ran;
    public Text gold_Text;

    private void OnEnable()
    {
        ran = Random.Range(50, 80);
        gold_Text.text = $"{ran} °ñµå";
    }


    public void Add_Gold_Ev()
    {
        HandingManager.Instance.battle.sound_Etc.soundClip = HandingManager.Instance.battle.eff_Sound[6];
        HandingManager.Instance.battle.sound_Etc_Obj.SetActive(true);
        GlobalData.gold += ran;
        Time.timeScale = 1;
        add_Gold_Btn.gameObject.SetActive(false);
        
    }
}
