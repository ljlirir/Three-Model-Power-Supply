
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static eTommensDC.WSDataBaseContol;

namespace eTommensDC
{
    public class ThreeModeControlThread
    {
        //BaudRate 波特率 Parity 检验位 ,DataBits 数据位,StopBits  停止位
        //  public WSMonitorThread(string nWSname, string nPortName, int nBaudRate, Parity nParity, Int32 nDataBits,StopBits nStopBits,)
        //COM端口，主机Address，端口互斥，是否写日志
        //设备 端口属性
        private ModBusComInfo WsModbusComInfo;
        //public ShortCutKeyList WsShortCutKeyList = new ShortCutKeyList();
        //public AutoControlList WsAutoControlList = new AutoControlList();

        //配置file
        //public static string DeviceCAndSTempleteXMLFileName = AppDomain.CurrentDomain.BaseDirectory + "setting\\Rules.XML";
        //public static string DeviceAddrXMLFileName = AppDomain.CurrentDomain.BaseDirectory + "setting\\DevicesClassInfo.XML";
        //public static string DeviceModelXMLFileName = AppDomain.CurrentDomain.BaseDirectory + "setting\\Rules.XML";
        //public static string ShortCutXMLFileName = AppDomain.CurrentDomain.BaseDirectory + "setting\\ShortCutKey.XML";
        //设备字长16位 长度 2个Byte ，32位 4个Byte，默认16位。
        public UInt16 byteLength = 2;
        /// <summary>
        /// 线程开始时间
        /// </summary>
        public DateTime ThreadStartTime;
        public bool ifGetDeviceData = false;
        public bool EnableProgram = false;
        public string DeviceClassName = "";
        //类型模版和快捷键模板 ID
        private string ShortCutKeyTID = "";
        private string DeviceClassTID = "";
        public int ShowBit = 3;
        private int AddressLength = 2;//Address字长
        private UInt16 PowerSwitchAddr = 0x0001; //<!-- 设备开关Address -->
        private int PowerSwitchBytes = 2;//<!-- 设备开关Address长度 -->

        private UInt16 ProtectStatAddr = 0x0002;//</ProtectStatAddr><!-- 保护状态Address -->
        private int ProtectStatBytes = 2;//</ProtectStatBytes>><!-- 保护状态Address长度 -->

        private UInt16 ModelAddr = 0x0003;//</ModelAddr><!-- 规格型号Address -->
        private int ModelBytes = 2;//<!-- 规格型号Address长度 -->

        private UInt16 ClassDetialAddr = 0x0004;//</ClassDetialAddr><!-- 分类尾缀Address -->
        private int ClassDetialBytes = 2;//</ClassDetialBytes><!-- 分类尾缀Address长度 -->

        private UInt16 DecimalsAddr = 0x0005;//</DecimalsAddr><!-- 小数点位数Address -->
        private int DecimalsBytes = 2;//</DecimalsBytes><!-- 小数点位数长度 -->

        private UInt16 VoltageAddr = 0x0010;//</VoltageAddr> <!-- 显示Voltage Address -->
        private int VoltageBytes = 2;//</VoltageBytes> <!-- 显示Voltage Address长度 -->

        private UInt16 CurrentAddr = 0x0011;//</CurrentAddr><!-- 显示Current Address -->
        private int CurrentBytes = 2;//</CurrentBytes><!-- 显示Current Address长度 -->

        private UInt16 PowerAddr = 0x0012;//</PowerAddr><!-- 显示Power Address -->
        private int PowerBytes = 4;//</PowerBytes><!-- 显示Power Address长度 -->

        private UInt16 PowerCalAddr = 0x0014;//</PowerCalAddr><!-- 计算Power Address -->
        private int PowerCalBytes = 4;//</PowerCalBytes><!-- 计算Power  Address长度 -->

        public bool EnableProtect = false;
        private UInt16 ProtectVolAddr = 0x0020;//</ProtectVolAddr><!--over voltage:保护 Address -->
        private int ProtectVolBytes = 2;//</ProtectVolBytes><!--over voltage:保护 Address长度 -->

        private UInt16 ProtectCurAddr = 0x0021;//</ProtectCurAddr><!--over current:保护 Address -->
        private int ProtectCurBytes = 2;//</ProtectCurBytes><!--over voltage:保护 Address长度 -->

        private UInt16 ProtectPowAddr = 0x0022;//</ProtectPowAddr><!--过Power保护 Address -->
        private int ProtectPowBytes = 4;//</ProtectPowBytes><!--过Power保护 Address长度 -->
                                        //  <!-- ----------------程控Setting-------------------------------- -->
        private UInt16 SetVolAddr = 0x0030;//</SetVolAddr><!--SettingVoltage Address -->
        private int SetVolBytes = 2;//</SetVolBytes><!--SettingVoltage AddressByte数 -->

        private UInt16 SetCurAddr = 0x0031;//</SetCurAddr><!--SettingCurrentAddress -->
        private int SetCurBytes = 2;//</SetCurBytes><!--SettingCurrentAddressByte数 -->

        private UInt16 SetTimeSpanAddr = 0x0032;//</TimeSpanAddr><!--Setting时间Address -->
        private int SetTimeSpanBytes = 2;//</SetTimeSpanBytes><!--Setting时间AddressByte数 -->


        //<!-- ------------------------------------------------------------------------- -->

        //<!-- ------------------------------------------------------------------------- -->
        private UInt16 PowerStatAddr = 0x8801;//</PowerStatAddr><!-- 设备开机状态Address -->
        private int PowerStatBytes = 2;//</PowerStatBytes><!-- 设备开关Address长度 -->

        private UInt16 defaultShowAddr = 0x8802;//</defaultShowAddr><!-- 预设值显示Address -->
        private int defaultShowBytes = 2;//</defaultShowBytes><!-- 预设值显示Address长度 -->

        private UInt16 SCPAddr = 0x8803;//</SCPAddr><!-- 短路Current保护Address -->
        private int SCPBytes = 2;//</SCPBytes><!-- 短路Current保护Address长度 -->


        private UInt16 BuzzerAddr = 0x8804;//</BuzzerAddr><!-- 蜂鸣器Address -->
        private int BuzzerBytes = 2;//</BuzzerBytes><!-- 蜂鸣器Address长度 -->

        private UInt16 DeviceAddr = 0x9999;//</DeviceAddr><!-- 设备Address -->
        private int DeviceBytes = 2;//</DeviceBytes><!-- 设备Address长度 -->

