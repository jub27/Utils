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
                //CharacterController의 Move 함수는 방향 * 속력 * 시간을 입력, 중력은 계산되지 않음
                _characterController.Move(moveVector.normalized * _moveSpeed * Time.deltaTime);
                break;
            case MoveType.SimpleMove:
                //CharacterController의 SimpleMove 함수는 방향 * 속력 입력, 중력 자동 처리
                _characterController.SimpleMove(moveVector.normalized * _moveSpeed);
                break;
        }
        Debug.Log(_characterController.velocity);
    }
}
