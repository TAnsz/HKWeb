using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;


namespace DotNet.Utilities
{
    /// <summary>
    /// ����ݭn�ե� <b>Win32</b> API ���ާ@���U���C
    /// </summary>
    [SuppressUnmanagedCodeSecurity()]
    public static partial class Win32
    {
        #region ��k

        /// <summary>
        /// ���������e�B�檺�ާ@�t�Ϊ����C
        /// </summary>
        /// <returns><see cref="Platform"/> ���Ȥ��@�A�L��ܷ�e�B�檺�ާ@�t�Ϊ����C</returns>
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
        /// ��ܾާ@�t�Υ��x�C
        /// </summary>
        private enum Platform : byte
        {
            /// <summary>
            /// Windows 95 �ާ@�t��.
            /// </summary>
            Windows95,
            /// <summary>
            /// Windows 98 �ާ@�t��.
            /// </summary>
            Windows98,
            /// <summary>
            /// Windows 98 �ĤG���ާ@�t��.
            /// </summary>
            Windows982ndEdition,
            /// <summary>
            /// Windows ME �ާ@�t��.
            /// </summary>
            WindowsME,
            /// <summary>
            /// Windows NT 3.51 �ާ@�t��.
            /// </summary>
            WindowsNT351,
            /// <summary>
            /// Windows NT 4.0 �ާ@�t��.
            /// </summary>
            WindowsNT40,
            /// <summary>
            /// Windows 2000 �ާ@�t��.
            /// </summary>
            Windows2000,
            /// <summary>
            /// Windows XP �ާ@�t��.
            /// </summary>
            WindowsXP,
            /// <summary>
            /// Windows 2003 �ާ@�t��.
            /// </summary>
            Windows2003,
            /// <summary>
            /// Windows Vista �ާ@�t��.
            /// </summary>
            WindowsVista,
            /// <summary>
            /// Windows CE �ާ@�t��.
            /// </summary>
            WindowsCE,
            /// <summary>
            /// �ާ@�t�Ϊ��������C
            /// </summary>
            UnKnown
        }

