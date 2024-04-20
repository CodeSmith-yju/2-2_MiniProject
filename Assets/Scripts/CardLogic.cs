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
            case 0: //"Ÿ��", 1, "���ظ� 6 �ݴϴ�."
                SetAttackDamage(6);//������ ���� ���ط� ����
                player.attack = true;//���ݻ��� üũ
                battle.enemy_Hit_Eff.sprite = battle.hit_Sp[0];
                battle.enemy_Eff_Hit_Sound.soundClip = battle.hit_Sound[0];
                Damaged();//������ ���ط��� �������� ���ݸ޼��� ����
                //������ ��ġ ��� �Լ�
                Debug.Log("Ÿ��");
                break;

            case 1: //"��Ÿ", 2, "���ظ� 8 �ݴϴ�. ����� 2�� �ο��մϴ�."
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
                
                //��� 2 �ο�
                Debug.Log("��Ÿ");
                break;

            case 2: //"���� ��ġ��", 1, "���� �� ��ŭ�� ���ظ� �ݴϴ�
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
                Debug.Log("�����ġ��");
                break;

            case 3: //"Ŭ�ν�����", 2, "���ظ� 12 �ݴϴ�. ��ȭ�� 2�� �ο��մϴ�."
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

                monster.Vulner_Dur(2); //��ȭ 2 �ο�

                

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

                Debug.Log("Ŭ�ν�����");
                break;

            case 4: //"���", 2, "���ظ� 14 �ݴϴ�. ���� ȿ���� 3��� ����˴ϴ�."
                if(player.power)
                {
                    SetAttackDamage(14 + (player.power_Count * 2)); 
                    // Damaged �޼ҵ忡�� �ѹ� �� �Ŀ� ī��Ʈ�� ���ϱ� ������ setAttackDamage�� ���� 2�踸 ���ϸ�ɵ���
                }
                else
                {
                    SetAttackDamage(14);
                }
                player.attack = true;
                battle.enemy_Hit_Eff.sprite = battle.hit_Sp[0];
                battle.enemy_Eff_Hit_Sound.soundClip = battle.hit_Sound[5];
                Damaged();
                Debug.Log("���");
                break;

            case 5: //"���� Ÿ��", 1, "���ظ� 9 �ݴϴ�. ī�带 1�� �̽��ϴ�." 
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
                Debug.Log("����Ÿ��");
                break;

            case 6: //"���� Ÿ��", 1, "���ظ� 5��ŭ 2�� �ݴϴ�."
                SetAttackDamage(5);
                player.attack = true;
                battle.enemy_Hit_Eff.sprite = battle.hit_Sp[0];
                battle.enemy_Eff_Hit_Sound.soundClip = battle.hit_Sound[0];
                Damaged();

                if(!GameManager.enemy_Dead_Check)
                {
                    StartCoroutine(Double_Atk());
                }
                
                Debug.Log("����Ÿ��");
                break;

            case 7: //"����", 1, "ü���� 2 �ҽ��ϴ�. ���ظ� 15 �ݴϴ�."
                StartCoroutine(Suicide(3));
                SetAttackDamage(15);
                player.attack = true;
                battle.enemy_Hit_Eff.sprite = battle.hit_Sp[0];
                battle.enemy_Eff_Hit_Sound.soundClip = battle.hit_Sound[0];

                Damaged();
                Debug.Log("����, ü�� 2 ����, �� ���� 15");
                break;

            case 8: //"����", 1, "���� 5 ����ϴ�."
                SetDefense(5);
                player.block = true;
                Defensed();
                Debug.Log("����");
                break;

            case 9: //"�� Ǯ��", 0, "���� 2 ����ϴ�. ���� ���� �� ���� 2 �ҽ��ϴ�."
                //����Ʈ ���
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

                
                //�� 2 ����
                //���� ������ �� 2 ����
                Debug.Log("��Ǯ��");
                break;

            case 10: //"���������", 1, "���� 8 ����ϴ�. ī�带 1�� �̽��ϴ�."
                //����Ʈ ���
                SetDefense(8);
                player.block = true;
                Defensed();
                HandingManager.Instance.PlusDraw(1);
                Debug.Log("���������, ���8 ȹ��, ī�� 1�� ��ο�");
                break;

            case 11: //"����", 0, "ü���� 3 �ҽ��ϴ�. �ڽ�Ʈ�� 2 ȸ���մϴ�"
                //����Ʈ ���
                StartCoroutine(Suicide(3));

                // ���� ���� ������ ���� �� ����� ���� �������� enemy ���� ������Ʈ�� �����ͼ� ���
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
                Debug.Log("����, ü�� 3 ����, �ڽ�Ʈ 2 ȸ��");
                break;

            case 12: //"���� �ָ�", 0, "ī�带 3�� �̽��ϴ�."
                //����Ʈ ���
                //ī�� 3�� ��ο�
                Debug.Log("�����ָ�");
                HandingManager.Instance.PlusDraw(3);
                break;

            case 13: //"��ȣ", 2, "���� 2��� �����մϴ�"
                //����Ʈ ���
                SetDefense(player.cur_Player_Defense_cut);
                Defensed();
                Debug.Log("��ȣ");
                break;

            case 14: //"��ȭ", 1, "���� 2 ����ϴ�."
                //����Ʈ ���
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
                //�� 2 ����
                
                Debug.Log("��ȭ");
                break;

            case 15: //"�ݼ�ȭ", 1, "�� ���� �� ���� 3 ����ϴ�."
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

                Debug.Log("�ݼ�ȭ");
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

    //11-25 ����Ÿ�ݿ��� ���� ���ÿ� �̹����� ��µǾ� �ణ�� �ð����� �� ���ü��� ���̱� ����
    private IEnumerator Double_Atk()
    {
        yield return new WaitForSeconds(0.6f);
        Damaged();
    }

    //�÷��̾� ü�� ���� �޼���
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