using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;


namespace DotNet.Utilities
{
    /// <summary>
    /// 執行需要調用 <b>Win32</b> API 的操作輔助類。
    /// </summary>
    [SuppressUnmanagedCodeSecurity()]
    public static partial class Win32
    {
        #region 方法

        /// <summary>
        /// 執行獲取當前運行的操作系統版本。
        /// </summary>
        /// <returns><see cref="Platform"/> 的值之一，他表示當前運行的操作系統版本。</returns>
        private static Platform GetCurrentPlatform()
        {
            OperatingSystem os = Environment.OSVersion;
            Platform pt;
            switch(os.Platform)
            {
                case (PlatformID.Win32Windows): // Win95, Win98 or Me
                    switch(os.Version.Minor)
                    {
                        case (0): // 95
                            pt = Platform.Windows95;
                            break;
                        case (10): // 98
                            if(os.Version.Revision.ToString() == "2222A")
                                pt = Platform.Windows982ndEdition;
                            else
                                pt = Platform.Windows98;
                            break;
                        case (90): // winme
                            pt = Platform.WindowsME;
                            break;
                        default: // Unknown
                            pt = Platform.UnKnown;
                            break;
                    }
                    break;
                case (PlatformID.Win32NT): //Win2k or Xp or 2003
                    switch(os.Version.Major)
                    {
                        case (3):
                            pt = Platform.WindowsNT351;
                            break;
                        case (4):
                            pt = Platform.WindowsNT40;
                            break;
                        case (5):
                            if(os.Version.Minor == 0)
                                pt = Platform.Windows2000;
                            else if(os.Version.Minor == 1)
                                pt = Platform.WindowsXP;
                            else if(os.Version.Minor == 2)
                                pt = Platform.Windows2003;
                            else
                                pt = Platform.UnKnown;
                            break;
                        case (6):
                            pt = Platform.WindowsVista;
                            break;
                        default:
                            pt = Platform.UnKnown;
                            break;
                    }
                    break;
                case (PlatformID.WinCE): // WinCE
                    pt = Platform.WindowsCE;
                    break;
                case (PlatformID.Win32S):
                case (PlatformID.Unix):
                default:
                    pt = Platform.UnKnown;
                    break;
            }
            return pt;
        }

        /// <summary>
        /// 表示操作系統平台。
        /// </summary>
        private enum Platform : byte
        {
            /// <summary>
            /// Windows 95 操作系統.
            /// </summary>
            Windows95,
            /// <summary>
            /// Windows 98 操作系統.
            /// </summary>
            Windows98,
            /// <summary>
            /// Windows 98 第二版操作系統.
            /// </summary>
            Windows982ndEdition,
            /// <summary>
            /// Windows ME 操作系統.
            /// </summary>
            WindowsME,
            /// <summary>
            /// Windows NT 3.51 操作系統.
            /// </summary>
            WindowsNT351,
            /// <summary>
            /// Windows NT 4.0 操作系統.
            /// </summary>
            WindowsNT40,
            /// <summary>
            /// Windows 2000 操作系統.
            /// </summary>
            Windows2000,
            /// <summary>
            /// Windows XP 操作系統.
            /// </summary>
            WindowsXP,
            /// <summary>
            /// Windows 2003 操作系統.
            /// </summary>
            Windows2003,
            /// <summary>
            /// Windows Vista 操作系統.
            /// </summary>
            WindowsVista,
            /// <summary>
            /// Windows CE 操作系統.
            /// </summary>
            WindowsCE,
            /// <summary>
            /// 操作系統版本未知。
            /// </summary>
            UnKnown
        }

