using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<CardInit> cardList = new List<CardInit>();
    
    void Awake()
    {
        cardList.Clear();

        //공격 카드
        cardList.Add(new CardInit(0, "타격", 1, "피해를 6 줍니다.", "공격", GameManager.GetCardThumb("strike"), GameManager.GetCardThumb("BgAttack"), GameManager.GetCardThumb("EdgeAttackT1"), GameManager.GetCardThumb("NameT1")));
        cardList.Add(new CardInit(1, "강타", 2, "피해를 8 줍니다. 취약을 2 부여합니다.", "공격", GameManager.GetCardThumb("bash"), GameManager.GetCardThumb("BgAttack"), GameManager.GetCardThumb("EdgeAttackT1"), GameManager.GetCardThumb("NameT1")));
        cardList.Add(new CardInit(2, "몸통 박치기", 1, "현재 방어도 만큼의 피해를 줍니다.", "공격", GameManager.GetCardThumb("body_slam"), GameManager.GetCardThumb("BgAttack"), GameManager.GetCardThumb("EdgeAttackT1"), GameManager.GetCardThumb("NameT1")));
        cardList.Add(new CardInit(3, "클로스라인", 2, "피해를 12 줍니다. 약화를 2 부여합니다.", "공격", GameManager.GetCardThumb("clothesline"), GameManager.GetCardThumb("BgAttack"), GameManager.GetCardThumb("EdgeAttackT1"), GameManager.GetCardThumb("NameT1")));
        cardList.Add(new CardInit(4, "대검", 2, "피해를 14 줍니다. 힘의 효과가 3배로 적용됩니다.", "공격", GameManager.GetCardThumb("heavy_blade"), GameManager.GetCardThumb("BgAttack"), GameManager.GetCardThumb("EdgeAttackT1"), GameManager.GetCardThumb("NameT1")));
        cardList.Add(new CardInit(5, "폼멜 타격", 1, "피해를 9 줍니다. 카드를 1장 뽑습니다.", "공격", GameManager.GetCardThumb("pommel_strike"), GameManager.GetCardThumb("BgAttack"), GameManager.GetCardThumb("EdgeAttackT1"), GameManager.GetCardThumb("NameT1")));
        cardList.Add(new CardInit(6, "이중 타격", 1, "피해를 5만큼 2번 줍니다.", "공격", GameManager.GetCardThumb("twin_strike"), GameManager.GetCardThumb("BgAttack"), GameManager.GetCardThumb("EdgeAttackT1"), GameManager.GetCardThumb("NameT1")));
        cardList.Add(new CardInit(7, "혈류", 1, "체력을 2 잃습니다. 피해를 15 줍니다.", "공격", GameManager.GetCardThumb("hemokinesis"), GameManager.GetCardThumb("BgAttack"), GameManager.GetCardThumb("EdgeAttackT2"), GameManager.GetCardThumb("NameT2")));

        //스킬 카드
        cardList.Add(new CardInit(8, "수비", 1, "방어도를 5 얻습니다.", "스킬", GameManager.GetCardThumb("defend"), GameManager.GetCardThumb("BgSkill"), GameManager.GetCardThumb("EdgeSkillT1"), GameManager.GetCardThumb("NameT1")));
        cardList.Add(new CardInit(9, "몸 풀기", 0, "힘을 2 얻습니다. 턴이 끝날 때 힘을 2 잃습니다.", "스킬", GameManager.GetCardThumb("flex"), GameManager.GetCardThumb("BgSkill"), GameManager.GetCardThumb("EdgeSkillT1"), GameManager.GetCardThumb("NameT1")));
        cardList.Add(new CardInit(10, "흘려보내기", 1, "방어도를 8 얻습니다. 카드를 1장 뽑습니다.", "스킬", GameManager.GetCardThumb("shrug_it_off"), GameManager.GetCardThumb("BgSkill"), GameManager.GetCardThumb("EdgeSkillT1"), GameManager.GetCardThumb("NameT1")));
        cardList.Add(new CardInit(11, "사혈", 0, "체력을 3 잃습니다. 코스트를 2 회복합니다", "스킬", GameManager.GetCardThumb("bloodletting"), GameManager.GetCardThumb("BgSkill"), GameManager.GetCardThumb("EdgeSkillT2"), GameManager.GetCardThumb("NameT2")));
        cardList.Add(new CardInit(12, "전투 최면", 0, "카드를 3장 뽑습니다.", "스킬", GameManager.GetCardThumb("battle_trance"), GameManager.GetCardThumb("BgSkill"), GameManager.GetCardThumb("EdgeSkillT2"), GameManager.GetCardThumb("NameT2")));
        cardList.Add(new CardInit(13, "참호", 2, "방어도가 2배로 증가합니다", "스킬", GameManager.GetCardThumb("entrench"), GameManager.GetCardThumb("BgSkill"), GameManager.GetCardThumb("EdgeSkillT2"), GameManager.GetCardThumb("NameT2")));

        //파워 카드
        cardList.Add(new CardInit(14, "발화", 1, "힘을 2 얻습니다.", "스킬", GameManager.GetCardThumb("inflame"), GameManager.GetCardThumb("BgPower"), GameManager.GetCardThumb("EdgePowerT2"), GameManager.GetCardThumb("NameT2")));
        cardList.Add(new CardInit(15, "금속화", 1, "턴 종료 시 방어도를 3 얻습니다.", "스킬", GameManager.GetCardThumb("metallicize"), GameManager.GetCardThumb("BgPower"), GameManager.GetCardThumb("EdgePowerT2"), GameManager.GetCardThumb("NameT2")));
        
    }
}
