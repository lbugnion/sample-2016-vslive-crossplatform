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
	[Register ("Commands2ViewController")]
	partial class Commands2ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField MyTextField { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MyTextField != null) {
				MyTextField.Dispose ();
				MyTextField = null;
			}
		}
	}
}
