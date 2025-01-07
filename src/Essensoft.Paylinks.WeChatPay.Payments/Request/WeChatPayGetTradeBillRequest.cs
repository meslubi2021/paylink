using Essensoft.Paylinks.WeChatPay.Core;
using Essensoft.Paylinks.WeChatPay.Payments.Response;

namespace Essensoft.Paylinks.WeChatPay.Payments.Request;

/// <summary>
/// 申请交易账单
/// </summary>
/// <para>
/// https://pay.weixin.qq.com/docs/merchant/apis/jsapi-payment/get-trade-bill.html
/// 申请交易账单
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/in-app-payment/get-trade-bill.html
/// 申请交易账单
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/h5-payment/get-trade-bill.html
/// 申请交易账单
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/native-payment/get-trade-bill.html
/// 申请交易账单
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/mini-program-payment/get-trade-bill.html
/// 申请交易账单
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/combine-payment/bill-download/get-trade-bill.html
/// 申请交易账单
/// 更新时间：2023.08.23
/// <br/>
/// <a href="https://pay.weixin.qq.com/docs/merchant/apis/bill-download/trade-bill/get-trade-bill.html
/// 申请交易账单
/// 更新时间：2023.08.16
/// </para>
public class WeChatPayGetTradeBillRequest : IWeChatPayRequest<WeChatPayGetTradeBillResponse>
{
    #region IWeChatPayRequest Members

    public WeChatPayRequestMethod GetRequestMethod() => WeChatPayRequestMethod.Get;

    public string GetRequestUrl() => "/v3/bill/tradebill";

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
}