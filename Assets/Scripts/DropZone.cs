using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class DropZone : BattleLogic, IDropHandler
{
    public CardLogic cardLogic;

    public void OnDrop(PointerEventData eventData)
    {
        Card dropCard = eventData.pointerDrag.GetComponent<Card>();
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if (HandingManager.Instance.endDraw && d.mousePointFollow)
        {
            d.isOnDropZone = true;
            if (d.isOnDropZone)
            {
                foreach (CardInit item in CardDataBase.cardList)
                {
                    if (dropCard.init.id == item.id)
                    {
                        if (cur_Cost >= dropCard.init.cost)
                        {
                            cur_Cost -= dropCard.init.cost;
                            cardLogic.CardCheck(dropCard.init.id); //카드 효과를 발현시킴
                            GameManager.card_Init++;
                            HandingManager.Instance.DropCard(0.3f, dropCard.order);

                            if (dropCard.init.id >= 8 && dropCard.init.id <= 13 && enemy.frenzu)
                            {
                                enemy_Eff.sprite = eff_Sp[2];
                                enemy_Eff.gameObject.SetActive(true);
                                if(enemy.power)
                                {
                                    enemy.power_Count++;
                                }
                                else
                                {
                                    enemy.power = true;
                                    E_Buff[0].gameObject.SetActive(true);
                                    enemy.power_Count++;
                                }
                            }
                        }
                        else
                        {
                            d.isOnDropZone = false;
                            d.DropZoneEndDrag();
                        }
                    }
                    HandingManager.Instance.SortAllCard();
                }
            }
        }
    }
}