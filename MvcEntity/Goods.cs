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
        /// ����
        /// </summary>
        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// �ۼ�
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// ���ͷ�
        /// </summary>
        public decimal? DistributionFee { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public decimal? profit { get; set; }

        /// <summary>
        /// ʱ��
        /// </summary>
        public DateTime? CreateTime { get; set; }


    }
}
