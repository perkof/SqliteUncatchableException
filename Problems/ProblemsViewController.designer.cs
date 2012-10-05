// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Problems
{
	[Register ("ProblemsViewController")]
	partial class ProblemsViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel lblCount { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnStart { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnStop { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblCount != null) {
				lblCount.Dispose ();
				lblCount = null;
			}

			if (btnStart != null) {
				btnStart.Dispose ();
				btnStart = null;
			}

			if (btnStop != null) {
				btnStop.Dispose ();
				btnStop = null;
			}
		}
	}
}
