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
	[Register ("Bindings7ViewController")]
	partial class Bindings7ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel MyLabelA1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView MyTextViewA1 { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MyLabelA1 != null) {
				MyLabelA1.Dispose ();
				MyLabelA1 = null;
			}
			if (MyTextViewA1 != null) {
				MyTextViewA1.Dispose ();
				MyTextViewA1 = null;
			}
		}
	}
}
