using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleLogic : MonoBehaviour
{
    public Character player;
    public Enemy enemy;
    private int enemy_Spawn;

    [Header("Move")]
    public PlayerController P_move;
    public PlayerController E_move;

    [Header("Player_Obj")]
    public GameObject player_Obj;
    public GameObject player_Dead_Obj;

    [Header("Enemy_Obj")]
    public GameObject enemy_Game_Obj;
    public GameObject[] enemy_Obj;


    [Header("Hp_Obj")]
    public Image player_Hp;
    public Image enemy_Hp;
    public Image player_Def_Hp;
    public Image enemy_Def_Hp;
    public Text player_Hp_Text;
    public Text player_Def_Cnt;
    public Text enemy_Hp_Text;
    public Text enemy_Def_Cnt;

    [Header("Popup_Obj")]
    public GameObject battle_Start_Popup;
    public GameObject player_Turn_Popup;
    public GameObject enemy_Turn_Popup;
    public GameObject win_Popup;
    public GameObject defeat_Popup;
    public GameObject Reward_page;

    [Header("Popup_Text")]
    public Text card_Count_Defeat;
    public Text kill_Count_Defeat;
    public Text total_Damage_Defeat;
    public Text total_Received_Damage_Defeat;
    public Text card_Count;
    public Text kill_Count;
    public Text total_Damage;
    public Text total_Received_Damage;

    [Header("Eff_Obj")]
    public Image player_Eff;
    public GameObject player_Eff_Sound_Obj;
    public Image player_Hit_Eff;
    public Image enemy_Eff;
    public GameObject enemy_Eff_Sound_Obj;
    public Image enemy_Hit_Eff;
    public GameObject sound_Etc_Obj;

    [Header("(De)Buff_Obj and Text")]
    public Image[] P_Buff;
    public Text[] P_Buff_Cnt;
    public Image[] E_Buff;
    public Text[] E_Buff_Cnt;


    [Header("Enemy_Act")]
    public Image enemy_Act_Img;
    public Text enemy_Act_Dmg;

    [Header("UI_Obj")]
    public GameObject able_Cost;
    public GameObject disable_Cost;
    public GameObject card_Hover_Sound_Obj;
    public GameObject card_Sound_Obj;
    public Text turn_Cnt_Text;
    public Button end_Btn;
    public Image end_Btn_Hover;
    public Text end_Btn_Text;
    public Text cost_Text;

    [Header("Sprite_Array")]
    public Sprite[] eff_Sp;
    public Sprite[] enemy_Act_Sp;
    public Sprite[] hit_Sp;
    public Sprite[] btn_Sp;

    [Header("Sound_Array")]
    public AudioClip[] eff_Sound;
    public AudioClip[] hit_Sound;
    public AudioClip[] card_Sounds;

    public int cur_Cost;
    [HideInInspector] public int max_Cost;
    [HideInInspector] public EffectSoundOnActive player_Eff_Sound;
    [HideInInspector] public EffectSoundOnActive card_Sound;
    [HideInInspector] public EffectSoundOnActive_Hover card_Hover_Sound;
    [HideInInspector] public EffectSoundOnActive enemy_Eff_Sound;
    [HideInInspector] public EffectSoundOnActive sound_Etc;
    [HideInInspector] public SoundOnActivate player_Eff_Hit_Sound;
    [HideInInspector] public SoundOnActivate enemy_Eff_Hit_Sound;

    [Header("Relic")]
    private bool default_Relic_chk = true; //12-01 add
    public GameObject blood_Vial;

    private void Awake()
    {
        GameManager.turn = GameManager.Turn.Battle;
        GameManager.turn_Count = 0;

        if (GameManager.battle_Count == 1)
        {
            player.Spawn_Player();
            GlobalData.max_Hp = player.max_Player_HP;
            GlobalData.cur_Hp = player.cur_Player_HP;
        }
        else
        {
            player.Player_state(GlobalData.max_Hp, GlobalData.cur_Hp);
        }

        for(int i = 0; i < enemy_Obj.Length; i++)
        {
            enemy_Obj[i].SetActive(false);
        }

        player_Eff = player_Eff.GetComponent<Image>();
        enemy_Eff = enemy_Eff.GetComponent<Image>();
        enemy_Act_Img = enemy_Act_Img.GetComponent<Image>();
        player_Eff_Sound = player_Eff_Sound_Obj.GetComponent<EffectSoundOnActive>();
        enemy_Eff_Sound = enemy_Eff_Sound_Obj.GetComponent<EffectSoundOnActive>();
        player_Eff_Hit_Sound = player_Hit_Eff.GetComponent<SoundOnActivate>();
        enemy_Eff_Hit_Sound = enemy_Hit_Eff.GetComponent<SoundOnActivate>();
        card_Sound = card_Sound_Obj.GetComponent<EffectSoundOnActive>();
        card_Hover_Sound = card_Hover_Sound_Obj.GetComponent<EffectSoundOnActive_Hover>();
        sound_Etc = sound_Etc_Obj.GetComponent<EffectSoundOnActive>();

        Debug.Log("배틀 시작");
        StartCoroutine(BattleStart_Popup());
    }

    private void Start()
    {
        player.burning_blood_set = true;
        if(GameManager.battle_Count == 3 || GameManager.battle_Count == 7)
        {
            enemy_Spawn = 2;
        }
        else if(GameManager.battle_Count == 9)
        {
            enemy_Spawn = 3;
        }
        else
        {
            enemy_Spawn = Random.Range(0, 2);
        }
        
        enemy.Spawn_Enemy(enemy_Spawn);

        enemy_Obj[enemy_Spawn].SetActive(true);


        if (enemy_Spawn == 0 || enemy_Spawn == 1)
        {
            RectTransform e_Eff_Rect = enemy_Eff.GetComponent<RectTransform>();
            RectTransform e_Hit_Rect = enemy_Hit_Eff.GetComponent<RectTransform>();
            RectTransform e_Act_Icon = enemy_Act_Img.GetComponent<RectTransform>();
            RectTransform e_Act_Text = enemy_Act_Dmg.GetComponent<RectTransform>();

            RectTransform e_Dmg_Text = enemy.E_hudPos.GetComponent<RectTransform>();

            e_Eff_Rect.sizeDelta = new Vector2(120, 120);
            e_Eff_Rect.anchoredPosition = new Vector3(309, -149);

            e_Hit_Rect.sizeDelta = new Vector2(450, 250);
            e_Hit_Rect.anchoredPosition = new Vector3(314, -140);

            e_Dmg_Text.anchoredPosition = new Vector3(386, -52);

            if (enemy_Spawn == 0)
            {
                e_Act_Icon.anchoredPosition = new Vector3(294, -54);
                e_Act_Text.anchoredPosition = new Vector3(277, -70);
            }
            else if(enemy_Spawn == 1)
            {
                e_Act_Icon.anchoredPosition = new Vector3(304, -85);
                e_Act_Text.anchoredPosition = new Vector3(287, -101);
            }
        }
        else if(enemy_Spawn == 2)
        {
            RectTransform e_Eff_Rect = enemy_Eff.GetComponent<RectTransform>();
            RectTransform e_Hit_Rect = enemy_Hit_Eff.GetComponent<RectTransform>();
            RectTransform e_Act_Icon = enemy_Act_Img.GetComponent<RectTransform>();
            RectTransform e_Act_Text = enemy_Act_Dmg.GetComponent<RectTransform>();

            RectTransform e_Dmg_Text = enemy.E_hudPos.GetComponent<RectTransform>();

            e_Eff_Rect.sizeDelta = new Vector2(200, 200);
            e_Eff_Rect.anchoredPosition = new Vector3(309, -44);

            e_Hit_Rect.sizeDelta = new Vector2(675, 375);
            e_Hit_Rect.anchoredPosition = new Vector3(342, -43);

            e_Dmg_Text.anchoredPosition = new Vector3(371, -79);

            e_Act_Icon.anchoredPosition = new Vector3(285, 146);
            e_Act_Text.anchoredPosition = new Vector3(268, 130);
        }
        else if(enemy_Spawn == 3)
        {
            RectTransform e_Eff_Rect = enemy_Eff.GetComponent<RectTransform>();
            RectTransform e_Hit_Rect = enemy_Hit_Eff.GetComponent<RectTransform>();
            RectTransform e_Act_Icon = enemy_Act_Img.GetComponent<RectTransform>();
            RectTransform e_Act_Text = enemy_Act_Dmg.GetComponent<RectTransform>();

            RectTransform e_Dmg_Text = enemy.E_hudPos.GetComponent<RectTransform>();

            e_Eff_Rect.sizeDelta = new Vector2(200, 200);
            e_Eff_Rect.anchoredPosition = new Vector3(309, -44);

            e_Hit_Rect.sizeDelta = new Vector2(675, 375);
            e_Hit_Rect.anchoredPosition = new Vector3(342, -43);

            e_Dmg_Text.anchoredPosition = new Vector3(371, -79);

            e_Act_Icon.anchoredPosition = new Vector3(285, 146);
            e_Act_Text.anchoredPosition = new Vector3(268, 130);
        }

    }

    private void Update()
    {
        BattleUpdate();
        BuffUpdate();
        ButtonUpdate();
    }


    private void ButtonUpdate()
    {
        if (HandingManager.Instance.endDraw && GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            end_Btn.interactable = true;
            TextAlpha(1f);
            end_Btn_Text.text = "턴 종료";
            HandingManager.Instance.StartCoroutine(HandingManager.Instance.Card_Cost_Chk());
        }
        else
        {
            end_Btn.interactable = false;

            if (GameManager.turn == GameManager.Turn.EnemyTurn)
            {
                end_Btn_Text.text = "적 턴";
            }
            else
            {
                end_Btn_Text.text = "턴 종료";
            }
        }
    }

    private void TextAlpha(float f)
    {
        Color color = end_Btn_Text.color;
        color.a = f;
        end_Btn_Text.color = color;
    }

    private void BattleUpdate()
    {
        if (GameManager.turn == GameManager.Turn.Battle)
        {
            player_Obj.SetActive(true);
            player_Dead_Obj.SetActive(false);
            player_Hp_Text.text = $"{player.cur_Player_HP}/{player.max_Player_HP}";
            player_Hp.fillAmount = (float)player.cur_Player_HP / player.max_Player_HP;

            enemy_Game_Obj.SetActive(true);
            enemy_Hp_Text.text = $"{enemy.cur_Enemy_HP}/{enemy.max_Enemy_HP}";
            enemy_Hp.fillAmount = (float)enemy.cur_Enemy_HP / enemy.max_Enemy_HP;
            
        }

        if (GameManager.turn == GameManager.Turn.EnemyTurn)
        {
            player.Player_state(player.max_Player_HP, player.cur_Player_HP);

            player_Hp.fillAmount = (float) player.cur_Player_HP / player.max_Player_HP;
            player_Hp_Text.text = $"{player.cur_Player_HP}/{player.max_Player_HP}";


            player_Def_Cnt.text = $"{player.cur_Player_Defense_cut}";


            if (player.cur_Player_Defense_cut == 0)
            {
                player_Def_Hp.gameObject.SetActive(false);
                player_Hp.gameObject.SetActive(true);
            }

            enemy.Action();
        }
        else if (GameManager.turn == GameManager.Turn.PlayerTurn | GameManager.turn == GameManager.Turn.EndTurn)
        {
            //11-25 추가 2줄.
            //사혈 사용 시 캐릭터 체력바에 적용 안 되는 현상 개선을 위함.
            player_Hp.fillAmount = (float)player.cur_Player_HP / player.max_Player_HP;
            player_Hp_Text.text = $"{player.cur_Player_HP}/{player.max_Player_HP}";

            enemy.Enemy_state(enemy.max_Enemy_HP, enemy.cur_Enemy_HP);

            enemy_Hp.fillAmount = (float)enemy.cur_Enemy_HP / enemy.max_Enemy_HP;
            enemy_Hp_Text.text = $"{enemy.cur_Enemy_HP}/{enemy.max_Enemy_HP}";
            Cost_Obj();
            cost_Text.text = $"{cur_Cost}/{max_Cost}";

            enemy_Def_Cnt.text = $"{enemy.cur_Enemy_Defense_cut}";

            if (enemy.cur_Enemy_Defense_cut == 0)
            {
                enemy_Def_Hp.gameObject.SetActive(false);
                enemy_Hp.gameObject.SetActive(true);
            }


            if (player.block)
            {
                player_Def_Hp.gameObject.SetActive(true);
                player_Hp.gameObject.SetActive(false);
                player_Def_Cnt.text = player.cur_Player_Defense_cut.ToString();
            }
            else
            {
                player_Def_Hp.gameObject.SetActive(false);
                player_Hp.gameObject.SetActive(true);
            }

            // 디버프가 걸리면 데미지 텍스트가 바뀌게 하기 위해 적용
            enemy.Action();

        }


        if (player.cur_Player_HP <= 0 && GameManager.player_Dead_Check == false)
        {
            GameManager.player_Dead_Check = true;
            BattleEnd();
            player_Obj.SetActive(false);
            player_Dead_Obj.SetActive(true);
            player_Hp_Text.text = $"0/{player.max_Player_HP}";
            card_Count_Defeat.text = $"사용한 카드 수 ({GameManager.card_Init})";//사용한 카드의 수량
            kill_Count_Defeat.text = $"없앤 몬스터 수 ({GameManager.kill_Init})";//사냥한 몬스터의 수
            total_Damage_Defeat.text = $"입힌 피해량 ({GameManager.total_Dmg_Init})";//입힌 피해량
            total_Received_Damage_Defeat.text = $"받은 피해량 ({GameManager.total_ReceivedDmg_Init})";//받은 피해량
            defeat_Popup.SetActive(true);
        }
        else if (enemy.cur_Enemy_HP <= 0 && GameManager.enemy_Dead_Check == false)
        {
            GameManager.enemy_Dead_Check = true;
            BattleEnd();

            enemy_Game_Obj.SetActive(false);
            enemy_Hp_Text.text = $"0/{enemy.max_Enemy_HP}";
            
            if(GameManager.battle_Count == 9)
            {
                card_Count.text = $"사용한 카드 수 ({GameManager.card_Init})";//사용한 카드의 수량
                kill_Count.text = $"없앤 몬스터 수 ({GameManager.kill_Init})";//사냥한 몬스터의 수
                total_Damage.text = $"입힌 피해량 ({GameManager.total_Dmg_Init})";//입힌 피해량
                total_Received_Damage.text = $"받은 피해량 ({GameManager.total_ReceivedDmg_Init})";//받은 피해량

                win_Popup.SetActive(true);
            }
            else
            {
                Reward_page.SetActive(true);
            }
            
        }

        if (GameManager.turn == GameManager.Turn.BattleEnd || GameManager.turn == GameManager.Turn.GameOver)
        {
            enemy_Act_Img.gameObject.SetActive(false);
            enemy_Act_Dmg.gameObject.SetActive(false);
        }

        if(!enemy_Eff.gameObject.activeSelf && !player_Eff.gameObject.activeSelf)
        {
            if(GameManager.turn == GameManager.Turn.EnemyTurn)
            {
                RectTransform p_Rect = player_Eff.GetComponent<RectTransform>();
                p_Rect.sizeDelta = new Vector2(120, 120);
            }
            
            else if (GameManager.turn == GameManager.Turn.PlayerTurn)
            {
                if(!enemy_Obj[2].gameObject.activeSelf || !enemy_Obj[3].gameObject.activeSelf)
                {
                    RectTransform e_Rect = enemy_Eff.GetComponent<RectTransform>();
                    e_Rect.sizeDelta = new Vector2(120, 120);
                }
                else
                {
                    RectTransform e_Rect = enemy_Eff.GetComponent<RectTransform>();
                    e_Rect.sizeDelta = new Vector2(200, 200);
                }
                
            }
            
        }

        if (!enemy_Hit_Eff.gameObject.activeSelf && !player_Hit_Eff.gameObject.activeSelf)
        {
            if (GameManager.turn == GameManager.Turn.EnemyTurn)
            {
                RectTransform p_Rect = player_Hit_Eff.GetComponent<RectTransform>();
                p_Rect.sizeDelta = new Vector2(395, 247);
            }

            else if (GameManager.turn == GameManager.Turn.PlayerTurn)
            {
                if(enemy_Spawn == 0 || enemy_Spawn == 1)
                {
                    RectTransform e_Rect = enemy_Hit_Eff.GetComponent<RectTransform>();
                    e_Rect.sizeDelta = new Vector2(450, 250);
                }
                else
                {
                    RectTransform e_Rect = enemy_Hit_Eff.GetComponent<RectTransform>();
                    e_Rect.sizeDelta = new Vector2(675, 375);
                }
            }

        }

        GlobalData.cur_Hp = player.cur_Player_HP;
        GlobalData.max_Hp = player.max_Player_HP; 

    }

    private void BuffUpdate()
    {
        if(GameManager.turn == GameManager.Turn.PlayerTurn | GameManager.turn == GameManager.Turn.EndTurn)
        {
            if(enemy.vulner)
            {
                E_Buff[3].gameObject.SetActive(true);
                E_Buff_Cnt[3].text = $"{enemy.vulner_Duration}";
            }
            else
            {
                E_Buff[3].gameObject.SetActive(false);
            }
            
            if(enemy.weak)
            {
                E_Buff[2].gameObject.SetActive(true);
                E_Buff_Cnt[2].text = $"{enemy.weak_Duration}";
            }
            else
            {
                E_Buff[2].gameObject.SetActive(false);
            }

            if(player.power || player.warm_Up)
            {
                P_Buff[0].gameObject.SetActive(true);
                P_Buff_Cnt[0].text = $"{player.power_Count}";
            }
            else
            {
                P_Buff[0].gameObject.SetActive(false);
            }

            if(player.warm_Up)
            {
                P_Buff[1].gameObject.SetActive(true);
                P_Buff_Cnt[1].text = $"{2 * player.warm_Up_Cnt}";
            }

            if(player.metallize)
            {
                P_Buff[2].gameObject.SetActive(true);
                P_Buff_Cnt[2].text = $"{(3 * player.metallize_Cnt)}";
            }
            else
            {
                P_Buff[2].gameObject.SetActive(false);
            }

            if (enemy.power && enemy.frenzu)
            {
                E_Buff_Cnt[0].text = $"{enemy.power_Count}";
            }
            else
            {
                E_Buff[0].gameObject.SetActive(false);
            }

        }
        else if (GameManager.turn == GameManager.Turn.EnemyTurn)
        {
            if (player.vulner)
            {
                P_Buff[4].gameObject.SetActive(true);
                P_Buff_Cnt[4].text = $"{player.vulner_Duration}";
            }
            else
            {
                P_Buff[4].gameObject.SetActive(false);
            }

            if (player.weak)
            {
                P_Buff[3].gameObject.SetActive(true);
                P_Buff_Cnt[3].text = $"{player.weak_Duration}";
            }
            else
            {
                P_Buff[3].gameObject.SetActive(false);
            }

            if (enemy.power)
            {
                E_Buff_Cnt[0].text = $"{enemy.power_Count}";
            }
            else
            {
                E_Buff[0].gameObject.SetActive(false);
            }
        }
    }

    public IEnumerator BattleStart_Popup()
    {
        battle_Start_Popup.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        PlayerTurn();
    }

    private void PlayerTurn()
    {
        GameManager.turn = GameManager.Turn.PlayerTurn;

        if (enemy.weak)
        {
            enemy.weak_Duration--;

            if (enemy.weak_Duration == 0)
            {
                enemy.weak = false;
            }
        }

        if (enemy.vulner)
        {
            enemy.vulner_Duration--;

            if (enemy.vulner_Duration == 0)
            {
                enemy.vulner = false;
            }
        }


        Debug.Log("내턴 시작");
        GameManager.turn_Count++;
        int turn_Cnt = GameManager.turn_Count;

        player_Turn_Popup.SetActive(true);
        StartCoroutine(HandingManager.Instance.DrawDelay());
        turn_Cnt_Text.text = $"{turn_Cnt} 턴";
        max_Cost = 3;
        cur_Cost = max_Cost;


        if (player.barricade)
        {
            player.block = true;
        }
        else
        {
            player.block = false;
            player.cur_Player_Defense_cut = 0;
        }

        // 적 행동 보여주는 코드 작성
        enemy.Act_Enemy(enemy_Spawn);
        enemy.Action();
    }

    public void EndTurn()
    {
        if(player.metallize)
        {
            if (!player_Eff_Sound_Obj.activeSelf)
            {
                player_Eff_Sound.soundClip = eff_Sound[0];
                player_Eff_Sound_Obj.SetActive(true);
            }
            player_Eff.sprite = eff_Sp[0];
            if (player.block == false)
            {
                player.block = true;
                player_Eff.gameObject.SetActive(true);
                player.cur_Player_Defense_cut += (3 * player.metallize_Cnt);
            }
            else
            {
                player_Eff.gameObject.SetActive(true);
                player.cur_Player_Defense_cut += (3 * player.metallize_Cnt);
            }
        }

        if(player.warm_Up)
        {
            player.warm_Up = false;
            player.power_Count -= 2 * player.warm_Up_Cnt;
            if(player.power_Count == 0 && !player.power)
            {
                P_Buff[0].gameObject.SetActive(false);
            }
            P_Buff[1].gameObject.SetActive(false);
            player.warm_Up_Cnt = 0;
        }

        GameManager.turn = GameManager.Turn.EndTurn;
        end_Btn_Hover.gameObject.SetActive(false);
        end_Btn_Text.color = Color.white;
        end_Btn.image.sprite = btn_Sp[0];
        HandingManager.Instance.TurnEndReDraw();

        StartCoroutine(EnemyTurn());
    }

    private IEnumerator EnemyTurn()
    {
        Debug.Log("적턴 시작");
        yield return new WaitForSeconds(0.5f);
        GameManager.turn = GameManager.Turn.EnemyTurn;

        if (player.weak)
        {
            player.weak_Duration--;

            if (player.weak_Duration == 0)
            {
                player.weak = false;
            }
        }

        if (player.vulner)
        {
            player.vulner_Duration--;

            if (player.vulner_Duration == 0)
            {
                player.vulner = false;
            }
        }


        enemy_Turn_Popup.SetActive(true);

        yield return new WaitForSeconds(2.5f);

        enemy_Def_Hp.gameObject.SetActive(false);
        enemy_Hp.gameObject.SetActive(true);
        enemy.cur_Enemy_Defense_cut = 0;


        yield return new WaitForSeconds(1f);

        if (enemy.attack)
        {
            if (enemy.weak_Atk && !GameManager.player_Dead_Check)
            {
                player.Weak_Dur(2);
                player_Eff.sprite = eff_Sp[5];
                if (!player_Eff_Sound_Obj.activeSelf)
                {
                    player_Eff_Sound.soundClip = eff_Sound[2];
                    player_Eff_Sound_Obj.SetActive(true);
                }
                player_Eff.gameObject.SetActive(true);
            }



            if(enemy.repeat_Attack && !GameManager.player_Dead_Check)
            {
                for (int i = 1; i <= enemy.repeat_Cnt; i++)
                {
                    enemy.Damaged();
                    P_move.Leftmove();
                    E_move.Leftmove();
                    yield return new WaitForSeconds(0.6f);
                }
                enemy_Act_Img.gameObject.SetActive(false);
                enemy_Act_Dmg.gameObject.SetActive(false);

                enemy.repeat_Cnt++;
            }
            else
            {
                enemy.Damaged();
                P_move.Leftmove();
                E_move.Leftmove();
            }
            

            if (enemy.block)
            {
                yield return new WaitForSeconds(1f);
                enemy.Defense();
            }

            enemy_Act_Img.gameObject.SetActive(false);
            enemy_Act_Dmg.gameObject.SetActive(false);
        }
        else
        { // 버프 효과 작성 (방어도, 힘 등)
            if (enemy.block)
            {
                enemy.Defense();
            }
            else if(enemy.vulner_Atk && !GameManager.player_Dead_Check)
            {
                RectTransform p_Rect = player_Eff.GetComponent<RectTransform>();

                player.Vulner_Dur(2);
                player_Eff.sprite = eff_Sp[4];
                p_Rect.sizeDelta = new Vector2(160, 120);
                if (!player_Eff_Sound_Obj.activeSelf)
                {
                    player_Eff_Sound.soundClip = eff_Sound[2];
                    player_Eff_Sound_Obj.SetActive(true);
                }
                player_Eff.gameObject.SetActive(true);
                E_move.Leftmove();
            }
            else if(enemy.power)
            {
                enemy_Eff.sprite = eff_Sp[2];
                enemy_Eff.gameObject.SetActive(true);
                if(!E_Buff[0].gameObject.activeSelf)
                {
                    E_Buff[0].gameObject.SetActive(true);
                }

                if (!enemy_Eff_Sound_Obj.activeSelf)
                {
                    enemy_Eff_Sound.soundClip = eff_Sound[1];
                    enemy_Eff_Sound_Obj.SetActive(true);
                }
                else
                {
                    sound_Etc.soundClip = eff_Sound[1];
                    sound_Etc_Obj.SetActive(true);
                }

            }
            else if(enemy.frenzu_Check)
            {
                enemy.frenzu = true;
                enemy_Eff.sprite = eff_Sp[7];
                enemy_Eff.gameObject.SetActive(true);

                E_Buff[1].gameObject.SetActive(true);
                E_Buff_Cnt[1].text = "1";

                if (!enemy_Eff_Sound_Obj.activeSelf)
                {
                    enemy_Eff_Sound.soundClip = eff_Sound[1];
                    enemy_Eff_Sound_Obj.SetActive(true);
                }
                else
                {
                    sound_Etc.soundClip = eff_Sound[1];
                    sound_Etc_Obj.SetActive(true);
                }

            }
                enemy_Act_Img.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(2f);
        PlayerTurn();
    }

    public void Cost_Obj()
    {
        if(cur_Cost <= 0)
        {
            able_Cost.SetActive(false);
            disable_Cost.SetActive(true);
        }
        else
        {
            able_Cost.SetActive(true);
            disable_Cost.SetActive(false);
        }
    }

    private void BattleEnd()
    {
        
        if (!GameManager.player_Dead_Check && GameManager.enemy_Dead_Check)
        {
            Burning_Blood_use();
            player_Hp.fillAmount = (float)player.cur_Player_HP / player.max_Player_HP;
            player_Hp_Text.text = $"{player.cur_Player_HP}/{player.max_Player_HP}";
        }

        HandingManager.Instance.BattleEnd();
    }

    public void Burning_Blood_use()
    {
        if (player.burning_blood_set)
        {
            if (player.cur_Player_HP + 6 >= player.max_Player_HP)
            {

                player.cur_Player_HP = player.max_Player_HP;
                player.burning_blood_set = false;
                Debug.Log("현재 체력이 최대체력 -6 이상일때");
                default_Relic_chk = false;

            }
            else if (default_Relic_chk)
            {
                player.cur_Player_HP += 6;
                Debug.Log("현재체력이 최대체력-6 미만일때");
                player.burning_blood_set = false;
            }
        }
        else
        {
            return;
        }
    }
}
