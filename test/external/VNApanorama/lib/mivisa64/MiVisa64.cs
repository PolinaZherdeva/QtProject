using System;
using System.Runtime.InteropServices;
using System.Text;

using ViUInt16 = System.UInt16;
using ViUInt32 = System.UInt32;

namespace MiVisa
{
	internal sealed class Visa
	{
		// --------------------------------------------------------------------------------
		//  Adapted from visa32.bas which was distributed by VXIplug&play Systems Alliance
		// --------------------------------------------------------------------------------
		//  Title   : mivisa.cs
		//  Purpose : VISA definitions for C#
		// -------------------------------------------------------------------------
		public const int VI_SPEC_VERSION = 4194304;

		#region - Resource Template Functions and Operations ----------------------------
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#141", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus OpenDefaultRM(out ViSession sesn);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#128", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus GetDefaultRM(out ViSession sesn);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#129", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus FindRsrc(ViSession sesn, string expr, out ViSession vi, out ViUInt32 retCount, StringBuilder desc);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#130", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus FindNext(ViSession vi, StringBuilder desc);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#146", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus ParseRsrc(ViSession sesn, string desc, ref ViIntfType intfType, ref ViUInt16 intfNum);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#147", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus ParseRsrcEx(ViSession sesn, string desc, ref ViIntfType intfType, ref ViUInt16 intfNum, StringBuilder rsrcClass, StringBuilder expandedUnaliasedName, StringBuilder aliasIfExists);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#131", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Open(ViSession sesn, string viDesc, ViAccessMode mode, ViUInt32 timeout, out ViSession vi);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#132", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Close(ViSession vi);

		#region viGetAttribute Overloads
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#133", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus GetAttribute(ViSession vi, ViAttr attrName, out byte attrValue);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#133", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus GetAttribute(ViSession vi, ViAttr attrName, out short attrValue);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#133", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus GetAttribute(ViSession vi, ViAttr attrName, out int attrValue);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#133", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus GetAttribute(ViSession vi, ViAttr attrName, StringBuilder attrValue);
		#endregion

		#region viSetAttribute Overloads
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#134", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus SetAttribute(ViSession vi, ViAttr attrName, byte attrValue);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#134", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus SetAttribute(ViSession vi, ViAttr attrName, short attrValue);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#134", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus SetAttribute(ViSession vi, ViAttr attrName, int attrValue);
		#endregion

		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#142", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus StatusDesc(ViSession vi, ViStatus status, StringBuilder desc);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#143", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Terminate(ViSession vi, short degree, ViJobId jobId);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#144", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Lock(ViSession vi, ViAccessMode lockType, int timeout, string requestedKey, StringBuilder accessKey);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#145", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Unlock(ViSession vi);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#135", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus EnableEvent(ViSession vi, ViEventType eventType, short mechanism, int context);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#136", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus DisableEvent(ViSession vi, ViEventType eventType, short mechanism);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#137", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus DiscardEvents(ViSession vi, ViEventType eventType, short mechanism);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#138", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus WaitOnEvent(ViSession vi, ViEventType inEventType, ViUInt32 timeout, ref ViEventType outEventType, ref int outEventContext);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#139", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus InstallHandler(ViSession vi, ViEventType eventType, object handler, int UserHandle);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#140", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus UninstallHandler(ViSession vi, ViEventType eventType, object handler, int userHandle);
		#endregion

		#region - Basic I/O Operations --------------------------------------------------
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#256", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Read(ViSession vi, byte[] buffer, ViUInt32 count, out ViUInt32 retCount);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#277", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus ReadAsync(ViSession vi, byte[] buffer, ViUInt32 count, out ViJobId jobId);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#219", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus ReadToFile(ViSession vi, string filename, ViUInt32 count, ref ViUInt32 retCount);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#257", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Write(ViSession vi, byte[] buffer, ViUInt32 count, out ViUInt32 retCount);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#278", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus WriteAsync(ViSession vi, byte[] buffer, ViUInt32 count, out ViJobId jobId);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#218", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus WriteFromFile(ViSession vi, string filename, ViUInt32 count, ref ViUInt32 retCount);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#258", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus AssertTrigger(ViSession vi, ViUInt16 protocol);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#259", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus ReadSTB(ViSession vi, ref ViUInt16 status);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#260", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Clear(ViSession vi);
		#endregion

		#region - Formatted and Buffered I/O Operations ---------------------------------
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#267", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus SetBuf(ViSession vi, ViUInt16 mask, ViUInt32 bufSize);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#268", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Flush(ViSession vi, ViUInt16 mask);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#202", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus BufWrite(ViSession vi, byte[] buffer, ViUInt32 count, out ViUInt32 retCount);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#203", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus BufRead(ViSession vi, byte[] buffer, ViUInt32 count, out ViUInt32 retCount);

