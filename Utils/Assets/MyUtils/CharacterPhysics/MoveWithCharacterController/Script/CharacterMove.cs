using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoveWithCharacterController
{

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
        private float _jumpForce;
        [SerializeField]
        private float _gravity;
        [SerializeField]
        private MoveType _characterControllerMoveType;

        private CharacterController _characterController;
        private Vector3 _xzMoveVector = Vector3.zero;
        private float _yMoveSpeed = 0;
        private bool _isJumping;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            _xzMoveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            _xzMoveVector.Normalize();
            _xzMoveVector *= _moveSpeed;

            if (_characterController.isGrounded)
            {
                _isJumping = false;
                _yMoveSpeed = 0;
                if (Input.GetButton("Jump"))
                {
                    _yMoveSpeed = _jumpForce;
                }
            }
            else
            {
                _yMoveSpeed += -_gravity * Time.fixedDeltaTime;
            }

            Vector3 moveVector = new Vector3(_xzMoveVector.x, _yMoveSpeed, _xzMoveVector.z);
            var characterMoveResult = _characterController.Move(moveVector * Time.fixedDeltaTime);
        }
    }
}