        /// <summary>
        /// ���IDE�]�ƿ��~���A�N�X���`�q�P�ƭȪ������C
        /// </summary>
        /// <remarks>��ƭȻP�`�q�w�q�b <b>WinIoCtl.h</b> ��󤤡C</remarks>
        private enum DriverError : byte
        {
            /// <summary>
            /// �]�ƵL���~�C
            /// </summary>
            SMART_NO_ERROR = 0, // No error
            /// <summary>
            /// �]��IDE������~�C
            /// </summary>
            SMART_IDE_ERROR = 1, // Error from IDE controller
            /// <summary>
            /// �L�Ī��R�O�аO�C
            /// </summary>
            SMART_INVALID_FLAG = 2, // Invalid command flag
            /// <summary>
            /// �L�Ī��R�O�ƾڡC
            /// </summary>
            SMART_INVALID_COMMAND = 3, // Invalid command byte
            /// <summary>
            /// �w�İϵL�ġ]�p�w�İϬ��ũΦa�}���~�^�C
            /// </summary>
            SMART_INVALID_BUFFER = 4, // Bad buffer (null, invalid addr..)
            /// <summary>
            /// �]�ƽs�����~�C
            /// </summary>
            SMART_INVALID_DRIVE = 5, // Drive number not valid
            /// <summary>
            /// IOCTL���~�C
            /// </summary>
            SMART_INVALID_IOCTL = 6, // Invalid IOCTL
            /// <summary>
            /// �L�k��w�Τ᪺�w�İϡC
            /// </summary>
            SMART_ERROR_NO_MEM = 7, // Could not lock user's buffer
            /// <summary>
            /// �L�Ī�IDE���U�R�O�C
            /// </summary>
            SMART_INVALID_REGISTER = 8, // Some IDE Register not valid
            /// <summary>
            /// �L�Ī��R�O�]�m�C
            /// </summary>
            SMART_NOT_SUPPORTED = 9, // Invalid cmd flag set
            /// <summary>
            /// ���w�n�d�䪺�]�O���޸��L�ġC
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
        /// �ھګ��w���]�ƫH���ͦ��]�ƪ��ԲӫH���C
        /// </summary>
        /// <param name="phdinfo">�@�� <see cref="IdSector"/></param>
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
        /// ����bNT���x�U���w�ǦC�����w�L�H���C
        /// </summary>
        /// <param name="driveIndex">���z�ϽL���ƶq�C</param>
        /// <returns></returns>
        private static HDiskInfo GetHddInfoNT(byte driveIndex)
        {
            GetVersionOutParams vers = new GetVersionOutParams();
            SendCmdInParams inParam = new SendCmdInParams();
            SendCmdOutParams outParam = new SendCmdOutParams();
            uint bytesReturned = 0;

            // �ϥ� Win2000 �� Xp�U����k����w��H��

            // ����]�ƪ��y�`�C
            IntPtr hDevice =
                CreateFile(string.Format(@"\\.\PhysicalDrive{0}", driveIndex), GENERIC_READ | GENERIC_WRITE,
                           FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

            // �}�l�ˬd
            if(hDevice == IntPtr.Zero)
                throw new UnauthorizedAccessException("���� Win32 API ��� CreateFile ���ѡC");
            if(0 == DeviceIoControl(hDevice, SMART_GET_VERSION, IntPtr.Zero, 0, ref vers,
                (uint)Marshal.SizeOf(vers),
                ref bytesReturned,
                IntPtr.Zero))
            {
                CloseHandle(hDevice);
                throw new IOException(string.Format(ResourcesApi.Win32_DeviceIoControlErr, "SMART_GET_VERSION"));
            }
            // �˴�IDE����R�O�O�_���
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
                throw new UnauthorizedAccessException("���} smartvsd.vxd ��󥢱ѡC");
            if(0 == DeviceIoControl(hDevice, SMART_GET_VERSION, 
                IntPtr.Zero, 0, 
                ref vers, (uint)Marshal.SizeOf(vers), ref bytesReturned, IntPtr.Zero))
            {
                CloseHandle(hDevice);
                throw new IOException(string.Format(ResourcesApi.Win32_DeviceIoControlErr, "SMART_GET_VERSION"));
            }
            // �p�G IDE ��ų�w�R�O���Q�ѧO�Υ���
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
                // �˴��XIDE��ATAPI�����A�L�k�B�z
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
            // �������y�`
            CloseHandle(hDevice);
            ChangeByteOrder(outParam.bBuffer.sModelNumber);
            ChangeByteOrder(outParam.bBuffer.sSerialNumber);
            ChangeByteOrder(outParam.bBuffer.sFirmwareRev);
            return GetHardDiskInfo(outParam.bBuffer);
        }

        #endregion

        #region Win32

        /// <summary>
        /// ���o���w���f���t�ε�檺�y�`�C
        /// </summary>
        /// <param name="hwnd">���V�n����t�ε�浡�f�� <see cref="IntPtr"/> �y�`�C</param>
        /// <param name="bRevert">����t�ε�檺�覡�C�]�m�� <b>true</b>�A��ܱ�����l���t�ε��A�_�h�]�m�� <b>false</b> �C</param>
        /// <returns>���V�n������t�ε�檺 <see cref="IntPtr"/> �y�`�C</returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetSystemMenu(IntPtr hwnd, bool bRevert);

        /// <summary>
        /// ������w����椤���ء]��涵�^���ƶq�C
        /// </summary>
        /// <param name="hMenu">���V�n�����涵�ƶq���t�ε�檺 <see cref="IntPtr"/> �y�`�C</param>
        /// <returns>��椤�����ؼƶq</returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetMenuItemCount(IntPtr hMenu);

        /// <summary>
        /// �R�����w�������ءC
        /// </summary>
        /// <param name="hMenu">���V�n��������檺 <see cref="IntPtr"/> �C</param>
        /// <param name="uPosition">�����ܪ������ت����ѲšC</param>
        /// <param name="uFlags"></param>
        /// <returns>�D�s��ܦ��\�A�s��ܥ��ѡC</returns>
        /// <remarks>
        /// �p�G�b <paramref name="uFlags"/> ���ϥΤF<see cref="MF_BYPOSITION"/> �A�h�b <paramref name="uPosition"/> �Ѽƪ�ܵ�涵�����ޡF
        /// �p�G�b <paramref name="uFlags"/> ���ϥΤF <b>MF_BYCOMMAND</b>�A�h�b <paramref name="uPosition"/> ���ϥε�涵��ID�C
        /// </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int RemoveMenu(IntPtr hMenu, int uPosition, int uFlags);

        /// <summary>
        /// �����@�ӫ��w�����w�ﹳ���V���]�ơC�C
        /// </summary>
        /// <param name="hObject">�n�������y�` <see cref="IntPtr"/> ��H�C</param>
        /// <returns>���\��^ <b>0</b> �A�����\��^�D�s�ȡC</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int CloseHandle(IntPtr hObject);

        /// <summary>
        /// ���楴�}/�إ߸귽���\��C
        /// </summary>
        /// <param name="lpFileName">���w�n���}���]�ƩΤ�󪺦W�١C</param>
        /// <param name="dwDesiredAccess">
        /// <para>Win32 �`�q�A�Ω󱱨��]�ƪ�Ū�X�ݡB�g�X�ݩ�Ū/�g�X�ݪ��`�ơC���e�p�U��G
        /// <p><list type="table">
        /// <listheader>
        /// <term>�W��</term>
        /// <description>����</description>
        /// </listheader>
        /// <item>
        /// <term>GENERIC_READ</term><description>���w��]�ƶi��Ū���X�ݡC</description>
        /// </item>
        /// <item>
        /// <term>GENERIC_WRITE</term><description>���w��]�ƶi��g�X�ݡC</description>
        /// </item>
        /// <item><term><b>0</b></term><description>�p�G�Ȭ��s�A�h��ܥu���\����P�@�ӳ]�Ʀ������H���C</description></item>
        /// </list></p>
        /// </para>
        /// </param>
        /// <param name="dwShareMode">���w���}�]�Ʈɪ����@�ɼҦ�</param>
        /// <param name="lpSecurityAttributes"></param>
        /// <param name="dwCreationDisposition">Win32 �`�q�A���w�ާ@�t�Υ��}��󪺤覡�C���e�p�U��G
        /// <para><p>
        /// <list type="table">
        /// <listheader><term>�W��</term><description>����</description></listheader>
        /// <item>
        /// <term>CREATE_NEW</term>
        /// <description>���w�ާ@�t�����Ыطs���C�p�G���s�b�A�h�ߥX <see cref="IOException"/> ���`�C</description>
        /// </item>
        /// <item><term>CREATE_ALWAYS</term><description>���w�ާ@�t�����Ыطs���C�p�G���w�s�b�A���N�Q��g�C</description></item>
        /// </list>
        /// </p></para>
        /// </param>
        /// <param name="dwFlagsAndAttributes"></param>
        /// <param name="hTemplateFile"></param>
        /// <returns>�ϥΨ�ƥ��}���]�ƪ��y�`�C</returns>
        /// <remarks>
        /// ����ƥi�H���楴�}�Ϋإߤ��B���y�B�ؿ�/��󧨡B���z�ϽL�B���B�t�α���w�İϡB�ϱa�]�ơB
        /// �q�H�귽�B�l��t�ΩM�R�W�޹D�C
        /// </remarks>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode,
                                                IntPtr lpSecurityAttributes, uint dwCreationDisposition,
                                                uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        /// <summary>
        /// ��]�ư�����w���ާ@�C
        /// </summary>
        /// <param name="hDevice">�n����ާ@���]�ƥy�`�C</param>
        /// <param name="dwIoControlCode">Win32 API �`�ơA��J���O�H <b>FSCTL_</b> ���e�󪺱`�ơA�w�q�b 
        /// <b>WinIoCtl.h</b> ��󤺡A���榹������k������J <b>SMART_GET_VERSION</b> �C</param>
        /// <param name="lpInBuffer">��ѼƬ����w�ɡA�q�{����J�ȬO <b>0</b> �C</param>
        /// <param name="nInBufferSize">��J�w�İϪ��r�`�ƶq�C</param>
        /// <param name="lpOutBuffer">�@�� <b>GetVersionOutParams</b> �A��ܰ����ƫ��X���]���ˬd�C</param>
        /// <param name="nOutBufferSize">��X�w�İϪ��r�`�ƶq�C</param>
        /// <param name="lpBytesReturned">��ڸ˸����X�w�İϪ��r�`�ƶq�C</param>
        /// <param name="lpOverlapped">�P�B�ާ@����A�@�뤣�ϥΡA�q�{�Ȭ� <b>0</b> �C</param>
        /// <returns>�D�s��ܦ��\�A�s��ܥ��ѡC</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, IntPtr lpInBuffer,
                                                  uint nInBufferSize, ref GetVersionOutParams lpOutBuffer,
                                                  uint nOutBufferSize, ref uint lpBytesReturned,
                                                  [Out] IntPtr lpOverlapped);

