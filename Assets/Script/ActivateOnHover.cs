using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActivateOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objectToActivate;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }
    }
}
