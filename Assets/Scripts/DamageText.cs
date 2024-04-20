using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public float moveSpeed1;
    public float moveSpeed2;
    TextMeshPro text;
    public float destroyTime;
    public int damage;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.text = damage.ToString();
        Invoke("DestroyObject", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(moveSpeed1 * Time.deltaTime, moveSpeed2 * Time.deltaTime, 0));
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