        /// <summary>
        /// 表示IDE設備錯誤狀態代碼的常量與數值的對應。
        /// </summary>
        /// <remarks>其數值與常量定義在 <b>WinIoCtl.h</b> 文件中。</remarks>
        private enum DriverError : byte
        {
            /// <summary>
            /// 設備無錯誤。
            /// </summary>
            SMART_NO_ERROR = 0, // No error
            /// <summary>
            /// 設備IDE控制器錯誤。
            /// </summary>
            SMART_IDE_ERROR = 1, // Error from IDE controller
            /// <summary>
            /// 無效的命令標記。
            /// </summary>
            SMART_INVALID_FLAG = 2, // Invalid command flag
            /// <summary>
            /// 無效的命令數據。
            /// </summary>
            SMART_INVALID_COMMAND = 3, // Invalid command byte
            /// <summary>
            /// 緩衝區無效（如緩衝區為空或地址錯誤）。
            /// </summary>
            SMART_INVALID_BUFFER = 4, // Bad buffer (null, invalid addr..)
            /// <summary>
            /// 設備編號錯誤。
            /// </summary>
            SMART_INVALID_DRIVE = 5, // Drive number not valid
            /// <summary>
            /// IOCTL錯誤。
            /// </summary>
            SMART_INVALID_IOCTL = 6, // Invalid IOCTL
            /// <summary>
            /// 無法鎖定用戶的緩衝區。
            /// </summary>
            SMART_ERROR_NO_MEM = 7, // Could not lock user's buffer
            /// <summary>
            /// 無效的IDE註冊命令。
            /// </summary>
            SMART_INVALID_REGISTER = 8, // Some IDE Register not valid
            /// <summary>
            /// 無效的命令設置。
            /// </summary>
            SMART_NOT_SUPPORTED = 9, // Invalid cmd flag set
            /// <summary>
            /// 指定要查找的設別索引號無效。
            /// </summary>
            SMART_NO_IDE_DEVICE = 10
        }

        public static void ChangeByteOrder(byte[] charArray)
        {
            byte temp;
            for(int i = 0; i < charArray.Length; i += 2)
            {
                temp = charArray[i];
                charArray[i] = charArray[i + 1];
                charArray[i + 1] = temp;
            }
        }

        /// <summary>
        /// 根據指定的設備信息生成設備的詳細信息。
        /// </summary>
        /// <param name="phdinfo">一個 <see cref="IdSector"/></param>
        /// <returns></returns>
        private static HDiskInfo GetHardDiskInfo(IdSector phdinfo)
        {
            HDiskInfo hdd = new HDiskInfo();
            hdd.ModuleNumber = Encoding.ASCII.GetString(phdinfo.sModelNumber).Trim();
            hdd.Firmware = Encoding.ASCII.GetString(phdinfo.sFirmwareRev).Trim();
            hdd.SerialNumber = Encoding.ASCII.GetString(phdinfo.sSerialNumber).Trim();
            hdd.Capacity = phdinfo.ulTotalAddressableSectors / 2 / 1024;
            hdd.BufferSize = phdinfo.wBufferSize / 1024;
            return hdd;
        }

