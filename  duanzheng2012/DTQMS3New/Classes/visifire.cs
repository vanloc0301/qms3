using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace DTQMS3New.Classes
{
    public class visifire
    {
        public string type = "Column";
        public int width = 300;
        public int height = 300;
        public string doc;
        public string title;
        public bool doublerow=false;
        public string xtitle;
        public bool view3d;
        private string View3d;
        public string ytitle;
        public double[] data;
        public double[] data2;
        public string[] column;
        public string s1;
        public string s2;
        public int len;
        static string head = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">"
                            + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">"
                            + "<html xmlns=\"http://www.w3.org/1999/xhtml\">\n"
                            + "<head>\n"
                            + "<title>This is my first Visifire Chart</title>\n"
                            + "<script type=\"text/javascript\" src=\"Visifire.js\"></script>\n"
                            + "</head>\n"
                            + "<body>\n"
                            + "<div id=\"VisifireChart0\" >"
                            + "<script type=\"text/javascript\" >";
        static string end = "vChart.setDataXml(chartXml);"
                            + "vChart.render(\"VisifireChart0\");"
                            + "</script>"
                            + "</div>"
                            + "</body>"
                            + "</html>";
        public void setType(string typeD)
        {
            this.type = typeD;
            genDoc();
        }
        public void reSize(int widthD, int heightD)
        {
            this.height = heightD;
            this.width = widthD;
            genDoc();
        }
        public void settitle(string titleD, string xtitleD, string ytitleD)
        {
            this.title = titleD;
            this.xtitle = xtitleD;
            this.ytitle = ytitleD;
        }
        public void setData(string[] columnD, double[] dataD, int lenD)
        {
            this.column = columnD;
            this.data = dataD;
            this.len = lenD;
            genDoc();
        }
        public void setData2(double[] dataD2)
        {
            this.data2 = dataD2;
            this.doublerow = true;
            genDoc();
        }
        public void set3D(bool triD)
        {
            if (triD)
                this.View3d = " View3D=\"True\" ";
            else
                this.View3d = " ";
        }
        private string genXml()
        {
            if (len <= 0)
                return "";
            string xml = "";
            xml += "<vc:Chart xmlns:vc=\"clr-namespace:Visifire.Charts;assembly=SLVisifire.Charts\" Width=\"" + (this.width - 15).ToString() + "\" Height=\"" + (this.height - 15).ToString() + "\" BorderThickness=\"0\" Theme=\"Theme1\" " + this.View3d + " ToolBarEnabled=\"True\">";
            xml += "<vc:Chart.Titles>";
            xml += "<vc:Title Text=\"" + this.title + "\" />";
            xml += "</vc:Chart.Titles>";
            xml += "<vc:Chart.AxesX>";
            xml += "<vc:Axis Title=\"" + this.xtitle + "\"/>";
            xml += "</vc:Chart.AxesX>";
            xml += "<vc:Chart.AxesY>";
            xml += "<vc:Axis Title=\"" + this.ytitle + "\" />   ";
            xml += "</vc:Chart.AxesY>";
            xml += "<vc:Chart.Series>";
            xml += "<vc:DataSeries LegendText=\""+s1+"\" RenderAs=\"" + this.type + "\" AxisYType=\"Primary\" >";
            xml += "<vc:DataSeries.DataPoints>";
                for (int i = 0; i < this.len; i++)
                    xml += "<vc:DataPoint AxisXLabel=\"" + this.column[i] + "\" YValue=\"" + this.data[i] + "\" />";

            xml += "</vc:DataSeries.DataPoints>"
                        + "</vc:DataSeries>";
                        if(this.doublerow)
                        {
                            xml += "<vc:DataSeries LegendText=\""+s2+"\" RenderAs=\"" + this.type + "\" AxisYType=\"Primary\" >";
                             xml += "<vc:DataSeries.DataPoints>";
                                 for (int i = 0; i < this.len; i++)
                                     xml += "<vc:DataPoint AxisXLabel=\"" + this.column[i] + "\" YValue=\"" + this.data2[i] + "\" />";

                                 xml += "</vc:DataSeries.DataPoints>"
                                  + "</vc:DataSeries>";
                        }
                  xml  += "</vc:Chart.Series>"
                + "</vc:Chart>";

            return xml;


        }
        private void genDoc()
        {
            string xml = genXml();
            string size = "var vChart = new Visifire('SL.Visifire.Charts.xap', \"MyChart\", " + (this.width - 15) + ", " + (this.height - 15) + ");"
                           + "var chartXml = '";
            doc = head + size + xml + "';" + end;
        }
        public Uri displayChart()
        {
            FileStream fs = new FileStream("chart/" + this.title + ".htm", FileMode.Create);

            byte[] data = new UTF8Encoding().GetBytes(this.doc);

            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
            genDoc();
            string str = System.AppDomain.CurrentDomain.BaseDirectory;
            Uri url = new Uri(str + "chart/" + this.title + ".htm");
            return url;
        }
        public Uri refresh()
        {
            FileStream fs = new FileStream("chart/" + this.title + ".htm", FileMode.Create);

            byte[] data = new UTF8Encoding().GetBytes(this.doc);

            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
            string str = System.AppDomain.CurrentDomain.BaseDirectory;
            Uri url = new Uri(str + "chart/" + this.title + ".htm");
            return url;


        }
    }
}
