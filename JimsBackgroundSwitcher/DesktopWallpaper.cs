using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

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

            void SetSlideshow(IntPtr items);

            IntPtr GetSlideshow();

            void SetSlideshowOptions(DesktopSlideshowDirection options, uint slideshowTick);

            [PreserveSig]
            uint GetSlideshowOptions(out DesktopSlideshowDirection options, out uint slideshowTick);

            void AdvanceSlideshow([MarshalAs(UnmanagedType.LPWStr)] string monitorID,
                [MarshalAs(UnmanagedType.I4)] DesktopSlideshowDirection direction);

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
            foreach (Screen screen in Screen.AllScreens)
            {
                int width = screen.Bounds.Width;
                int height = screen.Bounds.Height;

                string resolution = width + "x" + height;
                Console.Out.WriteLine(resolution);
            }
        }

        public static void GetSlideShow()
        {
            DesktopWallpaper.IDesktopWallpaper wallpaper = DesktopWallpaper.WallpaperWrapper.GetWallpaper();

            var slideshowPointer = wallpaper.GetSlideshow();

            var arr = Marshal.GetObjectForIUnknown(slideshowPointer);

            var shellArr = (IShellItemArray) arr;
            IntPtr item0Pointer;
            shellArr.GetItemAt(1, out item0Pointer);

            var item0Raw = Marshal.GetObjectForIUnknown(item0Pointer);
            var item0 = (IShellItem) item0Raw;

            Console.Out.WriteLine(item0.GetDisplayName(SIGDN.SIGDN_URL));

            Marshal.ReleaseComObject(arr);

            Marshal.ReleaseComObject(item0Raw);

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

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
        public interface IShellItem
        {
            void BindToHandler(IBindCtx pbc, REFGUID rbhid, Guid riid);
            void Compare(IShellItem psi, SICHINTF hint, int piOrder);
            SFGAOF GetAttributes(SFGAOF sfgaoMask);
            void GetParent(IntPtr ppsi);

            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetDisplayName(SIGDN sigdnName);
        }

        public struct REFGUID
        {
            public static Guid BHID_SFUIObject = new Guid("3981E225-F559-11D3-8E3A-00C04F6837D5");
            public static Guid BHID_DataObject = new Guid("B8C0BD9F-ED24-455C-83E6-D5390C4FE8C4");
            public static Guid BHID_AssociationArray = new Guid("BEA9EF17-82F1-4F60-9284-4F8DB75C3BE9");
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

        public enum GETPROPERTYSTOREFLAGS
        {
            GPS_DEFAULT = 0,
            GPS_HANDLERPROPERTIESONLY = 0x1,
            GPS_READWRITE = 0x2,
            GPS_TEMPORARY = 0x4,
            GPS_FASTPROPERTIESONLY = 0x8,
            GPS_OPENSLOWITEM = 0x10,
            GPS_DELAYCREATION = 0x20,
            GPS_BESTEFFORT = 0x40,
            GPS_NO_OPLOCK = 0x80,
            GPS_PREFERQUERYPROPERTIES = 0x100,
            GPS_MASK_VALID = 0x1ff,
            GPS_EXTRINSICPROPERTIES = 0x00000200,
            GPS_EXTRINSICPROPERTIESONLY = 0x00000400
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("b63ea76d-1f85-456f-a19c-48159efa858b")]
        public interface IShellItemArray
        {
            void BindToHandler(IBindCtx pbc, REFGUID rbhid, Guid riid);
            IntPtr EnumItems();
            SFGAOF GetAttributes(SIATTRIBFLAGS dwAttribFlags, SFGAOF sfgaoMask);
            UInt32 GetCount();
            uint GetItemAt(UInt32 dwIndex, out IntPtr ppsi);
            void GetPropertyDescriptionList(PROPERTYKEY keyType, Guid riid);
            void GetPropertyStoreFlags(GETPROPERTYSTOREFLAGS flags, Guid riid);
        }
    }
}