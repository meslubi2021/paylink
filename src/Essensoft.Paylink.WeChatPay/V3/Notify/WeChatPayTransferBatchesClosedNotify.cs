using System.Text.Json.Serialization;

namespace Essensoft.Paylink.WeChatPay.V3.Notify
{
    /// <summary>
    /// 商家转账到零钱 - 商家转账批次关闭回调通知
    /// </summary>
    /// <remarks>
    /// <para><a href="https://pay.weixin.qq.com/docs/merchant/apis/batch-transfer-to-balance/transfer-batch-callback-notice.html">商家转账到零钱 - 商家转账批次回调通知API</a> - 最新更新时间：2024.03.25</para>
    /// </remarks>
    public class WeChatPayTransferBatchesClosedNotify : WeChatPayNotify
    {
        /// <summary>
        /// 商户号
        /// </summary>
        /// <remarks>
        /// 微信支付分配的商户号
        /// </remarks>
        [JsonPropertyName("mchid")]
        public string MchId { get; set; }

        /// <summary>
        /// 商家批次单号
        /// </summary>
        /// <remarks>
        /// 商户系统内部的商家批次单号，在商户系统内部唯一
        /// </remarks>
        [JsonPropertyName("out_batch_no")]
        public string OutBatchNo { get; set; }

        /// <summary>
        /// 微信批次单号
        /// </summary>
        /// <remarks>
        /// 微信批次单号，微信商家转账系统返回的唯一标识
        /// </remarks>
        [JsonPropertyName("batch_id")]
        public string BatchId { get; set; }

        /// <summary>
        /// 批次状态
        /// </summary>
        /// <remarks>
        /// WAIT_PAY: 待付款确认。需要付款出资商户在商家助手小程序或服务商助手小程序进行付款确认
        /// ACCEPTED:已受理。批次已受理成功，若发起批量转账的30分钟后，转账批次单仍处于该状态，可能原因是商户账户余额不足等。商户可查询账户资金流水，若该笔转账批次单的扣款已经发生，则表示批次已经进入转账中，请再次查单确认
        /// PROCESSING:转账中。已开始处理批次内的转账明细单
        /// FINISHED:已完成。批次内的所有转账明细单都已处理完成
        /// CLOSED:已关闭。可查询具体的批次关闭原因确认
        /// </remarks>
        [JsonPropertyName("batch_status")]
        public string BatchStatus { get; set; }

        /// <summary>
        /// 批次总笔数
        /// </summary>
        /// <remarks>
        /// 转账总笔数。
        /// </remarks>
        [JsonPropertyName("total_num")]
        public int TotalNum { get; set; }

        /// <summary>
        /// 批次总金额
        /// </summary>
        /// <remarks>
        /// 转账总金额，单位为“分”。
        /// </remarks>
        [JsonPropertyName("total_amount")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// 批次关闭原因
        /// </summary>
        /// <remarks>
        /// 如果批次单状态为“CLOSED”（已关闭），则有关闭原因
        /// 可选取值：
        /// OVERDUE_CLOSE：系统超时关闭，可能原因账户余额不足或其他错误
        /// TRANSFER_SCENE_INVALID：付款确认时，转账场景已不可用，系统做关单处理
        /// </remarks>
        [JsonPropertyName("close_reason")]
        public string CloseReason { get; set; }

        /// <summary>
        /// 批次更新时间
        /// </summary>
        /// <remarks>
        /// 遵循rfc3339标准格式，格式为yyyy-MM-DDTHH:mm:ss+TIMEZONE，yyyy-MM-DD表示年月日，T出现在字符串中，表示time元素的开头，HH:mm:ss.表示时分秒，TIMEZONE表示时区（+08:00表示东八区时间，领先UTC 8小时，即北京时间）。例如：2015-05-20T13:29:35+08:00表示北京时间2015年05月20日13点29分35秒。
        /// </remarks>
        [JsonPropertyName("update_time")]
        public string UpdateTime { get; set; }
    }
}