        /// <summary>
        /// ��]�ư�����w���ާ@�C
        /// </summary>
        /// <param name="hDevice">�n����ާ@���]�ƥy�`�C</param>
        /// <param name="dwIoControlCode">Win32 API �`�ơA��J���O�H <b>FSCTL_</b> ���e�󪺱`�ơA�w�q�b 
        /// <b>WinIoCtl.h</b> ��󤺡A���榹������k������J <b>SMART_SEND_DRIVE_COMMAND</b> �� <b>SMART_RCV_DRIVE_DATA</b> �C</param>
        /// <param name="lpInBuffer">�@�� <b>SendCmdInParams</b> ���c�A���O�s�V�t�εo�e���d�߭n�D����R�O���ƾڵ��c�C</param>
        /// <param name="nInBufferSize">��J�w�İϪ��r�`�ƶq�C</param>
        /// <param name="lpOutBuffer">�@�� <b>SendCmdOutParams</b> ���c�A���O�s�t�ήھکR�O��^���]�Ƭ۫H�H���G�i��ƾڡC</param>
        /// <param name="nOutBufferSize">��X�w�İϪ��r�`�ƶq�C</param>
        /// <param name="lpBytesReturned">��ڸ˸����X�w�İϪ��r�`�ƶq�C</param>
        /// <param name="lpOverlapped">�P�B�ާ@����A�@�뤣�ϥΡA�q�{�Ȭ� <b>0</b> �C</param>
        /// <returns>�D�s��ܦ��\�A�s��ܥ��ѡC</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, ref SendCmdInParams lpInBuffer,
                                                  uint nInBufferSize, ref SendCmdOutParams lpOutBuffer,
                                                  uint nOutBufferSize, ref uint lpBytesReturned,
                                                  [Out] IntPtr lpOverlapped);

