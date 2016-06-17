using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.MessagePlugin
{
    public class MessageStatus
    {
        public int FindPassWord
        {
            get;
            set;
        }

        public int OrderCreated
        {
            get;
            set;
        }

        public int OrderPay
        {
            get;
            set;
        }

        public int OrderRefund
        {
            get;
            set;
        }

        public int OrderShipping
        {
            get;
            set;
        }

        public int ShopAudited
        {
            get;
            set;
        }

        public int ShopSuccess
        {
            get;
            set;
        }

        public MessageStatus()
        {
        }
    }
}
