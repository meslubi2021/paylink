using Essensoft.Paylink.WeChatPay.V3.Response;

namespace Essensoft.Paylink.WeChatPay.V3.Request;

/// <summary>
/// 发起商家转账API - 最新更新时间：2024.03.22
/// </summary>
/// <remarks>
/// 发起商家转账接口。商户可以通过该接口同时向多个用户微信零钱进行转账操作。请求消息中应包含商家批次单号、转账名称、appid、转账总金额、转账总笔数、转账openid、收款用户姓名等信息。注意受理成功将返回批次单号，此时并不代表转账成功，请通过查单接口查询单据的付款状态
/// </remarks>
public class WeChatPayTransferBatchesRequest : IWeChatPayPrivacyPostRequest<WeChatPayTransferBatchesResponse>
{
    private WeChatPayObject _bodyModel;

    public string GetRequestUrl()
    {
        return "https://api.mch.weixin.qq.com/v3/transfer/batches";
    }

    public WeChatPayObject GetBodyModel()
    {
        return _bodyModel;
    }

    public void SetBodyModel(WeChatPayObject bodyModel)
    {
        _bodyModel = bodyModel;
    }
}
