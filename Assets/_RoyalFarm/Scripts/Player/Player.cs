using System;
using _RoyalFarm.Scripts.InputSystem;
using _RoyalFarm.Scripts.InputSystem.Data;
using _RoyalFarm.Scripts.Player.Data;
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

        private void Awake()
        {
            _data = GetPlayerData();
            SendPlayerDataToControllers();
        }

        private PlayerData GetPlayerData() => Resources.Load<PlayerSO>(PlayerDataPath).Data;

        private void SendPlayerDataToControllers()
        {
            movementController.SetMovementData(_data.MovementData);
        }

        private void Start()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            //TODO canMove parameter shouldn't managed by input taken or released.
            InputEvents.Instance.onInputTaken += () => PlayerEvents.Instance.onMoveConditionChanged?.Invoke(true);
            InputEvents.Instance.onInputReleased += () => PlayerEvents.Instance.onMoveConditionChanged?.Invoke(false);
            InputEvents.Instance.onInputDragged += OnInputDragged;

            PlayerEvents.Instance.onCropFieldEntered += OnCropFieldEntered;
            PlayerEvents.Instance.onCropFieldExited += OnCropFieldExited;
        }
        
        //TODO change InputParams to PlayerData->MoveVector
        private void OnInputDragged(InputParams inputParams)
        {
            movementController.UpdateInputValue(inputParams);
            animationController.ManagerAnimationRegardingInputParam(inputParams);
        }

        //TODO move to state
        private void OnCropFieldEntered()
        {
            animationController.PlaySowAnimation();
        }

        private void OnCropFieldExited()
        {
            animationController.StopSowAnimation();
        }

        
        private void OnDestroy()
        {
            UnSubscribeEvents();
        }

        private void UnSubscribeEvents()
        {
            InputEvents.Instance.onInputTaken -= () => PlayerEvents.Instance.onMoveConditionChanged?.Invoke(true);
            InputEvents.Instance.onInputReleased -= () => PlayerEvents.Instance.onMoveConditionChanged?.Invoke(false);
            InputEvents.Instance.onInputDragged -= OnInputDragged;

            PlayerEvents.Instance.onCropFieldEntered += OnCropFieldEntered;
            PlayerEvents.Instance.onCropFieldExited += OnCropFieldExited;
        }
    }
}