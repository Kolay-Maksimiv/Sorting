using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModel
{
    public class LineChartViewMode
    {
        public string Name { get; set; }
        public List<NameValueViewMode> Series { get; set; }
    }

    public class NameValueViewMode
    {
        public double Value { get; set; }
        public double Name { get; set; }
    }

    public class LineChartResponce<T>
    {
        public List<T> Data { get; set; }
        public int Total { get; set; }
    }
}
