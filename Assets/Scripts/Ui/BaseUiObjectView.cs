using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUiObjectView : MonoBehaviour
{
    public void Init()
    {
        InitInternal();
    }

    public void Show()
    {

    }

    public void Hide()
    {

    }

    public void UpdateData(object[] data)
    {
        UpdateDataInternal(data);
    }

    #region protected

    protected virtual void InitInternal()
    {

    }

    protected virtual void UpdateDataInternal(object[] data)
    {

    }

    #endregion
}
