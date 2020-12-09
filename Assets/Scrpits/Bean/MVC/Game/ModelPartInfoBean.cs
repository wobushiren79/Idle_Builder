using System.Collections;
using UnityEngine;

public class ModelPartInfoBean : BaseBean
{
    public long model_id;
    public long model_part_id;
    public string part_name;
    //每级收益
    public string add_price;
    //解锁金钱
    public long unlock_money;
    //最高等级
    public int max_level;
    //升级金钱
    public string level_money;

    public string name;
    public string content;

    public long GetLevelUpMoney(int level)
    {
        long[] levelMoney = StringUtil.SplitBySubstringForArrayLong(level_money, ',');
        if (level >= levelMoney.Length)
        {
            //如果等级大于长度则获取最后一位
            return levelMoney[levelMoney.Length - 1];
        }
        else
        {
            return levelMoney[level];
        }
    }

    public long GetAddPrice(int level)
    {
        long[] addPrice = StringUtil.SplitBySubstringForArrayLong(add_price, ',');
        if (level >= addPrice.Length)
        {
            //如果等级大于长度则获取最后一位
            return addPrice[addPrice.Length - 1];
        }
        else
        {
            return addPrice[level];
        }
    }
}