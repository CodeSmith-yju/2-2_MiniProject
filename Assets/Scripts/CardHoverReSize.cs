using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHoverReSize : MonoBehaviour
{

    private Vector3 ori_Scale;
    public SoundManager shop;

    private void Start()
    {
        ori_Scale = transform.localScale;   
    }

    private void OnMouseEnter()
    {
        if (!shop.sound_Obj[1].activeSelf)
        {
            shop.card_Sound[1].soundClip = shop.card_Sounds[1];
            shop.sound_Obj[1].SetActive(true);
        }
    }


    private void OnMouseOver()
    {
        Vector3 new_Scale = ori_Scale * 1.2f;
        transform.localScale = new_Scale;
    }

    private void OnMouseExit()
    {
        if (shop.sound_Obj[1].activeSelf)
        {
            shop.sound_Obj[1].SetActive(false);
        }
        transform.localScale = ori_Scale;
    }
}
