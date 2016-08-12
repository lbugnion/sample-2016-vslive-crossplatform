// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using System.CodeDom.Compiler;
using Foundation;
using UIKit;

namespace ObservableListApple
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton CollectionViewCircleButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton CollectionViewGridButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton TableSourceWithReuseIdButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CollectionViewCircleButton != null) {
				CollectionViewCircleButton.Dispose ();
				CollectionViewCircleButton = null;
			}
			if (CollectionViewGridButton != null) {
				CollectionViewGridButton.Dispose ();
				CollectionViewGridButton = null;
			}
			if (TableSourceWithReuseIdButton != null) {
				TableSourceWithReuseIdButton.Dispose ();
				TableSourceWithReuseIdButton = null;
			}
		}
	}
}
