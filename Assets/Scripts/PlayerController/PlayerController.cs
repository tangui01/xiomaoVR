using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 第一视角玩家控制器
/// </summary>
public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    private float InputX;
    private float InputY;

    [SerializeField] private float MoveSpeed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        GetInput();
        Move();
    }
    private void GetInput()
    {
        InputX = Input.GetAxisRaw("Horizontal");
        InputY = Input.GetAxisRaw("Vertical");
    }
    private void Move()
    {
        Vector3 dir = transform.forward * InputY * MoveSpeed * Time.deltaTime + InputX*Time.deltaTime * MoveSpeed* transform.right;
        characterController.Move(dir);
    }
}
