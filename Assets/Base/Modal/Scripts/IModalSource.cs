namespace AutoShGame.Base.Modal
{
    public interface IModalSource
    {
        public BaseModal GetModalBySource<T>();
    }
}