        /// <summary>
        /// 獲取在NT平台下指定序列號的硬盤信息。
        /// </summary>
        /// <param name="driveIndex">物理磁盤的數量。</param>
        /// <returns></returns>
        private static HDiskInfo GetHddInfoNT(byte driveIndex)
        {
            GetVersionOutParams vers = new GetVersionOutParams();
            SendCmdInParams inParam = new SendCmdInParams();
            SendCmdOutParams outParam = new SendCmdOutParams();
            uint bytesReturned = 0;

            // 使用 Win2000 或 Xp下的方法獲取硬件信息

            // 獲取設備的句柄。
            IntPtr hDevice =
                CreateFile(string.Format(@"\\.\PhysicalDrive{0}", driveIndex), GENERIC_READ | GENERIC_WRITE,
                           FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

            // 開始檢查
            if(hDevice == IntPtr.Zero)
                throw new UnauthorizedAccessException("執行 Win32 API 函數 CreateFile 失敗。");
            if(0 == DeviceIoControl(hDevice, SMART_GET_VERSION, IntPtr.Zero, 0, ref vers,
                (uint)Marshal.SizeOf(vers),
                ref bytesReturned,
                IntPtr.Zero))
            {
                CloseHandle(hDevice);
                throw new IOException(string.Format(ResourcesApi.Win32_DeviceIoControlErr, "SMART_GET_VERSION"));
            }
            // 檢測IDE控制命令是否支持
            if(0 == (vers.fCapabilities & 1))
            {
                CloseHandle(hDevice);
                throw new IOException(ResourcesApi.Win32_DeviceIoControlNotSupport);
            }
            // Identify the IDE drives
            if(0 != (driveIndex & 1))
                inParam.irDriveRegs.bDriveHeadReg = 0xb0;
            else
                inParam.irDriveRegs.bDriveHeadReg = 0xa0;
            if(0 != (vers.fCapabilities & (16 >> driveIndex)))
            {
                // We don't detect a ATAPI device.
                CloseHandle(hDevice);
                throw new IOException(ResourcesApi.Win32_DeviceIoControlNotSupport);
            }
            else
                inParam.irDriveRegs.bCommandReg = 0xec;
            inParam.bDriveNumber = driveIndex;
            inParam.irDriveRegs.bSectorCountReg = 1;
            inParam.irDriveRegs.bSectorNumberReg = 1;
            inParam.cBufferSize = 512;

            if(0 == DeviceIoControl(
                hDevice,
                SMART_RCV_DRIVE_DATA,
                ref inParam,
                (uint)Marshal.SizeOf(inParam),
                ref outParam,
                (uint)Marshal.SizeOf(outParam),
                ref bytesReturned,
                IntPtr.Zero))
            {
                CloseHandle(hDevice);
                throw new IOException(
                        string.Format(ResourcesApi.Win32_DeviceIoControlErr, "SMART_RCV_DRIVE_DATA"));
            }
            CloseHandle(hDevice);
            ChangeByteOrder(outParam.bBuffer.sModelNumber);
            ChangeByteOrder(outParam.bBuffer.sSerialNumber);
            ChangeByteOrder(outParam.bBuffer.sFirmwareRev);
            return GetHardDiskInfo(outParam.bBuffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driveIndex"></param>
        /// <returns></returns>
        private static HDiskInfo GetHddInfo9X(byte driveIndex)
        {
            GetVersionOutParams vers = new GetVersionOutParams();
            SendCmdInParams inParam = new SendCmdInParams();
            SendCmdOutParams outParam = new SendCmdOutParams();
            uint bytesReturned = 0;
            IntPtr hDevice = CreateFile(@"\\.\Smartvsd", 0, 0, IntPtr.Zero, CREATE_NEW, 0, IntPtr.Zero);
            if(hDevice == IntPtr.Zero)
                throw new UnauthorizedAccessException("打開 smartvsd.vxd 文件失敗。");
            if(0 == DeviceIoControl(hDevice, SMART_GET_VERSION, 
                IntPtr.Zero, 0, 
                ref vers, (uint)Marshal.SizeOf(vers), ref bytesReturned, IntPtr.Zero))
            {
                CloseHandle(hDevice);
                throw new IOException(string.Format(ResourcesApi.Win32_DeviceIoControlErr, "SMART_GET_VERSION"));
            }
            // 如果 IDE 的鑒定命令不被識別或失敗
            if(0 == (vers.fCapabilities & 1))
            {
                CloseHandle(hDevice);
                throw new IOException(ResourcesApi.Win32_DeviceIoControlNotSupport);
            }
            if(0 != (driveIndex & 1))
                inParam.irDriveRegs.bDriveHeadReg = 0xb0;
            else
                inParam.irDriveRegs.bDriveHeadReg = 0xa0;
            if(0 != (vers.fCapabilities & (16 >> driveIndex)))
            {
                // 檢測出IDE為ATAPI類型，無法處理
                CloseHandle(hDevice);
                throw new IOException(ResourcesApi.Win32_DeviceIoControlNotSupport);
            }
            else
                inParam.irDriveRegs.bCommandReg = 0xec;
            inParam.bDriveNumber = driveIndex;
            inParam.irDriveRegs.bSectorCountReg = 1;
            inParam.irDriveRegs.bSectorNumberReg = 1;
            inParam.cBufferSize = BUFFER_SIZE;
            if(0 == DeviceIoControl(hDevice, SMART_RCV_DRIVE_DATA, ref inParam, (uint)Marshal.SizeOf(inParam), ref outParam, (uint)Marshal.SizeOf(outParam), ref bytesReturned, IntPtr.Zero))
            {
                CloseHandle(hDevice);
                throw new IOException(string.Format(ResourcesApi.Win32_DeviceIoControlErr, "SMART_RCV_DRIVE_DATA"));
            }
            // 關閉文件句柄
            CloseHandle(hDevice);
            ChangeByteOrder(outParam.bBuffer.sModelNumber);
            ChangeByteOrder(outParam.bBuffer.sSerialNumber);
            ChangeByteOrder(outParam.bBuffer.sFirmwareRev);
            return GetHardDiskInfo(outParam.bBuffer);
        }

        #endregion

        #region Win32

        /// <summary>
        /// 取得指定窗口的系統菜單的句柄。
        /// </summary>
        /// <param name="hwnd">指向要獲取系統菜單窗口的 <see cref="IntPtr"/> 句柄。</param>
        /// <param name="bRevert">獲取系統菜單的方式。設置為 <b>true</b>，表示接收原始的系統菜單，否則設置為 <b>false</b> 。</param>
        /// <returns>指向要獲取的系統菜單的 <see cref="IntPtr"/> 句柄。</returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetSystemMenu(IntPtr hwnd, bool bRevert);

        /// <summary>
        /// 獲取指定的菜單中條目（菜單項）的數量。
        /// </summary>
        /// <param name="hMenu">指向要獲取菜單項數量的系統菜單的 <see cref="IntPtr"/> 句柄。</param>
        /// <returns>菜單中的條目數量</returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetMenuItemCount(IntPtr hMenu);

        /// <summary>
        /// 刪除指定的菜單條目。
        /// </summary>
        /// <param name="hMenu">指向要移除的菜單的 <see cref="IntPtr"/> 。</param>
        /// <param name="uPosition">欲改變的菜單條目的標識符。</param>
        /// <param name="uFlags"></param>
        /// <returns>非零表示成功，零表示失敗。</returns>
        /// <remarks>
        /// 如果在 <paramref name="uFlags"/> 中使用了<see cref="MF_BYPOSITION"/> ，則在 <paramref name="uPosition"/> 參數表示菜單項的索引；
        /// 如果在 <paramref name="uFlags"/> 中使用了 <b>MF_BYCOMMAND</b>，則在 <paramref name="uPosition"/> 中使用菜單項的ID。
        /// </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int RemoveMenu(IntPtr hMenu, int uPosition, int uFlags);

        /// <summary>
        /// 關閉一個指定的指針對像指向的設備。。
        /// </summary>
        /// <param name="hObject">要關閉的句柄 <see cref="IntPtr"/> 對象。</param>
        /// <returns>成功返回 <b>0</b> ，不成功返回非零值。</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int CloseHandle(IntPtr hObject);

        /// <summary>
        /// 執行打開/建立資源的功能。
        /// </summary>
        /// <param name="lpFileName">指定要打開的設備或文件的名稱。</param>
        /// <param name="dwDesiredAccess">
        /// <para>Win32 常量，用於控制對設備的讀訪問、寫訪問或讀/寫訪問的常數。內容如下表：
        /// <p><list type="table">
        /// <listheader>
        /// <term>名稱</term>
        /// <description>說明</description>
        /// </listheader>
        /// <item>
        /// <term>GENERIC_READ</term><description>指定對設備進行讀取訪問。</description>
        /// </item>
        /// <item>
        /// <term>GENERIC_WRITE</term><description>指定對設備進行寫訪問。</description>
        /// </item>
        /// <item><term><b>0</b></term><description>如果值為零，則表示只允許獲取與一個設備有關的信息。</description></item>
        /// </list></p>
        /// </para>
        /// </param>
        /// <param name="dwShareMode">指定打開設備時的文件共享模式</param>
        /// <param name="lpSecurityAttributes"></param>
        /// <param name="dwCreationDisposition">Win32 常量，指定操作系統打開文件的方式。內容如下表：
        /// <para><p>
        /// <list type="table">
        /// <listheader><term>名稱</term><description>說明</description></listheader>
        /// <item>
        /// <term>CREATE_NEW</term>
        /// <description>指定操作系統應創建新文件。如果文件存在，則拋出 <see cref="IOException"/> 異常。</description>
        /// </item>
        /// <item><term>CREATE_ALWAYS</term><description>指定操作系統應創建新文件。如果文件已存在，它將被改寫。</description></item>
        /// </list>
        /// </p></para>
        /// </param>
        /// <param name="dwFlagsAndAttributes"></param>
        /// <param name="hTemplateFile"></param>
        /// <returns>使用函數打開的設備的句柄。</returns>
        /// <remarks>
        /// 本函數可以執行打開或建立文件、文件流、目錄/文件夾、物理磁盤、卷、系統控制的緩衝區、磁帶設備、
        /// 通信資源、郵件系統和命名管道。
        /// </remarks>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode,
                                                IntPtr lpSecurityAttributes, uint dwCreationDisposition,
                                                uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        /// <summary>
        /// 對設備執行指定的操作。
        /// </summary>
        /// <param name="hDevice">要執行操作的設備句柄。</param>
        /// <param name="dwIoControlCode">Win32 API 常數，輸入的是以 <b>FSCTL_</b> 為前綴的常數，定義在 
        /// <b>WinIoCtl.h</b> 文件內，執行此重載方法必須輸入 <b>SMART_GET_VERSION</b> 。</param>
        /// <param name="lpInBuffer">當參數為指針時，默認的輸入值是 <b>0</b> 。</param>
        /// <param name="nInBufferSize">輸入緩衝區的字節數量。</param>
        /// <param name="lpOutBuffer">一個 <b>GetVersionOutParams</b> ，表示執行函數後輸出的設備檢查。</param>
        /// <param name="nOutBufferSize">輸出緩衝區的字節數量。</param>
        /// <param name="lpBytesReturned">實際裝載到輸出緩衝區的字節數量。</param>
        /// <param name="lpOverlapped">同步操作控制，一般不使用，默認值為 <b>0</b> 。</param>
        /// <returns>非零表示成功，零表示失敗。</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, IntPtr lpInBuffer,
                                                  uint nInBufferSize, ref GetVersionOutParams lpOutBuffer,
                                                  uint nOutBufferSize, ref uint lpBytesReturned,
                                                  [Out] IntPtr lpOverlapped);

        /// <summary>
        /// 對設備執行指定的操作。
        /// </summary>
        /// <param name="hDevice">要執行操作的設備句柄。</param>
        /// <param name="dwIoControlCode">Win32 API 常數，輸入的是以 <b>FSCTL_</b> 為前綴的常數，定義在 
        /// <b>WinIoCtl.h</b> 文件內，執行此重載方法必須輸入 <b>SMART_SEND_DRIVE_COMMAND</b> 或 <b>SMART_RCV_DRIVE_DATA</b> 。</param>
        /// <param name="lpInBuffer">一個 <b>SendCmdInParams</b> 結構，它保存向系統發送的查詢要求具體命令的數據結構。</param>
        /// <param name="nInBufferSize">輸入緩衝區的字節數量。</param>
        /// <param name="lpOutBuffer">一個 <b>SendCmdOutParams</b> 結構，它保存系統根據命令返回的設備相信信息二進制數據。</param>
        /// <param name="nOutBufferSize">輸出緩衝區的字節數量。</param>
        /// <param name="lpBytesReturned">實際裝載到輸出緩衝區的字節數量。</param>
        /// <param name="lpOverlapped">同步操作控制，一般不使用，默認值為 <b>0</b> 。</param>
        /// <returns>非零表示成功，零表示失敗。</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, ref SendCmdInParams lpInBuffer,
                                                  uint nInBufferSize, ref SendCmdOutParams lpOutBuffer,
                                                  uint nOutBufferSize, ref uint lpBytesReturned,
                                                  [Out] IntPtr lpOverlapped);

        #endregion

        #region 結構

        /// <summary>
        /// 保存當前計算機 IDE 設備（硬盤）的硬件信息的結構。
        /// </summary>
        [Serializable]
        public struct HDiskInfo
        {
            /// <summary>
            /// 硬盤型號。
            /// </summary>
            public string ModuleNumber;

            /// <summary>
            /// 硬盤的固件版本。
            /// </summary>
            public string Firmware;

            /// <summary>
            /// 硬盤序列號。
            /// </summary>
            public string SerialNumber;

            /// <summary>
            /// 硬盤容量，以M為單位。
            /// </summary>
            public uint Capacity;
            
            /// <summary>
            /// 設備緩存大小（以M為單位）。
            /// </summary>
            public int BufferSize;
        }

        /// <summary>
        /// 表示使用 <b>DeviceIoControl</b> 函數時保存返回的驅動器硬件信息的結構
        /// </summary>
        /// <remarks>>此數據結構定義在 <b>WinIoCtl.h</b> 文件名為 <b>_GETVERSIONINPARAMS</b> 結構中。</remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct GetVersionOutParams
        {
            /// <summary>
            /// IDE設備的二進制硬件版本。
            /// </summary>
            public byte bVersion;

            /// <summary>
            /// IDE設備的二進制修訂版本。
            /// </summary>
            public byte bRevision;

            /// <summary>
            /// 此值操作系統沒有使用，使用此數據結構時被設置為 <b>0</b> 。
            /// </summary>
            public byte bReserved;

            /// <summary>
            /// IDE設備的二進制映射。
            /// </summary>
            public byte bIDEDeviceMap;

            /// <summary>
            /// IDE設備的二進制容量數據。
            /// </summary>
            public uint fCapabilities;

            /// <summary>
            /// 保留內容，不使用。
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public uint[] dwReserved; // For future use.
        }

        /// <summary>
        /// 一個數據結構，表示使用 <b>DeviceIoControl</b> 函數時發送到操作系統中的命令數據結構 <b>SendCmdInParams</b> 的成員結構。
        /// 它表示要獲取磁盤設備性能參數的具體定義規則。
        /// </summary>
        /// <seealso cref="SendCmdInParams"/>
        /// <remarks>此數據結構定義在 <b>WinIoCtl.h</b> 文件名為 <b>_IDEREGS</b> 中。</remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct IdeRegs
        {
            /// <summary>
            /// 發送到操作系統的註冊命令，此為系統的 <b>SMART Command</b> 。
            /// </summary>
            public byte bFeaturesReg;

            /// <summary>
            /// 獲取IDE設備扇區數。
            /// </summary>
            public byte bSectorCountReg;

            /// <summary>
            /// 獲取IDE設備編號。
            /// </summary>
            public byte bSectorNumberReg;

            /// <summary>
            /// 獲取IDE設備低端柱面值。
            /// </summary>
            public byte bCylLowReg;

            /// <summary>
            /// 獲取IDE設備高端柱面值。
            /// </summary>
            public byte bCylHighReg;

            /// <summary>
            /// 獲取IDE設備的頭信息。
            /// </summary>
            public byte bDriveHeadReg;

            /// <summary>
            /// 獲取IDE設備的真正命令。
            /// </summary>
            public byte bCommandReg;

            /// <summary>
            /// 保留內容，此值應設置為 <b>0</b> 。
            /// </summary>
            public byte bReserved;
        }

        /// <summary>
        /// 保存執行 <b>DeviceIoControl</b> 函數時向系統提交的執行操作命令。
        /// </summary>
        /// <seealso cref="SendCmdInParams"/>
        /// <remarks>此數據結構定義在 <b>WinIoCtl.h</b> 文件名為 <b>_SENDCMDINPARAMS</b> 中。</remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct SendCmdInParams
        {
            /// <summary>
            /// 輸出的數據緩衝大小。
            /// </summary>
            public uint cBufferSize;

            /// <summary>
            /// 保存向系統發送的磁盤設備命令的數據結構。
            /// </summary>
            public IdeRegs irDriveRegs;

            /// <summary>
            /// 希望系統控制的物理磁盤的編號。
            /// </summary>
            public byte bDriveNumber;

            /// <summary>
            /// 保留的數據，不使用。
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] bReserved;

            /// <summary>
            /// 保留的數據，不使用。
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public uint[] dwReserved;

            /// <summary>
            /// 保存當前 <b>SendCmdInParams</b> 結構填充數據後的大小。
            /// </summary>
            public byte bBuffer;
        }

