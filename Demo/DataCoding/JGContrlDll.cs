using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ETCF
{
    class JGContrlDll
    {
        [DllImport("WJLaser.dll", EntryPoint = "JG_NETINIT", CallingConvention = CallingConvention.StdCall)]
        public static extern int JG_NETINIT(JGCallBackDelegate pfunc, byte[] ipaddr, int port);


        [DllImport("WJLaser.dll", EntryPoint = "JG_PARAMETERINIT", CallingConvention = CallingConvention.StdCall)]
        public static extern int JG_PARAMETERINIT(byte[] para);


        [DllImport("WJLaser.dll", EntryPoint = "JG_GETPARAMETER", CallingConvention = CallingConvention.StdCall)]
        public static extern int JG_GETPARAMETER(ref byte para);


        [DllImport("WJLaser.dll", EntryPoint = "JG_STARTCAPTUREWAVE", CallingConvention = CallingConvention.StdCall)]
        public static extern int JG_STARTCAPTUREWAVE();



        [DllImport("WJLaser.dll", EntryPoint = "JG_STOPCAPTUREWAVE", CallingConvention = CallingConvention.StdCall)]
        public static extern int JG_STOPCAPTUREWAVE();



        [DllImport("WJLaser.dll", EntryPoint = "JG_ACQUREPOSITION", CallingConvention = CallingConvention.StdCall)]
        public static extern int JG_ACQUREPOSITION(ref byte position, ref int len);


        [DllImport("WJLaser.dll", EntryPoint = "JG_GETDATA", CallingConvention = CallingConvention.StdCall)]
        public static extern int JG_GETDATA(ref byte position, int len);

        public delegate int JGCallBackDelegate(int type, IntPtr data, int len);

        public JGCallBackDelegate pLaserCallBack;

        public int Initialize(byte[] ipaddr, int port)
        {
            int val;

            val = JG_NETINIT(pLaserCallBack, ipaddr, port);
            return val;
        }


        public int SetParameter(byte[] param)
        {
            int val;
            val = JG_PARAMETERINIT(param);
            return val;
        }

        public int GetParameter(byte[] param)
        {
            int val;
            val = JG_GETPARAMETER(ref param[0]);
            return val;
        }

        public int StartCaptureWave()
        {
            int val;
            val = JG_STARTCAPTUREWAVE();
            return val;

        }

        public int StopCaptureWave()
        {
            int val;
            val = JG_STOPCAPTUREWAVE();
            return val;

        }

        public int AcqurePosition(byte[] position, int len)
        {
            int val;
            val = JG_ACQUREPOSITION(ref position[0], ref len);
            return val;

        }
    }
}
