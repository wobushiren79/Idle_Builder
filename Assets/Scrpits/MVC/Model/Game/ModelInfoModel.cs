using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ModelInfoModel : BaseMVCModel
{

    protected ModelInfoService modelInfoService;
    protected ModelPartInfoService modelPartInfoService;

    public override void InitData()
    {
        modelInfoService = new ModelInfoService();
        modelPartInfoService = new ModelPartInfoService();
    }

    /// <summary>
    /// 通过ID获取模型数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ModelInfoBean GetModelInfoById(long id)
    {
        List<ModelInfoBean> listData=  modelInfoService.QueryDataById(id);
        if (!CheckUtil.ListIsNull(listData)&& listData.Count>0)
        {
            return listData[0];
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 通过模型ID获取模型部分数据
    /// </summary>
    /// <param name="modelId"></param>
    /// <returns></returns>
    public List<ModelPartInfoBean> GetModelPartInfoByModelId(long modelId)
    {
        return modelPartInfoService.QueryDataByModelId(modelId);
    }

}