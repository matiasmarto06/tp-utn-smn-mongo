using System;
using System.Windows.Forms;
using api_parser;

namespace collector_winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Parser parser = new Parser();
            MessageBox.Show(parser.GetContent());
            Console.WriteLine(parser.GetContent());
        }
    }
}
