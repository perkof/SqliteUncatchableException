using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Timers;

namespace Problems
{
	public partial class ProblemsViewController : UIViewController
	{
		public ProblemsViewController () : base ("ProblemsViewController", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

		}

		void OnTimerElapsed (object sender, ElapsedEventArgs e)
		{
			InvokeOnMainThread(delegate {
				try{
					var items = SqlLiteHelper.GetQuery();
					lblCount.Text = items.Count().ToString();
				} catch (Exception ex)
				{
					Console.WriteLine(string.Format("This should catch the exception: {0}", ex));
				}
			});
		}

		void Start (object sender, EventArgs e)
		{
			btnStop.Enabled = true;
			SqlLiteHelper.StartCreatingRecords();
		}

		void Stop (object sender, EventArgs e)
		{
			btnStart.Enabled = true;
			SqlLiteHelper.StopCreatingRecords();
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.

			var sqlLite = SqlLiteHelper.GetConnection();

			var timer = new Timer
			{
				AutoReset = true,
				Interval = 0.7 * 1000,
			};

			timer.Elapsed += OnTimerElapsed;
			timer.Start();

			btnStart.TouchDown += Start;
			btnStop.TouchDown += Stop;

			btnStop.Enabled = false;

		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