        private UInt16 SDTimeAddr = 0xCCCC;//</SDTimeAddr><!-- SDTimeAddress -->
        private int SDTimeBytes = 2;//</SDTimeBytes><!-- SDTimeAddress长度 -->




        //----------------------------------------------------------------------------------缓冲
        private UInt16 WBuffHeadLength = 2;
        private UInt16 RBuffHeadLength = 3;
        private UInt16 CRCLength = 2;
        private UInt16 VCPDataCount = 4;
        private UInt16 OCPDataCount = 4;
        private UInt16 OneRegsiterLen = 1;

        private byte[] GetVCPSendCommand;
        private byte[] GetVCPRecviByte;

        private byte[] GetOCPSendCommand;
        private byte[] GetOCPRecviByte;

        private byte[] sSetShortCutKeyCommand;
        private byte[] ReadShortCutKeyCmd;
        private byte[] SSetShortCutKeyRecviByte;
        private byte[] ReadSCKVolRecviByte;
        private byte[] ReadSCKCurrRecviByte;
        private byte[] ReadSCKSpanTimeRecviByte;
        private byte[] ReadSCKSpanEnableBytes;
        //写单个数据
        private byte[] WriteSRegCommand;
        private byte[] WriteSRegRecviByte;
        //读单个数据 缓冲
        private byte[] ReadSRegCommand;
        private byte[] ReadSRegRecviByte;
        //写单个数据
        private byte[] WriteControlCommand;
        private byte[] WriteControlRecviByte;
        //------------------------------------------------------------------------------------//
        private static bool iFWriteLog = true;//是否写日志,初始化 写日志 
        public Thread ReadSerialThread; //读线程

        public Thread AutoControlThread;//控制输出线程
        //  private string baudRate;
        private int errorCount = 0;//连续读写错误次数,如果中间有一次对 ，清零 
        private int maxErrorCount = 5;//最大连续读写错误，超过这个数，重新关闭端口
        private int totalErrorCount = 0;
        //  private int DataErrorCount = 0; //读出来 数错误次数值
        //  private int maxDataErrorCount = 5;//读出来 数错误次数最大值
        public Boolean lineError = false;//线路出错      
        private MutexSerialPort WsComMutex;
        //
        public bool tstop = false;//是否停止线程 
        //暂时控制
        public bool autoPause = false;
        public bool autoStop = false;
        //机器和线程状态
        public DeviceStat WSDeviceStat = DeviceStat.UnKnown;



        //接收到 型号
        private string rClassID;
        //型号尾缀
        private string rModelID;

        public string ClassTitle = "";
        public string ModelTitle = "";
        //十进制数放大 倍数，比如数据 位数是小数点两位，既要放大10*10=100，三位要放大10*10*10=1000
        private int VolMultTen = 100;
        private int CurrMultTen = 100;
        private int PowMultTen = 100;
        //开关状态，初始化 未知
        public UInt16 rDeviceStat = (UInt16)StatON_OFF.UnKnown;

        //接收到 Current，Voltage，Power
        public float rVoltage = 0;//Voltage
        public float rCurrent = 0;//Current
        public float rPower = 0;//Power
        //转化成 16位无符号数
        public UInt32 rUVoltage = 0;//Voltage
        public UInt32 rUCurrent = 0;//Current
        public UInt32 rUPower = 0;//Power

        //最大 保护值
        public float MaxVoltage = 0;
        public float MaxCurrent = 0;
        public float MaxPower = 0;
        //读到 over voltage:保护值
        public float rOVPVoltage = 0;
        public float rOCPCurrent = 0;
        public float rOPPower = 0;
        //要发送 over voltage:保护Voltage，Current，Power
        private UInt32 sOVPVoltage = 0;//Voltage     

        public bool recordChangeValue { get; set; }//记录变化值

        private string wSname;//设备名称
        public string WSname
        {
            get { return wSname; }
            set { wSname = value; }
        }
        private byte hostAddress;
        public byte HostAddress
        {
            get { return hostAddress; }
            set { hostAddress = value; }
        }
        //COM口的名字
        private string portName;
        public string PortName
        {
            get { return portName; }
            set { portName = value; }
        }
        //采样频率
        private int sampRate;
        public int SampRate
        {
            get { return sampRate; }
            set { sampRate = value; }
        }
        //波特率
        private int baudRate;
        public int BaudRate  
        {
            get { return baudRate; }
            set { baudRate = value; }
        }
        //读写超时设置
        private int readTimeOut;
        public int ReadTimeOut
        {
            get { return readTimeOut; }
            set { readTimeOut = value; }
        }
        private int writeTimeOut;
        public int WriteTimeOut
        {
            get { return writeTimeOut; }
            set { writeTimeOut = value; }
        }
        private DateTime rcDatetime;
        public int DelayTime { get; set; }
        public float protect_V { get; set; }
        public float protect_A { get; set; }
        public float protect_W { get; set; }
        private int sampRateSleepTime;
        public int WSampRate
        {
            get { return WsModbusComInfo.SampRate; }
            set
            {
                WsModbusComInfo.SampRate = value;
                //读写各休眠一次，X2
                sampRateSleepTime = WsModbusComInfo.SampRate - 2 * WsModbusComInfo.DelayTime;
                if (sampRateSleepTime < 0)
                {
                    sampRateSleepTime = 1;
                }
            }
        }
        private byte getaddreHbyte(UInt16 maddr)
        {
            return (byte)((maddr & 0xFF00) >> 8);
        }
        private byte getaddreLbyte(UInt16 maddr)
        {
            return (byte)(maddr & 0xFF);
        }
           public int ErrorCount
       {
           get { return errorCount; }
           set { errorCount = value; }
       }
       public int MaxErrorCount
       {
           get { return maxErrorCount; }
           set { maxErrorCount = value; }
       }
       public bool IFWriteLog
       {
           set { iFWriteLog = value; }
       }
  
