using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : State
{
    
    public Character player;
    public BattleLogic battle;
    [HideInInspector] public int max_Enemy_HP;
    [HideInInspector] public int cur_Enemy_HP;
    [HideInInspector] public int cur_Enemy_Defense_cut = 0;
    [HideInInspector] public int damaged;
    public bool vulner_Atk = false;
    public bool weak_Atk = false;
    public bool repeat_Attack = false;
    public int repeat_Cnt = 2;

    public bool frenzu = false; // 귀족 그램린 격분 버프
    public bool frenzu_Check = false; 

    // public State state; // enemy 상태 State 객체
    bool dup = false; // 중복 방지 변수
    
    // random 난수, switch-case문 이용
    
    public void Spawn_Enemy(int ran_Spawn) {
        if(GameManager.turn_Count != 0) {
            return;
        }

        switch(ran_Spawn) {
            case 0:
                Jaw_Worm();
                break;
            case 1:
                Silme();
                break;
            case 2:
                bookOfStabbing();
                break;
            case 3:
                GremlinNob();
                break;
        }
    }

    private void Jaw_Worm() {
        max_Enemy_HP = 40;
        cur_Enemy_HP = 40;
        Enemy_state(max_Enemy_HP, cur_Enemy_HP);
    }

    private void Silme() {
        max_Enemy_HP = 40;
        cur_Enemy_HP = 40;
        Enemy_state(max_Enemy_HP, cur_Enemy_HP);
    }

    private void bookOfStabbing()
    {
        max_Enemy_HP = 80;
        cur_Enemy_HP = 80;
        Enemy_state(max_Enemy_HP, cur_Enemy_HP);
    }

    private void GremlinNob()
    {
        max_Enemy_HP = 100;
        cur_Enemy_HP = 100;
        Enemy_state(max_Enemy_HP, cur_Enemy_HP);
    }

    public void Enemy_state(int maxHp, int curHp) {
        max_Enemy_HP = maxHp;
        cur_Enemy_HP = curHp;
    }


    public void Act_Enemy(int cases) {
        attack = false;
        SetAttackDamage(0);
        block = false;
        SetDefense(0);
        weak_Atk = false;
        vulner_Atk = false;
        repeat_Attack = false;

        if (GameManager.turn_Count == 1) {
            cur_Enemy_Defense_cut = 0;
        }
        
        switch(cases) {
            case 0: // 턱벌레 패턴
                if(GameManager.turn_Count == 1) {
                    attack = true;
                    SetAttackDamage(10);
                    damaged = GetAttackDamage();
                    Debug.Log("10데미지로 공격");
                }
                else {
                    int ran;
                    if(dup) {
                        ran = Random.Range(0, 2);
                        dup = false;
                    }
                    else {
                        ran = Random.Range(0, 3);
                    }
                    switch (ran)
                    {  
                        case 0: 
                            attack = true;
                            SetAttackDamage(10);
                            damaged = GetAttackDamage();
                            Debug.Log("10데미지로 공격");
                            break;
                        case 1:
                            attack = true;
                            block = true;
                            SetAttackDamage(6);
                            damaged = GetAttackDamage();
                            Debug.Log("6데미지로 공격");
                            SetDefense(5);
                            Debug.Log("방어도 5얻음");
                            break;
                        case 2:
                            attack = false;
                            block = true;
                            SetDefense(6);
                            Debug.Log("방어도 6얻음");
                            dup = true;
                            break;
                    }
                }
                break;
            case 1: // 슬라임 패턴
                int ran_2 = Random.Range(0, 3);
                switch(ran_2) 
                {
                    case 0:
                        attack = true;
                        SetAttackDamage(10);
                        damaged = GetAttackDamage();
                        Debug.Log("10데미지로 공격");
                        break;
                    case 1:
                        vulner_Atk = true;
                        Debug.Log("약화");
                        break;
                    case 2:
                        attack = true;
                        weak_Atk = true;
                        SetAttackDamage(3);
                        damaged = GetAttackDamage();
                        Debug.Log("취약");
                        break;
                }
                break;
            case 2: // 칼부림 책 패턴
                int ran_3 = Random.Range(0, 3);
                switch(ran_3)
                {
                    case 0:
                        attack = true;
                        repeat_Attack = true;
                        SetAttackDamage(2);
                        damaged = GetAttackDamage();
                        Debug.Log("연타 공격");
                        break;
                    case 1:
                        attack = true;
                        SetAttackDamage(14);
                        damaged = GetAttackDamage();
                        Debug.Log("단타 공격");
                        break;
                    case 2:
                        power = true;
                        power_Count += 2;
                        Debug.Log("힘 증가");
                        break;
                }
                break;
            case 3:
                int ran_4;
                if(GameManager.turn_Count == 1)
                {
                    ran_4 = 1;
                }
                else if (GameManager.turn_Count == 2 || (GameManager.turn_Count - 2) % 3 == 0)
                {
                    ran_4 = 2;
                }
                else
                {
                    ran_4 = 3;
                }
                switch(ran_4)
                {
                    case 1:
                        frenzu_Check = true;
                        break;
                    case 2:
                        attack = true;
                        weak_Atk = true;
                        SetAttackDamage(3);
                        damaged = GetAttackDamage();
                        break;
                    case 3:
                        attack = true;
                        SetAttackDamage(12);
                        damaged = GetAttackDamage();
                        break;
                }
                break;
        }
    }

    public void Damaged()
    {
        int enemy_Base_Damage;


        if (power)
        {
            enemy_Base_Damage = damaged + power_Count;
        }
        else
        {
            enemy_Base_Damage = damaged;
        }

        if (player.weak)
        {
            if (vulner)
            {
                GameManager.total_ReceivedDmg_Init += (int)((enemy_Base_Damage * 1.50) * 0.75);
                P_TakeDamage((int)((enemy_Base_Damage * 1.50) * 0.75));
                Damage_Calc((int)((enemy_Base_Damage * 1.50) * 0.75));
            }
            else
            {
                GameManager.total_ReceivedDmg_Init += (int)(enemy_Base_Damage * 1.50);
                P_TakeDamage((int)(enemy_Base_Damage * 1.50));
                Damage_Calc((int)(enemy_Base_Damage * 1.50));
            }
        }
        else
        {
            if (vulner)
            {
                GameManager.total_ReceivedDmg_Init += (int)(enemy_Base_Damage * 0.75);
                P_TakeDamage((int)(enemy_Base_Damage * 0.75));
                Damage_Calc((int)(enemy_Base_Damage * 0.75));
            }
            else
            {
                GameManager.total_ReceivedDmg_Init += enemy_Base_Damage;
                P_TakeDamage(enemy_Base_Damage);
                Damage_Calc(enemy_Base_Damage);
            }
        }

        battle.player_Hit_Eff.gameObject.SetActive(true);
    }

    public void Defense()
    {
        if (block)
        {
            cur_Enemy_Defense_cut += GetDefense();
        }

        battle.enemy_Eff_Sound.soundClip = battle.eff_Sound[0];
        battle.enemy_Eff_Sound_Obj.SetActive(true);
        battle.enemy_Eff.sprite = battle.eff_Sp[0];
        battle.enemy_Eff.gameObject.SetActive(true);
        battle.enemy_Def_Hp.gameObject.SetActive(true);
        battle.enemy_Hp.gameObject.SetActive(false);
        battle.enemy_Def_Cnt.text = cur_Enemy_Defense_cut.ToString();
    }



    private void Damage_Calc(int base_Damage)
    {
        if (player.cur_Player_Defense_cut > base_Damage)
        {
            battle.player_Eff_Hit_Sound.soundClip = battle.hit_Sound[2];
            player.cur_Player_Defense_cut -= base_Damage;
        }
        else if (player.cur_Player_Defense_cut == 0)
        {
            battle.player_Eff_Hit_Sound.soundClip = battle.hit_Sound[0];
            player.cur_Player_HP -= base_Damage;
        }
        else
        {
            battle.player_Eff_Hit_Sound.soundClip = battle.hit_Sound[3];
            player.cur_Player_HP -= base_Damage - player.cur_Player_Defense_cut;
            player.cur_Player_Defense_cut = 0;
        }
    }

    public void Action()
    {
        battle.enemy_Act_Dmg.gameObject.SetActive(false);

        int base_Damage;

        if (power)
        {
            base_Damage = damaged + power_Count;
        }
        else
        {
            base_Damage = damaged;
        }
        
        if (attack)
        {
            if (block)
            {
                battle.enemy_Act_Img.sprite = battle.enemy_Act_Sp[1];
                battle.enemy_Act_Img.gameObject.SetActive(true);
                if (vulner)
                {
                    double vulner_Damage = Mathf.Floor(base_Damage * 0.75f);
                    battle.enemy_Act_Dmg.text = vulner_Damage.ToString();
                }
                else
                {
                    battle.enemy_Act_Dmg.text = base_Damage.ToString("F0");
                }
                battle.enemy_Act_Dmg.gameObject.SetActive(true);
            }
            else if(weak_Atk)
            {
                battle.enemy_Act_Img.sprite = battle.enemy_Act_Sp[3];
                battle.enemy_Act_Img.gameObject.SetActive(true);
                if (vulner)
                {
                    double vulner_Damage = Mathf.Floor(base_Damage * 0.75f);
                    battle.enemy_Act_Dmg.text = vulner_Damage.ToString();
                }
                else
                {
                    battle.enemy_Act_Dmg.text = base_Damage.ToString("F0");
                }
                battle.enemy_Act_Dmg.gameObject.SetActive(true);
            }
            else if(repeat_Attack)
            {
                battle.enemy_Act_Img.sprite = battle.enemy_Act_Sp[6];
                battle.enemy_Act_Img.gameObject.SetActive(true);
                if (vulner)
                {
                    double vulner_Damage = Mathf.Floor(base_Damage * 0.75f);
                    string dmg = vulner_Damage.ToString();
                    battle.enemy_Act_Dmg.text = $"{dmg}x{repeat_Cnt}";
                }
                else
                {
                    battle.enemy_Act_Dmg.text = $"{base_Damage.ToString("F0")}x{repeat_Cnt}";
                }
                battle.enemy_Act_Dmg.gameObject.SetActive(true);
            }
            else
            {
                battle.enemy_Act_Img.sprite = battle.enemy_Act_Sp[0];
                battle.enemy_Act_Img.gameObject.SetActive(true);
                if (vulner)
                {
                    double vulner_Damage = Mathf.Floor(base_Damage * 0.75f);
                    battle.enemy_Act_Dmg.text = vulner_Damage.ToString();
                }
                else
                {
                    battle.enemy_Act_Dmg.text = base_Damage.ToString("F0");
                }
                battle.enemy_Act_Dmg.gameObject.SetActive(true);
            }
        }
        else if (block)
        {
            battle.enemy_Act_Img.sprite = battle.enemy_Act_Sp[2];
            battle.enemy_Act_Img.gameObject.SetActive(true);
        }
        
        else if (vulner_Atk)
        {
            battle.enemy_Act_Img.sprite = battle.enemy_Act_Sp[4];
            battle.enemy_Act_Img.gameObject.SetActive(true);
        }

        else if (power)
        {
            battle.enemy_Act_Img.sprite = battle.enemy_Act_Sp[5];
            battle.enemy_Act_Img.gameObject.SetActive(true);
        }

        else if (frenzu_Check)
        {
            battle.enemy_Act_Img.sprite = battle.enemy_Act_Sp[5];
            battle.enemy_Act_Img.gameObject.SetActive(true);
        }
    }


}



