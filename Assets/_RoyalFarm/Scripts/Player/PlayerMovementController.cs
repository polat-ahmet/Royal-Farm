using System;
using _RoyalFarm.Scripts.InputSystem.Data;
using _RoyalFarm.Scripts.Player.Data;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

namespace _RoyalFarm.Scripts.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        private CharacterController _characterController;

        [ShowInInspector] private PlayerMovementData _data;
        [ShowInInspector] private bool _canMove;
        [ShowInInspector] private Vector3 _inputValue;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _canMove = true;
        }

        internal void SetMovementData(PlayerMovementData movementData)
        {
            _data = movementData;
        }

        private void Start()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PlayerEvents.Instance.onMoveConditionChanged += OnMoveConditionChanged;
        }

        private void OnMoveConditionChanged(bool state) => _canMove = state;

        internal void UpdateInputValue(InputParams inputParams)
        {
            _inputValue = inputParams.MoveVector;
        }

        private void FixedUpdate()
        {
            if (!_canMove) return;

            Move();
        }

        private void Move()
        {
            var inputValue = _inputValue.normalized;
            Vector3 moveVector = inputValue * (_data.Speed * Time.fixedDeltaTime);

            moveVector.z = moveVector.y;
            moveVector.y = 0;

            _characterController.Move(moveVector);
        }

        private void OnDestroy()
        {
            UnSubscribeEvents();
        }

        private void UnSubscribeEvents()
        {
            PlayerEvents.Instance.onMoveConditionChanged -= OnMoveConditionChanged;
        }
    }
}