        /// <summary>
        /// 當執行 <b>DeviceIoControl</b> 函數後系統返回的 <b>SendCmdOutParams</b> 結構中
        /// 保存磁盤設備當前錯誤信息的數據結構。
        /// </summary>
        /// <seealso cref="SendCmdInParams"/>
        /// <remarks>
        /// 此數據結構定義在 <b>WinIoCtl.h</b> 文件名為 <b>_DRIVERSTATUS</b> 中。
        /// <para>
        /// 錯誤代碼如下表：<br />
        /// <list type="table">
        /// <listheader>
        /// <term>名稱</term>
        /// <description>說明</description>
        /// <item><term>SMART_NO_ERROR = 0</term>
        /// <description>沒有錯誤。</description></item>
        /// <item><term>SMART_IDE_ERROR = 1</term>
        /// <description>IDE控制器錯誤</description>。</item>
        /// <item><term>SMART_INVALID_FLAG = 2</term>
        /// <description>發送的命令標記無效。</description></item>
        /// <item><term>SMART_INVALID_COMMAND = 3</term>
        /// <description>發送的二進制命令無效。</description></item>
        /// <item><term>SMART_INVALID_BUFFER = 4</term>
        /// <description>二進制緩存無效（緩存為空或者無效地址）。</description></item>
        /// <item><term>SMART_INVALID_DRIVE = 5</term>
        /// <description>物理驅動器編號無效。</description></item>
        /// <item><term>SMART_INVALID_IOCTL = 6</term>
        /// <description>無效的IOCTL。</description></item>
        /// <item><term>SMART_ERROR_NO_MEM =  7</term>
        /// <description>使用的緩衝區無法鎖定。</description></item>
        /// <item><term>SMART_INVALID_REGISTER = 8</term>
        /// <description>IDE註冊命令無效。</description></item>
        /// <item><term>SMART_NOT_SUPPORTED = 9</term>
        /// <description>命令標記設置無效。</description></item>
        /// <item><term>SMART_NO_IDE_DEVICE = 10</term>
        /// <description>發送的物理驅動器索引超過限制。</description></item>
        /// </list>
        /// </para>
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct DriverStatus
        {
            /// <summary>
            /// 如果檢查的IDE設備發生錯誤，保存的錯誤代碼，<b>0</b> 表示沒有錯誤。
            /// </summary>
            public byte bDriverError;

            /// <summary>
            /// IDE設備被註冊的錯誤內容。
            /// </summary>
            public byte bIDEStatus;

            /// <summary>
            /// 保留的數據，不使用。
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] bReserved;

