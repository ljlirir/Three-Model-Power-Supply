using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace eTommensDC
{
    internal class WSDataBaseContol
    {
        public enum MaxVCP
        {
            MaxVoltage = 0,
            MaxCurrent = 1,
            MaxPower = 2,
        };
        //数据位数长度
        public class DataBitLenth
        {
            public static UInt16 DataBit16 = 2;
            public static UInt16 DataBit32 = 4;
            public static UInt16 DataBit64 = 8;
        };

        /// <summary>
        ///     数据库控制类，用于数据库的连接，写入等操作
        /// </summary>
        public class WSDatabaseContol
        {
            public static void Create()
            {

                string dbPath = "data.db3"; // 数据库文件路径
                // 创建或打开数据库连接
                using (SQLiteConnection wSDBConnection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    wSDBConnection.Open();
                    // 创建表的SQL语句
                    string createTableSql = @"
                CREATE TABLE IF NOT EXISTS ElectValue (
                    nName TEXT,
                    nChannels TEXT,
                    nVoltage REAL,
                    nCurrent REAL,
                    nPower REAL,
                    nSampTime REAL,
                    nPort TEXT,
                    nMAddress INTEGER
                );";
                    // 使用SQLiteCommand执行SQL语句
                    using (SQLiteCommand cmd = new SQLiteCommand(createTableSql, wSDBConnection))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("表Devices已成功创建！");
                    }
                    wSDBConnection.Close();

                }

            }


            //WSDatabaseContol wSDatabaseContol = new WSDatabaseContol();
            public static SQLiteConnection wSDBConnection = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "DataBase\\TMData.db3;Version=3;");
            //public static SQLiteConnection wSDBConnection = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "DataBase\\ThreeData.db3;Version=3;");

            private static SQLiteDataAdapter wreadSQLdataAdpter = new SQLiteDataAdapter();
            private static object wslock = new object();//数据库锁
                                                        // private static object WlockRead = new object();//读锁，主要用于mysqldatareader
                                                        // private static ConnectionState state;





            public static void WriteSQLWSCollect(string nMname, float nVoltage, float nCurrent, float nPower, DateTime nSampTime, string nPort, int nMddress)
            {
                //写之前先锁住，防止多个线程同时写数据库

                lock (wslock)
                {
                    //  try
                    //    { 

                    //判
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();

                    SQLiteCommand wWrCollecteddata = wSDBConnection.CreateCommand();

                    //往数据库中插入一条数据
                    wWrCollecteddata.CommandText = "insert into  ElectValue (Mname,Voltage,Current,Power,SampTime,Port,MAddress)" +
                                          "values(@nMname,@nVoltage,@nCurrent,@nPower,@nSampTime,@nPort,@nMddress)";
                    wWrCollecteddata.Parameters.Clear();
                    wWrCollecteddata.Parameters.AddWithValue("@nMname", nMname);
                    wWrCollecteddata.Parameters.AddWithValue("@nVoltage", nVoltage);
                    wWrCollecteddata.Parameters.AddWithValue("@nCurrent", nCurrent);
                    wWrCollecteddata.Parameters.AddWithValue("@nPower", nPower);
                    wWrCollecteddata.Parameters.AddWithValue("@nSampTime", nSampTime);
                    wWrCollecteddata.Parameters.AddWithValue("@nPort", nPort);
                    wWrCollecteddata.Parameters.AddWithValue("@nMddress", nMddress);
                    ;
                    wWrCollecteddata.ExecuteNonQuery();

                    //   }
                    //   catch(Exception EX)
                    //   {

                    //      MESSAGE
                    //   }
                }
            }
            public static void Open()
            {


                if (wSDBConnection.State != ConnectionState.Open)
                {
                    wSDBConnection.Open();
                }

            }
            public static void Close()
            {
                lock (wslock)
                {
                    wSDBConnection.Close();
                }
            }
            public static ConnectionState State { get { return wSDBConnection.State; } }





            public static void WriteSQLWSCollectAll(string nMname, float nVoltage1, float nCurrent1, float nVoltage2, float nCurrent2, float nVoltage3, float nCurrent3, DateTime nSampTime, string nPort, int nMAddress)
            {
                //写之前先锁住，防止多个线程同时写数据库

                lock (wslock)
                {
                    //  try
                    //    { 

                    //判
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();

                    //string createTableSql = @"
                    //CREATE TABLE IF NOT EXISTS ElectValue (
                    //    nName TEXT,
                    //    nChannels TEXT,
                    //    nVoltage REAL,
                    //    nCurrent REAL,
                    //    nPower REAL,
                    //    nSampTime REAL,
                    //    nPort TEXT,
                    //    nMAddress INTEGER
                    //);";
                    SQLiteCommand wWrCollecteddata = wSDBConnection.CreateCommand();
                    //string sql_creatTable = "CREATE TABLE  if not exists "
                    //                        + " 三通道数据库 "
                    //                        + "( id INT, Mname TEXT,Channels TEXT, Voltage NUM, Current NUM, Power NUM, SampTime NUM, Port TEXT, MAddress INT)";
                    //wWrCollecteddata.CommandText = sql_creatTable;
                    //wWrCollecteddata.ExecuteNonQuery();
                    //wWrCollecteddata.CommandText = "CREATE TABLE if not exists"+"三通道数据库"+"(id)";

                    //using (var command = new SQLiteCommand(createTableSql, connection))
                    //SQLiteCommand cmd = new SQLiteCommand(createTableSql, wSDBConnection);
                    //往数据库中插入一条数据
                    wWrCollecteddata.CommandText = "insert into  ElectValue (Mname,Voltage1,Current1,Voltage2,Current2,Voltage3,Current3,SampTime,Port,MAddress)" +
                                          "values(@nMname,@nVoltage1,@nCurrent1,@nVoltage2,@nCurrent2,@nVoltage3,@nCurrent3,@nSampTime,@nPort,@nMAddress)";
                    wWrCollecteddata.Parameters.Clear();

                    wWrCollecteddata.Parameters.AddWithValue("@nMname", nMname);

                    wWrCollecteddata.Parameters.AddWithValue("@nVoltage1", nVoltage1);
                    wWrCollecteddata.Parameters.AddWithValue("@nCurrent1", nCurrent1);

                    wWrCollecteddata.Parameters.AddWithValue("@nVoltage2", nVoltage2);
                    wWrCollecteddata.Parameters.AddWithValue("@nCurrent2", nCurrent2);

                    wWrCollecteddata.Parameters.AddWithValue("@nVoltage3", nVoltage3);
                    wWrCollecteddata.Parameters.AddWithValue("@nCurrent3", nCurrent3);
                    //wWrCollecteddata.Parameters.AddWithValue("@nPower", nPower);
                    wWrCollecteddata.Parameters.AddWithValue("@nSampTime", nSampTime);
                    wWrCollecteddata.Parameters.AddWithValue("@nPort", nPort);
                    wWrCollecteddata.Parameters.AddWithValue("@nMAddress", nMAddress);
                    //wWrCollecteddata.Parameters.AddWithValue("@nPower", nPower);



                    wWrCollecteddata.ExecuteNonQuery();
                    Console.WriteLine("表ElectValue已成功创建！");

                    //   }
                    //   catch(Exception EX)
                    //   {

                    //      MESSAGE
                    //   }
                }
            }
            public static List<string> GetMname()
            {
                lock (wslock)
                {
                    List<string> MnameList = new List<string>();
                    try
                    {

                        if (wSDBConnection.State != ConnectionState.Open)
                            wSDBConnection.Open();

                        SQLiteCommand getNameDataComnd = wSDBConnection.CreateCommand();

                        getNameDataComnd.CommandText = "select distinct(Mname) from  ElectValue";
                        SQLiteDataReader getNameDataReader = getNameDataComnd.ExecuteReader();
                        while (getNameDataReader.Read())
                        {
                            MnameList.Add(getNameDataReader["Mname"].ToString());
                        }

                        return MnameList;

                    }
                    catch
                    {
                        return MnameList;
                    }

                }
            }
            /// <summary>
            ///根据设备名称，获得数据
            /// </summary>
            /// <param name="nWSname"></param>
            /// <returns></returns>
            //-------------------------------------------------------------------------------------------------------------------
            public static DataTable GetAllDatabyDeviceName(string nMname, DataTable nChartDataTable)
            {

                lock (wslock)
                {
                    try
                    {

                        if (wSDBConnection.State != ConnectionState.Open)
                            wSDBConnection.Open();

                        SQLiteCommand todayDataComnd = wSDBConnection.CreateCommand();
                        if (nMname == "")
                        {

                            todayDataComnd.CommandText = "select * from  ElectValue  order by SampTime asc";
                        }
                        else
                        {
                            todayDataComnd.CommandText = "select * from ElectValue where Mname=@nMname  order by SampTime asc";
                            todayDataComnd.Parameters.Clear();
                            todayDataComnd.Parameters.AddWithValue("@nMname", nMname);
                        }
                        SQLiteDataAdapter todayDataAdapter = new SQLiteDataAdapter();
                        todayDataAdapter.SelectCommand = todayDataComnd;
                        nChartDataTable.Clear();
                        todayDataAdapter.Fill(nChartDataTable);
                        return nChartDataTable;
                    }
                    catch
                    {
                        return nChartDataTable;//如果出错，依然是空的。。
                    }

                }
            }
            //------------------------------------------------------------------------------------------------------------------------
            //什么时间到什么时间的记录
            public static void GetDataHistoryByDeviceName(DateTime nBeginDate, DateTime nLastDate, string nWSname, DataTable inGetDataHistoryDataTable)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();//连接判断

                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();//创建数据库
                    DataTable getDataHistoryDataTable = inGetDataHistoryDataTable;//最后存到这个里面去
                    getDataHistoryDataTable.Clear();
                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();

                    DateTime tempBeginDate = new DateTime();//开始时间
                    tempBeginDate = nBeginDate;
                    DateTime tempLastDate = new DateTime();//结束时间
                    tempLastDate = nLastDate;
                    getDataCommand.CommandText = "select *from  ElectValue where SampTime>@cltime and SampTime<@lasttime and Mname=@nMname  ";
                    getDataCommand.Parameters.Clear();
                    getDataCommand.Parameters.AddWithValue("@cltime", tempBeginDate);
                    getDataCommand.Parameters.AddWithValue("@lasttime", tempLastDate);
                    getDataCommand.Parameters.AddWithValue("@nMname", nWSname);
                    getDataHistorysDataAdpeter.SelectCommand = getDataCommand;
                    getDataHistorysDataAdpeter.Fill(getDataHistoryDataTable);

                }


            }
            //
            public static void GetDataHistoryByDeviceName(DateTime nBeginDate, DateTime nLastDate, DataTable inGetDataHistoryDataTable)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();
                    DataTable getDataHistoryDataTable = inGetDataHistoryDataTable;
                    getDataHistoryDataTable.Clear();
                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();

                    DateTime tempBeginDate = new DateTime();
                    tempBeginDate = nBeginDate;
                    DateTime tempLastDate = new DateTime();
                    tempLastDate = nLastDate;
                    getDataCommand.CommandText = "select *from  ElectValue where SampTime>@cltime and SampTime<@lasttime  ";
                    getDataCommand.Parameters.Clear();
                    getDataCommand.Parameters.AddWithValue("@cltime", tempBeginDate);
                    getDataCommand.Parameters.AddWithValue("@lasttime", tempLastDate);

                    getDataHistorysDataAdpeter.SelectCommand = getDataCommand;
                    getDataHistorysDataAdpeter.Fill(getDataHistoryDataTable);

                }


            }
            public static void GetDataHistoryByDeviceName(DateTime nBeginDate, DateTime nLastDate, string nWSname, MaxVCP nMaxVCP, DataTable inGetDataHistoryDataTable)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();
                    DataTable getDataHistoryDataTable = inGetDataHistoryDataTable;
                    getDataHistoryDataTable.Clear();
                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();

                    DateTime tempBeginDate = new DateTime();
                    tempBeginDate = nBeginDate;
                    DateTime tempLastDate = new DateTime();
                    tempLastDate = nLastDate;
                    if (nMaxVCP == MaxVCP.MaxVoltage)
                    {
                        getDataCommand.CommandText = "select *from  ElectValue where SampTime>@cltime and SampTime<@lasttime and Mname=@nMname and Voltage=Max(Voltage)  ";
                    }
                    getDataCommand.Parameters.Clear();
                    getDataCommand.Parameters.AddWithValue("@cltime", tempBeginDate);
                    getDataCommand.Parameters.AddWithValue("@lasttime", tempLastDate);
                    getDataCommand.Parameters.AddWithValue("@nMname", nWSname);
                    getDataHistorysDataAdpeter.SelectCommand = getDataCommand;
                    getDataHistorysDataAdpeter.Fill(getDataHistoryDataTable);

                }


            }

            //取最后几条记录       
            public static void GetDataHistoryByDeviceName(string nWSname, int lastNum, DataTable inGetDataHistoryDataTable)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();
                    DataTable getDataHistoryDataTable = inGetDataHistoryDataTable;
                    getDataHistoryDataTable.Clear();
                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();

                    getDataCommand.CommandText = "select *from  ElectValue where   Mname=@nMname  order by id  desc limit " +
                                                 lastNum.ToString() + " offset 0";
                    getDataCommand.Parameters.Clear();
                    getDataCommand.Parameters.AddWithValue("@nMname", nWSname);
                    getDataHistorysDataAdpeter.SelectCommand = getDataCommand;
                    getDataHistorysDataAdpeter.Fill(getDataHistoryDataTable);

                }


            }

            public static void GetDataHistoryByDeviceName(DateTime nbegindate, string nWSname, int lastNum, DataTable inGetDataHistoryDataTable)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();
                    DataTable getDataHistoryDataTable = inGetDataHistoryDataTable;
                    getDataHistoryDataTable.Clear();
                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();

                    getDataCommand.CommandText = "select *from  ElectValue where   Mname=@nMname and SampTime>=@nbegindate  order by id  desc limit " +
                                                 lastNum.ToString() + " offset 0";
                    getDataCommand.Parameters.Clear();
                    getDataCommand.Parameters.AddWithValue("@nMname", nWSname);
                    getDataCommand.Parameters.AddWithValue("@nbegindate", nbegindate);
                    getDataHistorysDataAdpeter.SelectCommand = getDataCommand;
                    getDataHistorysDataAdpeter.Fill(getDataHistoryDataTable);

                }


            }
            //之前什么时候开始到现在的
            public static void GetDataHistoryByDeviceName(DateTime nBeginDate, string nWSname, DataTable inGetDataHistoryDataTable)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();
                    DataTable getDataHistoryDataTable = inGetDataHistoryDataTable;
                    getDataHistoryDataTable.Clear();
                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();

                    DateTime tempBeginDate = new DateTime();
                    tempBeginDate = nBeginDate;

                    getDataCommand.CommandText = "select *from  ElectValue where SampTime>@cltime  and  Mname=@nMname  ";
                    getDataCommand.Parameters.Clear();
                    getDataCommand.Parameters.AddWithValue("@cltime", tempBeginDate);

                    getDataCommand.Parameters.AddWithValue("@nMname", nWSname);
                    getDataHistorysDataAdpeter.SelectCommand = getDataCommand;
                    getDataHistorysDataAdpeter.Fill(getDataHistoryDataTable);

                }


            }


            ///////////////////////////////////////////////////////////////////////////////
            public static void GetDataHistoryByDeviceName(DataTable inGetDataHistoryDataTable)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();//数据库
                    DataTable getDataHistoryDataTable = inGetDataHistoryDataTable;
                    getDataHistoryDataTable.Clear();
                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();



                    getDataCommand.CommandText = "select *from  ElectValue  ";
                    getDataCommand.Parameters.Clear();

                    getDataHistorysDataAdpeter.SelectCommand = getDataCommand;
                    getDataHistorysDataAdpeter.Fill(getDataHistoryDataTable);

                }
            }
            ////获取所有已经采到数据的站点的最近一条记录
            //--------------------------------------------------------------------------------------------------
            public static DataTable GetLateData(DataTable inGetDataHistoryDataTable)
            {

                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();
                    DataTable getDataHistoryDataTable = inGetDataHistoryDataTable;
                    getDataHistoryDataTable.Clear();
                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();

                    getDataCommand.CommandText = " select * from  ElectValue where id in (select MAX(id) FROM  ElectValue GROUP BY Mname)";
                    //"select WSname,TempT,Humidity,Radiation,WindSpeed,WindDirection,WindDirectCode," +
                    //                          "MAX(CollectionTime) as CollectionTime  from `" + wTableName + "` GROUP BY WSname ";

                    getDataHistorysDataAdpeter.SelectCommand = getDataCommand;
                    getDataHistorysDataAdpeter.Fill(getDataHistoryDataTable);
                    return getDataHistoryDataTable;
                }

            }
            //取得指定站点的最近一条记录
            public static DataTable GetLateDatabyWSname(string nWSname, DataTable inGetDataHistoryDataTable)
            {

                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();
                    DataTable getDataHistoryDataTable = inGetDataHistoryDataTable;
                    getDataHistoryDataTable.Clear();
                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();
                    getDataCommand.CommandText = "select  *  from  ElectValue  where WSname=@WSname and id=MAX(id) ";

                    getDataCommand.Parameters.Clear();
                    getDataCommand.Parameters.AddWithValue("@WSname", nWSname);
                    getDataHistorysDataAdpeter.SelectCommand = getDataCommand;

                    getDataHistorysDataAdpeter.Fill(getDataHistoryDataTable);
                    return getDataHistoryDataTable;
                }


            }

            //--------------------------------------------------------------
            //////////////////////////////

            public static void GetDataHistoryByMaxValue(DateTime nBeginDate, DateTime nLastDate, DataTable inGetDataHistoryDataTable)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();
                    DataTable getDataHistoryDataTable = inGetDataHistoryDataTable;
                    getDataHistoryDataTable.Clear();
                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();

                    DateTime tempBeginDate = new DateTime();
                    tempBeginDate = nBeginDate;
                    DateTime tempLastDate = new DateTime();
                    tempLastDate = nLastDate;
                    getDataCommand.CommandText = "select *from  ElectValue where SampTime>@cltime and SampTime<@lasttime  ";
                    getDataCommand.Parameters.Clear();
                    getDataCommand.Parameters.AddWithValue("@cltime", tempBeginDate);
                    getDataCommand.Parameters.AddWithValue("@lasttime", tempLastDate);

                    getDataHistorysDataAdpeter.SelectCommand = getDataCommand;
                    getDataHistorysDataAdpeter.Fill(getDataHistoryDataTable);

                }


            }



            //------------------------------------------------------------------
            public static void DelDataHistoryByDeviceName(DateTime nBeginDate, DateTime nLastDate, string nWSname)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();

                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();

                    DateTime tempBeginDate = new DateTime();
                    tempBeginDate = nBeginDate;
                    DateTime tempLastDate = new DateTime();
                    tempLastDate = nLastDate;
                    getDataCommand.CommandText = "delete *from  ElectValue where SampTime>@cltime and SampTime<@lasttime and Mname=@nMname  ";
                    getDataCommand.Parameters.Clear();
                    getDataCommand.Parameters.AddWithValue("@cltime", tempBeginDate);
                    getDataCommand.Parameters.AddWithValue("@lasttime", tempLastDate);
                    getDataCommand.Parameters.AddWithValue("@nMname", nWSname);
                    getDataCommand.ExecuteNonQuery();

                }


            }
            //按照时间删除
            public static void DelDataHistoryByDateTime(DateTime nBeginDate, DateTime nLastDate)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();

                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();

                    DateTime tempBeginDate = new DateTime();
                    tempBeginDate = nBeginDate;
                    DateTime tempLastDate = new DateTime();
                    tempLastDate = nLastDate;
                    getDataCommand.CommandText = "delete *from  ElectValue where SampTime>@cltime and SampTime<@lasttime  ";
                    getDataCommand.Parameters.Clear();
                    getDataCommand.Parameters.AddWithValue("@cltime", tempBeginDate);
                    getDataCommand.Parameters.AddWithValue("@lasttime", tempLastDate);

                    getDataCommand.ExecuteNonQuery();


                }


            }
            public static void DelDataHistoryByDateTime(DateTime preBeginDate)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();

                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();

                    DateTime tempBeginDate = new DateTime();
                    tempBeginDate = preBeginDate;

                    getDataCommand.CommandText = "delete from  ElectValue where SampTime<@preBeginDate  ";
                    getDataCommand.Parameters.Clear();
                    getDataCommand.Parameters.AddWithValue("@preBeginDate", tempBeginDate);


                    getDataCommand.ExecuteNonQuery();


                }


            }
            public static void DelDataHistoryByID(int nID)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();

                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();


                    getDataCommand.CommandText = "delete from  ElectValue where id=@nID ";
                    getDataCommand.Parameters.Clear();
                    getDataCommand.Parameters.AddWithValue("@nID", nID);

                    getDataCommand.ExecuteNonQuery();

                }


            }
            public static void DelDataHistoryByID(int begID, int endID)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();

                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();


                    getDataCommand.CommandText = "delete from  ElectValue where id>=@nbegID and id<=@nEndID";
                    getDataCommand.Parameters.Clear();
                    getDataCommand.Parameters.AddWithValue("@nID", begID);
                    getDataCommand.Parameters.AddWithValue("@nEndID", endID);
                    getDataCommand.ExecuteNonQuery();

                }


            }
            public static void DelDataHistoryByID(int begID, int endID, string nWSname)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();

                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();


                    getDataCommand.CommandText = "delete from  ElectValue where id>=@nbegID and id<=@nEndID and  and Mname=@nMname";
                    getDataCommand.Parameters.Clear();
                    getDataCommand.Parameters.AddWithValue("@nID", begID);
                    getDataCommand.Parameters.AddWithValue("@nEndID", endID);
                    getDataCommand.Parameters.AddWithValue("@nMname", nWSname);
                    getDataCommand.ExecuteNonQuery();

                }


            }
            //-----------------------------------------------------------------------------------------

            public static void SelectdisDeviceName(DataTable MyDeviceDataTable)
            {
                lock (wslock)
                {
                    if (wSDBConnection.State != ConnectionState.Open)
                        wSDBConnection.Open();
                    SQLiteDataAdapter getDataHistorysDataAdpeter = new SQLiteDataAdapter();
                    DataTable getDeviceNameataTable = MyDeviceDataTable;
                    getDeviceNameataTable.Clear();
                    SQLiteCommand getDataCommand = wSDBConnection.CreateCommand();
                    getDataCommand.CommandText = "select distinct(Mname) as Mname  from  ElectValue  ";
                    getDataCommand.Parameters.Clear();

                    getDataHistorysDataAdpeter.SelectCommand = getDataCommand;
                    getDataHistorysDataAdpeter.Fill(getDeviceNameataTable);

                }


            }
            /// <summary>
            /// 封装了一个按钮，点击他来生成一个数据库，调试用，按钮名自己设定
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void button1_Click(object sender, EventArgs e)
            {

                string dbPath = "DataBase\\TMData.db3;"; // 指定数据库文件路径


                using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))

                {

                    connection.Open();


                    // 创建ElectValue表

                    //INTEGER PRIMARY KEY AUTOINCREMENT表示按照升序自动增加
                    //TIMESTAMP DEFAULT CURRENT_TIMESTAMP  表示自动记录时间
                    string createTableSql = @"

                CREATE TABLE IF NOT EXISTS ElectValue (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,

                    Mname TEXT,

                    Channels TEXT,

                    Voltage REAL,

                    Current REAL,

                    SampTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

                    Port TEXT,

                    MAddress INTEGER

                );";


                    using (var command = new SQLiteCommand(createTableSql, connection))

                    {

                        command.ExecuteNonQuery();


                        Console.WriteLine("ElectValue表已成功创建。");
                        MessageBox.Show("ElectValue表已成功创建。");

                    }


                }
            }
        }
    }
}
