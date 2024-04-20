using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class HpManager : MonoBehaviour
{
    [Header("PLAYER")]
    public int Player_maxHp;    //�÷��̾� �ִ� ü�� ���ڰ�
    public int Player_curHp;    //�÷��̾� ���� ü�� ���ڰ�

    public Image Player_Hpbar;  //�÷��̾� ü�¹� �̹���
    public Image Player_Shield; //�÷��̾� ����� �̹���

    public Text Player_hptxt;   //�÷��̾� ü���� ȭ�鿡 ǥ���� �ؽ�Ʈ
    public Text P_S_Cnt;        //�÷��̾��� ���� ��ġ�� ȭ�鿡 ǥ���� �ؽ�Ʈ
    public Text Bar_HP;         //��ܹ� ���� �÷��̾� ü�� ��ġ�� ǥ���� �ؽ�Ʈ
    //public Text P_S_HP;       //�̰� �ʿ���°�

    [Header("Enemy")]
    public int Enemy_maxHp;     //���ʹ� �ִ� ü�� ���ڰ�
    public int Enemy_curHp;     //���ʹ� ���� ü�� ���ڰ�

    public Image Enemy_Hpbar;   //���ʹ� ü�¹� �̹���
    public Image Enemy_Shield;  //���ʹ� ����� �̹���

    public Text Enemy_hptxt;    //���ʹ� ü���� ȭ�鿡 ǥ���� �ؽ�Ʈ
    public Text E_S_Cnt;        //���ʹ�  ���� ��ġ�� ȭ�鿡 ǥ���� �ؽ�Ʈ
    //public Text E_S_HP;

    [Header("Cost")]
    public int maxcost;
    public int curcost;
    public Text CostText;

    //11-01
    public GameObject Live_Cost;
    public GameObject D_Cost;


    [Header("Checker")]
    public bool E_Check = false;//�÷��̾�/�� ĳ���� ���üũ�� ����
    public bool P_Check = false;//�÷��̾�/�� ĳ���� ���üũ�� ����

    public bool Player_shieldCheck = false;//�÷��̾�/�� ĳ���� �� ���üũ�� ����
    public bool Enemy_shieldCheck = false;
    public int Player_shield_cnt;
    public int Enemy_shield_cnt;

    //11-03
    [Header("WinPopup")]
    //�¸���
    public Text card_Count;//����� ī���� ����
    public Text kill_Count;//����� ������ ��
    public Text done_Damage;//���� ���ط�
    public Text received_Damage;//���� ���ط�

    [Header("DefeatPopup")]
    //�й��
    public Text card_Count_deft;//����� ī���� ����
    public Text kill_Count_deft;//����� ������ ��
    public Text done_Damage_deft;//���� ���ط�
    public Text received_Damage_deft;//���� ���ط�

    [HideInInspector] public int cardCount_init;//�� ���� ������ ����..�� ������ Text�� ���� ��.
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
        Turn_Count.text = $"{Turn_Count_init} ��";
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