        #endregion

        #region ���c

        /// <summary>
        /// �O�s��e�p��� IDE �]�ơ]�w�L�^���w��H�������c�C
        /// </summary>
        [Serializable]
        public struct HDiskInfo
        {
            /// <summary>
            /// �w�L�����C
            /// </summary>
            public string ModuleNumber;

            /// <summary>
            /// �w�L���T�󪩥��C
            /// </summary>
            public string Firmware;

            /// <summary>
            /// �w�L�ǦC���C
            /// </summary>
            public string SerialNumber;

            /// <summary>
            /// �w�L�e�q�A�HM�����C
            /// </summary>
            public uint Capacity;
            
            /// <summary>
            /// �]�ƽw�s�j�p�]�HM�����^�C
            /// </summary>
            public int BufferSize;
        }

        /// <summary>
        /// ��ܨϥ� <b>DeviceIoControl</b> ��ƮɫO�s��^���X�ʾ��w��H�������c
        /// </summary>
        /// <remarks>>���ƾڵ��c�w�q�b <b>WinIoCtl.h</b> ���W�� <b>_GETVERSIONINPARAMS</b> ���c���C</remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct GetVersionOutParams
        {
            /// <summary>
            /// IDE�]�ƪ��G�i��w�󪩥��C
            /// </summary>
            public byte bVersion;

            /// <summary>
            /// IDE�]�ƪ��G�i��׭q�����C
            /// </summary>
            public byte bRevision;

            /// <summary>
            /// ���Ⱦާ@�t�ΨS���ϥΡA�ϥΦ��ƾڵ��c�ɳQ�]�m�� <b>0</b> �C
            /// </summary>
            public byte bReserved;

            /// <summary>
            /// IDE�]�ƪ��G�i��M�g�C
            /// </summary>
            public byte bIDEDeviceMap;

            /// <summary>
            /// IDE�]�ƪ��G�i��e�q�ƾڡC
            /// </summary>
            public uint fCapabilities;

            /// <summary>
            /// �O�d���e�A���ϥΡC
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public uint[] dwReserved; // For future use.
        }

