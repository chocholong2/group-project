using UnityEngine;

public class Enemy : MonoBehaviour
{
    // HP ��
    [SerializeField] private float hp = 100f;

    // Inspector���� �Ҵ��� ��ǥ ��ġ�� Transform
    [SerializeField] private Transform targetPosition;

    // Inspector���� ���� ������ �̵� �ӵ�
    [SerializeField] private float moveSpeed = 5f;

    // �̵��� �Ϸ�Ǿ����� üũ�ϴ� �÷���
    private bool isMoving = false;

    // ����ִ��� üũ�ϴ� �÷���
    private bool isAlive = true;

    // Start�� ���� ���� �� ȣ��˴ϴ�
    void Start()
    {
        // targetPosition�� �����Ǿ� �ִ��� Ȯ��
        if (targetPosition != null)
        {
            // �̵� ����
            isMoving = true;
        }
        else
        {
            Debug.LogWarning("Target Position�� �������� �ʾҽ��ϴ�!");
        }
    }

    // Update�� �� �����Ӹ��� ȣ��˴ϴ�
    void Update()
    {
        // ������� ���� �̵�
        if (isAlive && isMoving && targetPosition != null)
        {
            // ���� ��ġ���� ��ǥ ��ġ�� �̵�
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition.position,
                moveSpeed * Time.deltaTime
            );

            // ��ǥ ��ġ�� �����ߴ��� Ȯ��
            if (Vector3.Distance(transform.position, targetPosition.position) < 0.001f)
            {
                // ��Ȯ�� ��ġ�� ��ġ
                transform.position = targetPosition.position;
                isMoving = false;

                // ���������� �˸�
                Debug.Log($"{gameObject.name}�� ��ǥ ��ġ�� �����߽��ϴ�.");
            }
        }
    }

    // �������� �޴� �Լ�
    public void Damaged(float damage)
    {
        // �̹� �׾��ٸ� �������� ���� ����
        if (isAlive ==false) return;

        // HP ����
        hp -= damage;

        Debug.Log($"{gameObject.name}��(��) {damage}�� �������� �޾ҽ��ϴ�. ���� HP: {hp}");

        // HP�� 0 ���ϰ� �Ǹ� Dead �Լ� ȣ��
        if (hp <= 0)
        {
            hp = 0;
            Dead();
        }
    }

    // ��� ó�� �Լ�
    private void Dead()
    {
        isAlive = false;
        isMoving = false;

        Debug.Log($"{gameObject.name}��(��) ����߽��ϴ�.");

        // ���� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }

    // ��Ÿ�� �߿� ��ǥ ��ġ�� �����ϱ� ���� �޼���
    public void SetTargetPosition(Transform newTarget)
    {
        targetPosition = newTarget;
        if (targetPosition != null && isAlive)
        {
            isMoving = true;
        }
    }

    // �̵� �ӵ��� ��Ÿ�� �߿� �����ϱ� ���� �޼���
    public void SetMoveSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    // HP�� ��ȯ�ϴ� �޼���
    public float GetHp()
    {
        return hp;
    }

    // ���� ���θ� ��ȯ�ϴ� �޼���
    public bool IsAlive()
    {
        return isAlive;
    }
}