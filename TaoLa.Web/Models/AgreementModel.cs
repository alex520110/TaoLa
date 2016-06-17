using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaoLa.Web.Models
{
    public class AgreementModel
    {
        public string AgreementContent
        {
            get;
            set;
        }

        public int AgreementType
        {
            get;
            set;
        }

        public AgreementModel()
        {
        }
    }
}