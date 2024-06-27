using System.Text.Json.Serialization;

namespace Essensoft.Paylink.WeChatPay.V3.Response;

public class WeChatPayTransferBatchesResponse : WeChatPayResponse
{
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
    /// 批次创建时间
    /// </summary>
    /// <remarks>
    /// 批次受理成功时返回，按照使用rfc3339所定义的格式，格式为YYYY-MM-DDThh:mm:ss+TIMEZONE
    /// </remarks>
    [JsonPropertyName("create_time")]
    public string CreateTime { get; set; }

    /// <summary>
    /// 批次状态
    /// </summary>
    /// <remarks>
    /// ACCEPTED:已受理。批次已受理成功，若发起批量转账的30分钟后，转账批次单仍处于该状态，可能原因是商户账户余额不足等。商户可查询账户资金流水，若该笔转账批次单的扣款已经发生，则表示批次已经进入转账中，请再次查单确认
    /// PROCESSING:转账中。已开始处理批次内的转账明细单
    /// FINISHED:已完成。批次内的所有转账明细单都已处理完成
    /// CLOSED:已关闭。可查询具体的批次关闭原因确认
    /// </remarks>
    [JsonPropertyName("batch_status")]
    public string BatchStatus { get; set; }

}
