using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Random : MonoBehaviour
{
    public GameObject clone_CardPrefeb;
    public GameObject shopPopUp;
    public Button close_Btn;
    public SoundManager shop;

    public List<int> price = new List<int>();

    public Deck deck;
    private int ran;

    private List<int> dup_Num_Check = new List<int>();


    private void Start()
    {
        for (int i = 0; i < shopPopUp.transform.childCount; i++)
        {
            int ran_Price = Random.Range(30, 60);
            price.Add(ran_Price);

            ShopCardPrint(shopPopUp.transform.GetChild(i), price[i]);
        }

        dup_Num_Check.Clear();
    }


    public void ShowPopup()
    {
        shopPopUp.SetActive(true);
        close_Btn.gameObject.SetActive(true);

        if (!shop.sound_Obj[2].activeSelf)
        {
            shop.card_Sound[2].soundClip = shop.ui_Sounds[0];
            shop.sound_Obj[2].SetActive(true);
        }
        else if (!shop.sound_Obj[3].activeSelf)
        {
            shop.card_Sound[3].soundClip = shop.ui_Sounds[0];
            shop.sound_Obj[3].SetActive(true);
        }
        else
        {
            shop.card_Sound[4].soundClip = shop.ui_Sounds[0];
            shop.sound_Obj[4].SetActive(true);
        }
    }

    public void ClosePopup()
    {
        if (!shop.sound_Obj[2].activeSelf)
        {
            shop.card_Sound[2].soundClip = shop.ui_Sounds[3];
            shop.sound_Obj[2].SetActive(true);
        }
        else if (!shop.sound_Obj[3].activeSelf)
        {
            shop.card_Sound[3].soundClip = shop.ui_Sounds[3];
            shop.sound_Obj[3].SetActive(true);
        }
        else
        {
            shop.card_Sound[4].soundClip = shop.ui_Sounds[3];
            shop.sound_Obj[4].SetActive(true);
        }
        shopPopUp.SetActive(false);
        close_Btn.gameObject.SetActive(false);
    }


    public void ShopCardPrint(Transform cnt, int price)
    {
        GameObject obj = Instantiate(clone_CardPrefeb);
        Card temp = obj.GetComponent<Card>();
        Draggable drag = obj.GetComponent<Draggable>();
        Button btn = obj.AddComponent<Button>();
        CardHoverReSize resize = obj.AddComponent<CardHoverReSize>();
        resize.shop = shop;

        temp.transform.SetParent(cnt);

        Text price_Text = cnt.transform.Find("PriceTag").transform.Find("GoldImg").transform.Find("PriceText").GetComponent<Text>();
        price_Text.text = price.ToString();

        ran = Random.Range(0, CardDataBase.cardList.Count);
        int ran_Check;

        ran_Check = ran;
        ran_Check = Duplicate_Id_Check(ran);

        temp.SetInitializeData(CardDataBase.cardList[ran_Check]);
        obj.transform.localScale = new Vector3(1.1f, 1.1f);
        btn.onClick.AddListener(() => SaveDeckAdd(temp, cnt, price));
        Destroy(drag);

        dup_Num_Check.Add(ran_Check);
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


    private void SaveDeckAdd(Card card, Transform gameObject, int price)
    {
        if(GlobalData.gold >= price)
        {
            GlobalData.gold -= price;
            if (!shop.sound_Obj[2].activeSelf)
            {
                shop.card_Sound[0].soundClip = shop.card_Sounds[0];
                shop.sound_Obj[0].SetActive(true);
                shop.card_Sound[2].soundClip = shop.ui_Sounds[1];
                shop.sound_Obj[2].SetActive(true);
            }
            else if (!shop.sound_Obj[3].activeSelf)
            {
                shop.card_Sound[0].soundClip = shop.card_Sounds[0];
                shop.sound_Obj[0].SetActive(true);
                shop.card_Sound[3].soundClip = shop.ui_Sounds[1];
                shop.sound_Obj[3].SetActive(true);
            }
            else
            {
                shop.card_Sound[0].soundClip = shop.card_Sounds[0];
                shop.sound_Obj[0].SetActive(true);
                shop.card_Sound[4].soundClip = shop.ui_Sounds[1];
                shop.sound_Obj[4].SetActive(true);
            }

            Deck.saveDeck.Add(CardDataBase.cardList[card.init.id]);
            deck.Show_SaveDeck();

            for (int i = 0; i < gameObject.childCount; i++)
            {
                if (i != 0)
                {
                    gameObject.GetChild(i).gameObject.SetActive(false);
                }
                else
                {
                    gameObject.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
        else
        {
            if (!shop.sound_Obj[2].activeSelf)
            {
                shop.card_Sound[2].soundClip = shop.ui_Sounds[2];
                shop.sound_Obj[2].SetActive(true);
                shop.card_Sound[0].soundClip = shop.card_Sounds[3];
                shop.sound_Obj[0].SetActive(true);
            }
            else if (!shop.sound_Obj[3].activeSelf)
            {
                shop.card_Sound[3].soundClip = shop.ui_Sounds[2];
                shop.sound_Obj[3].SetActive(true);
                shop.card_Sound[0].soundClip = shop.card_Sounds[3];
                shop.sound_Obj[0].SetActive(true);
            }
            else
            {
                shop.card_Sound[4].soundClip = shop.ui_Sounds[2];
                shop.sound_Obj[4].SetActive(true);
                shop.card_Sound[0].soundClip = shop.card_Sounds[3];
                shop.sound_Obj[0].SetActive(true);
            }
            return;
        }
    }
}
