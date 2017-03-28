using Aliyun;
using LeaRun.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Areas.APIExten.Controllers
{
    public class AliYunController : Controller
    {
        public static LeaRun.Utilities.LogHelper log = LeaRun.Utilities.LogFactory.GetLogger("AliYunController");
        // GET: AliYun
        public void Index()
        {
            try
            {
                CheckWhois();
                log.Debug("this is ok "+ DateTime.Now);
            }
            catch (Exception ex)
            {
                log.Debug("this is GG " + DateTime.Now);
            }
        }
        public void CheckWhois()
        {

            string localIp = ConfigHelper.AppSettings("IP");
            string currIp = localIp;

            if (localIp != currIp)
            {
                UpWhois(currIp);
                ConfigHelper.SetValue("IP", currIp);
            }
        }
        public void UpWhois(string ip)
        {
            string DomainName = ConfigHelper.AppSettings("Whois");
            string RR = ConfigHelper.AppSettings("AName");
            AliyunRequest model = new AliyunRequest();
            model.AccessKeyId = ConfigHelper.AppSettings("AL_ID");
            model.Access_Key_Secret = ConfigHelper.AppSettings("AL_KEY");
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