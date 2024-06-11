using System.Text.Json;
using System;
using Amanda_Eks.models;

namespace Amanda_Eks
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void initializeBooks(String type)
        {
            string jsonFilePath = "";

            switch (type)
            {
                case "Lydbog":
                    jsonFilePath = @"Database\Lydbøger.json";
                    string jsonString = File.ReadAllText(jsonFilePath);

                    // Deserialize the JSON data to a List of Person objects
                    List<Lydbog> lydboeger = JsonSerializer.Deserialize<List<Lydbog>>(jsonString);
                    booksList.Columns.Add("Titel");
                    booksList.Columns.Add("Forfatter");
                    booksList.Columns.Add("Genrer");
                    booksList.Columns.Add("PublikationsAar");
                    booksList.Columns.Add("Udgiver");
                    booksList.Columns.Add("MatchPercentage");
                    booksList.Columns.Add("ISBN");

                    foreach (Lydbog bog in lydboeger)
                    {
                        ListViewItem item = new ListViewItem(bog.Titel);
                        item.SubItems.Add(bog.Forfatter);
                        item.SubItems.Add(string.Join(", ", bog.Genrer));
                        item.SubItems.Add(bog.PublikationsAar.ToString());
                        item.SubItems.Add(bog.Udgiver);
                        item.SubItems.Add(bog.MatchPercentage.ToString("F1"));
                        item.SubItems.Add(bog.ISBN);

                        MessageBox.Show(bog.Titel);
                        booksList.Items.Add(item);
                    }
                    
                    booksList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    break;
                case "Bog":
                    //TODO: Implement
                    break;
                case "Tegneserie":
                    break;
                default:
                    break;
            }
        }

        private void typeDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            initializeBooks(typeDropdown.SelectedItem.ToString() != null ? typeDropdown.SelectedItem.ToString() : null);
        }

        private void booksList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}