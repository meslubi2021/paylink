using Essensoft.Paylink.Alipay;
using Essensoft.Paylink.WeChatPay;

namespace WebApplicationSample
{
    public class PaylinkOptions
    {
        public AlipayOptions Alipay { get; set; }

        public WeChatPayOptions WeChatPay { get; set; }
    }
}
