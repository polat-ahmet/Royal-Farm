using System;
using _RoyalFarm.Scripts.Crop;
using _RoyalFarm.Scripts.InputSystem;
using _RoyalFarm.Scripts.InputSystem.Data;
using _RoyalFarm.Scripts.Player.Data;
using _RoyalFarm.Scripts.Player.States;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _RoyalFarm.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerAnimationController animationController;

        [ShowInInspector] private PlayerData _data;
        private const string PlayerDataPath = "Data/PlayerSO";
        
        private PlayerStateMachine _stateMachine;

        private void Awake()
        {
            _data = GetPlayerData();
            SendPlayerDataToControllers();
        }

        private PlayerData GetPlayerData() => Resources.Load<PlayerSO>(PlayerDataPath).Data;

        //Delegate movement controls to states
        private void SendPlayerDataToControllers()
        {
            movementController.SetMovementData(_data.MovementData);
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            //TODO canMove parameter shouldn't managed by input taken or released.
            InputEvents.Instance.onInputTaken += () => PlayerEvents.Instance.onMoveConditionChanged?.Invoke(true);
            InputEvents.Instance.onInputReleased += () => PlayerEvents.Instance.onMoveConditionChanged?.Invoke(false);
            InputEvents.Instance.onInputDragged += OnInputDragged;
        }
        
        private void Start()
        {
            _stateMachine = new PlayerStateMachine();
            _stateMachine.Initialize();
        }
        
        //TODO change InputParams to PlayerData->MoveVector
        private void OnInputDragged(InputParams inputParams)
        {
            movementController.UpdateInputValue(inputParams);
            animationController.ManagerAnimationRegardingInputParam(inputParams);
        }
        
        private void OnDisable()
        {
            UnSubscribeEvents();
            _stateMachine.Dispose();
        }

        private void UnSubscribeEvents()
        {
            InputEvents.Instance.onInputTaken -= () => PlayerEvents.Instance.onMoveConditionChanged?.Invoke(true);
            InputEvents.Instance.onInputReleased -= () => PlayerEvents.Instance.onMoveConditionChanged?.Invoke(false);
            InputEvents.Instance.onInputDragged -= OnInputDragged;
        }
    }
}