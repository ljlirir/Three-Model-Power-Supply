using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTommensDC
{
    internal class WriteWsLog
    {
        private static object lockWriteComlog = new object();
        private static string logpath;
        public static string LogPath
        {
            get { return logpath; }
            set { logpath = value; }
        }
        /// <summary>
        /// 写日志文，写之前先设logpath;
        /// </summary>
        /// <param name="logtxt"></param>
        public static void WriteWslogs(String logtxt)
        {
#if DEBUG
            try
            {
                lock (lockWriteComlog)
                {
                    System.IO.StreamWriter swlog = new System.IO.StreamWriter(logpath + "COM" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true);
                    swlog.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "  " + logtxt);
                    swlog.Close();
                }
            }
            catch
            {

            }
#endif
        }
    }
    public class WriteTCPWsLog
    {
        // private static Mutex writeLogMutex = new Mutex();
        private static object lockWriteTCPlog = new object();
        private static string logpath;
        public static string LogPath
        {
            get { return logpath; }
            set { logpath = value; }
        }
        /// <summary>
        /// 写日志文，写之前先设logpath;
        /// </summary>
        /// <param name="logtxt"></param>
        public static void WriteWslogs(String logtxt)
        {
#if DEBUG
            try
            {
                lock (lockWriteTCPlog)
                {
                    System.IO.StreamWriter swlog = new System.IO.StreamWriter(logpath + "TCP" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true);
                    swlog.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "  " + logtxt);
                    swlog.Close();
                }
            }
            catch
            {

            }
#endif
        }
    }

    public class WriteStartWsLog
    {
        // private static Mutex writeLogMutex = new Mutex();

        private static string logpath;
        public static string LogPath
        {
            get { return logpath; }
            set { logpath = value; }
        }
        /// <summary>
        /// 写日志文，写之前先设logpath;
        /// </summary>
        /// <param name="logtxt"></param>
        public static void Writelogs(String logtxt)
        {
#if DEBUG
            try
            {

                System.IO.StreamWriter swlog = new System.IO.StreamWriter(logpath + "ServerStart_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true);
                swlog.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "  " + logtxt);
                swlog.Close();
            }
            catch
            {

            }
#endif

        }
    }

    }
