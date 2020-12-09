using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameModelManager : BaseManager, IModelInfoView
{
    public ModelInfoController modelInfoController;

    //当前加载的模型
    public GameModelCpt currentLoadModel;

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

    public void GetAllModel(Action<List<ModelInfoBean>> action)
    {
        modelInfoController.GetAllModel(action);
    }

    public GameModelCpt GetCurrentLoadModel()
    {
        return currentLoadModel;
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
        //添加模型控件
        GameModelCpt gameModel = CptUtil.AddCpt<GameModelCpt>(objModel);
        gameModel.SetData(userModelData, modelInfo);
        //设置加载的模型
        currentLoadModel = gameModel;
        action?.Invoke();
        Resources.UnloadUnusedAssets();
    }

    #region 数据回掉
    public void GetModelInfoFail(string failMsg)
    {

    }

    public void GetModelInfoSuccess(ModelInfoBean modelInfo, Action<ModelInfoBean> action)
    {
        action?.Invoke(modelInfo);
    }

    public void GetAllModelInfoSuccess(List<ModelInfoBean> listModelInfo, Action<List<ModelInfoBean>> action)
    {
        action?.Invoke(listModelInfo);
    }

    public void GetAllModelInfoFail(string failMsg)
    {
    }
    #endregion
}