       public bool TTStop
       {
           get { return tstop; }
           set { tstop = value; }
       }
        public float OVPVoltage
        {
            get { return WsModbusComInfo.protect_V; }
            set
            {
                sOVPVoltage = (UInt32)(value * VolMultTen);
                WsModbusComInfo.protect_V = value;
                WsModbusComInfo.ChangeNoteStation(MainForm.comSetXMLFileName);//：调用 WsModbusComInfo 实例的 ChangeNoteStation 方法，更新配置文件（由 CollectForm.comSetXMLFileName 提供文件名）。
            }

        }
        private UInt32 sOCPCurrent;//电流
        public float OCPCurrent
        {
            get { return sOCPCurrent / CurrMultTen; }
            set
            {
                sOCPCurrent = (UInt16)(value * CurrMultTen);
                WsModbusComInfo.protect_A = value;
                WsModbusComInfo.ChangeNoteStation(MainForm.comSetXMLFileName);
            }

        }
        private UInt32 sOPPower;//功率
        public float OPPower
        {
            get { return sOPPower / PowMultTen; }
            set
            {
                sOPPower = (UInt32)(value * PowMultTen);
                WsModbusComInfo.protect_W = value;
                WsModbusComInfo.ChangeNoteStation(MainForm.comSetXMLFileName);
            }
        }
        private bool AllocateDevicePriBuff()
        {
            if (WriteSRegCommand == null)
                WriteSRegCommand = new byte[WBuffHeadLength + AddressLength + AddressLength + CRCLength];
            if (WriteSRegRecviByte == null)
                WriteSRegRecviByte = new byte[WriteSRegCommand.Length];
            // { WsModbusComInfo.HostAddress, (byte)DeviceRWFunction.WriteSReg, beginAddrsByte[1], beginAddrsByte[0], wDataByte[1], wDataByte[0] };
            if (ReadSRegCommand == null)
                ReadSRegCommand = new byte[WBuffHeadLength + AddressLength + AddressLength + CRCLength];
            if (ReadSRegRecviByte == null)
                ReadSRegRecviByte = new byte[RBuffHeadLength + AddressLength + CRCLength];
            ///控制VoltageCurrent线程专用
            return true;
        }
        public class MutexSerialPort
        {
            //每个端口对应一个锁，于用端口互斥访问。每创建一个锁，加入到此队列中来。
            public static List<MutexSerialPort> listMutexSerialPort = new List<MutexSerialPort>();
            //锁，用于访问端口。
            private Mutex sMutex;
            //加锁的端口句杯，创建一个锁，只创建一个句柄。
            public SerialPort sMutexPort;
            public MutexSerialPort(string nportName)
            {
                portName = nportName;
                sMutex = new Mutex();
                sMutexPort = new SerialPort();
                //端口名称
                sMutexPort.PortName = nportName;
                //    sMutex.WaitOne();
                //   sMutex.ReleaseMutex
            }

            public string portName;
            //不设置超时，程序读写超时在端口参数设
            public bool WaitOne()
            {
                return sMutex.WaitOne();
            }
            public void ReleaseMutex()
            {
                sMutex.ReleaseMutex();
            }
            //用于查找端口对应的锁是否存在，不存在就创建。
            public static MutexSerialPort GetAndCreatePortByName(string nportName)
            {
                MutexSerialPort reSericalMutex = null;
                foreach (MutexSerialPort tempSericalMutex in listMutexSerialPort)
                {
                    if (tempSericalMutex.portName == nportName)
                    {
                        reSericalMutex = tempSericalMutex;

                    }

                }
                if (reSericalMutex == null)//锁找不到就创建。
                {
                    reSericalMutex = new MutexSerialPort(nportName);
                    listMutexSerialPort.Add(reSericalMutex);
                }
                return reSericalMutex;
            }
        }
        public DeviceCtlStat getDeviceDecimal()
        {
            // 尝试读取寄存器数据
            if (ReadRegister(DecimalsAddr) != DeviceCtlStat.Success)
            {
                return DeviceCtlStat.DeviceReadError;
            }

            try
            {
                // 提取电压小数位数
                byte vbyte = ReadSRegRecviByte[RBuffHeadLength];
                this.VolMultTen = CalculateMultiplier(vbyte);

                // 提取电流小数位数
                byte cwbyte = ReadSRegRecviByte[RBuffHeadLength];
                byte cbyte = (byte)((cwbyte & 0xF0) >> 4);
                this.CurrMultTen = CalculateMultiplier(cbyte);

                // 提取功率小数位数
                byte wbyte = (byte)(cwbyte & 0x0F);
                this.PowMultTen = CalculateMultiplier(wbyte);

//#if DEBUG
                // 记录调试日志
//                WriteComWsLog.WriteWslogs($"从设备中读出小数据位被除数 Voltage: {this.VolMultTen}, Current: {this.CurrMultTen}, Power: {this.PowMultTen}");
//#endif

                return DeviceCtlStat.Success;
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"Error in getDeviceDecimal: {ex.Message}");
                return DeviceCtlStat.DeviceReadError;
            }
        }

        // 辅助方法：计算倍数值
        private int CalculateMultiplier(byte decimalPlaces)
        {
            return (int)Math.Pow(10, decimalPlaces); // 使用数学公式替代循环
        }

        private void AddCRCToArrayLast(byte[] targetData)
        {

            byte sHCRCBit;
            byte sLCRCBit;
            ModbusCRC.CRC16Calc(targetData, targetData.Length - 2, out sHCRCBit, out sLCRCBit);
            targetData[targetData.Length - 2] = sHCRCBit;
            targetData[targetData.Length - 1] = sLCRCBit;
        }

