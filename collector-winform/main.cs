using System;
using System.Configuration;
using System.Windows.Forms;
using api_parser;

namespace collector_winform
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            Parser parser = new Parser(ConfigurationManager.AppSettings["MeteostatApiKey"], ConfigurationManager.AppSettings["MeteostatHost"], station:"89055");
            MessageBox.Show(parser.GetContent());
            Console.WriteLine(parser.GetContent());
        }
    }
}
