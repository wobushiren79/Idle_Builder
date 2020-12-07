using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ModelPartInfoService : BaseMVCService
{
    public ModelPartInfoService() : base("model_part_info", "model_part_info_details_" + GameCommonInfo.GameConfig.language)
    {

    }

    /// <summary>
    /// 查询所有数据
    /// </summary>
    /// <returns></returns>
    public List<ModelPartInfoBean> QueryAllData()
    {
        return BaseQueryAllData<ModelPartInfoBean>("model_part_id");
    }

    /// <summary>
    /// 通过ID查询数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<ModelPartInfoBean> QueryDataById(long id)
    {
        return BaseQueryData<ModelPartInfoBean>("model_part_id", "id", id + "");
    }

    /// <summary>
    /// 通过ID查询数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<ModelPartInfoBean> QueryDataByModelId(long modelId)
    {
        return BaseQueryData<ModelPartInfoBean>("model_part_id", "model_id", modelId + "");
    }

}