        /// <summary>
        /// �@�Ӽƾڵ��c�A��ܨϥ� <b>DeviceIoControl</b> ��Ʈɵo�e��ާ@�t�Τ����R�O�ƾڵ��c <b>SendCmdInParams</b> ���������c�C
        /// ����ܭn����ϽL�]�Ʃʯ�Ѽƪ�����w�q�W�h�C
        /// </summary>
        /// <seealso cref="SendCmdInParams"/>
        /// <remarks>���ƾڵ��c�w�q�b <b>WinIoCtl.h</b> ���W�� <b>_IDEREGS</b> ���C</remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct IdeRegs
        {
            /// <summary>
            /// �o�e��ާ@�t�Ϊ����U�R�O�A�����t�Ϊ� <b>SMART Command</b> �C
            /// </summary>
            public byte bFeaturesReg;

            /// <summary>
            /// ���IDE�]�Ʈ��ϼơC
            /// </summary>
            public byte bSectorCountReg;

            /// <summary>
            /// ���IDE�]�ƽs���C
            /// </summary>
            public byte bSectorNumberReg;

            /// <summary>
            /// ���IDE�]�ƧC�ݬW���ȡC
            /// </summary>
            public byte bCylLowReg;

            /// <summary>
            /// ���IDE�]�ư��ݬW���ȡC
            /// </summary>
            public byte bCylHighReg;

            /// <summary>
            /// ���IDE�]�ƪ��Y�H���C
            /// </summary>
            public byte bDriveHeadReg;

            /// <summary>
            /// ���IDE�]�ƪ��u���R�O�C
            /// </summary>
            public byte bCommandReg;

            /// <summary>
            /// �O�d���e�A�������]�m�� <b>0</b> �C
            /// </summary>
            public byte bReserved;
        }

        /// <summary>
        /// �O�s���� <b>DeviceIoControl</b> ��ƮɦV�t�δ��檺����ާ@�R�O�C
        /// </summary>
        /// <seealso cref="SendCmdInParams"/>
        /// <remarks>���ƾڵ��c�w�q�b <b>WinIoCtl.h</b> ���W�� <b>_SENDCMDINPARAMS</b> ���C</remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct SendCmdInParams
        {
            /// <summary>
            /// ��X���ƾڽw�Ĥj�p�C
            /// </summary>
            public uint cBufferSize;

            /// <summary>
            /// �O�s�V�t�εo�e���ϽL�]�ƩR�O���ƾڵ��c�C
            /// </summary>
            public IdeRegs irDriveRegs;

            /// <summary>
            /// �Ʊ�t�α�����z�ϽL���s���C
            /// </summary>
            public byte bDriveNumber;

            /// <summary>
            /// �O�d���ƾڡA���ϥΡC
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] bReserved;

            /// <summary>
            /// �O�d���ƾڡA���ϥΡC
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public uint[] dwReserved;

            /// <summary>
            /// �O�s��e <b>SendCmdInParams</b> ���c��R�ƾګ᪺�j�p�C
            /// </summary>
            public byte bBuffer;
        }

