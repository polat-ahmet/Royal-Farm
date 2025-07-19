using _RoyalFarm.Scripts.InputSystem.Data;
using _RoyalFarm.Scripts.Player.Animation;
using UnityEngine;

namespace _RoyalFarm.Scripts.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PlayerEvents.Instance.onMoveConditionChanged += OnMoveConditionChanged;
            PlayerEvents.Instance.onChangePlayerAnimationState += OnChangeAnimationState;

            PlayerEvents.Instance.onEnablePlayerAnimationLayer += OnEnableAnimationLayer;
            PlayerEvents.Instance.onDisablePlayerAnimationLayer += OnDisableAnimationLayer;
        }

        private void OnEnableAnimationLayer(PlayerAnimationLayerType layerType)
        {
            animator.SetLayerWeight((int)layerType, 1);
        }
        
        private void OnDisableAnimationLayer(PlayerAnimationLayerType layerType)
        {
            animator.SetLayerWeight((int)layerType, 0);
        }
        
        private void OnMoveConditionChanged(bool state)
        {
            if (state == false)
            {
                PlayIdleAnimation();
            }
        }
        
        private void OnChangeAnimationState(PlayerAnimationStateType animationStateType)
        {
            animator.Play(animationStateType.ToString());
        }

        internal void ManagerAnimationRegardingInputParam(InputParams inputParams)
        {
            if (inputParams.MoveVector.magnitude > 0)
            {
                PlayRunningAnimation(inputParams);
            }
            else
            {
                PlayIdleAnimation();
            }
        }

        private void PlayRunningAnimation(InputParams inputParams)
        {
            animator.Play(PlayerAnimationStateType.Running.ToString());
            animator.transform.forward = inputParams.MoveVector.normalized;
        }

        private void PlayIdleAnimation()
        {
            animator.Play(PlayerAnimationStateType.Idle.ToString());
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
        
        private void UnSubscribeEvents()
        {
            PlayerEvents.Instance.onMoveConditionChanged -= OnMoveConditionChanged;
            PlayerEvents.Instance.onChangePlayerAnimationState -= OnChangeAnimationState;

            PlayerEvents.Instance.onEnablePlayerAnimationLayer -= OnEnableAnimationLayer;
            PlayerEvents.Instance.onDisablePlayerAnimationLayer -= OnDisableAnimationLayer;
        }
    }
}