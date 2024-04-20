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
        nameTxt.text = name;//��Ÿ�� ����
        descTxt1.text = desc1;//���� ���� �� ü����
        descTxt2.text = desc2;//(\n)ȸ���մϴ�.
        descTxt3.text = desc3;//6
    }

}
