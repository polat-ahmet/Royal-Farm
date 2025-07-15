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

        private void OnEnableAnimationLayer(PlayerAnimationLayers layer)
        {
            animator.SetLayerWeight((int)layer, 1);
        }
        
        private void OnDisableAnimationLayer(PlayerAnimationLayers layer)
        {
            animator.SetLayerWeight((int)layer, 0);
        }
        
        private void OnMoveConditionChanged(bool state)
        {
            if (state == false)
            {
                PlayIdleAnimation();
            }
        }
        
        private void OnChangeAnimationState(PlayerAnimationStates animationState)
        {
            animator.Play(animationState.ToString());
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
            animator.Play(PlayerAnimationStates.Running.ToString());
            animator.transform.forward = inputParams.MoveVector.normalized;
        }

        private void PlayIdleAnimation()
        {
            animator.Play(PlayerAnimationStates.Idle.ToString());
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