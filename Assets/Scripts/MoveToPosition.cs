using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    // Inspector에서 설정할 대상 위치
    public Transform targetTransform;

    // Inspector에서 조절할 이동 속도
    public float moveSpeed = 5f;

    private bool hasMoved = false;

    void Update()
    {
        if (!hasMoved && targetTransform != null)
        {
            // 현재 위치에서 타겟 위치까지 이동
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetTransform.position,
                moveSpeed * Time.deltaTime
            );

            // 도착 여부 체크
            if (Vector3.Distance(transform.position, targetTransform.position) < 0.01f)
            {
                hasMoved = true;
            }
        }
    }
}
