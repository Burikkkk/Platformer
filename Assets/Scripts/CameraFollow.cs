using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player; // �����
    [SerializeField] private float smoothSpeed = 5f; // �������� �������� ������
    [SerializeField] private Vector2 deadZone = new Vector2(2f, 1.5f); // ������ ������� ����

    private Vector3 initialOffset; // ��������� �������� ������
    private Vector3 targetPosition; // ������� ������� ������

    void Start()
    {
        // ���������� ��������� �������� ����� ������� � �������
        initialOffset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // ������� ������� ������ (� ������ ���������� ��������)
        targetPosition = player.position + initialOffset;

        // ���������, ����� �� ����� �� ������� ������� ����
        float deltaX = Mathf.Abs(transform.position.x - targetPosition.x);
        float deltaY = Mathf.Abs(transform.position.y - targetPosition.y);

        if (deltaX > deadZone.x || deltaY > deadZone.y)
        {
            // ������� ������ ������ ���� ����� ����� �� �������
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
