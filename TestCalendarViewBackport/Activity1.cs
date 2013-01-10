using System;

using Android.App;
using Android.Widget;
using Android.OS;
using CalendarView=Net.Simonvt.Widget.CalendarView;

namespace TestCalendarViewBackport
{
	[Activity (Label = "TestCalendarViewBackport", MainLauncher = true)]
	public class Activity1 : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.main);

			var cal = FindViewById<CalendarView>(Resource.Id.net_simonvt_widget_CalendarView1);
			var textView = FindViewById<TextView>(Resource.Id.myText);

			cal.DateChange += (sender, e) => {
				var date = new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc)
					.AddMilliseconds(cal.Date)
						.ToLocalTime();
				textView.Text = string.Format(
					"You selected: {0}-{1}-{2} ({3})", 
					e.Year, e.Month+1, e.DayOfMonth,
					date.ToShortDateString());
			};
		}
	}
}