        private bool CompareArrayByLeng(byte[] oneArray, byte[] secArray, int ArrayLength)
        {
            if ((oneArray.Length < ArrayLength) || (secArray.Length < ArrayLength))
            {

            }
            for (int arrayindex = 0; arrayindex < ArrayLength; arrayindex++)
            {
                if (oneArray[arrayindex] != secArray[arrayindex])
                {
                    return false;
                }
            }
            return true;

        }
        private DeviceCtlStat ReadRegister(UInt16 begAddr)
        {
            ReadSRegCommand[0] = WsModbusComInfo.HostAddress;
            ReadSRegCommand[1] = (byte)DeviceRWFunction.ReadMReg;
            ReadSRegCommand[2] = getaddreHbyte(begAddr);
            ReadSRegCommand[3] = getaddreLbyte(begAddr);
            ReadSRegCommand[4] = getaddreHbyte(OneRegsiterLen); 
            ReadSRegCommand[5] = getaddreLbyte(OneRegsiterLen);
            AddCRCToArrayLast(ReadSRegCommand);
            bool getReadLength = false;
            while ((!getReadLength) && (errorCount <= maxErrorCount))
            {
                //端口读写时先做互斥锁定，如果同时向端口发送数据，应该会有问题 。
                WsComMutex.WaitOne();

                //每个程序写之前也要延迟一下，防止前一个线程刚读完。                   
                Thread.Sleep(WsModbusComInfo.DelayTime);

                WsComMutex.sMutexPort.Write(ReadSRegCommand, 0, ReadSRegCommand.Length);
                // myport.ReadBufferSize = 15;

                //反复读，直到满意 止

                int totoldelayMs = 0;
                while (totoldelayMs <= WsModbusComInfo.ReadTimeOut)
                {
                    if (WsComMutex.sMutexPort.BytesToRead >= ReadSRegRecviByte.Length)
                    {
                        WsComMutex.sMutexPort.Read(ReadSRegRecviByte, 0, ReadSRegRecviByte.Length);
                        getReadLength = true;
                        break;
                    }
                    Thread.Sleep(WsModbusComInfo.DelayTime);
                    totoldelayMs = totoldelayMs + WsModbusComInfo.DelayTime;

                }
                this.rcDatetime = DateTime.Now;
                if (getReadLength != true)
                {
                    WsComMutex.sMutexPort.Read(ReadSRegRecviByte, 0, WsComMutex.sMutexPort.BytesToRead);

                    errorCount = errorCount + 1;
                }
                else
                {

                    WsComMutex.ReleaseMutex();

                    errorCount = 0;
                    break;
                }


                WsComMutex.ReleaseMutex();
            }

            if (getReadLength == true)
            {
                return DeviceCtlStat.Success;
            }
            else
            {
                return DeviceCtlStat.DeviceReadError;
            }

        }
        private DeviceCtlStat ReadRegister(byte[] rSendCommand, byte[] rReadData, int rReadCount)
        {
            bool getReadLength = false;
            while ((!getReadLength) && (errorCount <= maxErrorCount))
            {
                //端口读写时先做互斥锁定，如果同时向端口发送数据，应该会有问题 。
                WsComMutex.WaitOne();

                //每个程序写之前也要延迟一下，防止前一个线程刚读完。                   
                Thread.Sleep(WsModbusComInfo.DelayTime);

                WsComMutex.sMutexPort.Write(rSendCommand, 0, rSendCommand.Length);
                // myport.ReadBufferSize = 15;

                //反复读，直到满意 止

                int totoldelayMs = 0;
                while (totoldelayMs <= WsModbusComInfo.ReadTimeOut)
                {
                    if (WsComMutex.sMutexPort.BytesToRead >= rReadCount)
                    {
                        WsComMutex.sMutexPort.Read(rReadData, 0, rReadCount);
                        getReadLength = true;
                        break;
                    }
                    Thread.Sleep(WsModbusComInfo.DelayTime);
                    totoldelayMs = totoldelayMs + WsModbusComInfo.DelayTime;

                }
                this.rcDatetime = DateTime.Now;
                if (getReadLength != true)
                {
                    WsComMutex.sMutexPort.Read(rReadData, 0, WsComMutex.sMutexPort.BytesToRead);

                    errorCount = errorCount + 1;
                }
                else
                {

                    WsComMutex.ReleaseMutex();

                    errorCount = 0;
                    break;
                }


                WsComMutex.ReleaseMutex();
            }

            if (getReadLength == true)
            {
                return DeviceCtlStat.Success;
            }
            else
            {
                return DeviceCtlStat.DeviceReadError;
            }

        }
        private DeviceCtlStat WriteRegister(UInt16 beginAddrs, UInt16 wData)
        {
            byte[] beginAddrsByte = BitConverter.GetBytes(beginAddrs);
            byte[] wDataByte = BitConverter.GetBytes(wData);

            //   byte[] tempwriteData = new byte[] { WsModbusComInfo.HostAddress, (byte)DeviceRWFunction.WriteSReg, beginAddrsByte[1], beginAddrsByte[0], wDataByte[1], wDataByte[0] };
            WriteSRegCommand[0] = WsModbusComInfo.HostAddress;
            WriteSRegCommand[1] = (byte)DeviceRWFunction.WriteSReg;
            WriteSRegCommand[2] = beginAddrsByte[1];
            WriteSRegCommand[3] = beginAddrsByte[0];
            WriteSRegCommand[4] = wDataByte[1];
            WriteSRegCommand[5] = wDataByte[0];
            AddCRCToArrayLast(WriteSRegCommand);

            // byte[] writeRevData = new byte[writeData.Length];
            bool getReadLength = false;
            int totoldelayMs = 0;
            bool WriteSucess = false;
            try
            {

                while ((!getReadLength) && (errorCount <= maxErrorCount))
                {
                    //端口读写时先做互斥锁定，如果同时向端口发送数据，应该会有问题 。
                    WsComMutex.WaitOne();

                    //每个程序写之前也要延迟一下，防止前一个线程刚读完。                   
                    //   Thread.Sleep(WsModbusComInfo.DelayTime);

                    WsComMutex.sMutexPort.Write(WriteSRegCommand, 0, WriteSRegCommand.Length);

                    //WriteComWsLog.WriteWslogs(WsModbusComInfo.WSname + "start to receive the data");
                    //延迟一下，不然会Reading错误
                    //  Thread.Sleep(WsModbusComInfo.DelayTime);
                    //
                    totoldelayMs = 0;
                    while (totoldelayMs <= WsModbusComInfo.ReadTimeOut)
                    {

                        if (WsComMutex.sMutexPort.BytesToRead >= WriteSRegRecviByte.Length)
                        {

                            WsComMutex.sMutexPort.Read(WriteSRegRecviByte, 0, WriteSRegRecviByte.Length);
                            getReadLength = true;
                            break;
                        }
                        Thread.Sleep(WsModbusComInfo.DelayTime);

                        totoldelayMs = totoldelayMs + WsModbusComInfo.DelayTime;

                    }
                    if (getReadLength != true)//不成功
                    {
                        WsComMutex.sMutexPort.Read(WriteSRegRecviByte, 0, WsComMutex.sMutexPort.BytesToRead);
                        errorCount = errorCount + 1;

                        WsComMutex.ReleaseMutex();
                        continue;
                    }
                    else
                    {

                        this.rcDatetime = DateTime.Now;
                        WriteWsLog.WriteWslogs(WsModbusComInfo.WSname + "Receiving success ");
                        WriteSucess = CompareArrayByLeng(WriteSRegCommand, WriteSRegRecviByte, WriteSRegCommand.Length);
                        if (WriteSucess)
                        {

                            //成功要写file了。。。
                            //WriteComWsLog.WriteWslogs(" Correct: " + System.BitConverter.ToString(WriteSRegRecviByte));
                            string logstr = "  Voltage：" + rVoltage.ToString() + "  Current:" +
                                 rCurrent.ToString() + " Power：" + rPower.ToString();
                            WriteWsLog.WriteWslogs(logstr);
                            this.errorCount = 0;
                            WriteWsLog.WriteWslogs("Written register release lock ");
                            WsComMutex.ReleaseMutex();
                            break;
                        }
                        else
                        {
                            WriteWsLog.WriteWslogs(" Error: " + System.BitConverter.ToString(WriteSRegRecviByte));
                            string logstr = " The data sent is：" + System.BitConverter.ToString(WriteSRegCommand);
                            WriteWsLog.WriteWslogs(logstr);
                            errorCount = errorCount + 1;
                            WriteWsLog.WriteWslogs("Written register release lock ");
                            WsComMutex.ReleaseMutex();


                        }


                    }


                }


                if (WriteSucess != true)
                {
                    return DeviceCtlStat.DeviceWriteError;
                }
                else { return DeviceCtlStat.Success; };
            }
            catch (Exception ex)
            {
                //WriteComWsLog.WriteWslogs("Written register release lock ");
                WsComMutex.ReleaseMutex();
                this.errorCount = this.errorCount + 1;
                //WriteComWsLog.WriteWslogs("Receiving timeout,please check the device is normal operation or not!info:" + ex.Message);
                //如果次数达到一定次数，就要重新启动串口,看看这样子是否会有                
                return DeviceCtlStat.DeviceWriteError;
            }




        }