            /// <summary>
            /// 保留的數據，不使用。
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public uint[] dwReserved;
        }

        /// <summary>
        /// 表示當執行 <b>DeviceIoControl</b> 函數後保存系統根據查詢命令返回的磁盤設備信息的數據結構。
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct SendCmdOutParams
        {
            /// <summary>
            /// 表示所有二進制信息的緩存大小。
            /// </summary>
            public uint cBufferSize;

            /// <summary>
            /// 表示查詢到設備的錯誤信息狀態。
            /// </summary>
            public DriverStatus DriverStatus;

            /// <summary>
            /// 表示系統返回的設備硬件信息的二進制數據結構。
            /// </summary>
            public IdSector bBuffer;
        }

        /// <summary>
        /// 當執行 <b>DeviceIoControl</b> 函數後系統返回的 <b>SendCmdOutParams</b> 結構中
        /// 保存磁盤設備的硬件信息的數據結構。
        /// </summary>
        /// <seealso cref="SendCmdInParams"/>
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 512)]
        private struct IdSector
        {
            /// <summary>
            /// 設備通用配置信息。
            /// </summary>
            public ushort wGenConfig;

            /// <summary>
            /// 設備的柱面數。
            /// </summary>
            public ushort wNumCyls;

            /// <summary>
            /// 保留內容，不使用。
            /// </summary>
            public ushort wReserved;

            /// <summary>
            /// 設備的磁頭數目。
            /// </summary>
            public ushort wNumHeads;

            /// <summary>
            /// 設備的磁道數目。
            /// </summary>
            public ushort wBytesPerTrack;

            /// <summary>
            /// 設備的扇區數目。
            /// </summary>
            public ushort wBytesPerSector;

            /// <summary>
            /// 設備廠商設定的扇區磁道數目。
            /// </summary>
            public ushort wSectorsPerTrack;

            /// <summary>
            /// 設備的出品廠商名稱。
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public ushort[] wVendorUnique;

            /// <summary>
            /// 設備出品廠商的全球唯一編碼。
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] sSerialNumber;

            /// <summary>
            /// 設備的緩存類型。
            /// </summary>
            public ushort wBufferType;

            /// <summary>
            /// 設備緩存容量（單位是byte）。
            /// </summary>
            public ushort wBufferSize;

            /// <summary>
            /// 設備的錯誤檢查和糾正（ECC）數據的大小。
            /// </summary>
            public ushort wECCSize;

            /// <summary>
            /// 設備的固件版本。
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] sFirmwareRev;

            /// <summary>
            /// 設備的型號。
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
            public byte[] sModelNumber;

            /// <summary>
            /// 設備廠商名稱的擴展內容（如果有）。
            /// </summary>
            public ushort wMoreVendorUnique;

            /// <summary>
            /// 設備雙指令輸入輸出模式。
            /// </summary>
            public ushort wDoubleWordIO;

            /// <summary>
            /// 設備的容量大小（單位Byte）。
            /// </summary>
            public ushort wCapabilities;

            /// <summary>
            /// 第一個保留的內容，不使用。
            /// </summary>
            public ushort wReserved1;

            /// <summary>
            /// 設備的PIO模式巡道時間。
            /// </summary>
            public ushort wPIOTiming;

            /// <summary>
            /// 設備DMA 模式巡道時間。
            /// </summary>
            public ushort wDMATiming;

            /// <summary>
            /// 設備的總線類型，如SCSI,IDE等。
            /// </summary>
            public ushort wBS;

            /// <summary>
            /// 設備的當前柱面數量。
            /// </summary>
            public ushort wNumCurrentCyls;

            /// <summary>
            /// 設備當前磁頭數量。
            /// </summary>
            public ushort wNumCurrentHeads;

            /// <summary>
            /// 設備的當前扇區的磁道數量。
            /// </summary>
            public ushort wNumCurrentSectorsPerTrack;

            /// <summary>
            /// 設備的當前扇區容量（單位byte）。
            /// </summary>
            public uint ulCurrentSectorCapacity;

            /// <summary>
            /// 多扇區讀寫模式支持。
            /// </summary>
            public ushort wMultSectorStuff;

            /// <summary>
            /// 用戶是否可自定義扇區地址(LBA模式）支持。
            /// </summary>
            public uint ulTotalAddressableSectors;

            /// <summary>
            /// 單指令DMA模式。
            /// </summary>
            public ushort wSingleWordDMA;

            /// <summary>
            /// 多指令DMA模式。
            /// </summary>
            public ushort wMultiWordDMA;

            /// <summary>
            /// 保留內容，不使用。
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public byte[] bReserved;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="left"></param>
            /// <param name="top"></param>
            /// <param name="right"></param>
            /// <param name="bottom"></param>
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="r"></param>
            public RECT(Rectangle r)
            {
                left = r.Left;
                top = r.Top;
                right = r.Right;
                bottom = r.Bottom;
            }
            /// <summary>
            /// 
            /// </summary>
            public int left;
            /// <summary>
            /// 
            /// </summary>
            public int top;
            /// <summary>
            /// 
            /// </summary>
            public int right;
            /// <summary>
            /// 
            /// </summary>
            public int bottom;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="width"></param>
            /// <param name="height"></param>
            /// <returns></returns>
            public static RECT FromXYWH(int x, int y, int width, int height)
            {
                return new RECT(x, y, x + width, y + height);
            }

            /// <summary>
            /// 
            /// </summary>
            public Size Size
            {
                get { return new Size(right - left, bottom - top); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public sealed class SCROLLINFO
        {
            public SCROLLINFO()
            {
                this.cbSize = Marshal.SizeOf(typeof(SCROLLINFO));
            }

            public SCROLLINFO(int mask, int min, int max, int page, int pos)
            {
                this.cbSize = Marshal.SizeOf(typeof(SCROLLINFO));
                this.fMask = mask;
                this.nMin = min;
                this.nMax = max;
                this.nPage = page;
                this.nPos = pos;
            }

            public int cbSize;
            public int fMask;
            public int nMin;
            public int nMax;
            public int nPage;
            public int nPos;
            public int nTrackPos;
        }
        #endregion

        #region 常量

        /// <summary>
        /// Win32 API 常數，指示在使用 <see cref="RemoveMenu"/> 函數時指定使用索引數而不是使用ID。
        /// </summary>
        private const int MF_BYPOSITION = 0x00000400;
        private const uint FILE_SHARE_READ = 0x00000001;
        private const uint FILE_SHARE_WRITE = 0x00000002;
        private const uint FILE_SHARE_DELETE = 0x00000004;
        private const uint SMART_GET_VERSION = 0x00074080; // SMART_GET_VERSION
        private const uint SMART_SEND_DRIVE_COMMAND = 0x0007c084; // SMART_SEND_DRIVE_COMMAND
        private const uint SMART_RCV_DRIVE_DATA = 0x0007c088; // SMART_RCV_DRIVE_DATA
        private const uint GENERIC_READ = 0x80000000;
        private const uint GENERIC_WRITE = 0x40000000;
        private const uint CREATE_NEW = 1;
        private const uint OPEN_EXISTING = 3;
        private const uint BUFFER_SIZE = 512;
        private static readonly Platform currentOs;

        #endregion
    }
}