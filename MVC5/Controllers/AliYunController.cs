using Aliyun;
using Blogs.Common;
using Blogs.Helper.LogHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class AliYunController : Controller
    {
        // GET: AliYun
        public void Index()
        {
            try
            {
                CheckWhois();
            }
            catch (Exception ex)
            {

            }
        }
        public void CheckWhois()
        {

            string localIp = ConfigHelper.GetAppSettings("IP");
            string currIp = localIp;//Environment.a Request.ServerVariables["LOCAl_ADDR"];
            //string text = string.Format("time:{0},localHost:{1},currIP:{1}", DateTime.Now, localIp, currIp);
            //LogSave.WarnLogSave(text);

            if (localIp != currIp)
            {
                UpWhois(currIp);
                ConfigHelper.SetAppSetting("IP", currIp);
            }
        }
        public void UpWhois(string ip)
        {
            string DomainName = ConfigHelper.GetAppSettings("Whois");
            string RR = ConfigHelper.GetAppSettings("AName");
            AliyunRequest model = new AliyunRequest();
            model.AccessKeyId = ConfigHelper.GetAppSettings("AL_ID");
            model.Access_Key_Secret = ConfigHelper.GetAppSettings("AL_KEY");
            AliyunUtils.Init(model);

            //获取单前ID值
            var data = new Dictionary<string, string> { };
            data.Add("DomainName", DomainName);
            ResponseDescribeDomainRecords getRes = AliyunUtils.GetResponse(ActionType.DescribeDomainRecords, data) as ResponseDescribeDomainRecords;
            var oldModel = getRes.DomainRecords.Record.Where(x => x.RR == RR).FirstOrDefault();

            //修改单前ID值
            data.Clear();
            data.Add("RecordId", oldModel.RecordId);
            data.Add("RR", RR);
            data.Add("Type", oldModel.Type);
            data.Add("Value", ip);
            data.Add("TTL", oldModel.TTL.ToString());
            data.Add("Line", oldModel.Line);
            var upRes = AliyunUtils.GetResponse(ActionType.UpdateDomainRecord, data);
        }
    }
}