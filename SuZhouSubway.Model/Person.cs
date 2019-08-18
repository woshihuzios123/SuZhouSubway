using SuZhouSubway.Model.Data;

namespace SuZhouSubway.Model
{
    public class Person : BaseModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 职责
        /// </summary>
        public string Duties { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string JobNumber { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 头像照片
        /// </summary>
        public string HeadPhoto { get; set; }
    }
}