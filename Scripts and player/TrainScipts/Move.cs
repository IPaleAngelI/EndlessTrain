using UnityEngine;

public class WheelController : MonoBehaviour
{
    public Rigidbody rb; // Ссылка на компонент Rigidbody
    public float torqueForce = 10f; // Сила крутящего момента
    public float wheelRadius = 0.5f; // Радиус колеса

    private void Start()
    {
        // Получаем компонент Rigidbody, если он не был назначен в инспекторе
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        // Проверяем нажатие клавиш "W" и "S"
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveBackward();
        }
    }

    private void MoveForward()
    {
        // Применяем крутящий момент для вращения колеса вперед
        Vector3 torque = transform.right * torqueForce;
        rb.AddTorque(torque, ForceMode.Force);
    }

    private void MoveBackward()
    {
        // Применяем крутящий момент для вращения колеса назад
        Vector3 torque = -transform.right * torqueForce;
        rb.AddTorque(torque, ForceMode.Force);
    }

    private void FixedUpdate()
    {
        // Обновляем позицию колеса в зависимости от его вращения
        float distanceTravelled = rb.angularVelocity.magnitude * wheelRadius * Time.fixedDeltaTime;
        Vector3 movement = transform.forward * distanceTravelled;
        rb.MovePosition(rb.position + movement);
    }
}