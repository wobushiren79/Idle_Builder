using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ModelInfoService : BaseMVCService
{
    public ModelInfoService() : base("model_info", "model_info_details_" + GameCommonInfo.GameConfig.language)
    {

    }

    /// <summary>
    /// 查询所有数据
    /// </summary>
    /// <returns></returns>
    public List<ModelInfoBean> QueryAllData()
    {
        return BaseQueryAllData<ModelInfoBean>("model_id");
    }

    /// <summary>
    /// 通过ID查询数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<ModelInfoBean> QueryDataById(long id)
    {
        return BaseQueryData<ModelInfoBean>("model_id", "id", id + "");
    }

}