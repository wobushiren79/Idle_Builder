using System;
using UnityEditor;
using UnityEngine;

public class GameModelManager : BaseManager, IModelInfoView
{
    public ModelInfoController modelInfoController;

    protected void Awake()
    {
        modelInfoController = new ModelInfoController(this, this);
    }

    /// <summary>
    /// 通过ID获取模型数据
    /// </summary>
    /// <param name="id"></param>
    /// <param name="action"></param>
    public void GetModelInfoById(long id, Action<ModelInfoBean> action)
    {
        modelInfoController.GetModelInfoById(id, action);
    }

    #region 数据回掉
    public void GetModelInfoFail(string failMsg)
    {

    }

    public void GetModelInfoSuccess(ModelInfoBean modelInfo, Action<ModelInfoBean> action)
    {
        action?.Invoke(modelInfo);
    }
    #endregion
}