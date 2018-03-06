using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
// ReSharper disable InconsistentNaming

namespace JimsBackgroundChanger
{
    class DesktopWallpaper
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public enum DesktopSlideshowOptions
        {
            ShuffleImages = 0x01
        }

        public enum DesktopSlideshowState
        {
            Enabled = 0x01,
            Slideshow = 0x02,
            DisabledByRemoteSession = 0x04
        }

        public enum DesktopSlideshowDirection
        {
            Forward = 0,
            Backward = 1
        }

        public enum DesktopWallpaperPosition
        {
            Center = 0,
            Tile = 1,
            Stretch = 2,
            Fit = 3,
            Fill = 4,
            Span = 5
        }

        [ComImport, Guid("B92B56A9-8B55-4E14-9A89-0199BBB6F93B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDesktopWallpaper
        {
            void SetWallpaper([MarshalAs(UnmanagedType.LPWStr)] string monitorID,
                [MarshalAs(UnmanagedType.LPWStr)] string wallpaper);

            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetWallpaper([MarshalAs(UnmanagedType.LPWStr)] string monitorID);

            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetMonitorDevicePathAt(uint monitorIndex);

            [return: MarshalAs(UnmanagedType.U4)]
            uint GetMonitorDevicePathCount();

            [return: MarshalAs(UnmanagedType.Struct)]
            Rect GetMonitorRECT([MarshalAs(UnmanagedType.LPWStr)] string monitorID);

            void SetBackgroundColor([MarshalAs(UnmanagedType.U4)] uint color);

            [return: MarshalAs(UnmanagedType.U4)]
            uint GetBackgroundColor();

            void SetPosition([MarshalAs(UnmanagedType.I4)] DesktopWallpaperPosition position);

            [return: MarshalAs(UnmanagedType.I4)]
            DesktopWallpaperPosition GetPosition();

            void SetSlideshow(Wallpaper.IShellItemArray items);

            Wallpaper.IShellItemArray GetSlideshow();

            void SetSlideshowOptions(DesktopSlideshowDirection options, uint slideshowTick);

            [PreserveSig]
            uint GetSlideshowOptions(out DesktopSlideshowDirection options, out uint slideshowTick);

            [PreserveSig]
            uint AdvanceSlideshow([In] [MarshalAs(UnmanagedType.LPWStr)] string monitorID,
                [In] [MarshalAs(UnmanagedType.I4)] DesktopSlideshowDirection direction);

            DesktopSlideshowDirection GetStatus();

            bool Enable();
        }

        public class WallpaperWrapper
        {
            static readonly Guid CLSID_DesktopWallpaper = new Guid("{C2CF3110-460E-4fc1-B9D0-8A1C0C9CC4BD}");

            public static IDesktopWallpaper GetWallpaper()
            {
                Type typeDesktopWallpaper = Type.GetTypeFromCLSID(CLSID_DesktopWallpaper);
                return (IDesktopWallpaper) Activator.CreateInstance(typeDesktopWallpaper);
            }
        }
    }

    public class Wallpaper
    {
        public static void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            Settings settings = Settings.Load();
            try
            {
                Command.Run(settings.CliCommand, settings.CliArgs);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            SetSlideShow(settings, GetResolution());
        }

        public static void GetSlideShow(string[] paths)
        {
            // Load into memory
            DesktopWallpaper.IDesktopWallpaper wallpaper = DesktopWallpaper.WallpaperWrapper.GetWallpaper();
            IShellItemArray slideshow = wallpaper.GetSlideshow();
            IShellItemArray pictures = FoldersToShellItemArray(paths);

            Console.Out.WriteLine("Now: ");
            PrintShellItemArray(slideshow);
            Console.Out.WriteLine("Program: ");
            PrintShellItemArray(pictures);

            // Cleanup
            Marshal.ReleaseComObject(pictures);
            Marshal.ReleaseComObject(slideshow);
            Marshal.ReleaseComObject(wallpaper);
        }

        public static void SetWallpaper(uint id, string path)
        {
            DesktopWallpaper.IDesktopWallpaper wallpaper = DesktopWallpaper.WallpaperWrapper.GetWallpaper();

            if (id <= wallpaper.GetMonitorDevicePathCount())
            {
                string monitor = wallpaper.GetMonitorDevicePathAt(id);
                wallpaper.SetWallpaper(monitor, path);
            }

            Marshal.ReleaseComObject(wallpaper);
        }

        public static void NextWallpaper()
        {
            DesktopWallpaper.IDesktopWallpaper wallpaper = DesktopWallpaper.WallpaperWrapper.GetWallpaper();

            Console.Out.WriteLine("Mon amount: " + wallpaper.GetMonitorDevicePathCount());
            string monitor = wallpaper.GetMonitorDevicePathAt(0);
            Console.Out.WriteLine("mon id: " + monitor);
            wallpaper.AdvanceSlideshow(null, DesktopWallpaper.DesktopSlideshowDirection.Forward);

            Marshal.ReleaseComObject(wallpaper);
        }

        public static Settings.Resolution GetResolution()
        {
            Screen biggestScreen = Screen.PrimaryScreen;
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Bounds.Width*screen.Bounds.Height > biggestScreen.Bounds.Width*biggestScreen.Bounds.Height) biggestScreen = screen;
            }
            return new Settings.Resolution(biggestScreen.Bounds.Width, biggestScreen.Bounds.Height, null);
        }

