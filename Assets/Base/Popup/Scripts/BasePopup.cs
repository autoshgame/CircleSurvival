using UnityEngine;

namespace AutoShGame.Base.Popup 
{
    public class BasePopup : MonoBehaviour
    {        
        public virtual BasePopup InitData<T>(T args) 
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
