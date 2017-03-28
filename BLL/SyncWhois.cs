using Aliyun;
using LeaRun.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace BLL
{
    public   class SyncWhois
    {
        private  static SyncWhois entity;
        private  static object obj = new object();
        private static LeaRun.Utilities.LogHelper log = LeaRun.Utilities.LogFactory.GetLogger("SyncWhois");

        public static SyncWhois GetHandler()
        {
            if (entity == null)
            {
                lock (obj) entity = new SyncWhois();
            }
            return entity;
        }

        public  void CheckWhois()
        {
            try
            {
                IPScanerHelper ipModel = new IPScanerHelper();
                string localIp = ConfigHelper.AppSettings("IP");
                string currIp = ipModel.IPLocation(); //System.Web.HttpContext.Current.Request.UserHostAddress;// Request.ServerVariables["LOCAl_ADDR"];
                string text = string.Format("time:{0},localHost:{1},currIP:{1}", DateTime.Now, localIp, currIp);

                if (localIp != currIp)
                {
                    UpWhois(currIp);
                    ConfigHelper.SetValue("IP", currIp);
                }
            }
            catch (Exception ex)
            {
                log.Debug("this is not !", ex);
            }
        }
        public  void UpWhois(string ip)
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
