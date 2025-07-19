using _RoyalFarm.Scripts.Crop;

namespace _RoyalFarm.Scripts.Player.States
{
    public abstract class BasePlayerState
    {
        protected PlayerStateMachine _stateMachine;

        public BasePlayerState(PlayerStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        internal virtual void Initialize()
        {
        }
        
        public abstract void Enter();
        public abstract void Exit();

        internal virtual void OnCropFieldEntered(CropField arg0)
        {
        }

        internal virtual void OnCropFieldExited(CropField arg0)
        {
        }

        internal virtual void OnCropFieldStateChanged(CropField cropField, CropFieldStateType cropFieldState)
        {
        }
        
        internal virtual void Dispose()
        {
        }
    }
}