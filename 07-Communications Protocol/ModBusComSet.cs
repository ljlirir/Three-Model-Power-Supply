using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace eTommensDC
{
    public class ModBusComInfo
    {
        public ModBusComInfo()
        {
        }
        //延迟时间
        public int DelayTime { get; set; }
        //是否只记录变化的值
        public bool recordChangeValue { get; set; }

        //设备名称
        private string wSname;
        public string WSname
        {
            get { return wSname; }
            set { wSname = value; }
        }
        //端口
        private string portName;
        public string PortName
        {
            get { return portName; }
            set { portName = value; }
        }
        //主机地
        /// <summary>
        /// 8位的硬件地址，16进制表示
        /// </summary>
        private byte hostAddress;
        public byte HostAddress
        {
            get { return hostAddress; }
            set { hostAddress = value; }
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
        //过压保护，过流保护，过功率保护
        public float protect_V { get; set; }
        public float protect_A { get; set; }
        public float protect_W { get; set; }
        public void AddXMLComNoteWSSetting(string SettingFilePath)
        {
            try
            {
                //string SettingFilePath = Application.StartupPath + "\\" + "WSComSet.XML";
                XmlDocument Settingdoc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;//忽略文档里面的注释
                XmlReader reader = XmlReader.Create(SettingFilePath, settings);
                Settingdoc.Load(reader);

                //  Settingdoc.Load(Application.StartupPath + "\\" + "WSSet.XML");
                XmlNode WSset = Settingdoc.SelectSingleNode("WSationSet");
                XmlElement modELement = Settingdoc.CreateElement("Sation");
                XmlAttribute modWSname = Settingdoc.CreateAttribute("WSname");
                modWSname.InnerText = this.wSname.ToString();
                XmlAttribute ComdelayTime = Settingdoc.CreateAttribute("ComDelayTime");
                ComdelayTime.InnerText = this.DelayTime.ToString();

                modELement.SetAttributeNode(modWSname);
                modELement.SetAttributeNode(ComdelayTime);

                XmlElement recordChangeValueElement = Settingdoc.CreateElement("RecordChangeValue");
                recordChangeValueElement.InnerText = this.recordChangeValue.ToString();
                modELement.AppendChild(recordChangeValueElement);

                XmlElement portNameElement = Settingdoc.CreateElement("PortName");
                portNameElement.InnerText = this.portName.ToString();
                modELement.AppendChild(portNameElement);
                XmlElement hostAddressElement = Settingdoc.CreateElement("HostAddress");
                hostAddressElement.InnerText = string.Format("{0:X00}", this.hostAddress);
                modELement.AppendChild(hostAddressElement);
                XmlElement sampRateElement = Settingdoc.CreateElement("SampRate");
                sampRateElement.InnerText = this.sampRate.ToString();
                modELement.AppendChild(sampRateElement);
                XmlElement baudRateElement = Settingdoc.CreateElement("BaudRate");
                baudRateElement.InnerText = this.baudRate.ToString();
                modELement.AppendChild(baudRateElement);
                WSset.AppendChild(modELement);
                XmlElement writeTimeOutElement = Settingdoc.CreateElement("WriteTimeOut");
                writeTimeOutElement.InnerText = this.writeTimeOut.ToString();
                modELement.AppendChild(writeTimeOutElement);
                XmlElement readTimeOutElement = Settingdoc.CreateElement("ReadTimeOut");
                readTimeOutElement.InnerText = this.readTimeOut.ToString();
                modELement.AppendChild(readTimeOutElement);
                XmlElement protectVElement = Settingdoc.CreateElement("Protect_V");
                protectVElement.InnerText = this.protect_V.ToString();
                modELement.AppendChild(protectVElement);
                XmlElement protectAElement = Settingdoc.CreateElement("Protect_A");
                protectAElement.InnerText = this.protect_A.ToString();
                modELement.AppendChild(protectAElement);
                XmlElement protectWElement = Settingdoc.CreateElement("Protect_W");
                protectWElement.InnerText = this.protect_W.ToString();
                modELement.AppendChild(protectWElement);

                WSset.AppendChild(modELement);
                reader.Close();
                Settingdoc.Save(SettingFilePath);


            }
            catch (XmlException ex)
            {
                MessageBox.Show("加载不成功，可能文件不存在！错误代码为：" + ex.Message);
            }

        }
        public static List<ThreeModeControlThread> readWSComSetting(string SettingFilePath)
        {
            XmlDocument Settingdoc = new XmlDocument();
            try
            {

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;//忽略文档里面的注释
                XmlReader reader = XmlReader.Create(SettingFilePath, settings);
                Settingdoc.Load(reader);

                //  Settingdoc.Load(Application.StartupPath + "\\" + "WSSet.XML");
                XmlNode WSset = Settingdoc.SelectSingleNode("WSationSet");

                XmlNodeList WSNodeList = WSset.ChildNodes;
                //List<ModBusComInfo> modBusSetList = new List<ModBusComInfo>();
                List<ThreeModeControlThread> ThreeModBusComInfoList = new List<ThreeModeControlThread>();
                //遍历WSationSet 下的所有子节点
                foreach (XmlNode indexXMLnode in WSNodeList)
                {
                    //方便读写创建的类
                    ThreeModeControlThread modBusSet = new ThreeModeControlThread();
                    XmlElement modELement = (XmlElement)indexXMLnode;
                    modBusSet.DelayTime = Convert.ToInt32(modELement.GetAttribute("ComDelayTime").ToString());
                    modBusSet.WSname = modELement.GetAttribute("WSname").ToString();
                    XmlNodeList Attrilist = modELement.ChildNodes;
                    foreach (XmlNode indexAttribNode in Attrilist)
                    {
                        if (indexAttribNode.Name == "PortName")
                        {

                            modBusSet.PortName = indexAttribNode.InnerText;
                        }
                        else if (indexAttribNode.Name == "RecordChangeValue")
                        {

                            modBusSet.recordChangeValue = Convert.ToBoolean(indexAttribNode.InnerText);
                        }
                        else if (indexAttribNode.Name == "HostAddress")
                        {
                            modBusSet.HostAddress = Convert.ToByte(indexAttribNode.InnerText, 16);
                        }
                        else if (indexAttribNode.Name == "SampRate")
                        {
                            modBusSet.SampRate = Convert.ToInt32(indexAttribNode.InnerText);
                        }
                        else if (indexAttribNode.Name == "BaudRate")
                        {
                            modBusSet.BaudRate = Convert.ToInt32(indexAttribNode.InnerText.Trim());
                        }
                        else if (indexAttribNode.Name == "WriteTimeOut")
                        {
                            if (indexAttribNode.InnerText.Trim() != "")
                                modBusSet.WriteTimeOut = Convert.ToInt32(indexAttribNode.InnerText);
                        }
                        else if (indexAttribNode.Name == "ReadTimeOut")
                        {
                            if (indexAttribNode.InnerText.Trim() != "")
                                modBusSet.ReadTimeOut = Convert.ToInt32(indexAttribNode.InnerText);
                        }
                        else if (indexAttribNode.Name == "Protect_V")
                        {
                            if (indexAttribNode.InnerText.Trim() != "")
                                modBusSet.protect_V = Convert.ToSingle(indexAttribNode.InnerText);
                        }
                        else if (indexAttribNode.Name == "Protect_A")
                        {
                            if (indexAttribNode.InnerText.Trim() != "")
                                modBusSet.protect_A = Convert.ToSingle(indexAttribNode.InnerText);
                        }
                        else if (indexAttribNode.Name == "Protect_W")
                        {
                            if (indexAttribNode.InnerText.Trim() != "")
                                modBusSet.protect_W = Convert.ToSingle(indexAttribNode.InnerText);
                        }
                    }
                    ThreeModBusComInfoList.Add(modBusSet);
                }
                reader.Close();

                return ThreeModBusComInfoList;

            }
            catch (XmlException ex)
            {
                MessageBox.Show("加载不成功，可能文件不存在！错误代码为：" + ex.Message);
                return null;

            }

        }
        public static void DelNoteWSSetting(string SettingFilePath, string keyString)
        {
            try
            {

                XmlDocument Settingdoc = new XmlDocument();
                XmlElement DelNodeELement = findNodeSation(keyString, Settingdoc, SettingFilePath);
                if (DelNodeELement != null)
                { DelNodeELement.ParentNode.RemoveChild(DelNodeELement); }
                Settingdoc.Save(SettingFilePath);
            }
            catch (XmlException ex)
            {
                MessageBox.Show("加载不成功，可能文件不存在！错误代码为：" + ex.Message);
            }

        }





        private static XmlElement findNodeSation(string iDStr, XmlDocument settingdoc, string filespath)
        {


            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释
            XmlReader reader = XmlReader.Create(filespath, settings);
            settingdoc.Load(reader);
            XmlElement WSELement = settingdoc.DocumentElement;
            string strPath = string.Format("/WSationSet/Sation[@WSname=\"{0}\"]", iDStr);

            XmlElement SelectXMLEL = (XmlElement)WSELement.SelectSingleNode(strPath);
            reader.Close();
            return SelectXMLEL;
        }
        public void ChangeNoteStation(string filespath)
        {

            try
            {

                XmlDocument Settingdoc = new XmlDocument();
                XmlElement chNodeELement = findNodeSation(this.wSname, Settingdoc, filespath);
                if (chNodeELement != null)
                {

                    chNodeELement.SetAttribute("ComDelayTime", this.DelayTime.ToString());
                    chNodeELement.SetAttribute("WSname", this.wSname);

                    XmlNodeList Attrilist = chNodeELement.ChildNodes;
                    foreach (XmlNode indexAttribNode in Attrilist)
                    {
                        if (indexAttribNode.Name == "PortName")
                        {

                            indexAttribNode.InnerText = this.portName;
                        }
                        else if (indexAttribNode.Name == "RecordChangeValue")
                        {

                            indexAttribNode.InnerText = recordChangeValue.ToString();
                        }
                        else if (indexAttribNode.Name == "HostAddress")
                        {
                            indexAttribNode.InnerText = string.Format("{0:X00}", this.hostAddress);
                        }
                        else if (indexAttribNode.Name == "SampRate")
                        {
                            indexAttribNode.InnerText = this.sampRate.ToString(); ;
                        }
                        else if (indexAttribNode.Name == "BaudRate")
                        {
                            indexAttribNode.InnerText = BaudRate.ToString();
                        }
                        else if (indexAttribNode.Name == "WriteTimeOut")
                        {

                            indexAttribNode.InnerText = this.writeTimeOut.ToString();
                        }
                        else if (indexAttribNode.Name == "ReadTimeOut")
                        {

                            indexAttribNode.InnerText = readTimeOut.ToString(); ;
                        }
                        else if (indexAttribNode.Name == "Protect_V")
                        {

                            indexAttribNode.InnerText = protect_V.ToString(); ;
                        }
                        else if (indexAttribNode.Name == "Protect_A")
                        {
                            indexAttribNode.InnerText = protect_A.ToString();
                        }
                        else if (indexAttribNode.Name == "Protect_W")
                        {

                            indexAttribNode.InnerText = protect_W.ToString();
                        }


                        Settingdoc.Save(filespath);
                    }
                }



            }
            catch (Exception ex)
            {
                WriteWsLog.WriteWslogs(ex.Message);
            }

        }
    }
}
