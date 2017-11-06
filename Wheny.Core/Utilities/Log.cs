using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheny.Core
{
    /// <summary>
    /// 日志记录
    ///   对Log4Net的二次分装
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        static Log()
        {
            //第一次调用时从默认配置文件加载配置信息
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// 加载指定的配置文件
        /// </summary>
        /// <param name="file"></param>
        public static void LoadConfig(FileInfo file)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(file);
        }

        /// <summary>
        /// 输出调试信息
        /// </summary>
        /// <param name="message">调试信息</param>
        /// <param name="ex">异常</param>
        public static void Debug(string message, Exception ex = null)
        {
            var frame = GetCurrentStackFrame();
            log4net.ILog log = log4net.LogManager.GetLogger(frame.GetMethod().DeclaringType);
            if (log.IsDebugEnabled)
            {
                var className = frame.GetMethod().DeclaringType.FullName;
                var methodName = frame.GetMethod().Name;
                var parameters = new List<string>();
                foreach (var parameter in frame.GetMethod().GetParameters())
                {
                    parameters.Add(parameter.ToString());
                }
                if (ex == null)
                {
                    log.Debug($"{message}\r\n 在 {className}.{methodName}({string.Join(", ", parameters.ToArray())})");
                }
                else
                {
                    log.Debug($"{message}\r\n 在 {className}.{methodName}({string.Join(", ", parameters.ToArray())})", ex);
                }
            }
        }

        /// <summary>
        /// 输出信息
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="ex">异常</param>
        public static void Info(string message, Exception ex = null)
        {
            var frame = GetCurrentStackFrame();
            log4net.ILog log = log4net.LogManager.GetLogger(frame.GetMethod().DeclaringType);
            if (log.IsInfoEnabled)
            {
                var className = frame.GetMethod().DeclaringType.FullName;
                var methodName = frame.GetMethod().Name;
                var parameters = new List<string>();
                foreach (var parameter in frame.GetMethod().GetParameters())
                {
                    parameters.Add(parameter.ToString());
                }
                if (ex == null)
                {
                    log.Info($"{message} \r\n 在 {className}.{methodName}({string.Join(", ", parameters.ToArray())})");
                }
                else
                {
                    log.Info($"{message} \r\n 在 {className}.{methodName}({string.Join(", ", parameters.ToArray())})", ex);
                }
            }
        }

        /// <summary>
        /// 输出警告信息
        /// </summary>
        /// <param name="message">警告信息</param>
        /// <param name="ex">异常</param>
        public static void Warn(string message, Exception ex = null)
        {
            var frame = GetCurrentStackFrame(true);
            log4net.ILog log = log4net.LogManager.GetLogger(frame.GetMethod().DeclaringType);
            if (log.IsWarnEnabled)
            {
                var className = frame.GetMethod().DeclaringType.FullName;
                var methodName = frame.GetMethod().Name;
                var parameters = new List<string>();
                foreach (var parameter in frame.GetMethod().GetParameters())
                {
                    parameters.Add(parameter.ToString());
                }
                if (ex == null)
                {
                    log.Warn($"{message} \r\n 在 {className}.{methodName}({string.Join(", ", parameters.ToArray())})");
                }
                else
                {
                    log.Warn($"{message} \r\n 在 {className}.{methodName}({string.Join(", ", parameters.ToArray())})", ex);
                }
            }
        }

        /// <summary>
        /// 输出错误信息
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="ex">异常</param>
        public static void Error(string message, Exception ex = null)
        {
            var frame = GetCurrentStackFrame(true);
            log4net.ILog log = log4net.LogManager.GetLogger(frame.GetMethod().DeclaringType);
            if (log.IsErrorEnabled)
            {
                var className = frame.GetMethod().DeclaringType.FullName;
                var methodName = frame.GetMethod().Name;
                var parameters = new List<string>();
                foreach (var parameter in frame.GetMethod().GetParameters())
                {
                    parameters.Add(parameter.ToString());
                }
                if (ex == null)
                {
                    log.Error($"{message} \r\n 在 {className}.{methodName}({string.Join(", ", parameters.ToArray())}) 位置 {frame.GetFileName()}:行号 {frame.GetFileLineNumber()}");
                }
                else
                {
                    log.Error($"{message} \r\n 在 {className}.{methodName}({string.Join(", ", parameters.ToArray())}) 位置 {frame.GetFileName()}:行号 {frame.GetFileLineNumber()}", ex);
                }
            }
        }

        /// <summary>
        /// 输出错误信息
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="ex">异常</param>
        public static void Fatal(string message, Exception ex = null)
        {
            var frame = GetCurrentStackFrame(true);
            log4net.ILog log = log4net.LogManager.GetLogger(frame.GetMethod().DeclaringType);
            if (log.IsFatalEnabled)
            {
                var className = frame.GetMethod().DeclaringType.FullName;
                var methodName = frame.GetMethod().Name;
                var parameters = new List<string>();
                foreach (var parameter in frame.GetMethod().GetParameters())
                {
                    parameters.Add(parameter.ToString());
                }
                if (ex == null)
                {
                    log.Fatal($"{message} \r\n 在 {className}.{methodName}({string.Join(", ", parameters.ToArray())}) 位置 {frame.GetFileName()}:行号 {frame.GetFileLineNumber()}");
                }
                else
                {
                    log.Fatal($"{message} \r\n 在 {className}.{methodName}({string.Join(", ", parameters.ToArray())}) 位置 {frame.GetFileName()}:行号 {frame.GetFileLineNumber()}", ex);
                }
            }
        }

        /// <summary>
        /// 取得当前线程发生错误的函数栈信息，如果找不到则返回调用当前类的函数栈信息
        /// </summary>
        /// <param name="needFileInfo">是否需要捕获发生文件名和行号</param>
        /// <returns></returns>
        private static StackFrame GetCurrentStackFrame(bool needFileInfo = false)
        {
            var stackTrace = new StackTrace(needFileInfo);
            var frames = stackTrace.GetFrames();
            for (var i = 2; i < frames.Length; i++)
            {
                var frame = frames[i];
                if (frame.GetMethod().DeclaringType.IsSubclassOf(typeof(Exception)))
                {
                    return frame;
                }
            }
            return frames[2];
        }
    }
}
