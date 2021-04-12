using System.Collections.Generic;

namespace yield
{
    public static class MovingMaxTask
    {
        public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
        {
            var points = new LinkedList<double>();
            var xPoints = new Queue<double>();

            foreach (var point in data)
            {
                xPoints.Enqueue(point.X);

                if (xPoints.Count > windowWidth && points.First.Value <= xPoints.Dequeue())
                {
                    points.RemoveFirst();
                    points.RemoveFirst();
                }

                while (points.Count != 0 && points.Last.Value < point.OriginalY)
                {
                    points.RemoveLast();
                    points.RemoveLast();
                }

                points.AddLast(point.X);
                points.AddLast(point.OriginalY);
                point.MaxY = points.First.Next.Value;

                yield return point;
            }
        }
    }
}

