using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIController
{
    private UIView uiView;

    public UIController(UIView uiView)
    {
        this.uiView = uiView;

        uiView.SetUIController(this);
    }

    public void OnShopToggleChanged(bool isOn)
    {
        if (isOn == false)
        {
            EventService.Instance.OnShopToggledOnEvent.InvokeEvent();
        }
        else
        { 
            EventService.Instance.OnInventoryToggledOnEvent.InvokeEvent();
        }
        uiView.UpdateShopORInventoryText(!isOn);
    }
}