        //写32位寄存器，因为无所多路寄存器，所以要分两次。
        private DeviceCtlStat WriteRegister(UInt16 beginAddrs, UInt32 wData)
        {
            byte[] beginAddrsByte = BitConverter.GetBytes(beginAddrs);
            byte[] secondAddrssBYte = BitConverter.GetBytes(beginAddrs + 1);//加一赋给字节数组
            byte[] wDataByte = BitConverter.GetBytes(wData);

            // byte[] tempwriteHData = new byte[] { WsModbusComInfo.HostAddress, (byte)DeviceRWFunction.WriteSReg, beginAddrsByte[1], beginAddrsByte[0], wDataByte[3], wDataByte[2] };
            WriteSRegCommand[0] = WsModbusComInfo.HostAddress;
            WriteSRegCommand[1] = (byte)DeviceRWFunction.WriteSReg;
            WriteSRegCommand[2] = beginAddrsByte[1];
            WriteSRegCommand[3] = beginAddrsByte[0];
            WriteSRegCommand[4] = wDataByte[3];
            WriteSRegCommand[5] = wDataByte[2];
            AddCRCToArrayLast(WriteSRegCommand);
            //  byte[] tempwriteLData= new byte[] { WsModbusComInfo.HostAddress, (byte)DeviceRWFunction.WriteSReg, secondAddrssBYte[1], secondAddrssBYte[0],wDataByte[1], wDataByte[0] };
            //   byte[] writeHData = new byte[tempwriteHData.Length + 2];
            //    byte[] writeLData = new byte[tempwriteLData.Length + 2];
            //        AddCRCToArray(tempwriteHData, writeHData);
            //        AddCRCToArray(tempwriteLData, writeLData);
            //不使用类中的接收数据，以免数据被冲掉
            //   byte[] writeRevData = new byte[writeLData.Length];
            bool getReadLength = false;
            int totoldelayMs = 0;
            bool WriteSucess = false;
            try
            {

                while ((!getReadLength) && (errorCount <= maxErrorCount))
                {
                    //端口读写时先做互斥锁定，如果同时向端口发送数据，应该会有问题的。
                    WsComMutex.WaitOne();

                    //每个程序写之前也要延迟一下，防止前一个线程刚读完。                   
                    //   Thread.Sleep(WsModbusComInfo.DelayTime);

                    WsComMutex.sMutexPort.Write(WriteSRegCommand, 0, WriteSRegCommand.Length);

                    WriteWsLog.WriteWslogs(WsModbusComInfo.WSname + " 开始接收数据 ");
                    //延迟一下，不然会读取错误
                    //  Thread.Sleep(WsModbusComInfo.DelayTime);
                    //
                    totoldelayMs = 0;
                    while (totoldelayMs <= WsModbusComInfo.ReadTimeOut)
                    {

                        if (WsComMutex.sMutexPort.BytesToRead >= WriteSRegRecviByte.Length)
                        {

                            WsComMutex.sMutexPort.Read(WriteSRegRecviByte, 0, WriteSRegRecviByte.Length);
                            getReadLength = true;
                            break;
                        }
                        Thread.Sleep(WsModbusComInfo.DelayTime);

                        totoldelayMs = totoldelayMs + WsModbusComInfo.DelayTime;

                    }
                    if (getReadLength != true)//不成功
                    {
                        WsComMutex.sMutexPort.Read(WriteSRegRecviByte, 0, WsComMutex.sMutexPort.BytesToRead);/////////////////------这里可能因为缓冲不够出错
                        errorCount = errorCount + 1;
                        continue;
                    }
                    else
                    {
                        WriteSucess = CompareArrayByLeng(WriteSRegCommand, WriteSRegRecviByte, WriteSRegRecviByte.Length);
                        if (WriteSucess)
                        {

                            this.errorCount = 0;

                        }
                        else
                        {
                            errorCount = errorCount + 1;
                            continue;


                        }


                    }
                    Thread.Sleep(WsModbusComInfo.DelayTime);
                    WriteSRegCommand[0] = WsModbusComInfo.HostAddress;
                    WriteSRegCommand[1] = (byte)DeviceRWFunction.WriteSReg;
                    WriteSRegCommand[2] = secondAddrssBYte[1];
                    WriteSRegCommand[3] = secondAddrssBYte[0];
                    WriteSRegCommand[4] = wDataByte[1];
                    WriteSRegCommand[5] = wDataByte[0];
                    AddCRCToArrayLast(WriteSRegCommand);
                    //  byte[] tempwriteLData= new byte[] { WsModbusComInfo.HostAddress, (byte)DeviceRWFunction.WriteSReg, secondAddrssBYte[1], secondAddrssBYte[0],wDataByte[1], wDataByte[0] };
                    WriteSucess = false;
                    WsComMutex.sMutexPort.Write(WriteSRegCommand, 0, WriteSRegCommand.Length);

                    WriteWsLog.WriteWslogs(WsModbusComInfo.WSname + " 开始接收数据 ");

                    totoldelayMs = 0;
                    while (totoldelayMs <= WsModbusComInfo.ReadTimeOut)
                    {

                        if (WsComMutex.sMutexPort.BytesToRead >= WriteSRegRecviByte.Length)
                        {

                            WsComMutex.sMutexPort.Read(WriteSRegRecviByte, 0, WriteSRegRecviByte.Length);
                            getReadLength = true;
                            break;
                        }
                        Thread.Sleep(WsModbusComInfo.DelayTime);

                        totoldelayMs = totoldelayMs + WsModbusComInfo.DelayTime;

                    }
                    if (getReadLength != true)//不成功
                    {
                        WsComMutex.sMutexPort.Read(WriteSRegRecviByte, 0, WsComMutex.sMutexPort.BytesToRead);
                        errorCount = errorCount + 1;

                        WsComMutex.ReleaseMutex();
                        continue;
                    }
                    else
                    {
                        WriteSucess = CompareArrayByLeng(WriteSRegCommand, WriteSRegRecviByte, WriteSRegRecviByte.Length);
                        if (WriteSucess)
                        {


                            this.errorCount = 0;

                            WsComMutex.ReleaseMutex();
                            break;
                        }
                        else
                        {

                            errorCount = errorCount + 1;

                            WsComMutex.ReleaseMutex();


                        }


                    }


                }


                if (WriteSucess != true)
                {
                    return DeviceCtlStat.DeviceWriteError;
                }
                else { return DeviceCtlStat.Success; };
            }
            catch (Exception ex)
            {
                WriteWsLog.WriteWslogs("写寄存器释放锁 ");
                WsComMutex.ReleaseMutex();
                this.errorCount = this.errorCount + 1;
                WriteWsLog.WriteWslogs(" 接收超时，请检查设备是否正常！ 错误次数" + ex.Message);
                //如果次数达到一定次数，就要重新启动串口,看看这样子是否会有                
                return DeviceCtlStat.DeviceWriteError;
            }



        }


