using SuZhouSubway.Model.Data;
using System.Collections.Generic;

namespace SuZhouSubway.Model
{
    /// <summary>
    /// 栏目
    /// </summary>
    public class Category : BaseModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 详情
        /// 导航属性
        /// </summary>
        public ICollection<Detail> Details { get; set; }

        /*/// <summary>
        /// 如果存在，则为子导航
        /// </summary>
        public ICollection<Category> Categories { get; set; }*/
    }
}