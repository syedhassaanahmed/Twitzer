









 
//------------------------------------------------------------------------------
//     Add a global shortcut in MSVS for beeing able to generate this file after 
//     you modify localization strings from resource files use:
//     MENU / TOOLS / OPTIONS / Keyboard
//     Add Command 'Build.TransformAllT4Templates' with shortcut Ctrl+Shift+Alt+T
//------------------------------------------------------------------------------

using Windows.ApplicationModel.Resources; 

namespace Twitzer.Strings
{
    public class LocalizedStrings
	{
		static readonly ResourceLoader ResourceLoader = ResourceLoader.GetForViewIndependentUse(); 	
  
		public string EmptyListError => ResourceLoader.GetString("EmptyListError");
  
		public string RefreshLabel => ResourceLoader.GetString("RefreshLabel");
  
		public string TodayDate => ResourceLoader.GetString("TodayDate");
 
	}
}

