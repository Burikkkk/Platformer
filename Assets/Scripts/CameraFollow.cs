using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player; // Игрок
    [SerializeField] private float smoothSpeed = 5f; // Скорость движения камеры
    [SerializeField] private Vector2 deadZone = new Vector2(2f, 1.5f); // Размер мертвой зоны

    private Vector3 initialOffset; // Начальное смещение камеры
    private Vector3 targetPosition; // Целевая позиция камеры

    void Start()
    {
        // Запоминаем начальное смещение между игроком и камерой
        initialOffset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Целевая позиция камеры (с учетом начального смещения)
        targetPosition = player.position + initialOffset;

        // Проверяем, вышел ли игрок за пределы мертвой зоны
        float deltaX = Mathf.Abs(transform.position.x - targetPosition.x);
        float deltaY = Mathf.Abs(transform.position.y - targetPosition.y);

        if (deltaX > deadZone.x || deltaY > deadZone.y)
        {
            // Двигаем камеру только если игрок вышел за границы
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
