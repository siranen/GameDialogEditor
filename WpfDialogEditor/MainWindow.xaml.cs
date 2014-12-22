using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace WpfDialogEditor
{
    /// <summary>
    /// MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        private string file;

        /// <summary>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                FileNameTextBox.Text = filename;

                Paragraph paragraph = new Paragraph();
                paragraph.Inlines.Add(System.IO.File.ReadAllText(filename));
                FlowDocument document = new FlowDocument(paragraph);
                FlowDocReader.Document = document;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                FileNameTextBox.Text = filename;

                Paragraph paragraph = new Paragraph();
                paragraph.Inlines.Add(System.IO.File.ReadAllText(filename));
                FlowDocument document = new FlowDocument(paragraph);
                FlowDocReader.Document = document;
            }
//treeView.ItemsSource = new XMLHeaderLogic[];

            XMLHeaderLogic.FromXml(System.IO.File.ReadAllText(file));
        }
        }
    



public class XMLHeaderLogic
        {
    private IEnumerable<XMLHeaderLogic> _children;


    private const string ATTR_FORMAT = "{0} = {1}";





            public string Header { get; private set; }



            public string Type { get; private set; }


    public IEnumerable<XMLHeaderLogic> Children
    {
        get { return _children; }
        private set { _children = value; }
    }


    private XMLHeaderLogic(string header, string type, IEnumerable<XMLHeaderLogic> children)
            {

                Header = header;

                Type = type;

                Children = children;

            }





            public static XMLHeaderLogic FromXml(string xml)
            {

                if (xml == null)
                {

                    throw new ArgumentNullException("xml");

                }

                var xmldoc = new XmlDocument();

                xmldoc.LoadXml(xml);

                return FromXmlElement(xmldoc.DocumentElement);

            }





            private static XMLHeaderLogic FromXmlElement(XmlNode node)
            {



                var children = node.ChildNodes.Cast<XmlNode>()

                    .Select(n => FromXmlElement(n))

                    .Where(n => n != null);



                string header;

                switch (node.NodeType)
                {

                    case XmlNodeType.Text:

                    case XmlNodeType.CDATA:

                    case XmlNodeType.Comment:

                        header = node.Value.Trim();

                        break;

                    case XmlNodeType.Element:

                        header = node.Name;

                        break;

                    default:

                        return null;

                }



                if (node.Attributes != null)
                {

                    var attrs = node.Attributes.Cast<XmlNode>()

                        .Select(n => new XMLHeaderLogic(

                            String.Format(ATTR_FORMAT, n.Name, n.Value),

                            XmlNodeType.Attribute.ToString(),

                            null));

                    children = attrs.Concat(children);

                }



                return new XMLHeaderLogic(header, node.NodeType.ToString(), children);

            }

        }
    }