        /// <summary>
        /// ����� <b>DeviceIoControl</b> ��ƫ�t�Ϊ�^�� <b>SendCmdOutParams</b> ���c��
        /// �O�s�ϽL�]�Ʒ�e���~�H�����ƾڵ��c�C
        /// </summary>
        /// <seealso cref="SendCmdInParams"/>
        /// <remarks>
        /// ���ƾڵ��c�w�q�b <b>WinIoCtl.h</b> ���W�� <b>_DRIVERSTATUS</b> ���C
        /// <para>
        /// ���~�N�X�p�U��G<br />
        /// <list type="table">
        /// <listheader>
        /// <term>�W��</term>
        /// <description>����</description>
        /// <item><term>SMART_NO_ERROR = 0</term>
        /// <description>�S�����~�C</description></item>
        /// <item><term>SMART_IDE_ERROR = 1</term>
        /// <description>IDE������~</description>�C</item>
        /// <item><term>SMART_INVALID_FLAG = 2</term>
        /// <description>�o�e���R�O�аO�L�ġC</description></item>
        /// <item><term>SMART_INVALID_COMMAND = 3</term>
        /// <description>�o�e���G�i��R�O�L�ġC</description></item>
        /// <item><term>SMART_INVALID_BUFFER = 4</term>
        /// <description>�G�i��w�s�L�ġ]�w�s���ũΪ̵L�Ħa�}�^�C</description></item>
        /// <item><term>SMART_INVALID_DRIVE = 5</term>
        /// <description>���z�X�ʾ��s���L�ġC</description></item>
        /// <item><term>SMART_INVALID_IOCTL = 6</term>
        /// <description>�L�Ī�IOCTL�C</description></item>
        /// <item><term>SMART_ERROR_NO_MEM =  7</term>
        /// <description>�ϥΪ��w�İϵL�k��w�C</description></item>
        /// <item><term>SMART_INVALID_REGISTER = 8</term>
        /// <description>IDE���U�R�O�L�ġC</description></item>
        /// <item><term>SMART_NOT_SUPPORTED = 9</term>
        /// <description>�R�O�аO�]�m�L�ġC</description></item>
        /// <item><term>SMART_NO_IDE_DEVICE = 10</term>
        /// <description>�o�e�����z�X�ʾ����޶W�L����C</description></item>
        /// </list>
        /// </para>
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct DriverStatus
        {
            /// <summary>
            /// �p�G�ˬd��IDE�]�Ƶo�Ϳ��~�A�O�s�����~�N�X�A<b>0</b> ��ܨS�����~�C
            /// </summary>
            public byte bDriverError;

            /// <summary>
            /// IDE�]�ƳQ���U�����~���e�C
            /// </summary>
            public byte bIDEStatus;

            /// <summary>
            /// �O�d���ƾڡA���ϥΡC
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] bReserved;

