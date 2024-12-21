﻿using System.Text.Json;
using System.Threading.Tasks;
using Essensoft.Paylink.WeChatPay;
using Essensoft.Paylink.WeChatPay.V3;
using Essensoft.Paylink.WeChatPay.V3.Notify;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebApplicationSample.Controllers
{
    [Route("wechatpay/v3/notify")]
    public class WeChatPayV3NotifyController : Controller
    {
        private readonly ILogger<WeChatPayV3NotifyController> _logger;
        private readonly IWeChatPayNotifyClient _client;
        private readonly IOptions<PaylinkOptions> _optionsAccessor;

        public WeChatPayV3NotifyController(ILogger<WeChatPayV3NotifyController> logger, IWeChatPayNotifyClient client, IOptions<PaylinkOptions> optionsAccessor)
        {
            _logger = logger;
            _client = client;
            _optionsAccessor = optionsAccessor;
        }

        /// <summary>
        /// 支付结果通知
        /// </summary>
        [Route("transactions")]
        [HttpPost]
        public async Task<IActionResult> Transactions()
        {
            try
            {
                var notify = await _client.ExecuteAsync<WeChatPayTransactionsNotify>(Request, _optionsAccessor.Value.WeChatPay);
                if (notify.TradeState == WeChatPayTradeState.Success)
                {
                    _logger.LogInformation("支付结果通知 => OutTradeNo: " + notify.OutTradeNo);
                    return WeChatPayNotifyResult.Success;
                }

                return WeChatPayNotifyResult.Failure;
            }
            catch (WeChatPayException ex)
            {
                _logger.LogWarning("出现异常: " + ex.Message);
                return WeChatPayNotifyResult.Failure;
            }
        }

        /// <summary>
        /// 退款结果通知
        /// </summary>
        [Route("refund")]
        [HttpPost]
        public async Task<IActionResult> Refund()
        {
            try
            {
                var notify = await _client.ExecuteAsync<WeChatPayRefundDomesticRefundsNotify>(Request, _optionsAccessor.Value.WeChatPay);
                if (notify.RefundStatus == WeChatPayRefundStatus.Success)
                {
                    _logger.LogInformation("退款结果通知 => OutTradeNo: " + notify.OutTradeNo);
                    return WeChatPayNotifyResult.Success;
                }

                return WeChatPayNotifyResult.Failure;
            }
            catch (WeChatPayException ex)
            {
                _logger.LogWarning("出现异常: " + ex.Message);
                return WeChatPayNotifyResult.Failure;
            }
        }

        #region 微信支付分

        /// <summary>
        /// 开启/解除授权服务回调通知
        /// </summary>
        [Route("score/permissions")]
        [HttpPost]
        public async Task<IActionResult> Permissions()
        {
            try
            {
                var notify = await _client.ExecuteAsync<WeChatPayScoreUserOpenOrCloseNotify>(Request, _optionsAccessor.Value.WeChatPay);
                if (notify.UserServiceStatus == WeChatPayScoreUserServiceStatus.Opened ||
                    notify.UserServiceStatus == WeChatPayScoreUserServiceStatus.Closed)
                {
                    _logger.LogInformation("开启/解除授权服务回调通知 => " + notify.Body);
                    return WeChatPayNotifyResult.Success;
                }

                return WeChatPayNotifyResult.Failure;
            }
            catch (WeChatPayException ex)
            {
                _logger.LogWarning("出现异常: " + ex.Message);
                return WeChatPayNotifyResult.Failure;
            }
        }

        /// <summary>
        /// 确认订单回调通知
        /// </summary>
        [Route("score/orderconfirm")]
        [HttpPost]
        public async Task<IActionResult> OrderConfirm()
        {
            try
            {
                var notify = await _client.ExecuteAsync<WeChatPayScoreUserConfirmNotify>(Request, _optionsAccessor.Value.WeChatPay);
                if (notify.State == WeChatPayServiceOrderState.Doing)
                {
                    _logger.LogInformation("确认订单回调通知 => " + notify.Body);
                    return WeChatPayNotifyResult.Success;
                }

                return WeChatPayNotifyResult.Failure;
            }
            catch (WeChatPayException ex)
            {
                _logger.LogWarning("出现异常: " + ex.Message);
                return WeChatPayNotifyResult.Failure;
            }
        }

        /// <summary>
        /// 订单支付成功回调通知
        /// </summary>
        [Route("score/orderpaid")]
        [HttpPost]
        public async Task<IActionResult> OrderPaid()
        {
            try
            {
                var notify = await _client.ExecuteAsync<WeChatPayScoreUserPaidNotify>(Request, _optionsAccessor.Value.WeChatPay);
                if (notify.State == WeChatPayServiceOrderState.Done)
                {
                    _logger.LogInformation("订单支付成功回调通知 => " + notify.Body);
                    return WeChatPayNotifyResult.Success;
                }

                return WeChatPayNotifyResult.Failure;
            }
            catch (WeChatPayException ex)
            {
                _logger.LogWarning("出现异常: " + ex.Message);
                return WeChatPayNotifyResult.Failure;
            }
        }

        /// <summary>
        /// 订单确认 或 支付成功 回调通知
        /// </summary>
        [Route("score/confirmorpaid")]
        [HttpPost]
        public async Task<IActionResult> OrderConfirmOrPaid()
        {
            try
            {
                var notify = await _client.ExecuteAsync<WeChatPayScoreUserPaidNotify>(Request, _optionsAccessor.Value.WeChatPay);
                if (notify.State == WeChatPayServiceOrderState.Doing || notify.State == WeChatPayServiceOrderState.Done)
                {
                    _logger.LogInformation("订单确认或支付成功回调通知: " + notify.Body);
                    return WeChatPayNotifyResult.Success;
                }

                return WeChatPayNotifyResult.Failure;
            }
            catch (WeChatPayException ex)
            {
                _logger.LogWarning("出现异常: " + ex.Message);
                return WeChatPayNotifyResult.Failure;
            }
        }

        #endregion

        /// <summary>
        /// 商家转账到零钱
        /// </summary>
        [Route("transfer")]
        [HttpPost]
        public async Task<IActionResult> Transfer()
        {
            try
            {
                var notify = await _client.ExecuteAsync<WeChatPayTransferBatchesFinishedNotify>(Request, _optionsAccessor.Value.WeChatPay);
                switch (notify.NotifyCiphertext.EventType)
                {
                    case "MCHTRANSFER.BATCH.FINISHED":
                        {
                            return WeChatPayNotifyResult.Success;
                        }
                    case "MCHTRANSFER.BATCH.CLOSED":
                        {
                            var closedNotify = JsonSerializer.Deserialize<WeChatPayTransferBatchesClosedNotify>(notify.ResourcePlaintext);
                            return WeChatPayNotifyResult.Success;
                        }
                }

                return WeChatPayNotifyResult.Failure;
            }
            catch (WeChatPayException ex)
            {
                _logger.LogWarning("出现异常: " + ex.Message);
                return WeChatPayNotifyResult.Failure;
            }
        }
    }
}
