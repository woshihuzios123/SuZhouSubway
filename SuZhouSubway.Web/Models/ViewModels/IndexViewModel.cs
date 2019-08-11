using System.Collections.Generic;
using SuZhouSubway.Model;

namespace SuZhouSubway.Web.Models.ViewModels
{
    public class IndexViewModel
    {
        /// <summary>
        /// 顶部左右切换导航
        /// </summary>
        public IEnumerable<Category> NavigationCategories { get; set; }


        /// <summary>
        /// 当前栏目
        /// 可以使用导航属性
        /// </summary>
        public Category CurrentCategory { get; set; }

        /*/// <summary>
        /// 下方栏目列表
        /// </summary>
        public IEnumerable<Detail> Details { get; set; }*/


    }
}