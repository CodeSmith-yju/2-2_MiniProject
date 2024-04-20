using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTip_control : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Relic Relic_obj;
    public ToolTip tooltip;
    public int desc_Value;
    //private int relic_num;//switch문사용해서 relic_num에따라 툴팁셋업이 달라진다면?

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (desc_Value){
            case 0:
                tooltip.gameObject.SetActive(true);
                tooltip.SetupTooltip(Relic_obj.burning_blood_name, Relic_obj.burning_blood_desc, Relic_obj.burning_blood_desc2, Relic_obj.burning_blood_desc3);
                break;
            case 1:
                tooltip.gameObject.SetActive(true);
                tooltip.SetupTooltip(Relic_obj.blood_bottle_name, Relic_obj.blood_bottle_desc, Relic_obj.blood_bottle_desc2, Relic_obj.blood_bottle_desc3);
                break;
        }
            
        //tooltip.SetupTooltip(rc.burning_blood_name, rc.burning_blood_desc, rc.burning_blood_desc2, rc.burning_blood_desc3);
        //tooltip.gameObject.SetActive(true);
        //tooltip.SetupTooltip(rc.blood_bottle_name, rc.blood_bottle_desc, rc.blood_bottle_desc2, rc.blood_bottle_desc3);
        //tooltip.SetupTooltip(player.burning_blood_name, player.burning_blood_desc, player.burning_blood_desc2, player.burning_blood_desc3 );
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