            private void GetVCPData()
        {
            while (!tstop)
            {
                try
                {
                    //

                    //端口读写时先做互斥锁定，如果同时向端口发送数据，应该会有问题 。
                    WsComMutex.WaitOne();

                    //每个程序写之前也要延迟一下，防止前一个线程刚读完。                   
                    Thread.Sleep(WsModbusComInfo.DelayTime);

                    WsComMutex.sMutexPort.Write(GetVCPSendCommand, 0, GetVCPSendCommand.Length);

                    // myport.ReadBufferSize = 15;

                    //延迟一下，不然会Reading错误
                    //  Thread.Sleep(WsModbusComInfo.DelayTime);
                    bool getReadLength = false;
                    int totoldelayMs = 0;
                    while (totoldelayMs <= WsModbusComInfo.ReadTimeOut)
                    {
                        if (WsComMutex.sMutexPort.BytesToRead >= GetVCPRecviByte.Length)
                        {
                            WsComMutex.sMutexPort.Read(GetVCPRecviByte, 0, GetVCPRecviByte.Length);
                            getReadLength = true;
                            break;
                        }
                        Thread.Sleep(WsModbusComInfo.DelayTime);
                        totoldelayMs = totoldelayMs + WsModbusComInfo.DelayTime;

                    }
                    //如果获不到大小，有多少就读多少。。相当于清了读缓冲
                    if (getReadLength != true)
                    {
                        WsComMutex.sMutexPort.Read(GetVCPRecviByte, 0, WsComMutex.sMutexPort.BytesToRead);


                    }
                    else
                    {
                    }
                    //
                    //   totoldelayMs = totoldelayMs + totoldelayMs;

                    //  WsComMutex.sMutexPort.Read(RecviByte, 0, 11);
                    this.rcDatetime = DateTime.Now;

                    WsComMutex.ReleaseMutex();
                    this.errorCount = 0;
                }
                catch (Exception ex)
                {
                    WsComMutex.ReleaseMutex();
                    this.errorCount = this.errorCount + 1;
                    WriteWsLog.WriteWslogs("Receiving timeout,please check the device is normal operation or not!info:" + ex.Message);
                    //如果次数达到一定次数，就要重新启动串口,看看这样子是否会有
                    if (errorCount >= maxErrorCount)
                    {
                        WriteWsLog.WriteWslogs("  Open the port again.....");
                        try
                        {
                            WsComMutex.WaitOne();
                            if (WsComMutex.sMutexPort.IsOpen)
                            {
                                WsComMutex.sMutexPort.Close();
                                Thread.Sleep(WsModbusComInfo.ReadTimeOut);
                            }
                            WsComMutex.sMutexPort.Open();
                            Thread.Sleep(500);
                            WsComMutex.ReleaseMutex();
                            WriteWsLog.WriteWslogs("Open the port again successed。。。。");
                            continue;
                        }
                        catch (Exception nEx)
                        {
                            WsComMutex.ReleaseMutex();
                            WriteWsLog.WriteWslogs("Error:open com fail! The com restart fail,please check line connecting...." + nEx);
                            break;
                        }
                    }

                    continue;
                }
                byte addr = GetVCPRecviByte[0];
                byte fution = GetVCPRecviByte[1];
                //功能码是0X03才是要 数据
                if (fution == (byte)DeviceRWFunction.ReadMReg)
                {
                    //获取CRC 值，和计算 是否一样！
                    UInt16 vcrc = ByteToInt.bytesToUint16(GetVCPRecviByte, GetVCPRecviByte.Length - CRCLength);
                    UInt16 vcrcs = ModbusCRC.CRC16Calc(GetVCPRecviByte, GetVCPRecviByte.Length - CRCLength);
                    if (vcrc == vcrcs)
                    {
                        //有一次正确，错误次数清零
                        ErrorCount = 0;
                        //获得16位整数 各项值
                        UInt32 twrVoltage = 0;
                        UInt32 twrCurrent = 0;
                        UInt32 twrPower = 0;
                        //两个Byte16位,4个Byte32位
                        if (VoltageBytes == DataBitLenth.DataBit16)
                        {
                            twrVoltage = ByteToInt.bytesToUint16(GetVCPRecviByte, RBuffHeadLength);
                        }
                        else if (VoltageBytes == DataBitLenth.DataBit32)
                        {
                            twrVoltage = ByteToInt.bytesToUint32(GetVCPRecviByte, RBuffHeadLength);
                        }
                        if (CurrentBytes == DataBitLenth.DataBit16)
                        {
                            twrCurrent = ByteToInt.bytesToUint16(GetVCPRecviByte, RBuffHeadLength + VoltageBytes);
                        }
                        else if (CurrentBytes == DataBitLenth.DataBit32)
                        {
                            twrCurrent = ByteToInt.bytesToUint32(GetVCPRecviByte, RBuffHeadLength + VoltageBytes);
                        }
                        if (PowerBytes == DataBitLenth.DataBit16)
                        {
                            twrPower = ByteToInt.bytesToUint16(GetVCPRecviByte, RBuffHeadLength + VoltageBytes + CurrentBytes);
                        }
                        else if (PowerBytes == DataBitLenth.DataBit32)
                        {
                            twrPower = ByteToInt.bytesToUint32(GetVCPRecviByte, RBuffHeadLength + VoltageBytes + CurrentBytes);
                        }
                        ifGetDeviceData = true;
                        //三个值做比较
                        if (WsModbusComInfo.recordChangeValue == true)
                        {

                            if ((twrVoltage != rUVoltage) || (twrCurrent != rUCurrent) || (twrPower != rUPower))
                            {
                                rUVoltage = twrVoltage;
                                rUCurrent = twrCurrent;
                                rUPower = twrPower;
                                rVoltage = (float)twrVoltage / VolMultTen;
                                rCurrent = (float)twrCurrent / CurrMultTen;
                                rPower = (float)twrPower / PowMultTen;

                                //写入数据库
                                //       WSDatabaseContol.WriteSQLWSCollect(wSname, rVoltage, rCurrent, rPower,);
                                WSDatabaseContol.WriteSQLWSCollect(WsModbusComInfo.WSname, rVoltage, rCurrent, rPower, rcDatetime, WsModbusComInfo.PortName, WsModbusComInfo.HostAddress);
                            }

                        }
                        else
                        {
                            rVoltage = (float)twrVoltage / VolMultTen;
                            rCurrent = (float)twrCurrent / CurrMultTen;
                            rPower = (float)twrPower / PowMultTen;
                            //写入数据库
                            WSDatabaseContol.WriteSQLWSCollect(WsModbusComInfo.WSname, rVoltage, rCurrent, rPower, rcDatetime, WsModbusComInfo.PortName, WsModbusComInfo.HostAddress);
                        }

                        //    WriteComWsLog.WriteWslogs(" Correct: " + System.BitConverter.ToString(RecviByte));
                        //      string logstr =  "  Voltage：" + rVoltage.ToString() + "  Current:" +
                        //           rCurrent.ToString() + " Power：" + rPower.ToString();
                        //      WriteComWsLog.WriteWslogs(logstr);
                        //       WSDatabaseContol.WriteSQLWSCollect(wSname, wTempT, wHumidity, wRadiation, wWindSpeed, wWindDirection, WindDirectCode);


                    }
                    else
                    {
                        ErrorCount = ErrorCount + 1;
                        WriteWsLog.WriteWslogs(" CRC Error " + System.BitConverter.ToString(GetVCPRecviByte));
                        //CRC校验出错了，就等待一个超时 时间，然后清楚缓冲区
                        WsComMutex.WaitOne();
                        Thread.Sleep(WsModbusComInfo.ReadTimeOut);

                        WsComMutex.sMutexPort.DiscardInBuffer();
                        WsComMutex.sMutexPort.DiscardOutBuffer();
                        WsComMutex.ReleaseMutex();
                        //
                        if (ErrorCount > maxErrorCount)
                        {
                            try
                            {
                                WsComMutex.WaitOne();
                                if (WsComMutex.sMutexPort.IsOpen)
                                {
                                    WsComMutex.sMutexPort.Close();
                                    Thread.Sleep(500);
                                }
                                WsComMutex.sMutexPort.Open();
                                Thread.Sleep(500);
                                WsComMutex.ReleaseMutex();
                                WriteWsLog.WriteWslogs("Open the port again successed。。。。");
                                continue;
                            }
                            catch (Exception nEx)
                            {
                                WsComMutex.ReleaseMutex();
                                WriteWsLog.WriteWslogs("Error:open com fail! The com restart fail,please check line connecting...." + nEx);
                                break;

                            }


                        }
                    }
                }
                else //读到功能码不是03 ，就认 是错 。。
                {
                    WriteWsLog.WriteWslogs("Reading Voltage Error codes:" + System.BitConverter.ToString(GetVCPRecviByte));
                    WsComMutex.WaitOne();
                    Thread.Sleep(WsModbusComInfo.ReadTimeOut);

                    WsComMutex.sMutexPort.DiscardInBuffer();
                    WsComMutex.sMutexPort.DiscardOutBuffer();
                    WsComMutex.ReleaseMutex();
                    ErrorCount = ErrorCount + 1;
                    if (ErrorCount > maxErrorCount)
                    {
                        try
                        {
                            WsComMutex.WaitOne();

                            if (WsComMutex.sMutexPort.IsOpen)
                            {
                                WsComMutex.sMutexPort.Close();
                                Thread.Sleep(500);
                            }
                            WsComMutex.sMutexPort.Open();
                            Thread.Sleep(500);
                            WsComMutex.ReleaseMutex();
                            WriteWsLog.WriteWslogs("Open the port again successed。。。。");
                            continue;
                        }
                        catch (Exception nEx)
                        {
                            WsComMutex.ReleaseMutex();
                            WriteWsLog.WriteWslogs("Error:open com fail! The com restart fail,please check line connecting...." + nEx);

                        }


                    }

                }
                ////需要休息一下了，采样频率 休眠时间,已经计算去掉了延时
                Thread.Sleep(sampRateSleepTime);
                WSDeviceStat = DeviceStat.Running;
            }


        }

