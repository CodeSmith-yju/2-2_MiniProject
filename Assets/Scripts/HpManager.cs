using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class HpManager : MonoBehaviour
{
    [Header("PLAYER")]
    public int Player_maxHp;    //플레이어 최대 체력 숫자값
    public int Player_curHp;    //플레이어 현재 체력 숫자값

    public Image Player_Hpbar;  //플레이어 체력바 이미지
    public Image Player_Shield; //플레이어 쉴드바 이미지

    public Text Player_hptxt;   //플레이어 체력을 화면에 표시할 텍스트
    public Text P_S_Cnt;        //플레이어의 쉴드 수치를 화면에 표시할 텍스트
    public Text Bar_HP;         //상단바 에서 플레이어 체력 수치를 표시할 텍스트
    //public Text P_S_HP;       //이거 필요없는거

    [Header("Enemy")]
    public int Enemy_maxHp;     //에너미 최대 체력 숫자값
    public int Enemy_curHp;     //에너미 현재 체력 숫자값

    public Image Enemy_Hpbar;   //에너미 체력바 이미지
    public Image Enemy_Shield;  //에너미 쉴드바 이미지

    public Text Enemy_hptxt;    //에너미 체력을 화면에 표시할 텍스트
    public Text E_S_Cnt;        //에너미  쉴드 수치를 화면에 표시할 텍스트
    //public Text E_S_HP;

    [Header("Cost")]
    public int maxcost;
    public int curcost;
    public Text CostText;

    //11-01
    public GameObject Live_Cost;
    public GameObject D_Cost;


    [Header("Checker")]
    public bool E_Check = false;//플레이어/적 캐릭터 사망체크용 변수
    public bool P_Check = false;//플레이어/적 캐릭터 사망체크용 변수

    public bool Player_shieldCheck = false;//플레이어/적 캐릭터 방어도 사용체크용 변수
    public bool Enemy_shieldCheck = false;
    public int Player_shield_cnt;
    public int Enemy_shield_cnt;

    //11-03
    [Header("WinPopup")]
    //승리시
    public Text card_Count;//사용한 카드의 수량
    public Text kill_Count;//사냥한 몬스터의 수
    public Text done_Damage;//입힌 피해량
    public Text received_Damage;//받은 피해량

    [Header("DefeatPopup")]
    //패배시
    public Text card_Count_deft;//사용한 카드의 수량
    public Text kill_Count_deft;//사냥한 몬스터의 수
    public Text done_Damage_deft;//입힌 피해량
    public Text received_Damage_deft;//받은 피해량

    [HideInInspector] public int cardCount_init;//각 수를 저장할 변수..이 변수를 Text에 넣을 것.
    [HideInInspector] public int killCount_init;
    [HideInInspector] public int doneDamage_init;
    [HideInInspector] public int receivedDamage_init;


    [Header("Effect")]
    public GameObject player_Eff_Shield;
    public GameObject enemy_Eff_Shield;
    public GameObject P_def_eff;
    public GameObject E_def_eff;

    [Header("StatePopup")]
    public GameObject Battle_start;
    public GameObject Enemy_Turn;
    public GameObject My_Turn;
    public int Turn_Count_init;
    public Text Turn_Count;

    [Header("Move")]
    public PlayerController P_move;
    public PlayerController E_move;





    private void Start()
    {
        //BattleStart_SD = GetComponent<AudioSource>();
        Player_maxHp = 80;
        Player_curHp = Player_maxHp;

        Enemy_maxHp = 45;
        Enemy_curHp = Enemy_maxHp;

        Turn_Count_init = 1;
        maxcost = 3;
        curcost = maxcost;
        Player_shield_cnt = 0;
        Enemy_shield_cnt = 0;
        moveHPBar();

        StartCoroutine("StartPopup");
        //BattleStart_SD.Play();
    }

    public IEnumerator StartPopup()
    {
        Battle_start.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        Turn_Count.text = $"{Turn_Count_init} 턴";
        //MyTurn_SD.Play();
        My_Turn.gameObject.SetActive(true);
    }

    public void moveHPBar()
    {
        Player_Hpbar.fillAmount = (float)Player_curHp / Player_maxHp;
        Player_hptxt.text = $"{Player_curHp}/{Player_maxHp}";
        P_S_Cnt.text = $"{Player_shield_cnt}";

        Enemy_Hpbar.fillAmount = (float)Enemy_curHp / Enemy_maxHp;
        Enemy_hptxt.text = $"{Enemy_curHp}/{Enemy_maxHp}";
        E_S_Cnt.text = $"{Enemy_shield_cnt}";

        //Bar_HP.text = P_S_HP.text;

        CostText.text = $"{curcost}/{maxcost}";
        if (Enemy_curHp <= 0)
        {
            Enemy_hptxt.text = $"{0}/{Enemy_maxHp}";
        }
        if (Player_curHp <= 0)
        {
            Player_hptxt.text = $"{0}/{Player_maxHp}";
        }

        if (Player_shield_cnt > 0)
        {
            Player_shieldCheck = true;
            Player_Hpbar.gameObject.SetActive(false);
            Player_Shield.gameObject.SetActive(true);

        }
        else
        {
            Player_Hpbar.gameObject.SetActive(true);
            Player_Shield.gameObject.SetActive(false);
        }

        if (Enemy_shield_cnt > 0)
        {
            Enemy_shieldCheck = true;
            Enemy_Hpbar.gameObject.SetActive(false);
            Enemy_Shield.gameObject.SetActive(true);
        }
        else
        {
            Enemy_Hpbar.gameObject.SetActive(true);
            Enemy_Shield.gameObject.SetActive(false);
        }

    }

    public int plusShield(int shield_cnt)
    {
        return shield_cnt;
    }


    public void plusAttack(int Attack_cnt)
    {
        if (Enemy_shield_cnt == 0)
        {
            //P_Atk_SD.Play();
            Enemy_curHp -= Attack_cnt;
            doneDamage_init += Attack_cnt;
        }
        else if (Attack_cnt >= Enemy_shield_cnt)
        {
            //DefenseBreak_SD.Play();
            Enemy_curHp -= (Attack_cnt - Enemy_shield_cnt);
            Enemy_shield_cnt = 0;
            //doneDamage_init += (Attack_cnt - Enemy_shield_cnt);
            doneDamage_init += Attack_cnt;
        }
        else
        {
            //BlockAtk_SD.Play();
            Enemy_shield_cnt -= Attack_cnt;
            doneDamage_init += Attack_cnt;
        }
        
    }

    public void EndTurn(int Attack_cnt)
    {
        if (Player_shield_cnt == 0)
        {
            //E_Atk_SD.Play();
            Player_curHp -= Attack_cnt;
            receivedDamage_init += Attack_cnt;
        }
        else if (Attack_cnt >= Player_shield_cnt)
        {
            //DefenseBreak_SD.Play();
            Player_curHp -= (Attack_cnt - Player_shield_cnt);
            Player_shield_cnt = 0;
            receivedDamage_init += Attack_cnt;
        }
        else
        {
            //BlockAtk_SD.Play();
            Player_shield_cnt -= Attack_cnt;
            receivedDamage_init += Attack_cnt;
        }
    }
    public void CostManager()
    {
        if (curcost <= 0)
        {
            Live_Cost.gameObject.SetActive(false);
            D_Cost.gameObject.SetActive(true);
        }
        else
        {
            Live_Cost.gameObject.SetActive(true);
            D_Cost.gameObject.SetActive(false);
        }
    }
}