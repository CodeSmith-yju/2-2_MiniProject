using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NextSeance : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage;
    public Sprite normalSprite;
    public Sprite hoverSprite;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        normalSprite = buttonImage.sprite; // 기본 이미지 저장
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 마우스를 올렸을 때 호출되는 메서드
        if (buttonImage != null && hoverSprite != null)
        {
            buttonImage.sprite = hoverSprite; // hoverSprite로 이미지 변경
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 마우스를 내렸을 때 호출되는 메서드
        if (buttonImage != null && normalSprite != null)
        {
            buttonImage.sprite = normalSprite; // normalSprite로 이미지 변경
        }
    }
}
