using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System;

namespace eTommensDC
{
    //全局变量存放处

    public enum DeviceCtlStat
    {
        Success = 0,
        //读错误
        DeviceReadError = 1,
        //写错误
        DeviceWriteError = 2,
        //打开串口错误
        DeviceOpenComError = 3,
        //接收 数据错误
        DeviceReadDataError = 4,

        //
        UnKnown = 5,
    }
    public enum DeviceStat
    {
        UnKnown = 1,
        Initialized = 2,
        Running = 4,

        lineError = 8,


    }

    public enum DeviceRWFunction : byte
    {
        ReadMReg = 0x03,//读多路寄存器
        WriteSReg = 0x06,//写单路寄存器
        WriteMReg = 0x10,//写多路寄存器

    }
    public enum StatON_OFF
    {
        ON = 0x01,
        OFF = 0x00,
        UnKnown = 0x02,
    }
    public enum StatVCPPretect
    {
        ON = 0x01,
        OFF = 0x02,
    }
    public class ByteToInt
    {
        public static Int16 bytesToInt16(byte[] src, int offset)
        {
            Int16 value;
            value = (Int16)(((src[offset] & 0xFF) << 8)
                        | (src[offset + 1] & 0xFF));

            return value;
        }
        public static UInt16 bytesToUint16(byte[] src, int offset)
        {
            UInt16 value;
            value = (UInt16)(((src[offset] & 0xFF) << 8)
                        | (src[offset + 1] & 0xFF));

            return value;

        }
        public static UInt32 bytesToUint32(byte[] src, int offset)
        {
            UInt32 value;
            value = (UInt32)(((src[offset] & 0xFF) << 24) | ((src[offset + 1] & 0xFF) << 16) |
                        ((src[offset + 2] & 0xFF) << 8) | (src[offset + 3] & 0xFF));

            return value;

        }

    }
    //获得16位 字位Byte

    //每一个串口不能同时发送访问数据，多线程分开来访问。。
    public class MutexSerialPort : IDisposable
    {
        // 静态列表改为 private，通过方法控制访问
        private static readonly List<MutexSerialPort> _listMutexSerialPort = new List<MutexSerialPort>();

        // 互斥锁设为 private，禁止外部操作
        private readonly Mutex _sMutex = new Mutex();

        // 串口对象设为 private，通过方法暴露必要功能
        private readonly SerialPort _sMutexPort;

        // 端口名称字段
        private readonly string _portName;

        public MutexSerialPort(string portName)
        {
            _portName = portName;
            _sMutexPort = new SerialPort 
            { 
                PortName = portName
            };

            // 将当前实例加入列表
            _listMutexSerialPort.Add(this);
        }

        // 提供公共方法访问串口（带锁控制）
        public void SendData(byte[] data)
        {
            try
            {
                _sMutex.WaitOne();
                if (!_sMutexPort.IsOpen)
                    _sMutexPort.Open();

                _sMutexPort.Write(data, 0, data.Length);
            }
            finally
            {
                _sMutex.ReleaseMutex();
            }
        }

        // 实现 IDisposable 释放资源
        public void Dispose()
        {
            _sMutex?.Dispose();
            _sMutexPort?.Close();
            _listMutexSerialPort.Remove(this);
        }
    }

   
    }
