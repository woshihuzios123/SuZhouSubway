using SuZhouSubway.Model;
using System.Collections.Generic;

namespace SuZhouSubway.Web.Models.ViewModels
{
    public class DetailListDto
    {
        /// <summary>
        /// 栏目名称和简介
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// 栏目详情
        /// </summary>
        public List<Detail> Details { get; set; }
    }
}