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
	[Register ("Commands3ViewController")]
	partial class Commands3ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton DynamicParameterButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField MyTextField { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (DynamicParameterButton != null) {
				DynamicParameterButton.Dispose ();
				DynamicParameterButton = null;
			}
			if (MyTextField != null) {
				MyTextField.Dispose ();
				MyTextField = null;
			}
		}
	}
}