        //获得开关状态,返回的是机器状态，获得的并关状态已经保存在rDeviceStat
        public DeviceCtlStat getDevicePowerStat()
        {

            byte[] ReadPowerSWComand = new byte[WBuffHeadLength + AddressLength + AddressLength + CRCLength];
            ReadPowerSWComand[0] = WsModbusComInfo.HostAddress;
            ReadPowerSWComand[1] = (byte)DeviceRWFunction.ReadMReg;
            ReadPowerSWComand[2] = getaddreHbyte(OneRegsiterLen);//设置要读取的寄存器数量的高位和低位字节。
            ReadPowerSWComand[3] = getaddreLbyte(OneRegsiterLen);
            ReadPowerSWComand[4] = getaddreHbyte(PowerSwitchAddr);
            ReadPowerSWComand[5] = getaddreLbyte(PowerSwitchAddr);
            AddCRCToArrayLast(ReadPowerSWComand);


            byte[] ovpRdata = new byte[RBuffHeadLength + AddressLength + CRCLength];

            try
            {

                DeviceCtlStat ReadRegisterStat = ReadRegister(ReadPowerSWComand, ovpRdata, ovpRdata.Length);
                if (ReadRegisterStat != DeviceCtlStat.Success)
                {
                    return ReadRegisterStat;
                }
                byte addr = ovpRdata[0];
                byte fution = ovpRdata[1];
                //功能码是0X03才是要的数据
                if (fution == (byte)DeviceRWFunction.ReadMReg)
                {
                    //获取CRC的值，和计算的是否一样！
                    UInt16 vcrc = ByteToInt.bytesToUint16(ovpRdata, ovpRdata.Length - CRCLength);
                    UInt16 vcrcs = ModbusCRC.CRC16Calc(ovpRdata, ovpRdata.Length - CRCLength);
                    if (vcrc == vcrcs)
                    {
                        //有一次正确，错误次数清零
                        ErrorCount = 0;
                        //获得16位整数的各项值
                        rDeviceStat = ByteToInt.bytesToUint16(ovpRdata, RBuffHeadLength);


                    }
                }
                else
                {
                    this.WsComMutex.sMutexPort.DiscardInBuffer();
                    this.WsComMutex.sMutexPort.DiscardOutBuffer();
                    return DeviceCtlStat.DeviceReadError;
                }
                WriteWsLog.WriteWslogs("获得开关状态数据：" + System.BitConverter.ToString(ovpRdata));
                return DeviceCtlStat.Success;

            }
            catch (Exception ex)
            {
                WriteWsLog.WriteWslogs(ex.Message);
                return DeviceCtlStat.DeviceReadError;

            }


        }

