using UnityEngine;

public class DeactivateObjecters : MonoBehaviour
{
    public GameObject[] objectsToDeactivate;

    public void Deactivate()
    {
        Time.timeScale = 1;

        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }
}
