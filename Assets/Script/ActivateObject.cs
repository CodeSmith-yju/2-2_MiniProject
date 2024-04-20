using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    public GameObject objectToActivate;
    public void Activate()
    {
        Time.timeScale = 0;
        objectToActivate.SetActive(true);
    }
}
