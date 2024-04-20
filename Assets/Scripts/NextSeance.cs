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
        normalSprite = buttonImage.sprite; // �⺻ �̹��� ����
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // ���콺�� �÷��� �� ȣ��Ǵ� �޼���
        if (buttonImage != null && hoverSprite != null)
        {
            buttonImage.sprite = hoverSprite; // hoverSprite�� �̹��� ����
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ���콺�� ������ �� ȣ��Ǵ� �޼���
        if (buttonImage != null && normalSprite != null)
        {
            buttonImage.sprite = normalSprite; // normalSprite�� �̹��� ����
        }
    }
}
