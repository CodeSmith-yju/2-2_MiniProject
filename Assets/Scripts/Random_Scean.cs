using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Random_Scean : MonoBehaviour
{
    public GameObject[] events;
    public GameObject[] slime_results;
    public GameObject[] joust_results;
    public GameObject[] fishing_results;
    int ran;

    public Button[] slime_Btn;
    public Button[] joust_Btn;
    public Button[] fishing_Btn;

    public GameObject add_Card_Clone;
    public GameObject popup;

    //이 씬이 실행될때 모든 오브젝트를 초기화.
    private void Awake()
    {
        for(int i = 0; i < events.Length; i++)
        {
            events[i].SetActive(false);
        }

        //for (int i = 0; i < results.Length; i++){results[i].SetActive(false);}
    }
    //초기화 후 랜덤하게 하나의 오브젝트를 표시.
    private void Start()
    {
        ran = Random.Range(0, 3);
        if (GlobalData.gold < 50)
        {
            while(ran != 1)
            {
                ran = Random.Range(0, 3);
            }  
        }
       
        events[ran].SetActive(true);

        ButtonSetting(ran);
    }


    private void Act_Events(int cnt)
    {
        switch(cnt)
        {
            case 0: // 첫번째 버튼 이벤트
                if(ran == 0) // 돈 얻으려는 행동 이벤트
                {
                    events[ran].SetActive(false);
                    slime_results[cnt].SetActive(true);
                    if ((GlobalData.cur_Hp - 11) <= 0)
                    {
                        GameManager.player_Dead_Check = true;
                        HandingManager.Instance.BattleEnd();
                    }
                    else
                    {
                        GlobalData.cur_Hp -= 11;
                        GlobalData.gold += 75;
                    }
                }
                else if (ran == 1) // 살인마에게 내기
                {
                    events[ran].SetActive(false);
                    GlobalData.gold -= 50;
                    int ran_Check = Random.Range(0, 10);
                    if (ran_Check <= 6)
                    {
                        ran_Check = 0;
                    }
                    else
                    {
                        ran_Check = 1;
                    }
                    switch(ran_Check)
                    {
                        case 0:
                            GlobalData.gold += 100;
                            joust_results[0].SetActive(true);
                            break;
                        case 1:
                            joust_results[1].SetActive(true);
                            break;
                    }
                }
                else // 바나나 
                {
                    events[ran].SetActive(false);
                    fishing_results[cnt].SetActive(true);
                    if ((GlobalData.cur_Hp + 23) >= GlobalData.max_Hp)
                    {
                        GlobalData.cur_Hp = GlobalData.max_Hp;
                    }
                    else
                    {
                        GlobalData.cur_Hp += 23;
                    }
                    Debug.Log("체력 회복");
                }
                break;
            case 1: // 두번째 버튼 이벤트
                if (ran == 0) // 돈 안 얻고 떠나기
                {
                    events[ran].SetActive(false);
                    slime_results[cnt].SetActive(true);
                    if ((GlobalData.gold - 33) <= 0)
                    {
                        GlobalData.gold = 0;
                    }
                    else
                    {
                        GlobalData.gold -= 33;
                    }
                }
                else if (ran == 1) // 마스터에게 내기 걸기
                {
                    events[ran].SetActive(false);
                    GlobalData.gold -= 50;
                    int ran_Check = Random.Range(0, 10);
                    if (ran_Check <= 2)
                    {
                        ran_Check = 0;
                    }
                    else
                    {
                        ran_Check = 1;
                    }
                    switch (ran_Check)
                    {
                        case 0:
                            GlobalData.gold += 250;
                            joust_results[2].SetActive(true);
                            break;
                        case 1:
                            joust_results[3].SetActive(true);
                            break;
                    }
                }
                else // 도넛 이벤트
                {
                    events[ran].SetActive(false);
                    fishing_results[cnt].SetActive(true);
                    GlobalData.max_Hp += 5;
                }
                break;
            case 2: // 세번째 버튼 이벤트
                
                if(ran == 2)
                {
                    events[ran].SetActive(false);
                    fishing_results[cnt].SetActive(true);

                    Debug.Log("카드 얻기");
                    GameObject obj = Instantiate(add_Card_Clone);
                    Card temp = obj.GetComponent<Card>();
                    Draggable drag = obj.GetComponent<Draggable>();
                    Destroy(drag);

                    temp.transform.SetParent(popup.transform);


                    int ran_Card = Random.Range(0, CardDataBase.cardList.Count);

                    temp.SetInitializeData(CardDataBase.cardList[ran_Card]);
                    obj.transform.localScale = new Vector3(0.9f, 0.9f);

                    Deck.saveDeck.Add(CardDataBase.cardList[ran_Card]);
                }
                break;
        }
    }

    private void ButtonSetting(int index)
    {
        switch (index)
        {
            case 0:
                for (int i = 0; i < slime_Btn.Length; i++)
                {
                    int buttonIndex = i;
                    slime_Btn[i].GetComponent<Button>();
                    slime_Btn[i].onClick.AddListener(() => Act_Events(buttonIndex));
                }
                break;
            case 1:
                for (int i = 0; i < joust_Btn.Length; i++)
                {
                    int buttonIndex = i;
                    joust_Btn[i].GetComponent<Button>();
                    joust_Btn[i].onClick.AddListener(() => Act_Events(buttonIndex));
                }
                break;
            case 2:
                for (int i = 0; i < fishing_Btn.Length; i++)
                {
                    int buttonIndex = i;
                    fishing_Btn[i].GetComponent<Button>();
                    fishing_Btn[i].onClick.AddListener(() => Act_Events(buttonIndex));
                }
                break;
        }
    }




}
