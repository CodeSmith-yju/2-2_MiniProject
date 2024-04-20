using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActivateOnHoverBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image objectToActivate;
    public Button target_Btn;
    public Text target_Text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (target_Btn.interactable)
        {
            RectTransform rect = objectToActivate.GetComponent<RectTransform>();

            if (target_Btn.image.sprite.name.Equals("endTurnButton2"))
            {
                rect.sizeDelta = new Vector2(300, 260);
                objectToActivate.color = Color.red;
                target_Text.color = Color.red;
            }
            else
            {
                rect.sizeDelta = new Vector2(318, 290);

                objectToActivate.color = new Color32(22, 240, 255, 255);
                target_Text.color = new Color32(22, 240, 255, 255);
            }
            objectToActivate.gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (target_Btn.interactable)
        {
            objectToActivate.gameObject.SetActive(false);
            target_Text.color = Color.white;
        }
    }
}
