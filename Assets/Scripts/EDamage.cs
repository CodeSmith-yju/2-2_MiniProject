using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EDamage : MonoBehaviour
{
    public GameObject hudDamageText;

    public void TakeDamage(int E_damage)
    {
        //������ ��� �ڵ�
        GameObject hudText = Instantiate(hudDamageText);
        hudText.GetComponent<DamageText>().damage = E_damage;
    }

}