        public static void SetSlideShow(Settings settings, Settings.Resolution resolution)
        {
            DesktopWallpaper.IDesktopWallpaper wallpaper = DesktopWallpaper.WallpaperWrapper.GetWallpaper();

            try
            {
                IShellItemArray pictures =
                    FoldersToShellItemArray(settings.Resolutions.Find(res => res.Equals(resolution))?.Folders
                        .ToArray());
                if (pictures == null) throw new Exception("No resolution found");
                wallpaper.SetSlideshow(pictures);
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                Marshal.ReleaseComObject(wallpaper);
            }
        }
        
        public enum SIGDN : UInt32
        {
            SIGDN_NORMALDISPLAY = 0x00000000,
            SIGDN_PARENTRELATIVEPARSING = 0x80018001,
            SIGDN_DESKTOPABSOLUTEPARSING = 0x80028000,
            SIGDN_PARENTRELATIVEEDITING = 0x80031001,
            SIGDN_DESKTOPABSOLUTEEDITING = 0x8004c000,
            SIGDN_FILESYSPATH = 0x80058000,
            SIGDN_URL = 0x80068000,
            SIGDN_PARENTRELATIVEFORADDRESSBAR = 0x8007c001,
            SIGDN_PARENTRELATIVE = 0x80080001,
            SIGDN_PARENTRELATIVEFORUI = 0x80094001
        }

        public enum SICHINTF : UInt32
        {
            SICHINT_DISPLAY = 0x00000000,
            SICHINT_ALLFIELDS = 0x80000000,
            SICHINT_CANONICAL = 0x10000000,
            SICHINT_TEST_FILESYSPATH_IF_NOT_EQUAL = 0x20000000
        }

        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
        public interface IShellItem
        {
            // Not supported: IBindCtx.
            [PreserveSig]
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            int BindToHandler(
                [In] IntPtr pbc,
                [In] ref Guid bhid,
                [In] ref Guid riid,
                [Out, MarshalAs(UnmanagedType.Interface)] out IntPtr ppv);

            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            void GetParent([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetDisplayName([In] SIGDN sigdnName);

            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            void GetAttributes([In] SFGAOF sfgaoMask, out SFGAOF psfgaoAttribs);

            [PreserveSig]
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            int Compare(
                [In, MarshalAs(UnmanagedType.Interface)] IShellItem psi,
                [In] SICHINTF hint,
                out int piOrder);
        }

        public enum SIATTRIBFLAGS
        {
            SIATTRIBFLAGS_AND = 0x00000001,
            SIATTRIBFLAGS_OR = 0x00000002,
            SIATTRIBFLAGS_APPCOMPAT = 0x00000003,
            SIATTRIBFLAGS_MASK = 0x00000003,
            SIATTRIBFLAGS_ALLITEMS = 0x00004000
        }

        public enum SFGAOF : long
        {
            SFGAO_CANCOPY = 0x00000001L,
            SFGAO_CANMOVE = 0x00000002L,
            SFGAO_CANLINK = 0x00000004L,
            SFGAO_STORAGE = 0x00000008L,
            SFGAO_CANRENAME = 0x00000010L,
            SFGAO_CANDELETE = 0x00000020L,
            SFGAO_HASPROPSHEET = 0x00000040L,
            SFGAO_DROPTARGET = 0x00000100L,
            SFGAO_CAPABILITYMASK = 0x00000177L,
            SFGAO_SYSTEM = 0x00001000L,
            SFGAO_ENCRYPTED = 0x00002000L,
            SFGAO_ISSLOW = 0x00004000L,
            SFGAO_GHOSTED = 0x00008000L,
            SFGAO_LINK = 0x00010000L,
            SFGAO_SHARE = 0x00020000L,
            SFGAO_READONLY = 0x00040000L,
            SFGAO_HIDDEN = 0x00080000L,
            SFGAO_DISPLAYATTRMASK = 0x000FC000L,
            SFGAO_FILESYSANCESTOR = 0x10000000L,
            SFGAO_FOLDER = 0x20000000L,
            SFGAO_FILESYSTEM = 0x40000000L,
            SFGAO_HASSUBFOLDER = 0x80000000L,
            SFGAO_CONTENTSMASK = 0x80000000L,
            SFGAO_VALIDATE = 0x01000000L,
            SFGAO_REMOVABLE = 0x02000000L,
            SFGAO_COMPRESSED = 0x04000000L,
            SFGAO_BROWSABLE = 0x08000000L,
            SFGAO_NONENUMERATED = 0x00100000L,
            SFGAO_NEWCONTENT = 0x00200000L,
            SFGAO_CANMONIKER = 0x00400000L,
            SFGAO_HASSTORAGE = 0x00400000L,
            SFGAO_STREAM = 0x00400000L,
            SFGAO_STORAGEANCESTOR = 0x00800000L,
            SFGAO_STORAGEGAPMASK = 0x70C50008L,
            SFGAO_PKEYSFGAOMASK = 0x81044000L
        }

        public struct PROPERTYKEY
        {
            public Guid fmtid;
            public UInt32 pid;
        }

        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("b63ea76d-1f85-456f-a19c-48159efa858b")]
        public interface IShellItemArray
        {
            // Not supported: IBindCtx.
            [PreserveSig]
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            int BindToHandler(
                [In, MarshalAs(UnmanagedType.Interface)] IntPtr pbc,
                [In] ref Guid rbhid,
                [In] ref Guid riid,
                out IntPtr ppvOut);

