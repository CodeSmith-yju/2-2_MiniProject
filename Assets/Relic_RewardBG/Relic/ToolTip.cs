using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    public Text nameTxt;
    public Text descTxt1;
    public Text descTxt2;
    public Text descTxt3;
    //public int desc_Value;
    //public Text valueTxt;

    public void SetupTooltip(string name, string desc1, string desc2, string desc3) 
    {
        nameTxt.text = name;//불타는 혈액
        descTxt1.text = desc1;//전투 종료 시 체력을
        descTxt2.text = desc2;//(\n)회복합니다.
        descTxt3.text = desc3;//6
    }

}
