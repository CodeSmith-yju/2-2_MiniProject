using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_RandomSelect : MonoBehaviour
{
    public GameObject clone_CardPrefeb;
    public GameObject popup;
    public Deck deck;
    private int ran;
    private List<int> dup_Num_Check = new List<int>();

    public void Random_GeneratedCard()
    {
        popup.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            GameObject obj = Instantiate(clone_CardPrefeb);
            Card temp = obj.GetComponent<Card>();
            Draggable drag = obj.GetComponent<Draggable>();
            Button btn = obj.AddComponent<Button>();
            CardHoverReSize resize = obj.AddComponent<CardHoverReSize>();

            temp.transform.SetParent(popup.transform);

            ran = Random.Range(0, CardDataBase.cardList.Count);
            int ran_Check;

            if (i == 0)
            {
                ran_Check = ran;
            }
            else
            {
                ran_Check = Duplicate_Id_Check(ran);
            }

            temp.SetInitializeData(CardDataBase.cardList[ran_Check]);
            obj.transform.localScale = new Vector3(0.8f, 0.8f);
            btn.onClick.AddListener(() => SaveDeckAdd(temp));
            Destroy(drag);

            dup_Num_Check.Add(ran_Check);
        }

        dup_Num_Check.Clear();

    }

    int Duplicate_Id_Check(int cnt) 
    {
        int ran_card = Random.Range(0, CardDataBase.cardList.Count);

        if(dup_Num_Check.Contains(cnt) && !dup_Num_Check.Contains(ran_card))
        {
            return ran_card;
        }
        else if (dup_Num_Check.Contains(cnt) && dup_Num_Check.Contains(ran_card))
        {
            return Duplicate_Id_Check(cnt);
        }
        else
        {
            return cnt;
        }
    }


    private void SaveDeckAdd(Card card) 
    {
        if (!HandingManager.Instance.battle.card_Sound_Obj.activeSelf)
        {
            HandingManager.Instance.battle.card_Sound.soundClip = HandingManager.Instance.battle.card_Sounds[2];
            HandingManager.Instance.battle.card_Sound_Obj.SetActive(true);
            if (!HandingManager.Instance.battle.player_Eff_Sound_Obj.activeSelf)
            {
                HandingManager.Instance.battle.player_Eff_Sound.soundClip = HandingManager.Instance.battle.card_Sounds[4];
                HandingManager.Instance.battle.player_Eff_Sound_Obj.SetActive(true);
            }
        }

        Deck.saveDeck.Add(CardDataBase.cardList[card.init.id]);
        deck.Show_SaveDeck();
        popup.transform.DetachChildren();
        popup.SetActive(false);
    }


}
