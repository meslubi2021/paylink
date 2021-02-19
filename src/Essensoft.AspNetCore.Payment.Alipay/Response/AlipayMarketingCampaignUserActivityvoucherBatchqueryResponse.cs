using System.Text.Json.Serialization;
using System.Collections.Generic;
using Essensoft.AspNetCore.Payment.Alipay.Domain;

namespace Essensoft.AspNetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingCampaignUserActivityvoucherBatchqueryResponse.
    /// </summary>
    public class AlipayMarketingCampaignUserActivityvoucherBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 活动券列表
        /// </summary>
        [JsonPropertyName("activity_voucher_list")]
        public List<ActivityVoucherInfo> ActivityVoucherList { get; set; }
    }
}