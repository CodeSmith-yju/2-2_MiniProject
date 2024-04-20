using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHoverReSize_Battle : MonoBehaviour
{

    private Vector3 ori_Scale;

    private void Start()
    {
        ori_Scale = transform.localScale;   
    }

    private void OnMouseEnter()
    {
        if (!HandingManager.Instance.battle.card_Hover_Sound_Obj.activeSelf)
        {
            HandingManager.Instance.battle.card_Hover_Sound.soundClip = HandingManager.Instance.battle.card_Sounds[3];
            HandingManager.Instance.battle.card_Hover_Sound_Obj.SetActive(true);
        }
    }


    private void OnMouseOver()
    {
        Vector3 new_Scale = ori_Scale * 1.2f;
        transform.localScale = new_Scale;
    }

    private void OnMouseExit()
    {
        if (HandingManager.Instance.battle.card_Hover_Sound_Obj.activeSelf)
        {
            HandingManager.Instance.battle.card_Hover_Sound_Obj.SetActive(false);
        }
        transform.localScale = ori_Scale;
    }
}