		#region viPrintf Overloads
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#269", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Printf(ViSession vi, string writeFmt);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#269", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Printf(ViSession vi, string writeFmt, int[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#269", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Printf(ViSession vi, string writeFmt, short[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#269", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Printf(ViSession vi, string writeFmt, float[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#269", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Printf(ViSession vi, string writeFmt, double[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#269", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Printf(ViSession vi, string writeFmt, byte[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#269", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Printf(ViSession vi, string writeFmt, string arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#269", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Printf(ViSession vi, string writeFmt, int arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#269", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Printf(ViSession vi, string writeFmt, short arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#269", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Printf(ViSession vi, string writeFmt, double arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#269", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Printf(ViSession vi, string writeFmt, byte arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#269", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Printf(ViSession vi, string writeFmt, __arglist);
		#endregion

		#region viSPrintf Overloads
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#204", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SPrintf(ViSession vi, StringBuilder buffer, string writeFmt);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#204", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SPrintf(ViSession vi, StringBuilder buffer, string writeFmt, int[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#204", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SPrintf(ViSession vi, StringBuilder buffer, string writeFmt, short[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#204", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SPrintf(ViSession vi, StringBuilder buffer, string writeFmt, float[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#204", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SPrintf(ViSession vi, StringBuilder buffer, string writeFmt, double[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#204", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SPrintf(ViSession vi, StringBuilder buffer, string writeFmt, byte[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#204", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SPrintf(ViSession vi, StringBuilder buffer, string writeFmt, string arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#204", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SPrintf(ViSession vi, StringBuilder buffer, string writeFmt, int arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#204", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SPrintf(ViSession vi, StringBuilder buffer, string writeFmt, short arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#204", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SPrintf(ViSession vi, StringBuilder buffer, string writeFmt, double arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#204", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SPrintf(ViSession vi, StringBuilder buffer, string writeFmt, byte arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#204", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SPrintf(ViSession vi, StringBuilder buffer, string writeFmt, __arglist);
		#endregion

