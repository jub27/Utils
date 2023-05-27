using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMove : MonoBehaviour
{
    private enum MoveType
    {
        Move,
        SimpleMove
    }

    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private MoveType _moveType;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Vector3 moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        switch (_moveType)
        {
            case MoveType.Move:
                //CharacterController�� Move �Լ��� ���� * �ӷ� * �ð��� �Է�, �߷��� ������ ����
                _characterController.Move(moveVector.normalized * _moveSpeed * Time.deltaTime);
                break;
            case MoveType.SimpleMove:
                //CharacterController�� SimpleMove �Լ��� ���� * �ӷ� �Է�, �߷� �ڵ� ó��
                _characterController.SimpleMove(moveVector.normalized * _moveSpeed);
                break;
        }
        Debug.Log(_characterController.velocity);
    }
}
