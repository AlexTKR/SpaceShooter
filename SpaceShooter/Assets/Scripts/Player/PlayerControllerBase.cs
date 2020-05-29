namespace Scripts.Player
{
    public abstract class PlayerControllerBase 
    {
        public abstract void Init();
        public abstract void Tick();
        public abstract void Enable();
        public abstract void Disable();
    }
}