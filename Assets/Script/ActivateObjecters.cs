using UnityEngine;

public class ActivateObjecters : MonoBehaviour
{
    public GameObject[] objectsToActivate;

    public void Activate()
    {
        Time.timeScale = 1;

        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }
    }
}
