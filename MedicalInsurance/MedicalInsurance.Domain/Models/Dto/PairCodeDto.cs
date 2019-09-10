using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Dto
{
   public class PairCodeDto
    {
        /// <summary>
        /// 收费项目编码
        /// </summary>
        public string AKE001 { get; set; }
        /// <summary>
        /// 收费项目名称
        /// </summary>
        public string AKE002 { get; set; }
        /// <summary>
        /// 分类代码
        /// </summary>
        public string AKA063 { get; set; }
        /// <summary>
        /// 收费项目等级
        /// </summary>
        public string AKA065 { get; set; }
        /// <summary>
        /// 职工医保自付比例
        /// </summary>
        public string AKA069 { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string AKA067 { get; set; }
        /// <summary>
        /// 拼音助记码
        /// </summary>
        public string AKA020 { get; set; }
        /// <summary>
        /// 剂型
        /// </summary>
        public string AKA070 { get; set; }
        /// <summary>
        /// 居民医保自付比例
        /// </summary>
        public string CKE899 { get; set; }
        /// <summary>
        /// 限制用药标志
        /// </summary>
        public string AKA036 { get; set; }
        /// <summary>
        /// 零档限价（二级乙等以下）
        /// </summary>
        public string CKA599 { get; set; }
        /// <summary>
        /// 一档限价（二级乙等）
        /// </summary>
        public string CKA578 { get; set; }
        /// <summary>
        /// 二档限价（二级甲等）
        /// </summary>
        public string CKA579 { get; set; }
        /// <summary>
        /// 三档限价（三级乙等）
        /// </summary>
        public string CKA580 { get; set; }
        /// <summary>
        /// 四档限价（三级甲等）
        /// </summary>
        public string CKA560 { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>
        public string AAE100 { get; set; }
        /// <summary>
        /// 居民普通门诊报销标志
        /// </summary>
        public string CKE889 { get; set; }
        /// <summary>
        /// 居民普通门诊报销限价
        /// </summary>
        public string CKA601 { get; set; }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string AKA098 { get; set; }
        /// <summary>
        /// 药品准字号
        /// </summary>
        public string CKA603 { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string AKA074 { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string AAE013 { get; set; }
        /// <summary>
        /// 新码标志
        /// </summary>
        public string CKE897 { get; set; }
        /// <summary>
        /// 最近一次变更日期
        /// </summary>
        public string AAE036 { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string AAE030 { get; set; }
        /// <summary>
        /// 终止时间
        /// </summary>
        public string AAE031 { get; set; }

        /// <summary>
        /// 限制支付范围
        /// </summary>
        public string CKE599 { get; set; }
    }
}
