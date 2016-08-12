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
	[Register ("BindingsViewController")]
	partial class BindingsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton MyButtonA1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel MyLabelB1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch MySwitchA1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch MySwitchC1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch MySwitchC2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField MyTextFieldB1 { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MyButtonA1 != null) {
				MyButtonA1.Dispose ();
				MyButtonA1 = null;
			}
			if (MyLabelB1 != null) {
				MyLabelB1.Dispose ();
				MyLabelB1 = null;
			}
			if (MySwitchA1 != null) {
				MySwitchA1.Dispose ();
				MySwitchA1 = null;
			}
			if (MySwitchC1 != null) {
				MySwitchC1.Dispose ();
				MySwitchC1 = null;
			}
			if (MySwitchC2 != null) {
				MySwitchC2.Dispose ();
				MySwitchC2 = null;
			}
			if (MyTextFieldB1 != null) {
				MyTextFieldB1.Dispose ();
				MyTextFieldB1 = null;
			}
		}
	}
}
