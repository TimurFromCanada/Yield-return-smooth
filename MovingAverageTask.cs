using System.Collections.Generic;

namespace yield
{
    public static class MovingAverageTask
    {
        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
        {
            var average = 0.0;
            Queue<double> queue = new Queue<double>();

            foreach (var e in data)
            {
                queue.Enqueue(e.OriginalY);
                average += e.OriginalY;

                if (windowWidth >= queue.Count)
                {
                    e.AvgSmoothedY = average / queue.Count;
                }
                    
                else
                {
                    average -= queue.Dequeue();
                    e.AvgSmoothedY = average / queue.Count;
                }

                yield return e;
            }
        }
    }
}