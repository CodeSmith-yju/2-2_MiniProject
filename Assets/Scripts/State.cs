using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    private int damage; // 데미지 정수 변수
    private int defense; // 방어도 상태 확인 후 방어도 정수 변수
    public bool attack = false; // 공격 상태 확인
    public bool block = false; // 방어도 상태 확인 (기본적으로 모든 턴 종료 후 false 상태로 변함)
    public bool power = false; // 힘 상태 확인
    public bool vulner = false; // 약화 상태 확인
    public bool weak = false; // 취약 상태 확인
    public int vulner_Duration = 0; // 손상 지속시간
    public int power_Count = 0; // 올라간 힘의 수 (힘 수만큼 데미지 증가)
    public int weak_Duration = 0; // 약화 지속시간

    [Header("Damage Text")]
    public GameObject hudDamageText;
    public Transform P_hudPos;
    public Transform E_hudPos;


    //데미지 출력 관련
    public void P_TakeDamage(int E_damage)
    {
        //데미지 출력 코드
        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = P_hudPos.position;
        hudText.GetComponent<DamageText>().damage = E_damage;
        Debug.Log("출력");
    }

    public void E_TakeDamage(int E_damage)
    {
        //데미지 출력 코드
        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = E_hudPos.position;
        hudText.GetComponent<DamageText>().damage = E_damage;
        Debug.Log("출력");
    }

    public void SetAttackDamage(int damage) {
        this.damage = damage;
    }

    public void SetDefense(int defense) {
        this.defense = defense;
    }

    public int GetAttackDamage() {
        return damage;
    }

    public int GetDefense() {
        return defense;
    }

    public void Vulner_Dur(int dur) {
        vulner = true;
        vulner_Duration += dur;
    }

    public void Weak_Dur(int dur) {
        weak = true;
        weak_Duration += dur;
    }
}
