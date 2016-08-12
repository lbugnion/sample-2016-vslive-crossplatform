// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamBindingSample
{
	[Register ("Commands1ViewController")]
	partial class Commands1ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch MySwitch { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SimpleCommandButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton StaticParameterButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MySwitch != null) {
				MySwitch.Dispose ();
				MySwitch = null;
			}
			if (SimpleCommandButton != null) {
				SimpleCommandButton.Dispose ();
				SimpleCommandButton = null;
			}
			if (StaticParameterButton != null) {
				StaticParameterButton.Dispose ();
				StaticParameterButton = null;
			}
		}
	}
}
