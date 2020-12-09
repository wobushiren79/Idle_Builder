using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameModelProgress : BaseMonoBehaviour
{
    public Dictionary<string, Material> mapMaterialForModel = new Dictionary<string, Material>();
    public int dissolveAmountId;

    public void SetData(UserModelDataBean userModelData, ModelInfoBean modelInfo)
    {
        if (modelInfo == null)
            return;
        if (userModelData == null)
            return;
        mapMaterialForModel.Clear();
        if (!CheckUtil.ListIsNull(modelInfo.listPartData))
        {
            for (int i = 0; i < modelInfo.listPartData.Count; i++)
            {
                ModelPartInfoBean partInfo = modelInfo.listPartData[i];
                MeshRenderer itemRenderer = CptUtil.GetCptInChildrenByName<MeshRenderer>(gameObject, partInfo.part_name);
                if (!mapMaterialForModel.ContainsKey(partInfo.part_name))
                {
                    mapMaterialForModel.Add(partInfo.part_name, itemRenderer.material);
                }     
            }
        }
        dissolveAmountId = Shader.PropertyToID("_DissolveAmount");
    }

    /// <summary>
    /// 设置对应部位进度
    /// </summary>
    /// <param name="partName"></param>
    /// <param name="pro"></param>
    public void SetProgress(string partName, float pro)
    {
        if (mapMaterialForModel.TryGetValue(partName, out Material material))
        {
            material.SetFloat(dissolveAmountId, pro);
        }
    }

}