using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: XmlConfigurator(ConfigFile = "Config/Log4Net.config", Watch = true)]
namespace JWT.Common
{
    public class Log4Help
    {
        private static readonly ILog loginfo = LogManager.GetLogger("loginfo");

        private static readonly ILog logerror = LogManager.GetLogger("logerror");

        /// <summary>
        /// 打印日志信息
        /// </summary>
        /// <param name="info"></param>
        public static void Info(string info)
        {
            loginfo.Info(info);
        }

        /// <summary>
        /// 错误日志信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ex"></param>
        public static void Error(string info, Exception ex)
        {
            logerror.Error(info, ex);
        }
    }
}
