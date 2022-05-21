namespace MvcEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Goods
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string GoodName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// 售价
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// 配送费
        /// </summary>
        public decimal? DistributionFee { get; set; }
        /// <summary>
        /// 利润
        /// </summary>
        public decimal? profit { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? CreateTime { get; set; }


    }
}
