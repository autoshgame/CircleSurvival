namespace AutoShGame.Base.OneThousandUpdate
{
    public interface IUpdateable
    {
        void OnUpdate();
        void OnFixedUpdate();
        void OnLateUpdate();
    }
}