            [PreserveSig]
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            int GetPropertyStore(
                [In] int Flags,
                [In] ref Guid riid,
                out IntPtr ppv);

            [PreserveSig]
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            int GetPropertyDescriptionList(
                [In] ref PROPERTYKEY keyType,
                [In] ref Guid riid,
                out IntPtr ppv);

            [PreserveSig]
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            int GetAttributes(
                [In] SIATTRIBFLAGS dwAttribFlags,
                [In] SFGAOF sfgaoMask,
                out SFGAOF psfgaoAttribs);

            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            uint GetCount();

            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            IShellItem GetItemAt([In] uint dwIndex);

            // Not supported: IEnumShellItems (will use GetCount and GetItemAt instead).
            [PreserveSig]
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            int EnumItems([MarshalAs(UnmanagedType.Interface)] out IntPtr ppenumShellItems);
        }

        public static void PrintShellItemArray(IShellItemArray shellItemArray)
        {
            for (uint i = 0; i < shellItemArray.GetCount(); i++)
            {
                IShellItem si = shellItemArray.GetItemAt(i);
                Console.Out.WriteLine(si.GetDisplayName(SIGDN.SIGDN_FILESYSPATH));
                Marshal.ReleaseComObject(si);
            }
        }

        public static IShellItemArray FoldersToShellItemArray(string[] paths)
        {
            if (paths == null) return null;
            foreach (string path in paths)
            {
                if (!Directory.Exists(path)) throw new ArgumentException("The path does not exist.");
            }

            List<string> files = new List<string>();

            foreach (string path in paths)
            {
                string[] shortFiles = Directory.GetFiles(path);
                foreach (string file in shortFiles)
                {
                    if (IsImage(file)) files.Add(file);
                }
            }

            IntPtr[] PDILArr = new IntPtr[files.Count];

            for (int i = 0; i < files.Count; i++)
            {
                PDILArr[i] = ILCreateFromPath(files[i]);
            }

            SHCreateShellItemArrayFromIDLists((uint) files.Count, PDILArr, out var siArr);

            return siArr;
        }

        public static bool IsImage(string file)
        {
            if (!File.Exists(file)) throw new ArgumentException("Image doesn't exist.");
            Stream stream = new FileStream(file, FileMode.Open);
            stream.Seek(0, SeekOrigin.Begin);

            List<string> jpg = new List<string> {"FF", "D8"};
            List<string> bmp = new List<string> {"42", "4D"};
            List<string> gif = new List<string> {"47", "49", "46"};
            List<string> png = new List<string> {"89", "50", "4E", "47", "0D", "0A", "1A", "0A"};
            List<List<string>> imgTypes = new List<List<string>> {jpg, bmp, gif, png};

            List<string> bytesIterated = new List<string>();

            for (int i = 0; i < 8; i++)
            {
                string bit = stream.ReadByte().ToString("X2");
                bytesIterated.Add(bit);

                bool isImage = imgTypes.Any(img => !img.Except(bytesIterated).Any());
                if (isImage)
                {
                    stream.Close();
                    return true;
                }
            }
            stream.Close();
            return false;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = true)]
        private static extern void SHCreateShellItemArrayFromIDLists(
            [In] uint cidl,
            [In] IntPtr[] rgpidl,
            [Out] out IShellItemArray ppsiItemArray);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = true)]
        private static extern IntPtr ILCreateFromPath([In] [MarshalAs(UnmanagedType.LPWStr)] string pszPath);
    }
}