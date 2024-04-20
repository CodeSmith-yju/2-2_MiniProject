using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLogic : State
{
    public Enemy monster;
    public Character player;
    public BattleLogic battle;

    [Header("Move")]
    public PlayerController P_move;
    public PlayerController E_move;

    public void CardCheck(int id)
    {
        SetAttackDamage(0);
        SetDefense(0);
        attack = false;
        block = false;

        RectTransform e_Rect = battle.enemy_Eff.GetComponent<RectTransform>();
        RectTransform e_Hit_Rect = battle.enemy_Hit_Eff.GetComponent<RectTransform>();

        switch (id)
        {
            case 0: //"타격", 1, "피해를 6 줍니다."
                SetAttackDamage(6);//적에게 가할 피해량 설정
                player.attack = true;//공격상태 체크
                battle.enemy_Hit_Eff.sprite = battle.hit_Sp[0];
                battle.enemy_Eff_Hit_Sound.soundClip = battle.hit_Sound[0];
                Damaged();//설정한 피해량을 바탕으로 공격메서드 실행
                //데미지 수치 출력 함수
                Debug.Log("타격");
                break;

            case 1: //"강타", 2, "피해를 8 줍니다. 취약을 2턴 부여합니다."
                SetAttackDamage(8);
                player.attack = true;
                battle.enemy_Hit_Eff.sprite = battle.hit_Sp[1];
                if (battle.enemy_Obj[0].gameObject.activeSelf || battle.enemy_Obj[1].gameObject.activeSelf)
                {
                    e_Hit_Rect.anchoredPosition = new Vector3(328, -123);
                    e_Hit_Rect.sizeDelta = new Vector2(200, 200);
                }
                else
                {
                    e_Hit_Rect.sizeDelta = new Vector2(300, 300);
                }

                battle.enemy_Eff_Hit_Sound.soundClip = battle.hit_Sound[1];
                Damaged();
                monster.Weak_Dur(2);
                if(monster.weak && !GameManager.enemy_Dead_Check)
                {
                    battle.enemy_Eff.sprite = battle.eff_Sp[5];
                    if (!battle.enemy_Eff_Sound_Obj.activeSelf)
                    {
                        battle.enemy_Eff_Sound.soundClip = battle.eff_Sound[2];
                        battle.enemy_Eff_Sound_Obj.SetActive(true);
                    }
                    else
                    {
                        battle.sound_Etc.soundClip = battle.eff_Sound[2];
                        battle.sound_Etc_Obj.SetActive(true);
                    }
                    battle.enemy_Eff.gameObject.SetActive(true);
                }
                
                //취약 2 부여
                Debug.Log("강타");
                break;

            case 2: //"몸통 박치기", 1, "현재 방어도 만큼의 피해를 줍니다
                player.attack = true;
                SetAttackDamage(player.cur_Player_Defense_cut);
                battle.enemy_Hit_Eff.sprite = battle.hit_Sp[1];
                if (battle.enemy_Obj[0].gameObject.activeSelf || battle.enemy_Obj[1].gameObject.activeSelf)
                {
                    e_Hit_Rect.anchoredPosition = new Vector3(328, -123);
                    e_Hit_Rect.sizeDelta = new Vector2(200, 200);
                }
                else
                {
                    e_Hit_Rect.sizeDelta = new Vector2(300, 300);
                }
                battle.enemy_Eff_Hit_Sound.soundClip = battle.hit_Sound[4];
                Damaged();
                Debug.Log("몸통박치기");
                break;

            case 3: //"클로스라인", 2, "피해를 12 줍니다. 약화를 2턴 부여합니다."
                SetAttackDamage(12);
                player.attack = true;
                if (battle.enemy_Obj[0].gameObject.activeSelf || battle.enemy_Obj[1].gameObject.activeSelf)
                {
                    e_Hit_Rect.anchoredPosition = new Vector3(328, -123);
                    e_Hit_Rect.sizeDelta = new Vector2(200, 200);
                }
                else
                {
                    e_Hit_Rect.sizeDelta = new Vector2(300, 300);
                }
                battle.enemy_Hit_Eff.sprite = battle.hit_Sp[1];
                battle.enemy_Eff_Hit_Sound.soundClip = battle.hit_Sound[4];
                Damaged();

                monster.Vulner_Dur(2); //약화 2 부여

                

                if (monster.vulner && !GameManager.enemy_Dead_Check)
                {
                    battle.enemy_Eff.sprite = battle.eff_Sp[4];
                    
                    if (!battle.enemy_Eff_Sound_Obj.activeSelf)
                    {
                        battle.enemy_Eff_Sound.soundClip = battle.eff_Sound[2];
                        battle.enemy_Eff_Sound_Obj.SetActive(true);
                    }
                    else
                    {
                        battle.sound_Etc.soundClip = battle.eff_Sound[2];
                        battle.sound_Etc_Obj.SetActive(true);
                    }

                    e_Rect.sizeDelta = new Vector2(160, 120);
                    battle.enemy_Eff.gameObject.SetActive(true);
                    
                }

                Debug.Log("클로스라인");
                break;

            case 4: //"대검", 2, "피해를 14 줍니다. 힘의 효과가 3배로 적용됩니다."
                if(player.power)
                {
                    SetAttackDamage(14 + (player.power_Count * 2)); 
                    // Damaged 메소드에서 한번 더 파워 카운트를 더하기 때문에 setAttackDamage를 힘의 2배만 더하면될듯함
                }
                else
                {
                    SetAttackDamage(14);
                }
                player.attack = true;
                battle.enemy_Hit_Eff.sprite = battle.hit_Sp[0];
                battle.enemy_Eff_Hit_Sound.soundClip = battle.hit_Sound[5];
                Damaged();
                Debug.Log("대검");
                break;

            case 5: //"폼멜 타격", 1, "피해를 9 줍니다. 카드를 1장 뽑습니다." 
                SetAttackDamage(9);
                player.attack = true;
                battle.enemy_Hit_Eff.sprite = battle.hit_Sp[1];
                if (battle.enemy_Obj[0].gameObject.activeSelf || battle.enemy_Obj[1].gameObject.activeSelf)
                {
                    e_Hit_Rect.anchoredPosition = new Vector3(328, -123);
                    e_Hit_Rect.sizeDelta = new Vector2(200, 200);
                }
                else
                {
                    e_Hit_Rect.sizeDelta = new Vector2(300, 300);
                }
                
                battle.enemy_Eff_Hit_Sound.soundClip = battle.hit_Sound[1];
                HandingManager.Instance.PlusDraw(1);
                Damaged();
                Debug.Log("폼멜타격");
                break;

            case 6: //"이중 타격", 1, "피해를 5만큼 2번 줍니다."
                SetAttackDamage(5);
                player.attack = true;
                battle.enemy_Hit_Eff.sprite = battle.hit_Sp[0];
                battle.enemy_Eff_Hit_Sound.soundClip = battle.hit_Sound[0];
                Damaged();

                if(!GameManager.enemy_Dead_Check)
                {
                    StartCoroutine(Double_Atk());
                }
                
                Debug.Log("이중타격");
                break;

            case 7: //"혈류", 1, "체력을 2 잃습니다. 피해를 15 줍니다."
                StartCoroutine(Suicide(3));
                SetAttackDamage(15);
                player.attack = true;
                battle.enemy_Hit_Eff.sprite = battle.hit_Sp[0];
                battle.enemy_Eff_Hit_Sound.soundClip = battle.hit_Sound[0];

                Damaged();
                Debug.Log("혈류, 체력 2 감소, 적 피해 15");
                break;

            case 8: //"수비", 1, "방어도를 5 얻습니다."
                SetDefense(5);
                player.block = true;
                Defensed();
                Debug.Log("수비");
                break;

            case 9: //"몸 풀기", 0, "힘을 2 얻습니다. 턴이 끝날 때 힘을 2 잃습니다."
                //이펙트 출력
                battle.player_Eff.sprite = battle.eff_Sp[3];
                if (!battle.player_Eff_Sound_Obj.activeSelf)
                {
                    battle.player_Eff_Sound.soundClip = battle.eff_Sound[1];
                    battle.player_Eff_Sound_Obj.SetActive(true);
                }
                else
                {
                    battle.sound_Etc.soundClip = battle.eff_Sound[1];
                    battle.sound_Etc_Obj.SetActive(true);
                }
                battle.player_Eff.gameObject.SetActive(true);
                player.warm_Up = true;

                player.warm_Up_Cnt++;
                player.power_Count += 2 * player.warm_Up_Cnt;

                
                //힘 2 증가
                //턴이 끝나면 힘 2 감소
                Debug.Log("몸풀기");
                break;

            case 10: //"흘려보내기", 1, "방어도를 8 얻습니다. 카드를 1장 뽑습니다."
                //이펙트 출력
                SetDefense(8);
                player.block = true;
                Defensed();
                HandingManager.Instance.PlusDraw(1);
                Debug.Log("흘려보내기, 방어8 획득, 카드 1장 드로우");
                break;

            case 11: //"사혈", 0, "체력을 3 잃습니다. 코스트를 2 회복합니다"
                //이펙트 출력
                StartCoroutine(Suicide(3));

                // 사혈 자해 데미지 받을 때 사운드와 같이 나오도록 enemy 사운드 오브젝트를 빌려와서 사용
                if(!battle.enemy_Eff_Sound_Obj.activeSelf) 
                {
                    battle.enemy_Eff_Sound.soundClip = battle.eff_Sound[1];
                    battle.enemy_Eff_Sound_Obj.SetActive(true);
                }
                else
                {
                    battle.sound_Etc.soundClip = battle.eff_Sound[1];
                    battle.sound_Etc_Obj.SetActive(true);
                }
                
                battle.player_Eff.sprite = battle.eff_Sp[6];
                battle.player_Eff.gameObject.SetActive(true);


                battle.cur_Cost += 2;
                Debug.Log("사혈, 체력 3 감소, 코스트 2 회복");
                break;

            case 12: //"전투 최면", 0, "카드를 3장 뽑습니다."
                //이펙트 출력
                //카드 3장 드로우
                Debug.Log("전투최면");
                HandingManager.Instance.PlusDraw(3);
                break;

            case 13: //"참호", 2, "방어도가 2배로 증가합니다"
                //이펙트 출력
                SetDefense(player.cur_Player_Defense_cut);
                Defensed();
                Debug.Log("참호");
                break;

            case 14: //"발화", 1, "힘을 2 얻습니다."
                //이펙트 출력
                battle.player_Eff.sprite = battle.eff_Sp[2];
                if(!battle.player_Eff_Sound_Obj.activeSelf)
                {
                    battle.player_Eff_Sound.soundClip = battle.eff_Sound[3];
                    battle.player_Eff_Sound_Obj.SetActive(true);
                }
                else
                {
                    battle.sound_Etc.soundClip = battle.eff_Sound[3];
                    battle.sound_Etc_Obj.SetActive(true);
                }
                
                battle.player_Eff.gameObject.SetActive(true);
                player.power = true;
                player.power_Count += 2;
                //힘 2 증가
                
                Debug.Log("발화");
                break;

            case 15: //"금속화", 1, "턴 종료 시 방어도를 3 얻습니다."
                if (!battle.player_Eff_Sound_Obj.activeSelf)
                {
                    battle.player_Eff_Sound.soundClip = battle.eff_Sound[4];
                    battle.player_Eff_Sound_Obj.SetActive(true);
                }
                else if (!battle.enemy_Eff_Sound_Obj.activeSelf)
                {
                    battle.enemy_Eff_Sound.soundClip = battle.eff_Sound[4];
                    battle.enemy_Eff_Sound_Obj.SetActive(true);
                }
                else
                {
                    battle.sound_Etc.soundClip = battle.eff_Sound[4];
                    battle.sound_Etc_Obj.SetActive(true);
                }
                battle.player_Eff.sprite = battle.eff_Sp[1];
                battle.player_Eff.gameObject.SetActive(true);
                if (player.metallize)
                {
                    player.metallize_Cnt++;
                }
                else
                {
                    player.metallize = true;
                    player.metallize_Cnt = 1;
                }

                Debug.Log("금속화");
                break;

        }

    }

    private void Damaged()
    {
        int base_Damage;

        if (player.power || player.warm_Up)
        {
            base_Damage = GetAttackDamage() + player.power_Count;
        }
        else
        {
            base_Damage = GetAttackDamage();
        }
        

        if(monster.weak)
        {
            if(player.vulner)
            {
                GameManager.total_Dmg_Init += (int) ((base_Damage * 1.5) * 0.75);
                E_TakeDamage((int)((base_Damage * 1.5) * 0.75));
                Damage_Calc((int)((base_Damage * 1.5) * 0.75));
            }
            else
            {
                GameManager.total_Dmg_Init += (int)(base_Damage * 1.5);
                E_TakeDamage((int)(base_Damage * 1.5));
                Damage_Calc((int)(base_Damage * 1.5));
            }
        }
        else
        {
            if(player.vulner)
            {
                GameManager.total_Dmg_Init += (int)(base_Damage * 0.75);
                E_TakeDamage((int)(base_Damage * 0.75));
                Damage_Calc((int)(base_Damage * 0.75));
            }
            else
            {
                GameManager.total_Dmg_Init += base_Damage;
                E_TakeDamage(base_Damage);
                Damage_Calc(base_Damage);
            }
        }

        P_move.Rightmove();
        E_move.Rightmove();
        battle.enemy_Hit_Eff.gameObject.SetActive(true);

    }

    private void Damage_Calc(int base_Damage)
    {
        if (monster.cur_Enemy_Defense_cut > base_Damage)
        {
            battle.enemy_Eff_Hit_Sound.soundClip = battle.hit_Sound[2];
            monster.cur_Enemy_Defense_cut -= base_Damage;
        }
        else if (monster.cur_Enemy_Defense_cut == 0)
        {
            monster.cur_Enemy_HP -= base_Damage;
        }
        else
        {
            battle.enemy_Eff_Hit_Sound.soundClip = battle.hit_Sound[3];
            monster.cur_Enemy_HP -= base_Damage - monster.cur_Enemy_Defense_cut;
            monster.cur_Enemy_Defense_cut = 0;
        }
    }

    private void Defensed()
    {
        if (!battle.player_Eff_Sound_Obj.activeSelf)
        {
            battle.player_Eff_Sound.soundClip = battle.eff_Sound[0];
            battle.player_Eff_Sound_Obj.SetActive(true);
        }
        else
        {
            battle.sound_Etc.soundClip = battle.eff_Sound[0];
            battle.sound_Etc_Obj.SetActive(true);
        }
        battle.player_Eff.sprite = battle.eff_Sp[0];
        battle.player_Eff.gameObject.SetActive(true);
        if (player.block)
        {
            player.cur_Player_Defense_cut += GetDefense();
        }
    }

    //11-25 이중타격에서 거의 동시에 이미지가 출력되어 약간의 시간차를 둬 가시성을 높이기 위함
    private IEnumerator Double_Atk()
    {
        yield return new WaitForSeconds(0.6f);
        Damaged();
    }

    //플레이어 체력 감소 메서드
    private IEnumerator Suicide(int cnt)
    {
        player.cur_Player_HP -= cnt;
        P_TakeDamage(cnt);

        if (!battle.player_Eff_Sound_Obj.activeSelf)
        {
            battle.player_Eff_Sound.soundClip = battle.eff_Sound[5];
            battle.player_Eff_Sound_Obj.SetActive(true);
        }
        else
        {
            battle.player_Eff_Sound_Obj.SetActive(false);
            battle.player_Eff_Sound.soundClip = battle.eff_Sound[5];
            battle.player_Eff_Sound_Obj.SetActive(true);
        }
        yield return new WaitForSeconds(0.5f);
    }

}