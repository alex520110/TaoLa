using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TaoLa.Web.Framework
{
    public abstract class BaseAreaRegistration : AreaRegistration
    {
        protected static List<AreaRegistrationContext> areaContent = new List<AreaRegistrationContext>();

        protected static List<BaseAreaRegistration> areaRegistration = new List<BaseAreaRegistration>();

        public abstract int Order
        {
            get;
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            BaseAreaRegistration.areaContent.Add(context);
            BaseAreaRegistration.areaRegistration.Add(this);
        }

        public abstract void RegisterAreaOrder(AreaRegistrationContext context);

        public static void RegisterAllAreasOrder()
        {
            AreaRegistration.RegisterAllAreas();
            BaseAreaRegistration.Register();
        }

        private static void Register()
        {
            List<int[]> list = new List<int[]>();
            for (int i = 0; i < BaseAreaRegistration.areaRegistration.Count; i++)
            {
                list.Add(new int[]
                {
                    BaseAreaRegistration.areaRegistration[i].Order,
                    i
                });
            }
            list = (from o in list
                    orderby o[0]
                    select o).ToList<int[]>();
            foreach (int[] current in list)
            {
                BaseAreaRegistration.areaRegistration[current[1]].RegisterAreaOrder(BaseAreaRegistration.areaContent[current[1]]);
            }
        }
    }
}
