using UnityEngine;

public class DeactivateObject : MonoBehaviour
{
    public GameObject objectToDeactivate;

    public void Deactivate()
    {
        Time.timeScale = 1;
        objectToDeactivate.SetActive(false);
    }
}
