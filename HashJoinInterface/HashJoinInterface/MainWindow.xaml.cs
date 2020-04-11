using System;
using System.Collections.Generic;
using System.IO;
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

namespace HashJoinInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*data members********************************************************************************/
        public TableManager tableManager;
        private OuterTable selectedOuterTable;
        private InnerTable selectedInnerTable;
        private string selectedR1Attribute;
        private string selectedR2Attribute;

        public MainWindow()
        {
            //local vars
            DirectoryInfo R1InstanceDir = new DirectoryInfo("../../../R1-INSTANCES");
            FileInfo[] R1InstanceFiles = R1InstanceDir.GetFiles("*.csv");
            DirectoryInfo R2InstanceDir = new DirectoryInfo("../../../R2-INSTANCES");
            FileInfo[] R2InstanceFiles = R2InstanceDir.GetFiles("*.csv");

            InitializeComponent();

            //initialize data members
            tableManager = new TableManager("../../../R1-INSTANCES", "../../../R2-INSTANCES");

            //fill R1 Instance Combo Box
            foreach (FileInfo R1InstanceFile in R1InstanceFiles)
            {
                R1InstanceComboBox.Items.Add(R1InstanceFile.Name);
            }

            //fill R2 Instance Combo Box
            foreach (FileInfo R2InstanceFile in R2InstanceFiles)
            {
                R2InstanceComboBox.Items.Add(R2InstanceFile.Name);
            }
        }

        private void ClickEvent(object sender, RoutedEventArgs e)
        {
            //local vars
            string joinResult;
            String[] linesOfJoinResult;
            double selectivityOfJoin;
            
            //if one of the combo boxes has nothing selected
            if ((R1AttributeComboBox.SelectedIndex == -1) || (R2AttributeComboBox.SelectedIndex == -1) ||
                (R1InstanceComboBox.SelectedIndex == -1) || (R2InstanceComboBox.SelectedIndex == -1))
            {
                MessageBox.Show("You must make a selection for each Drop Down Box. Try again.");
                return;
            }

            //Remove all items from R1ListBox
            while (R1ListBox.Items.Count != 0)
            {
                R1ListBox.Items.RemoveAt(0);
            }

            //remove all items from R2ListBox
            while (R2ListBox.Items.Count != 0)
            {
                R2ListBox.Items.RemoveAt(0);
            }

            //remove all items from JoinResultListBox
            while (JoinResultListBox.Items.Count != 0)
            {
                JoinResultListBox.Items.RemoveAt(0);
            }

            //find selected R1 instance
            foreach (OuterTable outerTable in tableManager.outerTables)
            {
                if (outerTable.relationName == (string) R1InstanceComboBox.Items.GetItemAt(R1InstanceComboBox.SelectedIndex))
                {
                    selectedOuterTable = outerTable;
                }
            }

            //find selected R2 instance
            foreach (InnerTable innerTable in tableManager.innerTables)
            {
                if (innerTable.relationName == (string) R2InstanceComboBox.Items.GetItemAt(R2InstanceComboBox.SelectedIndex))
                {
                    selectedInnerTable = innerTable;
                }
            }

            //get selected R1 attribute
            selectedR1Attribute = (string) ((ComboBoxItem) R1AttributeComboBox.Items.GetItemAt(R1AttributeComboBox.SelectedIndex)).Content;

            //get selected R2 attribute
            selectedR2Attribute = (string) ((ComboBoxItem) R2AttributeComboBox.Items.GetItemAt(R2AttributeComboBox.SelectedIndex)).Content;

            //fill list box for R1
            foreach (String line in selectedOuterTable.outerTableFile)
            {
                R1ListBox.Items.Add(line);
            }

            //fill list box for R2
            foreach (String line in selectedInnerTable.innerTableFile)
            {
                R2ListBox.Items.Add(line);
            }

            //do join
            joinResult = tableManager.Join(selectedOuterTable.relationName, selectedInnerTable.relationName, selectedR1Attribute, selectedR2Attribute);

            //split join result into the separate lines
            linesOfJoinResult = joinResult.Split('\n');

            //remove '\r' from the end of each string
            for (int i = 0; i < linesOfJoinResult.Length - 1; ++i)
            {
                linesOfJoinResult[i] = linesOfJoinResult[i].Substring(0, linesOfJoinResult[i].Length - 1);
            }

            //put join result in list box
            foreach (string line in linesOfJoinResult)
            {
                JoinResultListBox.Items.Add(line);
            }

            //calculate selectivity
            selectivityOfJoin = tableManager.SelectivityOfJoin(selectedOuterTable.relationName, selectedInnerTable.relationName, selectedR1Attribute, selectedR2Attribute);

            //set selectivity label
            SelectivityOfJoinLabel.Text = "Selectivity of Join: " + Convert.ToString(selectivityOfJoin);
        }
    }
}