            /// <summary>
            /// �O�d���ƾڡA���ϥΡC
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public uint[] dwReserved;
        }

        /// <summary>
        /// ��ܷ���� <b>DeviceIoControl</b> ��ƫ�O�s�t�ήھڬd�ߩR�O��^���ϽL�]�ƫH�����ƾڵ��c�C
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct SendCmdOutParams
        {
            /// <summary>
            /// ��ܩҦ��G�i��H�����w�s�j�p�C
            /// </summary>
            public uint cBufferSize;

            /// <summary>
            /// ��ܬd�ߨ�]�ƪ����~�H�����A�C
            /// </summary>
            public DriverStatus DriverStatus;

            /// <summary>
            /// ��ܨt�Ϊ�^���]�Ƶw��H�����G�i��ƾڵ��c�C
            /// </summary>
            public IdSector bBuffer;
        }

        /// <summary>
        /// ����� <b>DeviceIoControl</b> ��ƫ�t�Ϊ�^�� <b>SendCmdOutParams</b> ���c��
        /// �O�s�ϽL�]�ƪ��w��H�����ƾڵ��c�C
        /// </summary>
        /// <seealso cref="SendCmdInParams"/>
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 512)]
        private struct IdSector
        {
            /// <summary>
            /// �]�Ƴq�ΰt�m�H���C
            /// </summary>
            public ushort wGenConfig;

            /// <summary>
            /// �]�ƪ��W���ơC
            /// </summary>
            public ushort wNumCyls;

            /// <summary>
            /// �O�d���e�A���ϥΡC
            /// </summary>
            public ushort wReserved;

            /// <summary>
            /// �]�ƪ����Y�ƥءC
            /// </summary>
            public ushort wNumHeads;

            /// <summary>
            /// �]�ƪ��ϹD�ƥءC
            /// </summary>
            public ushort wBytesPerTrack;

            /// <summary>
            /// �]�ƪ����ϼƥءC
            /// </summary>
            public ushort wBytesPerSector;

            /// <summary>
            /// �]�Ƽt�ӳ]�w�����ϺϹD�ƥءC
            /// </summary>
            public ushort wSectorsPerTrack;

            /// <summary>
            /// �]�ƪ��X�~�t�ӦW�١C
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public ushort[] wVendorUnique;

            /// <summary>
            /// �]�ƥX�~�t�Ӫ����y�ߤ@�s�X�C
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] sSerialNumber;

            /// <summary>
            /// �]�ƪ��w�s�����C
            /// </summary>
            public ushort wBufferType;

            /// <summary>
            /// �]�ƽw�s�e�q�]���Obyte�^�C
            /// </summary>
            public ushort wBufferSize;

            /// <summary>
            /// �]�ƪ����~�ˬd�M�ȥ��]ECC�^�ƾڪ��j�p�C
            /// </summary>
            public ushort wECCSize;

            /// <summary>
            /// �]�ƪ��T�󪩥��C
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] sFirmwareRev;

            /// <summary>
            /// �]�ƪ������C
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
            public byte[] sModelNumber;

            /// <summary>
            /// �]�Ƽt�ӦW�٪��X�i���e�]�p�G���^�C
            /// </summary>
            public ushort wMoreVendorUnique;

            /// <summary>
            /// �]�������O��J��X�Ҧ��C
            /// </summary>
            public ushort wDoubleWordIO;

            /// <summary>
            /// �]�ƪ��e�q�j�p�]���Byte�^�C
            /// </summary>
            public ushort wCapabilities;

            /// <summary>
            /// �Ĥ@�ӫO�d�����e�A���ϥΡC
            /// </summary>
            public ushort wReserved1;

            /// <summary>
            /// �]�ƪ�PIO�Ҧ����D�ɶ��C
            /// </summary>
            public ushort wPIOTiming;

            /// <summary>
            /// �]��DMA �Ҧ����D�ɶ��C
            /// </summary>
            public ushort wDMATiming;

            /// <summary>
            /// �]�ƪ��`�u�����A�pSCSI,IDE���C
            /// </summary>
            public ushort wBS;

            /// <summary>
            /// �]�ƪ���e�W���ƶq�C
            /// </summary>
            public ushort wNumCurrentCyls;

            /// <summary>
            /// �]�Ʒ�e���Y�ƶq�C
            /// </summary>
            public ushort wNumCurrentHeads;

            /// <summary>
            /// �]�ƪ���e���Ϫ��ϹD�ƶq�C
            /// </summary>
            public ushort wNumCurrentSectorsPerTrack;

            /// <summary>
            /// �]�ƪ���e���Ϯe�q�]���byte�^�C
            /// </summary>
            public uint ulCurrentSectorCapacity;

            /// <summary>
            /// �h����Ū�g�Ҧ�����C
            /// </summary>
            public ushort wMultSectorStuff;

            /// <summary>
            /// �Τ�O�_�i�۩w�q���Ϧa�}(LBA�Ҧ��^����C
            /// </summary>
            public uint ulTotalAddressableSectors;

            /// <summary>
            /// ����ODMA�Ҧ��C
            /// </summary>
            public ushort wSingleWordDMA;

            /// <summary>
            /// �h���ODMA�Ҧ��C
            /// </summary>
            public ushort wMultiWordDMA;

            /// <summary>
            /// �O�d���e�A���ϥΡC
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

        #region �`�q

        /// <summary>
        /// Win32 API �`�ơA���ܦb�ϥ� <see cref="RemoveMenu"/> ��Ʈɫ��w�ϥί��޼ƦӤ��O�ϥ�ID�C
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