using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject top_Bar;
    private Text header_Hp_Text;
    private Text header_Gold_Text;
    private Text header_battle_Cnt_Text;
    private Button set_Popup;
    private ActivateObject set_Btn;
    public Button btn_disable;

    private void Awake()
    {
        GameManager.battle_Count = 0;
        GameManager.kill_Init = 0;
        GameManager.card_Init = 0;
        GameManager.total_Dmg_Init = 0;
        GameManager.total_ReceivedDmg_Init = 0;

        GlobalData.cur_Hp = 80;
        GlobalData.max_Hp = 80;
        GlobalData.gold = 0;

        if(Deck.saveDeck != null)
        {
            Deck.saveDeck.Clear();
        }
        

        if (GameManager.battle_Count == 0)
        {
            DontDestroyOnLoad(top_Bar);
            btn_disable.gameObject.SetActive(false);
        }
        else if (GameManager.battle_Count != 0 && top_Bar == null)
        {
            Destroy(top_Bar);
        }


        
        

        header_battle_Cnt_Text = GameObject.Find("Top_Bar/TopBar/ICON/Floor/Map_Cnt").GetComponent<Text>();
        header_Hp_Text = GameObject.Find("Top_Bar/TopBar/ICON/Heart/NowHP").GetComponent<Text>();
        header_Gold_Text = GameObject.Find("Top_Bar/TopBar/ICON/Money/Gold_Cnt").GetComponent<Text>();
        set_Popup = GameObject.Find("Top_Bar/TopBar/ICON/Btns/Setting").GetComponent<Button>();

        set_Btn = set_Popup.GetComponent<ActivateObject>();
    }

    private void Update()
    {
        header_battle_Cnt_Text.text = $"{GameManager.battle_Count}";
        header_Hp_Text.text = $"{GlobalData.cur_Hp} / {GlobalData.max_Hp}";
        header_Gold_Text.text = $"{GlobalData.gold}";

        if (set_Btn.objectToActivate == null)
        {
            set_Btn.objectToActivate = GameObject.Find("Top_Bar/POPUP(set)/Popup(setting)");
        }
    }
}
