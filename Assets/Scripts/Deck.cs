using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;//ToList를 사용하기 위해 사용.

public class Deck : Pile
{
    public static List<CardInit> saveDeck;
    public List<CardInit> saveDeck_View;

    public static System.Action action_Deck; // 11- 19

    private void Awake()    //GameManager에서 Deck스크립트의 AddDeckMake() 메서드를 참조하게하기위해서 작성한 코드
    {
        //InitializeActionDeck();
        //if (GameManager.turn == GameManager.Turn.PlayerTurn){ Debug.Log("PlayerTrun"); }
        //DontDestroyOnLoad(gameObject)
    }
    private void InitializeActionDeck()
    {
        action_Deck = () => { AddDeckMake(); };
        Debug.Log("action_Deck initialized!");
    }

    public void Show_SaveDeck()
    {
        saveDeck_View = saveDeck.ToList();
    }



    void Start()
    {
        DefaultDeckMake();
    }

    private void DefaultDeckMake() {
        pileCount = transform.Find("Circle").transform.Find("Count").GetComponent<Text>();
        if (GameManager.battle_Count == 1)
        {
            saveDeck = new List<CardInit>();
            for (int i = 0; i < 12; i++)
            {
                if (i <= 2)
                {
                    saveDeck.Add(CardDataBase.cardList[0]);
                }
                else if (i == 3)
                {
                    saveDeck.Add(CardDataBase.cardList[1]);
                }
                else if (i == 4)
                {
                    saveDeck.Add(CardDataBase.cardList[3]);
                }
                else if (i == 5)
                {
                    saveDeck.Add(CardDataBase.cardList[5]);
                }
                else if (i == 6)
                {
                    saveDeck.Add(CardDataBase.cardList[6]);
                }
                else if (i <= 9)
                {
                    saveDeck.Add(CardDataBase.cardList[8]);
                }
                else if (i == 10)
                {
                    saveDeck.Add(CardDataBase.cardList[9]);
                }
                else if (i == 11)
                {
                    saveDeck.Add(CardDataBase.cardList[10]);
                }
            }

        }
        pile = saveDeck.ToList();
        Show_SaveDeck();
        Shuffle.shuffle(pile);
        pileCount.text = pile.Count.ToString();
    }
    /// <summary>
    /// pile List내의 원소를 무작위로 섞는다.
    /// </summary>
    public void ShufflePile()
    {
        Shuffle.shuffle(pile);
    }

    //11-18 추가
    /// <summary>
    /// saveDeck에 랜덤한 카드를 추가하고 섞인 덱의 카드 수를 UI에 표시하는코드
    /// </summary>
    public void AddDeckMake()
    {
        // Unity의 Random 클래스 사용
        int randomIndex = UnityEngine.Random.Range(0, CardDataBase.cardList.Count);

        // UI Text 컴포넌트를 찾아서 할당
        pileCount = transform.Find("Circle").transform.Find("Count").GetComponent<Text>();

        // 카드 리스트(CardInit)에 무작위로 선택된 카드를 추가
        pile.Add(CardDataBase.cardList[randomIndex]);

        // 리스트를 Pile(List)에 할당하고, 이를 리스트로 변환
        pile = saveDeck.ToList();

        // UI에 현재 덱의 카드 수를 표시
        pileCount.text = pile.Count.ToString();
    }
}
