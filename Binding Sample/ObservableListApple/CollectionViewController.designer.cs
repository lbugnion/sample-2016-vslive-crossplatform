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
	[Register ("CollectionViewController")]
	partial class CollectionViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UICollectionView MyTable { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MyTable != null) {
				MyTable.Dispose ();
				MyTable = null;
			}
		}
	}
}
