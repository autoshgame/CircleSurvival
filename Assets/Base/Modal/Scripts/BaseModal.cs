using UnityEngine;

namespace AutoShGame.Base.Modal 
{
    public class BaseModal : MonoBehaviour
    {        

        public virtual BaseModal InitData<T>(T args) 
        {
            return this;
        }

        public virtual void Show() 
        { 
            
        }

        public virtual void Close()
        {

        }
    }
}
