using System.Collections.Generic;

namespace yield
{
	public static class ExpSmoothingTask
	{
		public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
		{
			var e = data.GetEnumerator();
            double middle;

            if (e.MoveNext())
            {
				middle = e.Current.ExpSmoothedY = e.Current.OriginalY;
			}
				
			else
            {
				yield break;
            }
				
			yield return e.Current;

			while (e.MoveNext())
			{
				e.Current.ExpSmoothedY = alpha * e.Current.OriginalY + (1 - alpha) * middle;
				yield return e.Current;
				middle = e.Current.ExpSmoothedY;
			}
		}
	}
}


