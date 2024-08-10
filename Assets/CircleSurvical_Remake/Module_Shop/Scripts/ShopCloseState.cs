using AutoShGame.Base.FSMState;
using DG.Tweening;
using UnityEngine;
using System.Collections;

public class ShopCloseState : FSMState
{
    private ShopFSMDependency dependency;

    public override string GetState()
    {
        return ShopEvent.CLOSE;
    }

    public override void OnSetupDependency<T>(T args)
    {
        dependency = args as ShopFSMDependency;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        StartCoroutine(CloseShop());
    }

    IEnumerator CloseShop()
    {
        dependency.component.contentShop.DOScale(Vector3.zero, 0.3f).SetEase(Ease.Flash);
        yield return new WaitForSeconds(0.3f);

        dependency.component.shopItemList.ShopItems.Clear();

        for (int i = dependency.component.shopItemList.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(dependency.component.shopItemList.transform.GetChild(i).gameObject);
        }

        yield return new WaitForEndOfFrame();
            
        dependency.component.manager.gameObject.SetActive(false);
    }
}
