using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject Field_Obj;
    public List<Sprite> listCardThumbs;
    private static Dictionary<string, Sprite> dictCardThumbs = new Dictionary<string, Sprite>();
    public GameObject top_Bar;
    private Text header_Hp_Text;
    private Text header_Gold_Text;
    private Text header_battle_Cnt_Text;
    private Button set_Popup;
    private ActivateObject set_Btn;

    public enum Turn
    {
        Battle, PlayerTurn, EnemyTurn, EndTurn, BattleEnd, GameOver
    }

    public static Turn turn;

    public static int turn_Count = 0;
    public static int battle_Count = 0;

    public static int card_Init = 0;
    public static int kill_Init = 0;
    public static int total_Dmg_Init = 0;
    public static int total_ReceivedDmg_Init = 0;

    public static bool player_Dead_Check;
    public static bool enemy_Dead_Check;

    //[HideInInspector] public bool BtnEv = false;//내가대충적어놓은거 10-29

    private void Awake()
    {
        dictCardThumbs.Clear();
        foreach (var sp in listCardThumbs)
        {
            dictCardThumbs.Add(sp.name.ToLower(), sp);
        }

        player_Dead_Check = false;
        enemy_Dead_Check = false;

        ++battle_Count;

        header_battle_Cnt_Text = GameObject.Find("Top_Bar/TopBar/ICON/Floor/Map_Cnt").GetComponent<Text>();
        header_Hp_Text = GameObject.Find("Top_Bar/TopBar/ICON/Heart/NowHP").GetComponent<Text>();
        header_Gold_Text = GameObject.Find("Top_Bar/TopBar/ICON/Money/Gold_Cnt").GetComponent<Text>();
        set_Popup = GameObject.Find("Top_Bar/TopBar/ICON/Btns/Setting").GetComponent<Button>();

        set_Btn = set_Popup.GetComponent<ActivateObject>();

    }

    private void Update()
    {
        header_battle_Cnt_Text.text = $"{battle_Count}";
        header_Hp_Text.text = $"{GlobalData.cur_Hp} / {GlobalData.max_Hp}";
        header_Gold_Text.text = $"{GlobalData.gold}";

        if (set_Btn.objectToActivate == null)
        {
            set_Btn.objectToActivate = GameObject.Find("Top_Bar/POPUP(set)/Popup(setting)");
        }
    }

    public static Sprite GetCardThumb(string name)
    {
        dictCardThumbs.TryGetValue(name.ToLower(), out Sprite sp);
        return sp;
    }
}
