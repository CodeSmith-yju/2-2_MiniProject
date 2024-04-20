using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic : MonoBehaviour
{
    //public int desc_Value;

    public string burning_blood_name;
    public string burning_blood_desc;//버닝블러드의 텍스트 
    public string burning_blood_desc2;
    public int burning_blood_init;//버닝 블러드의 효과수치
    public string burning_blood_desc3;


    public bool bottle_use;
    public string blood_bottle_name;
    public string blood_bottle_desc;//버닝블러드의 텍스트 
    public string blood_bottle_desc2;
    public int blood_bottle_init;//버닝 블러드의 효과수치
    public string blood_bottle_desc3;

    void Start()
    {
        burning_blood_name = "불타는 혈액";
        burning_blood_desc = "전투 종료 시 체력을";//버닝블러드의 텍스트 
        burning_blood_desc2 = "회복합니다.";
        burning_blood_init = 6;//버닝 블러드의 효과수치
        burning_blood_desc3 = burning_blood_init.ToString();


        bottle_use = true;
        blood_bottle_name = "피가 담긴 병";
        blood_bottle_desc = "플레이어 체력을";
        blood_bottle_desc2 = "회복합니다.";
        blood_bottle_init = 2;
        blood_bottle_desc3 = blood_bottle_init.ToString();
    }

}
