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
	[Register ("Bindings5ViewController")]
	partial class Bindings5ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch MySwitchA1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField MyTextFieldA1 { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MySwitchA1 != null) {
				MySwitchA1.Dispose ();
				MySwitchA1 = null;
			}
			if (MyTextFieldA1 != null) {
				MyTextFieldA1.Dispose ();
				MyTextFieldA1 = null;
			}
		}
	}
}
