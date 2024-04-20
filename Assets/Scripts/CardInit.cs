using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[System.Serializable]
public class CardInit
{
    public int id;
    public string cardName;
    public int cost;
    public string cardDescription;
    public string cardType;
    public Sprite thumb;
    public Sprite bgThumb;
    public Sprite edgeThumb;
    public Sprite nameThumb;

    public CardInit()
    {

    }

    public CardInit(int Id, string CardName, int Cost, string CardDescription, string CardType , Sprite spThumb, Sprite spBgThumb, Sprite spEdgeThumb, Sprite spNameThumb)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        cardDescription = CardDescription;
        cardType = CardType;
        this.thumb = spThumb;
        this.bgThumb = spBgThumb;
        this.edgeThumb = spEdgeThumb;
        this.nameThumb = spNameThumb;
    }

}
