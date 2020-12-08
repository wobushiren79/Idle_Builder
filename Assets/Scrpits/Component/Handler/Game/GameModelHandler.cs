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
            StartCoroutine(CoroutineForLoadModel(data, userModelData, action));
        };
        GetModelInfoById(userModelData.modelId, callBack);
    }

    /// <summary>
    /// 携程-加载模型
    /// </summary>
    /// <param name="modelInfo"></param>
    /// <param name="userModelData"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public IEnumerator CoroutineForLoadModel(ModelInfoBean modelInfo, UserModelDataBean userModelData, Action action)
    {
        //读取模型
        ResourceRequest resourceRequest = Resources.LoadAsync("Model/" + modelInfo.model_name);
        yield return resourceRequest;
        GameObject objModelTemp = resourceRequest.asset as GameObject;
        //移除场景中的模型
        CptUtil.RemoveChildsByActive(gameObject);
        //创建模型
        GameObject objModel = Instantiate(gameObject, objModelTemp);
        //初始化模型位置
        objModel.transform.position = Vector3.zero;
        //添加模型触摸控制
        GameModelControl gameModelControl = objModel.AddComponent<GameModelControl>();
        action?.Invoke();
        Resources.UnloadUnusedAssets();
    }
}