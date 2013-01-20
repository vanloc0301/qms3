﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace CarReader.Classes
{
    public class CommPort
    {
        public int PortNum;
        public int BaudRate;
        public byte ByteSize;
        public byte Parity; // 0-4=no,odd,even,mark,space
        public byte StopBits; // 0,1,2 = 1, 1.5, 2
        public int ReadTimeout;

        //comm port win32 file handle
        private int hComm = -1;

        public bool Opened = false;

        //win32 api constants
        private const uint GENERIC_READ = 0x80000000;
        private const uint GENERIC_WRITE = 0x40000000;
        private const int OPEN_EXISTING = 3;
        private const int INVALID_HANDLE_VALUE = -1;

        [StructLayout(LayoutKind.Sequential)]
        public struct DCB
        {
            //taken from c struct in platform sdk
            public int DCBlength; // sizeof(DCB)
            public int BaudRate; // current baud rate
            /* these are the c struct bit fields, bit twiddle flag to set
            public int fBinary; // binary mode, no EOF check
            public int fParity; // enable parity checking
            public int fOutxCtsFlow; // CTS output flow control
            public int fOutxDsrFlow; // DSR output flow control
            public int fDtrControl; // DTR flow control type
            public int fDsrSensitivity; // DSR sensitivity
            public int fTXContinueOnXoff; // XOFF continues Tx
            public int fOutX; // XON/XOFF out flow control
            public int fInX; // XON/XOFF in flow control
            public int fErrorChar; // enable error replacement
            public int fNull; // enable null stripping
            public int fRtsControl; // RTS flow control
            public int fAbortOnError; // abort on error
            public int fDummy2; // reserved
            */
            public uint flags;
            public ushort wReserved; // not currently used
            public ushort XonLim; // transmit XON threshold
            public ushort XoffLim; // transmit XOFF threshold
            public byte ByteSize; // number of bits/byte, 4-8
            public byte Parity; // 0-4=no,odd,even,mark,space
            public byte StopBits; // 0,1,2 = 1, 1.5, 2
            public char XonChar; // Tx and Rx XON character
            public char XoffChar; // Tx and Rx XOFF character
            public char ErrorChar; // error replacement character
            public char EofChar; // end of input character
            public char EvtChar; // received event character
            public ushort wReserved1; // reserved; do not use
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct COMMTIMEOUTS
        {
            public int ReadIntervalTimeout;
            public int ReadTotalTimeoutMultiplier;
            public int ReadTotalTimeoutConstant;
            public int WriteTotalTimeoutMultiplier;
            public int WriteTotalTimeoutConstant;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct OVERLAPPED
        {
            public int Internal;
            public int InternalHigh;
            public int Offset;
            public int OffsetHigh;
            public int hEvent;
        }

        [DllImport("kernel32.dll")]
        private static extern int CreateFile(
        string lpFileName, // file name
        uint dwDesiredAccess, // access mode
        int dwShareMode, // share mode
        int lpSecurityAttributes, // SD
        int dwCreationDisposition, // how to create
        int dwFlagsAndAttributes, // file attributes
        int hTemplateFile // handle to template file
        );
        [DllImport("kernel32.dll")]
        private static extern bool GetCommState(
        int hFile, // handle to communications device
        ref DCB lpDCB // device-control block
        );
        [DllImport("kernel32.dll")]
        private static extern bool BuildCommDCB(
        string lpDef, // device-control string
        ref DCB lpDCB // device-control block
        );
        [DllImport("kernel32.dll")]
        private static extern bool SetCommState(
        int hFile, // handle to communications device
        ref DCB lpDCB // device-control block
        );
        [DllImport("kernel32.dll")]
        private static extern bool GetCommTimeouts(
        int hFile, // handle to comm device
        ref COMMTIMEOUTS lpCommTimeouts // time-out values
        );
        [DllImport("kernel32.dll")]
        private static extern bool SetCommTimeouts(
        int hFile, // handle to comm device
        ref COMMTIMEOUTS lpCommTimeouts // time-out values
        );
        [DllImport("kernel32.dll")]
        private static extern bool ReadFile(
        int hFile, // handle to file
        byte[] lpBuffer, // data buffer
        int nNumberOfBytesToRead, // number of bytes to read
        ref int lpNumberOfBytesRead, // number of bytes read
        ref OVERLAPPED lpOverlapped // overlapped buffer
        );
        [DllImport("kernel32.dll")]
        private static extern bool WriteFile(
        int hFile, // handle to file
        byte[] lpBuffer, // data buffer
        int nNumberOfBytesToWrite, // number of bytes to write
        ref int lpNumberOfBytesWritten, // number of bytes written
        ref OVERLAPPED lpOverlapped // overlapped buffer
        );
        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(
        int hObject // handle to object
        );
        [DllImport("kernel32.dll")]
        private static extern uint GetLastError();


        public void loadData(string path)
        {
            StreamReader sr = new StreamReader(path);
            sr.ReadLine();
            this.PortNum  = int.Parse(sr.ReadLine());
            sr.ReadLine();
            this.BaudRate = int.Parse(sr.ReadLine());
            sr.ReadLine();
            this.ByteSize = byte.Parse(sr.ReadLine());
            sr.ReadLine();
            this.Parity = byte.Parse(sr.ReadLine());
            sr.ReadLine();
            this.StopBits = byte.Parse(sr.ReadLine());
            this.ReadTimeout = 1000;
            sr.Close();
        }

        public void Open()
        {

            DCB dcbCommPort = new DCB();
            COMMTIMEOUTS ctoCommPort = new COMMTIMEOUTS();


            // OPEN THE COMM PORT.


            hComm = CreateFile("COM" + PortNum, GENERIC_READ | GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0);

            // IF THE PORT CANNOT BE OPENED, BAIL OUT.
            if (hComm == INVALID_HANDLE_VALUE)
            {
                throw (new ApplicationException("Comm Port Can Not Be Opened"));
            }

            // SET THE COMM TIMEOUTS.

            GetCommTimeouts(hComm, ref ctoCommPort);
            ctoCommPort.ReadTotalTimeoutConstant = ReadTimeout;
            ctoCommPort.ReadTotalTimeoutMultiplier = 0;
            ctoCommPort.WriteTotalTimeoutMultiplier = 0;
            ctoCommPort.WriteTotalTimeoutConstant = 0;
            SetCommTimeouts(hComm, ref ctoCommPort);

            // SET BAUD RATE, PARITY, WORD SIZE, AND STOP BITS.
            GetCommState(hComm, ref dcbCommPort);
            dcbCommPort.BaudRate = BaudRate;
            dcbCommPort.flags = 0;
            //dcb.fBinary=1;
            dcbCommPort.flags |= 1;
            if (Parity > 0)
            {
                //dcb.fParity=1
                dcbCommPort.flags |= 2;
            }
            dcbCommPort.Parity = Parity;
            dcbCommPort.ByteSize = ByteSize;
            dcbCommPort.StopBits = StopBits;
            if (!SetCommState(hComm, ref dcbCommPort))
            {
                //uint ErrorNum=GetLastError();
                throw (new ApplicationException("Comm Port Can Not Be Opened"));
            }
            //unremark to see if setting took correctly
            //DCB dcbCommPort2 = new DCB();
            //GetCommState(hComm, ref dcbCommPort2);
            Opened = true;

        }

        public void Close()
        {
            if (hComm != INVALID_HANDLE_VALUE)
            {
                CloseHandle(hComm);
            }
        }
        public byte[] Read(int NumBytes)
        {
            byte[] BufBytes;
            byte[] OutBytes;
            BufBytes = new byte[NumBytes];
            if (hComm != INVALID_HANDLE_VALUE)
            {
                OVERLAPPED ovlCommPort = new OVERLAPPED();
                int BytesRead = 0;
                ReadFile(hComm, BufBytes, NumBytes, ref BytesRead, ref ovlCommPort);
                OutBytes = new byte[BytesRead];
                Array.Copy(BufBytes, OutBytes, BytesRead);
            }
            else
            {
                throw (new ApplicationException("Comm Port Not Open"));
            }
            return OutBytes;
        }

        public void Write(byte[] WriteBytes)
        {
            if (hComm != INVALID_HANDLE_VALUE)
            {
                OVERLAPPED ovlCommPort = new OVERLAPPED();
                int BytesWritten = 0;
                WriteFile(hComm, WriteBytes, WriteBytes.Length, ref BytesWritten, ref ovlCommPort);
            }
            else
            {
                throw (new ApplicationException("Comm Port Not Open"));
            }
        }
    }
}