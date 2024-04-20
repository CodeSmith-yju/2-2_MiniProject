using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Transform targetObject;
    public float moveSpeed = 50f;

    private Vector3 initialPosition;
    private bool isMoving = false;
    private float moveDistance = 1f; // 추가된 변수: 이동할 거리

    void Start()
    {
        initialPosition = targetObject.position;
    }

    public void Rightmove()
    {
        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(RightMoveObject());
        }
    }
    public void Leftmove()
    {
        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(LeftMoveObject());
        }
    }

    public void SetMoveDistance(float distance) // 추가된 함수: 이동할 거리 설정
    {
        moveDistance = distance;
    }

    IEnumerator RightMoveObject()
    {
        Vector3 targetPosition = targetObject.position + Vector3.right * moveDistance;

        while (Vector3.Distance(targetObject.position, targetPosition) > 0.01f)
        {
            targetObject.position = Vector3.MoveTowards(targetObject.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        while (Vector3.Distance(targetObject.position, initialPosition) > 0.01f)
        {
            targetObject.position = Vector3.MoveTowards(targetObject.position, initialPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }

    IEnumerator LeftMoveObject()
    {
        Vector3 targetPosition = targetObject.position + Vector3.left * moveDistance;

        while (Vector3.Distance(targetObject.position, targetPosition) > 0.01f)
        {
            targetObject.position = Vector3.MoveTowards(targetObject.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        while (Vector3.Distance(targetObject.position, initialPosition) > 0.01f)
        {
            targetObject.position = Vector3.MoveTowards(targetObject.position, initialPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }
}
