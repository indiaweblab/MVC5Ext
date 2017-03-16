using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.toobar.Monely
{
    public enum MonelyModel
    {
        利率对比 = 0,
        分期收益 = 1
    }
    public enum RateType
    {
        年 = 0,
        月 = 1,
        日 = 2
    }
    public class RateView : BaseObj
    {
        [Display(Name ="贷款名字")]
        public string LostName { get; set; }
        [Display(Name = "贷款类型")]
        public string LostType { get; set; }
        [Display(Name = "贷款利率")]
        public double LostRate { get; set; }
        [Display(Name = "贷款金额")]
        public double LostQty { get; set; }

        [Display(Name = "贷款名字")]
        public string GetName { get; set; }
        [Display(Name = "贷款类型")]
        public string GetType { get; set; }
        [Display(Name = "贷款利率")]
        public double GetRate { get; set; }
        [Display(Name = "贷款金额")]
        public double GetQty { get; set; }

      
    }
}
