using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic : MonoBehaviour
{
    //public int desc_Value;

    public string burning_blood_name;
    public string burning_blood_desc;//���׺����� �ؽ�Ʈ 
    public string burning_blood_desc2;
    public int burning_blood_init;//���� ������ ȿ����ġ
    public string burning_blood_desc3;


    public bool bottle_use;
    public string blood_bottle_name;
    public string blood_bottle_desc;//���׺����� �ؽ�Ʈ 
    public string blood_bottle_desc2;
    public int blood_bottle_init;//���� ������ ȿ����ġ
    public string blood_bottle_desc3;

    void Start()
    {
        burning_blood_name = "��Ÿ�� ����";
        burning_blood_desc = "���� ���� �� ü����";//���׺����� �ؽ�Ʈ 
        burning_blood_desc2 = "ȸ���մϴ�.";
        burning_blood_init = 6;//���� ������ ȿ����ġ
        burning_blood_desc3 = burning_blood_init.ToString();


        bottle_use = true;
        blood_bottle_name = "�ǰ� ��� ��";
        blood_bottle_desc = "�÷��̾� ü����";
        blood_bottle_desc2 = "ȸ���մϴ�.";
        blood_bottle_init = 2;
        blood_bottle_desc3 = blood_bottle_init.ToString();
    }

}