        //软开关
        public DeviceCtlStat PowerOn()
        {
            WriteWsLog.WriteWslogs("开机 ");
            if (getDevicePowerStat() == DeviceCtlStat.DeviceReadError)
            {
                return DeviceCtlStat.DeviceReadError;
            }
            if (rDeviceStat == 0)
            {
                // WriteRegister(0, 1);
                if (WriteRegister(PowerSwitchAddr, (UInt16)StatON_OFF.ON) == DeviceCtlStat.Success)
                {
                    rDeviceStat = 1;
                    return DeviceCtlStat.Success;
                }
                else
                {
                    return DeviceCtlStat.DeviceWriteError;
                }
            }
            else if (rDeviceStat == 1)
            {
                return DeviceCtlStat.Success;

            }
            else
            {
                return DeviceCtlStat.DeviceReadError;
            }

        }
        //软关机
        public DeviceCtlStat PowerOFF()
        {

            if (getDevicePowerStat() == DeviceCtlStat.DeviceReadError)
            {
                return DeviceCtlStat.DeviceReadError;
            }
            if (rDeviceStat == 1)
            {
                if (WriteRegister(PowerSwitchAddr, (UInt16)StatON_OFF.OFF) == DeviceCtlStat.Success)
                {
                    rDeviceStat = 0;
                    return DeviceCtlStat.Success;
                }
                else
                {
                    return DeviceCtlStat.DeviceWriteError;
                }
            }
            else if (rDeviceStat == 0)
            {
                return DeviceCtlStat.Success;
            }
            else
            {
                return DeviceCtlStat.DeviceReadError;
            }
        }
        //读取机器的过压保护压
        public DeviceCtlStat getDeviceOVP_OCP_OPP()
        {
            WriteWsLog.WriteWslogs("获取过压保护 ");
            DeviceCtlStat getOVPOCPOPPStat = DeviceCtlStat.UnKnown;

            try
            {
                getOVPOCPOPPStat = ReadRegister(GetOCPSendCommand, GetOCPRecviByte, GetOCPRecviByte.Length);
                WriteWsLog.WriteWslogs("获得过压过流过功率数据，收到的数据是 " + System.BitConverter.ToString(GetOCPRecviByte));
                byte addr = GetOCPRecviByte[0];
                byte fution = GetOCPRecviByte[1];
                //功能码是0X03才是要的数据
                if (fution == (byte)DeviceRWFunction.ReadMReg)
                {
                    //获取CRC的值，和计算的是否一样！
                    WriteWsLog.WriteWslogs("获得过压过流过功率数据，收到的数据是 " + System.BitConverter.ToString(GetOCPRecviByte));
                    UInt16 vcrc = ByteToInt.bytesToUint16(GetOCPRecviByte, GetOCPRecviByte.Length - CRCLength);
                    UInt16 vcrcs = ModbusCRC.CRC16Calc(GetOCPRecviByte, GetOCPRecviByte.Length - CRCLength);
                    if (vcrc == vcrcs)
                    {
                        //有一次正确，错误次数清零
                        ErrorCount = 0;
                        //获得16位整数的各项值
                        rOVPVoltage = ByteToInt.bytesToUint16(GetOCPRecviByte, RBuffHeadLength) / VolMultTen;
                        rOCPCurrent = ByteToInt.bytesToUint16(GetOCPRecviByte, RBuffHeadLength + ProtectVolBytes) / CurrMultTen;
                        rOPPower = ByteToInt.bytesToUint32(GetOCPRecviByte, RBuffHeadLength + ProtectVolBytes + ProtectCurBytes) / PowMultTen;

                        WriteWsLog.WriteWslogs("过压 " + rOVPVoltage.ToString() + "过流：" + rOCPCurrent.ToString() + "过功率：" + rOPPower.ToString());
                        return DeviceCtlStat.Success;

                    }
                    else
                    {
                        return DeviceCtlStat.DeviceReadDataError;
                    }
                }
                else
                {
                    return DeviceCtlStat.DeviceReadDataError;
                }


            }
            catch (Exception ex)
            {
                WriteWsLog.WriteWslogs(ex.Message);
                return DeviceCtlStat.DeviceReadError;

            }

        }
        //设置设备过压保护值，返回零成功。非零失败
        public DeviceCtlStat setDeviceOVP()
        {
            if (this.ProtectVolBytes == DataBitLenth.DataBit16)
            {
                return WriteRegister(ProtectVolAddr, (UInt16)this.sOVPVoltage);
            }
            else
            {
                return WriteRegister(ProtectVolAddr, this.sOVPVoltage);
            }


        }
        //设置设备过流保护值，返回零成功。非零失败
        public DeviceCtlStat setDeviceOCP()
        {
            if (this.ProtectCurBytes == DataBitLenth.DataBit16)
            {
                return WriteRegister(ProtectCurAddr, (UInt16)this.sOCPCurrent);
            }
            else
            {
                return WriteRegister(ProtectCurAddr, this.sOCPCurrent);
            }
        }
        //设置设备过功率保护值，返回零成功。非零失败
       

    }
   
}
