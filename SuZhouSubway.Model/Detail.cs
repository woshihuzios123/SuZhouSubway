using SuZhouSubway.Model.Data;

namespace SuZhouSubway.Model
{
    public class Detail : BaseModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }


        /*/// <summary>
        /// 封面图片
        /// </summary>
        public string CoverImage { get; set; }*/


        /// <summary>
        /// 正文
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 外键
        /// </summary>

        public int? CategoryId { get; set; }

        /// <summary>
        /// 类型
        /// 导航属性
        /// </summary>
        public Category Category { get; set; }
    }
}