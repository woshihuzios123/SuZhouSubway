using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuZhouSubway.Model.Data
{
    public interface IBaseModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        bool Enabled { get; set; }


        /// <summary>
        /// 排序
        /// </summary>
        int Order { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreatedTime { get; set; }
    }
}