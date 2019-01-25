using System;
using Foundation;

using BindingiOSLibrary.TXWeChat;

namespace EnpotXamarin
{
    public class WeChatAPI : BindingiOSLibrary.TXWeChat.WXApiDelegate
    {
        //微信登录
        public bool Log(string appID)
        {
            var result = BindingiOSLibrary.TXWeChat.WXApi.RegisterApp(appID);
            return result;
        }

        //微信链接打开
        public bool Open(NSUrl url)
        {
            var result = BindingiOSLibrary.TXWeChat.WXApi.HandleOpenURL(url, this);
            return result;
        }

        //请求打开微信
        public override void OnReq(BindingiOSLibrary.TXWeChat.BaseReq req)
        {

        }

        //响应微信
        public override void OnResp(BindingiOSLibrary.TXWeChat.BaseResp resp)
        {

        }

        //发送信息到朋友圈
        public bool SendText(string text)
        {
            SendMessageToWXReq req = new BindingiOSLibrary.TXWeChat.SendMessageToWXReq();
            req.Text = text;
            req.BText = true;
            req.Scene = 1;
            BindingiOSLibrary.TXWeChat.WXApi.SendReq(req);

            return true;
        }

    }
}
