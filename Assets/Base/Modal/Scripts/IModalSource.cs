using System;

namespace AutoShGame.Base.Modal
{
    public interface IModalSource
    {
        public BaseModal GetModalBySource(Type type);
    }
}
