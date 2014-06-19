using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiveMeCounts.Services;
using GiveMeCounts.Services.Google;
using GiveMeCounts.Services.Mock;
using Ninject;

namespace GiveMeCounts.App_Start
{
    public class NinjectKernelConfig
    {
        public static void SetupForLiveService(IKernel kernel)
        {
            kernel.Bind<ICounterService>().To<GoogleCounterService>();
        }

        public static void SetupForMock(IKernel kernel)
        {
            kernel.Bind<ICounterService>().To<MockCounterService>();
        }
    }
}