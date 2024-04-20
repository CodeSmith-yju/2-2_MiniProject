using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestRoom_Script : MonoBehaviour
{
    public Text globalhp;
    public void Bed_Heal()
    {
        if (GlobalData.cur_Hp + ((int)(GlobalData.max_Hp * 0.3)) < GlobalData.max_Hp)
        {
            GlobalData.cur_Hp += (int)(GlobalData.max_Hp * 0.3);
        }
        else
        {
            GlobalData.cur_Hp = GlobalData.max_Hp;
        }
    }
    private void Start()
    {
        globalhp.text = $"({(int)(GlobalData.max_Hp * 0.3)})";
    }
}
