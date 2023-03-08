

using Android.Views;
using AndroidX.Core.View;

namespace SicCalcMaiu;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
		{
#if WINDOWS
			var mauiWindow = handler.VirtualView;
			var natieWindow = handler.PlatformView;
			natieWindow.Activate();
			IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(natieWindow);
			WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
			AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
			appWindow.Resize(new SizeInt32(WindowWith, WindowHeight))
#endif

		});

		MainPage = new AppShell();
	}
}
