#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.Graphics;
#endif


namespace SicCalcMaiu;

public partial class App : Application
{
	const int WindowWidth = 540;
	const int WindowHeight = 1000;
	public App()
	{
		InitializeComponent();
#if WINDOWS
         Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
		{

			var mauiWindow = handler.VirtualView;
			var natieWindow = handler.PlatformView;
			natieWindow.Activate();
			IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(natieWindow);
			WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
			AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
			appWindow.Resize(new Windows.Graphics.SizeInt32(WindowWidth, WindowHeight));


		});
#endif
		MainPage = new CalculatorPage();
	}
}
