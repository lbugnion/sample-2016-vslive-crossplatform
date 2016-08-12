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
	[Register ("Bindings8ViewController")]
	partial class Bindings8ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton MyButtonA1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel MyLabelA1 { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MyButtonA1 != null) {
				MyButtonA1.Dispose ();
				MyButtonA1 = null;
			}
			if (MyLabelA1 != null) {
				MyLabelA1.Dispose ();
				MyLabelA1 = null;
			}
		}
	}
}
