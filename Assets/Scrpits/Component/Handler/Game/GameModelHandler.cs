using System;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameModelHandler : BaseHandler<GameModelManager>
{
    /// <summary>
    /// 通过ID获取游戏模型数据
    /// </summary>
    /// <param name="id"></param>
    /// <param name="action"></param>
    public void GetModelInfoById(long id, Action<ModelInfoBean> action)
    {
        manager.GetModelInfoById(id, action);
    }

    public void GetAllModel(Action<List<ModelInfoBean>> action)
    {
        manager.GetAllModel(action);
    }

    /// <summary>
    /// 加载模型
    /// </summary>
    /// <param name="userModelData"></param>
    public void LoadModel(UserModelDataBean userModelData, Action action)
    {
        Action<ModelInfoBean> callBack = (data) =>
        {
            //加载模型
            manager.StartCoroutine(manager.CoroutineForLoadModel(data, userModelData, action));
        };
        GetModelInfoById(userModelData.modelId, callBack);
    }

    public void SetPartProgress(string partName,float progress)
    {
        GameModelCpt gameModel =  manager.GetCurrentLoadModel();
        gameModel.SetPartProgress(partName, progress);
    }

}