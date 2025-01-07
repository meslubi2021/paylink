using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// 发起异常退款
/// </summary>
/// <para>
/// https://pay.weixin.qq.com/docs/merchant/apis/refund/refunds/create-abnormal-refund.html
/// 发起异常退款
/// 更新时间：2023.08.16
/// </para>
public class WeChatPayApplyAbnormalRefundByRefundIdRequest : IWeChatPayRequest<WeChatPayApplyAbnormalRefundByRefundIdResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Post;

    public string GetRequestUrl() => $"/v3/refund/domestic/refunds/{RefundId}/apply-abnormal-refund";

    private bool _needVerify = true;

    public bool GetNeedVerify() => _needVerify;

    public void SetNeedVerify(bool value) => _needVerify = value;

    private object? _queryModel;

    public void SetQueryModel(object queryModel) => _queryModel = queryModel;

    public object? GetQueryModel() => _queryModel;

    private object? _bodyModel;

    public void SetBodyModel(object bodyModel) => _bodyModel = bodyModel;

    public object? GetBodyModel() => _bodyModel;

    #endregion

    /// <summary>
    /// 微信退款单号
    /// </summary>
    public string RefundId { get; set; }
}
