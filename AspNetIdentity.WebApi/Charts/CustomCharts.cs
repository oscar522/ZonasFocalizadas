using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.DataVisualization.Charting;

namespace AspNetIdentity.WebApi.Charts
{
    public static class CustomCharts
    {
        public static byte[] Chart(List<XY> xYs)
        {
            var chart = new Chart
              {
                Width = 1000,
                Height = 750,
                RenderType = RenderType.ImageTag,
                AntiAliasing = AntiAliasingStyles.All,
                TextAntiAliasingQuality = TextAntiAliasingQuality.High
            };

            chart.Titles.Add("Puntajes por dimensión");
            chart.Titles[0].Font = new Font("Arial", 16f);

            chart.ChartAreas.Add("");
            chart.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12f);
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12f);
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;

            chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12f);
            chart.ChartAreas[0].AxisY.Maximum = 100;
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Interval = 25;
            chart.ChartAreas[0].BackColor = Color.White;

            chart.Series.Add("");
            chart.Series[0].ChartType = SeriesChartType.Column;

            for(int i = 0; i < xYs.Count; i++)
            {
                chart.Series[0].Points.AddXY(xYs[i].xValue, xYs[i].yValue);
                chart.Series[0].Points[i].Color = Color.FromArgb(xYs[i].rgbColor["r"], xYs[i].rgbColor["g"], xYs[i].rgbColor["b"]);
            }
            
            

            using (var chartimage = new MemoryStream())
            {
                chart.SaveImage(chartimage, ChartImageFormat.Png);
                return chartimage.GetBuffer();
            }
        }
    }

    public class XY
    {
        public string xValue { get; set; }
        public float yValue { get; set; }
        public Dictionary<string,int> rgbColor { get; set; }
    }
}