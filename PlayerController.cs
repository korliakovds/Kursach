using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Швидкість руху гравця
    private Rigidbody2D rb; // Компонент Rigidbody2D гравця
    private Vector2 movement; // Вектор руху гравця
    public Transform point1; // Точка 1 для використання у навігації
    [SerializeField] GameObject NavMesh; // Об'єкт NavMesh для зміщення
    public NavMeshAgent navMeshAgent; // Компонент NavMeshAgent для навігації


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Отримуємо компонент NavMeshAgent
        rb = GetComponent<Rigidbody2D>(); // Отримуємо компонент Rigidbody2D гравця
        navMeshAgent = GetComponent<NavMeshAgent>(); // Отримуємо компонент NavMeshAgent
        navMeshAgent.updateRotation = false; // Вимикаємо автоматичний поворот для NavMeshAgent
        navMeshAgent.updateUpAxis = false; // Вимикаємо автоматичне орієнтування по висоті для NavMeshAgent
    }

    void Update()
    {
       
       // Отримуємо значення осей горизонталі і вертикалі
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Формуємо вектор руху гравця
        movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Обробка натискання кнопок миші
        if (Input.GetMouseButtonDown(0))
        {
            navMeshAgent.SetDestination(point1.position); // Встановлюємо пункт призначення для навігації NavMeshAgent
            Debug.Log(navMeshAgent.SetDestination(point1.position)); // Виводимо пункт призначення в консоль
        }
        else if (Input.GetMouseButtonDown(1))
        {
            NavMesh.transform.Translate(Vector3.forward); // Зміщуємо об'єкт NavMesh вперед
        }
    }

    void FixedUpdate()
    {
        // Застосовуємо силу до Rigidbody2D гравця для переміщення
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

