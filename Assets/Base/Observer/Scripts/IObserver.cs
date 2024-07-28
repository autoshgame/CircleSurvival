namespace AutoShGame.Base.Observer
{
    public interface IObserver<T>
    {
        void OnObserverNotify(T data);
    }
}
