using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : State
{
    
    [HideInInspector] public int max_Player_HP;
    [HideInInspector] public int cur_Player_HP;
    [HideInInspector] public int cur_Player_Defense_cut;
    [HideInInspector] public bool barricade = false;
    [HideInInspector] public bool Max_Cost_Relic = false;
    [HideInInspector] public bool metallize = false;
    [HideInInspector] public bool warm_Up = false;
    [HideInInspector] public bool body_Slam = false;
    [HideInInspector] public int warm_Up_Cnt = 0;
    [HideInInspector] public int metallize_Cnt = 0;

    public bool burning_blood_set;//���� ���尡 Ȱ��ȭ�Ǿ��ִ��� �ƴ��� üũ, �⺻�����̶� ���Ȱ��
    public bool blood_vial_set;//12-01 Add


    public void Spawn_Player() {
        max_Player_HP = 80;
        cur_Player_HP = 80;

        Player_state(max_Player_HP, cur_Player_HP);
    }


    public void Player_state(int max, int cur) {
        max_Player_HP = max;
        cur_Player_HP = cur;
    }




}
