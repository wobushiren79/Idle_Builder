using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ModelInfoController : BaseMVCController<ModelInfoModel, IModelInfoView>
{
    public ModelInfoController(BaseMonoBehaviour content, IModelInfoView view) : base(content, view)
    {

    }

    public override void InitData()
    {

    }

    /// <summary>
    /// 获取ID获取模型数据
    /// </summary>
    /// <param name="id"></param>
    /// <param name="action"></param>
    public void GetModelInfoById(long id, Action<ModelInfoBean> action)
    {
        ModelInfoBean modelInfo = GetModel().GetModelInfoById(id);
        if (modelInfo != null)
        {
            List<ModelPartInfoBean> listData = GetModel().GetModelPartInfoByModelId(modelInfo.id);
            modelInfo.listPartData = listData;
        }
        GetView().GetModelInfoSuccess(modelInfo, action);
    }

}