		#region viScanf Overloads
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, int[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, short[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, float[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, double[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, byte[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, ref int count, int[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, ref int count, short[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, ref int count, float[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, ref int count, double[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, ref int count, byte[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, StringBuilder arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, ref int stringSize, StringBuilder arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, out int arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, out short arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, out float arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, out double arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, out byte arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#271", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Scanf(ViSession vi, string readFmt, __arglist);

		#endregion

		#region viSScanf Overloads
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, int[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, short[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, float[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, double[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, byte[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, ref int count, int[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, ref int count, short[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, ref int count, float[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, ref int count, double[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, ref int count, byte[] arr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, StringBuilder arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, ref int stringSize, StringBuilder arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, out int arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, out short arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, out float arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, out double arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, out byte arg);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#206", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus SScanf(ViSession vi, string buffer, string readFmt, __arglist);
		#endregion

		#region viQueryf Overloads
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#279", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		public static extern ViStatus Queryf(ViSession vi, string writeFmt, string readFmt, __arglist);
		#endregion

		#endregion

		#region - Memory I/O Operations -------------------------------------------------
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#273", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus In8(ViSession vi, short accSpace, int offset, out byte val8);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#274", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Out8(ViSession vi, short accSpace, int offset, byte val8);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#261", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus In16(ViSession vi, short accSpace, int offset, out short val16);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#262", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Out16(ViSession vi, short accSpace, int offset, short val16);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#281", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus In32(ViSession vi, short accSpace, int offset, out int val32);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#282", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Out32(ViSession vi, short accSpace, int offset, int val32);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#283", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveIn8(ViSession vi, short accSpace, int offset, int length, byte[] buf8);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#284", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveOut8(ViSession vi, short accSpace, int offset, int length, byte[] buf8);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#285", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveIn16(ViSession vi, short accSpace, int offset, int length, short[] buf16);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#286", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveOut16(ViSession vi, short accSpace, int offset, int length, short[] buf16);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#287", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveIn32(ViSession vi, short accSpace, int offset, int length, int[] buf32);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#288", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveOut32(ViSession vi, short accSpace, int offset, int length, int[] buf32);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#200", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Move(ViSession vi, short srcSpace, int srcOffset, short srcWidth, short destSpace, int destOffset, short destWidth, int srcLength);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#201", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveAsync(ViSession vi, short srcSpace, int srcOffset, short srcWidth, short destSpace, int destOffset, short destWidth, int srcLength, out ViJobId jobId);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#263", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MapAddress(ViSession vi, short mapSpace, int mapOffset, int mapSize, short accMode, int suggested, out int address);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#264", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus UnmapAddress(ViSession vi);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#275", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern void Peek8(ViSession vi, int address, out byte val8);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#276", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern void Poke8(ViSession vi, int address, byte val8);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#265", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern void Peek16(ViSession vi, int address, out short val16);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#266", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern void Poke16(ViSession vi, int address, short val16);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#289", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern void Peek32(ViSession vi, int address, out int val32);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#290", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern void Poke32(ViSession vi, int address, int val32);

		#region 64-bit Extension Functions
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#220", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus In64(ViSession vi, short accSpace, int offset, out long val64);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#221", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Out64(ViSession vi, short accSpace, int offset, long val64);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#222", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus In8Ex(ViSession vi, short accSpace, long offset, out byte val8);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#223", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Out8Ex(ViSession vi, short accSpace, long offset, byte val8);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#224", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus In16Ex(ViSession vi, short accSpace, long offset, out short val16);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#225", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Out16Ex(ViSession vi, short accSpace, long offset, short val16);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#226", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus In32Ex(ViSession vi, short accSpace, long offset, out int val32);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#227", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Out32Ex(ViSession vi, short accSpace, long offset, int val32);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#228", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus In64Ex(ViSession vi, short accSpace, long offset, out long val64);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#229", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus Out64Ex(ViSession vi, short accSpace, long offset, long val64);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#230", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveIn64(ViSession vi, short accSpace, int offset, int length, long[] buf64);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#231", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveOut64(ViSession vi, short accSpace, int offset, int length, long[] buf64);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#232", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveIn8Ex(ViSession vi, short accSpace, long offset, int length, byte[] buf8);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#233", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveOut8Ex(ViSession vi, short accSpace, long offset, int length, byte[] buf8);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#234", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveIn16Ex(ViSession vi, short accSpace, long offset, int length, short[] buf16);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#235", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveOut16Ex(ViSession vi, short accSpace, long offset, int length, short[] buf16);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#236", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveIn32Ex(ViSession vi, short accSpace, long offset, int length, int[] buf32);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#237", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveOut32Ex(ViSession vi, short accSpace, long offset, int length, int[] buf32);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#238", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveIn64Ex(ViSession vi, short accSpace, long offset, int length, long[] buf64);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#239", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveOut64Ex(ViSession vi, short accSpace, long offset, int length, long[] buf64);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#240", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveEx(ViSession vi, short srcSpace, long srcOffset, short srcWidth, short destSpace, long destOffset, short destWidth, int srcLength);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#241", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MoveAsyncEx(ViSession vi, short srcSpace, long srcOffset, short srcWidth, short destSpace, long destOffset, short destWidth, int srcLength, out ViJobId jobId);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#242", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MapAddressEx(ViSession vi, short mapSpace, long mapOffset, int mapSize, short accMode, int suggested, out int address);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#243", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MemAllocEx(ViSession vi, int memSize, out long offset);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#244", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MemFreeEx(ViSession vi, long offset);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#245", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern void Peek64(ViSession vi, int address, out long val64);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#246", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern void Poke64(ViSession vi, int address, long val64);
		#endregion
		#endregion

		#region - Shared Memory Operations ----------------------------------------------
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#291", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MemAlloc(ViSession vi, int memSize, out int offset);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#292", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MemFree(ViSession vi, int offset);
		#endregion

		#region - Interface Specific Operations -----------------------------------------
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#208", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus GpibControlREN(ViSession vi, short mode);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#210", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus GpibControlATN(ViSession vi, short mode);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#211", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus GpibSendIFC(ViSession vi);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#212", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus GpibCommand(ViSession vi, string buffer, int count, out int retCount);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#213", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus GpibPassControl(ViSession vi, short primAddr, short secAddr);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#209", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus VxiCommandQuery(ViSession vi, short mode, int devCmd, out int devResponse);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#214", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus AssertUtilSignal(ViSession vi, short line);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#215", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus AssertIntrSignal(ViSession vi, short mode, int statusID);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#216", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus MapTrigger(ViSession vi, short trigSrc, short trigDest, short mode);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#217", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus UnmapTrigger(ViSession vi, short trigSrc, short trigDest);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#293", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus UsbControlOut(ViSession vi, short bmRequestType, short bRequest, short wValue, short wIndex, short wLength, byte[] buf);
		[DllImportAttribute("MIVISA64.DLL", EntryPoint = "#294", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern ViStatus UsbControlIn(ViSession vi, short bmRequestType, short bRequest, short wValue, short wIndex, short wLength, byte[] buf, out short retCnt);
		#endregion

		#region - Constants -----------------------------------------------------
		#region - VISA Definitions ------------------------------------------------------

		public const short VI_FIND_BUFLEN = 256;
		public const short VI_NULL = 0;
		public const short VI_TRUE = 1;
		public const short VI_FALSE = 0;

		public const short VI_PROT_NORMAL = 1;
		public const short VI_PROT_FDC = 2;
		public const short VI_PROT_HS488 = 3;
		public const short VI_PROT_4882_STRS = 4;
		public const short VI_PROT_USBTMC_VENDOR = 5;
		public const short VI_FDC_NORMAL = 1;
		public const short VI_FDC_STREAM = 2;
		public const short VI_LOCAL_SPACE = 0;
		public const short VI_A16_SPACE = 1;
		public const short VI_A24_SPACE = 2;
		public const short VI_A32_SPACE = 3;
		public const short VI_OPAQUE_SPACE = -1;
		public const short VI_UNKNOWN_LA = -1;
		public const short VI_UNKNOWN_SLOT = -1;
		public const short VI_UNKNOWN_LEVEL = -1;
		public const short VI_QUEUE = 1;
		public const short VI_ALL_MECH = -1;

		public const short VI_TRIG_ALL = -2;
		public const short VI_TRIG_SW = -1;
		public const short VI_TRIG_TTL0 = 0;
		public const short VI_TRIG_TTL1 = 1;
		public const short VI_TRIG_TTL2 = 2;
		public const short VI_TRIG_TTL3 = 3;
		public const short VI_TRIG_TTL4 = 4;
		public const short VI_TRIG_TTL5 = 5;
		public const short VI_TRIG_TTL6 = 6;
		public const short VI_TRIG_TTL7 = 7;
		public const short VI_TRIG_ECL0 = 8;
		public const short VI_TRIG_ECL1 = 9;
		public const short VI_TRIG_PANEL_IN = 27;
		public const short VI_TRIG_PANEL_OUT = 28;

		public const short VI_TRIG_PROT_DEFAULT = 0;
		public const short VI_TRIG_PROT_ON = 1;
		public const short VI_TRIG_PROT_OFF = 2;
		public const short VI_TRIG_PROT_SYNC = 5;

		public const short VI_READ_BUF = 1;
		public const short VI_WRITE_BUF = 2;
		public const short VI_READ_BUF_DISCARD = 4;
		public const short VI_WRITE_BUF_DISCARD = 8;
		public const short VI_IO_IN_BUF = 16;
		public const short VI_IO_OUT_BUF = 32;
		public const short VI_IO_IN_BUF_DISCARD = 64;
		public const short VI_IO_OUT_BUF_DISCARD = 128;
		public const short VI_FLUSH_ON_ACCESS = 1;
		public const short VI_FLUSH_WHEN_FULL = 2;
		public const short VI_FLUSH_DISABLE = 3;
		public const short VI_NMAPPED = 1;
		public const short VI_USE_OPERS = 2;
		public const short VI_DEREF_ADDR = 3;
		public const int VI_TMO_IMMEDIATE = 0;
		public const int VI_TMO_INFINITE = -1;
		public const short VI_NO_SEC_ADDR = -1;
		public const short VI_ASRL_PAR_NONE = 0;
		public const short VI_ASRL_PAR_ODD = 1;
		public const short VI_ASRL_PAR_EVEN = 2;
		public const short VI_ASRL_PAR_MARK = 3;
		public const short VI_ASRL_PAR_SPACE = 4;
		public const short VI_ASRL_STOP_ONE = 10;
		public const short VI_ASRL_STOP_ONE5 = 15;
		public const short VI_ASRL_STOP_TWO = 20;
		public const short VI_ASRL_FLOW_NONE = 0;
		public const short VI_ASRL_FLOW_XON_XOFF = 1;
		public const short VI_ASRL_FLOW_RTS_CTS = 2;
		public const short VI_ASRL_FLOW_DTR_DSR = 4;
		public const short VI_ASRL_END_NONE = 0;
		public const short VI_ASRL_END_LAST_BIT = 1;
		public const short VI_ASRL_END_TERMCHAR = 2;
		public const short VI_ASRL_END_BREAK = 3;
		public const short VI_STATE_ASSERTED = 1;
		public const short VI_STATE_UNASSERTED = 0;
		public const short VI_STATE_UNKNOWN = -1;
		public const short VI_BIG_ENDIAN = 0;
		public const short VI_LITTLE_ENDIAN = 1;
		public const short VI_DATA_PRIV = 0;
		public const short VI_DATA_NPRIV = 1;
		public const short VI_PROG_PRIV = 2;
		public const short VI_PROG_NPRIV = 3;
		public const short VI_BLCK_PRIV = 4;
		public const short VI_BLCK_NPRIV = 5;
		public const short VI_D64_PRIV = 6;
		public const short VI_D64_NPRIV = 7;
		public const short VI_WIDTH_8 = 1;
		public const short VI_WIDTH_16 = 2;
		public const short VI_WIDTH_32 = 4;
		public const short VI_GPIB_REN_DEASSERT = 0;
		public const short VI_GPIB_REN_ASSERT = 1;
		public const short VI_GPIB_REN_DEASSERT_GTL = 2;
		public const short VI_GPIB_REN_ASSERT_ADDRESS = 3;
		public const short VI_GPIB_REN_ASSERT_LLO = 4;
		public const short VI_GPIB_REN_ASSERT_ADDRESS_LLO = 5;
		public const short VI_GPIB_REN_ADDRESS_GTL = 6;
		public const short VI_GPIB_ATN_DEASSERT = 0;
		public const short VI_GPIB_ATN_ASSERT = 1;
		public const short VI_GPIB_ATN_DEASSERT_HANDSHAKE = 2;
		public const short VI_GPIB_ATN_ASSERT_IMMEDIATE = 3;
		public const short VI_GPIB_HS488_DISABLED = 0;
		public const short VI_GPIB_HS488_NIMPL = -1;
		public const short VI_GPIB_UNADDRESSED = 0;
		public const short VI_GPIB_TALKER = 1;
		public const short VI_GPIB_LISTENER = 2;
		public const short VI_VXI_CMD16 = 512;
		public const short VI_VXI_CMD16_RESP16 = 514;
		public const short VI_VXI_RESP16 = 2;
		public const short VI_VXI_CMD32 = 1024;
		public const short VI_VXI_CMD32_RESP16 = 1026;
		public const short VI_VXI_CMD32_RESP32 = 1028;
		public const short VI_VXI_RESP32 = 4;
		public const short VI_ASSERT_SIGNAL = -1;
		public const short VI_ASSERT_USE_ASSIGNED = 0;
		public const short VI_ASSERT_IRQ1 = 1;
		public const short VI_ASSERT_IRQ2 = 2;
		public const short VI_ASSERT_IRQ3 = 3;
		public const short VI_ASSERT_IRQ4 = 4;
		public const short VI_ASSERT_IRQ5 = 5;
		public const short VI_ASSERT_IRQ6 = 6;
		public const short VI_ASSERT_IRQ7 = 7;
		public const short VI_UTIL_ASSERT_SYSRESET = 1;
		public const short VI_UTIL_ASSERT_SYSFAIL = 2;
		public const short VI_UTIL_DEASSERT_SYSFAIL = 3;
		public const short VI_VXI_CLASS_MEMORY = 0;
		public const short VI_VXI_CLASS_EXTENDED = 1;
		public const short VI_VXI_CLASS_MESSAGE = 2;
		public const short VI_VXI_CLASS_REGISTER = 3;
		public const short VI_VXI_CLASS_OTHER = 4;
		#endregion
		#region - Backward Compatibility Macros -----------------------------------------
		public const int VI_ERROR_INV_SESSION = -1073807346;
		public const int VI_INFINITE = -1;
		public const short VI_NORMAL = 1;
		public const short VI_FDC = 2;
		public const short VI_HS488 = 3;
		public const short VI_ASRL488 = 4;
		public const short VI_ASRL_IN_BUF = 16;
		public const short VI_ASRL_OUT_BUF = 32;
		public const short VI_ASRL_IN_BUF_DISCARD = 64;
		public const short VI_ASRL_OUT_BUF_DISCARD = 128;
		#endregion
		#endregion

	}
	#region - Enums -----------------------------------------------------------

	#region - Job ID definition -----------------------------------------------------
	public enum ViJobId : int
	{
		VI_NULL
	}
	#endregion
	#region - Session definition ----------------------------------------------------
	public enum ViSession : int
	{
		VI_NULL
	}
	#endregion
	#region - Attributes ------------------------------------------------------------
	public enum ViAttr : int
	{
		VI_ATTR_RSRC_CLASS = -1073807359,
		VI_ATTR_RSRC_NAME = -1073807358,
		VI_ATTR_RSRC_IMPL_VERSION = 1073676291,
		VI_ATTR_RSRC_LOCK_STATE = 1073676292,
		VI_ATTR_MAX_QUEUE_LENGTH = 1073676293,
		VI_ATTR_USER_DATA = 1073676295,
		VI_ATTR_FDC_CHNL = 1073676301,
		VI_ATTR_FDC_MODE = 1073676303,
		VI_ATTR_FDC_GEN_SIGNAL_EN = 1073676305,
		VI_ATTR_FDC_USE_PAIR = 1073676307,
		VI_ATTR_SEND_END_EN = 1073676310,
		VI_ATTR_TERMCHAR = 1073676312,
		VI_ATTR_TMO_VALUE = 1073676314,
		VI_ATTR_GPIB_READDR_EN = 1073676315,
		VI_ATTR_IO_PROT = 1073676316,
		VI_ATTR_DMA_ALLOW_EN = 1073676318,
		VI_ATTR_ASRL_BAUD = 1073676321,
		VI_ATTR_ASRL_DATA_BITS = 1073676322,
		VI_ATTR_ASRL_PARITY = 1073676323,
		VI_ATTR_ASRL_STOP_BITS = 1073676324,
		VI_ATTR_ASRL_FLOW_CNTRL = 1073676325,
		VI_ATTR_RD_BUF_OPER_MODE = 1073676330,
		VI_ATTR_RD_BUF_SIZE = 1073676331,
		VI_ATTR_WR_BUF_OPER_MODE = 1073676333,
		VI_ATTR_WR_BUF_SIZE = 1073676334,
		VI_ATTR_SUPPRESS_END_EN = 1073676342,
		VI_ATTR_TERMCHAR_EN = 1073676344,
		VI_ATTR_DEST_ACCESS_PRIV = 1073676345,
		VI_ATTR_DEST_BYTE_ORDER = 1073676346,
		VI_ATTR_SRC_ACCESS_PRIV = 1073676348,
		VI_ATTR_SRC_BYTE_ORDER = 1073676349,
		VI_ATTR_SRC_INCREMENT = 1073676352,
		VI_ATTR_DEST_INCREMENT = 1073676353,
		VI_ATTR_WIN_ACCESS_PRIV = 1073676357,
		VI_ATTR_WIN_BYTE_ORDER = 1073676359,
		VI_ATTR_GPIB_ATN_STATE = 1073676375,
		VI_ATTR_GPIB_ADDR_STATE = 1073676380,
		VI_ATTR_GPIB_CIC_STATE = 1073676382,
		VI_ATTR_GPIB_NDAC_STATE = 1073676386,
		VI_ATTR_GPIB_SRQ_STATE = 1073676391,
		VI_ATTR_GPIB_SYS_CNTRL_STATE = 1073676392,
		VI_ATTR_GPIB_HS488_CBL_LEN = 1073676393,
		VI_ATTR_CMDR_LA = 1073676395,
		VI_ATTR_VXI_DEV_CLASS = 1073676396,
		VI_ATTR_MAINFRAME_LA = 1073676400,
		VI_ATTR_MANF_NAME = -1073807246,
		VI_ATTR_MODEL_NAME = -1073807241,
		VI_ATTR_VXI_VME_INTR_STATUS = 1073676427,
		VI_ATTR_VXI_TRIG_STATUS = 1073676429,
		VI_ATTR_VXI_VME_SYSFAIL_STATE = 1073676436,
		VI_ATTR_WIN_BASE_ADDR = 1073676440,
		VI_ATTR_WIN_SIZE = 1073676442,
		VI_ATTR_ASRL_AVAIL_NUM = 1073676460,
		VI_ATTR_MEM_BASE = 1073676461,
		VI_ATTR_ASRL_CTS_STATE = 1073676462,
		VI_ATTR_ASRL_DCD_STATE = 1073676463,
		VI_ATTR_ASRL_DSR_STATE = 1073676465,
		VI_ATTR_ASRL_DTR_STATE = 1073676466,
		VI_ATTR_ASRL_END_IN = 1073676467,
		VI_ATTR_ASRL_END_OUT = 1073676468,
		VI_ATTR_ASRL_REPLACE_CHAR = 1073676478,
		VI_ATTR_ASRL_RI_STATE = 1073676479,
		VI_ATTR_ASRL_RTS_STATE = 1073676480,
		VI_ATTR_ASRL_XON_CHAR = 1073676481,
		VI_ATTR_ASRL_XOFF_CHAR = 1073676482,
		VI_ATTR_WIN_ACCESS = 1073676483,
		VI_ATTR_RM_SESSION = 1073676484,
		VI_ATTR_VXI_LA = 1073676501,
		VI_ATTR_MANF_ID = 1073676505,
		VI_ATTR_MEM_SIZE = 1073676509,
		VI_ATTR_MEM_SPACE = 1073676510,
		VI_ATTR_MODEL_CODE = 1073676511,
		VI_ATTR_SLOT = 1073676520,
		VI_ATTR_INTF_INST_NAME = -1073807127,
		VI_ATTR_IMMEDIATE_SERV = 1073676544,
		VI_ATTR_INTF_PARENT_NUM = 1073676545,
		VI_ATTR_RSRC_SPEC_VERSION = 1073676656,
		VI_ATTR_INTF_TYPE = 1073676657,
		VI_ATTR_GPIB_PRIMARY_ADDR = 1073676658,
		VI_ATTR_GPIB_SECONDARY_ADDR = 1073676659,
		VI_ATTR_RSRC_MANF_NAME = -1073806988,
		VI_ATTR_RSRC_MANF_ID = 1073676661,
		VI_ATTR_INTF_NUM = 1073676662,
		VI_ATTR_TRIG_ID = 1073676663,
		VI_ATTR_GPIB_REN_STATE = 1073676673,
		VI_ATTR_GPIB_UNADDR_EN = 1073676676,
		VI_ATTR_DEV_STATUS_BYTE = 1073676681,
		VI_ATTR_FILE_APPEND_EN = 1073676690,
		VI_ATTR_VXI_TRIG_SUPPORT = 1073676692,
		VI_ATTR_TCPIP_ADDR = -1073806955,
		VI_ATTR_TCPIP_HOSTNAME = -1073806954,
		VI_ATTR_TCPIP_PORT = 1073676695,
		VI_ATTR_TCPIP_DEVICE_NAME = -1073806951,
		VI_ATTR_TCPIP_NODELAY = 1073676698,
		VI_ATTR_TCPIP_KEEPALIVE = 1073676699,
		VI_ATTR_4882_COMPLIANT = 1073676703,
		VI_ATTR_USB_SERIAL_NUM = -1073806944,
		VI_ATTR_USB_INTFC_NUM = 1073676705,
		VI_ATTR_USB_PROTOCOL = 1073676711,
		VI_ATTR_USB_MAX_INTR_SIZE = 1073676719,
		VI_ATTR_JOB_ID = 1073692678,
		VI_ATTR_EVENT_TYPE = 1073692688,
		VI_ATTR_SIGP_STATUS_ID = 1073692689,
		VI_ATTR_RECV_TRIG_ID = 1073692690,
		VI_ATTR_INTR_STATUS_ID = 1073692707,
		VI_ATTR_STATUS = 1073692709,
		VI_ATTR_RET_COUNT = 1073692710,
		VI_ATTR_BUFFER = 1073692711,
		VI_ATTR_RECV_INTR_LEVEL = 1073692737,
		VI_ATTR_OPER_NAME = -1073790910,
		VI_ATTR_GPIB_RECV_CIC_STATE = 1073693075,
		VI_ATTR_RECV_TCPIP_ADDR = -1073790568,
		VI_ATTR_USB_RECV_INTR_SIZE = 1073693104,
		VI_ATTR_USB_RECV_INTR_DATA = -1073790543
	}
	#endregion
	#region - Event Types -----------------------------------------------------------
	public enum ViEventType : int
	{
		VI_EVENT_IO_COMPLETION = 1073684489,
		VI_EVENT_TRIG = -1073799158,
		VI_EVENT_SERVICE_REQ = 1073684491,
		VI_EVENT_CLEAR = 1073684493,
		VI_EVENT_EXCEPTION = -1073799154,
		VI_EVENT_GPIB_CIC = 1073684498,
		VI_EVENT_GPIB_TALK = 1073684499,
		VI_EVENT_GPIB_LISTEN = 1073684500,
		VI_EVENT_VXI_VME_SYSFAIL = 1073684509,
		VI_EVENT_VXI_VME_SYSRESET = 1073684510,
		VI_EVENT_VXI_SIGP = 1073684512,
		VI_EVENT_VXI_VME_INTR = -1073799135,
		VI_EVENT_TCPIP_CONNECT = 1073684534,
		VI_EVENT_USB_INTR = 1073684535,
		VI_ALL_ENABLED_EVENTS = 1073709055
	}
	#endregion
	#region - Completion and Error Codes --------------------------------------------
	public enum ViStatus : int
	{
		VI_SUCCESS = 0,
		VI_SUCCESS_EVENT_EN = 1073676290,
		VI_SUCCESS_EVENT_DIS = 1073676291,
		VI_SUCCESS_QUEUE_EMPTY = 1073676292,
		VI_SUCCESS_TERM_CHAR = 1073676293,
		VI_SUCCESS_MAX_CNT = 1073676294,
		VI_SUCCESS_DEV_NPRESENT = 1073676413,
		VI_SUCCESS_TRIG_MAPPED = 1073676414,
		VI_SUCCESS_QUEUE_NEMPTY = 1073676416,
		VI_SUCCESS_NCHAIN = 1073676440,
		VI_SUCCESS_NESTED_SHARED = 1073676441,
		VI_SUCCESS_NESTED_EXCLUSIVE = 1073676442,
		VI_SUCCESS_SYNC = 1073676443,
		VI_WARN_QUEUE_OVERFLOW = 1073676300,
		VI_WARN_CONFIG_NLOADED = 1073676407,
		VI_WARN_NULL_OBJECT = 1073676418,
		VI_WARN_NSUP_ATTR_STATE = 1073676420,
		VI_WARN_UNKNOWN_STATUS = 1073676421,
		VI_WARN_NSUP_BUF = 1073676424,
		VI_WARN_EXT_FUNC_NIMPL = 1073676457,
		VI_ERROR_SYSTEM_ERROR = -1073807360,
		VI_ERROR_INV_OBJECT = -1073807346,
		VI_ERROR_RSRC_LOCKED = -1073807345,
		VI_ERROR_INV_EXPR = -1073807344,
		VI_ERROR_RSRC_NFOUND = -1073807343,
		VI_ERROR_INV_RSRC_NAME = -1073807342,
		VI_ERROR_INV_ACC_MODE = -1073807341,
		VI_ERROR_TMO = -1073807339,
		VI_ERROR_CLOSING_FAILED = -1073807338,
		VI_ERROR_INV_DEGREE = -1073807333,
		VI_ERROR_INV_JOB_ID = -1073807332,
		VI_ERROR_NSUP_ATTR = -1073807331,
		VI_ERROR_NSUP_ATTR_STATE = -1073807330,
		VI_ERROR_ATTR_READONLY = -1073807329,
		VI_ERROR_INV_LOCK_TYPE = -1073807328,
		VI_ERROR_INV_ACCESS_KEY = -1073807327,
		VI_ERROR_INV_EVENT = -1073807322,
		VI_ERROR_INV_MECH = -1073807321,
		VI_ERROR_HNDLR_NINSTALLED = -1073807320,
		VI_ERROR_INV_HNDLR_REF = -1073807319,
		VI_ERROR_INV_CONTEXT = -1073807318,
		VI_ERROR_NENABLED = -1073807313,
		VI_ERROR_ABORT = -1073807312,
		VI_ERROR_RAW_WR_PROT_VIOL = -1073807308,
		VI_ERROR_RAW_RD_PROT_VIOL = -1073807307,
		VI_ERROR_OUTP_PROT_VIOL = -1073807306,
		VI_ERROR_INP_PROT_VIOL = -1073807305,
		VI_ERROR_BERR = -1073807304,
		VI_ERROR_IN_PROGRESS = -1073807303,
		VI_ERROR_INV_SETUP = -1073807302,
		VI_ERROR_QUEUE_ERROR = -1073807301,
		VI_ERROR_ALLOC = -1073807300,
		VI_ERROR_INV_MASK = -1073807299,
		VI_ERROR_IO = -1073807298,
		VI_ERROR_INV_FMT = -1073807297,
		VI_ERROR_NSUP_FMT = -1073807295,
		VI_ERROR_LINE_IN_USE = -1073807294,
		VI_ERROR_NSUP_MODE = -1073807290,
		VI_ERROR_SRQ_NOCCURRED = -1073807286,
		VI_ERROR_INV_SPACE = -1073807282,
		VI_ERROR_INV_OFFSET = -1073807279,
		VI_ERROR_INV_WIDTH = -1073807278,
		VI_ERROR_NSUP_OFFSET = -1073807276,
		VI_ERROR_NSUP_VAR_WIDTH = -1073807275,
		VI_ERROR_WINDOW_NMAPPED = -1073807273,
		VI_ERROR_RESP_PENDING = -1073807271,
		VI_ERROR_NLISTENERS = -1073807265,
		VI_ERROR_NCIC = -1073807264,
		VI_ERROR_NSYS_CNTLR = -1073807263,
		VI_ERROR_NSUP_OPER = -1073807257,
		VI_ERROR_INTR_PENDING = -1073807256,
		VI_ERROR_ASRL_PARITY = -1073807254,
		VI_ERROR_ASRL_FRAMING = -1073807253,
		VI_ERROR_ASRL_OVERRUN = -1073807252,
		VI_ERROR_TRIG_NMAPPED = -1073807250,
		VI_ERROR_NSUP_ALIGN_OFFSET = -1073807248,
		VI_ERROR_USER_BUF = -1073807247,
		VI_ERROR_RSRC_BUSY = -1073807246,
		VI_ERROR_NSUP_WIDTH = -1073807242,
		VI_ERROR_INV_PARAMETER = -1073807240,
		VI_ERROR_INV_PROT = -1073807239,
		VI_ERROR_INV_SIZE = -1073807237,
		VI_ERROR_WINDOW_MAPPED = -1073807232,
		VI_ERROR_NIMPL_OPER = -1073807231,
		VI_ERROR_INV_LENGTH = -1073807229,
		VI_ERROR_INV_MODE = -1073807215,
		VI_ERROR_SESN_NLOCKED = -1073807204,
		VI_ERROR_MEM_NSHARED = -1073807203,
		VI_ERROR_LIBRARY_NFOUND = -1073807202,
		VI_ERROR_NSUP_INTR = -1073807201,
		VI_ERROR_INV_LINE = -1073807200,
		VI_ERROR_FILE_ACCESS = -1073807199,
		VI_ERROR_FILE_IO = -1073807198,
		VI_ERROR_NSUP_LINE = -1073807197,
		VI_ERROR_NSUP_MECH = -1073807196,
		VI_ERROR_INTF_NUM_NCONFIG = -1073807195,
		VI_ERROR_CONN_LOST = -1073807194
	}
	#endregion
	#region - Interface types -------------------------------------------------------
	public enum ViIntfType : short
	{
		VI_INTF_GPIB = 1,
		VI_INTF_VXI = 2,
		VI_INTF_GPIB_VXI = 3,
		VI_INTF_ASRL = 4,
		VI_INTF_PXI = 4,
		VI_INTF_TCPIP = 6,
		VI_INTF_USB = 7
	}
	#endregion
	#region - Access modes ----------------------------------------------------------
	[FlagsAttribute]
	public enum ViAccessMode : short
	{
		VI_NO_LOCK = 0,
		VI_EXCLUSIVE_LOCK = 1,
		VI_SHARED_LOCK = 2,
		VI_LOAD_CONFIG = 4
	}
	#endregion
	#endregion
}
