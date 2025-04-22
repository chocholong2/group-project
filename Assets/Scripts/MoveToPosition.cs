using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    // Inspector���� ������ ��� ��ġ
    public Transform targetTransform;

    // Inspector���� ������ �̵� �ӵ�
    public float moveSpeed = 5f;

    private bool hasMoved = false;

    void Update()
    {
        if (!hasMoved && targetTransform != null)
        {
            // ���� ��ġ���� Ÿ�� ��ġ���� �̵�
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetTransform.position,
                moveSpeed * Time.deltaTime
            );

            // ���� ���� üũ
            if (Vector3.Distance(transform.position, targetTransform.position) < 0.01f)
            {
                hasMoved = true;
            }
        }
    }
}
