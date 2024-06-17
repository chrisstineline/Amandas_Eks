using System.Text.Json;
using System;
using Amanda_Eks.models;
using static System.Reflection.Metadata.BlobBuilder;
using System.Windows.Forms;

namespace Amanda_Eks
{
    public partial class MainForm : Form
    {
        private Thread _thread;

        private bool _running;

        public MainForm()
        {
            InitializeComponent();
            _running = false;
            _thread = new Thread(new ThreadStart(Run));
        }

        private void initializeBooks(String type)
        {
            string jsonFilePath = "";
            string jsonString = "";

            switch (type)
            {
                case "Lydbog":
                    jsonFilePath = @"Database\Lydbøger.json";
                    jsonString = File.ReadAllText(jsonFilePath);

                    // Deserialize the JSON data to a List of Lydbog objects
                    List<Lydbog> lydboeger = JsonSerializer.Deserialize<List<Lydbog>>(jsonString);

                    // Convert books to a binding list that the DataGridView can use
                    var bookBindingList = new BindingSource
                    {
                        DataSource = lydboeger.Select(book => new
                        {
                            book.Titel,
                            book.Forfatter,
                            Genrer = string.Join(", ", book.Genrer),
                            book.PublikationsAar,
                            book.Udgiver,
                            book.ISBN,
                            book.IndtaltAf,
                            book.LaengdeIMinutter
                        }).ToList()
                    };

                    // Set the data source for the DataGridView
                    booksList.DataSource = bookBindingList;

                    //Initialize possible filters in the GUI. Year, Author and Genre.
                    initializeFilters(lydboeger);
                    break;
                case "Bog":
                    jsonFilePath = @"Database\Bøger.json";
                    jsonString = File.ReadAllText(jsonFilePath);

                    // Deserialize the JSON data to a List of Person objects
                    List<Bog> boeger = JsonSerializer.Deserialize<List<Bog>>(jsonString);

                    // Convert books to a binding list that the DataGridView can use
                    bookBindingList = new BindingSource
                    {
                        DataSource = boeger.Select(book => new
                        {
                            book.Titel,
                            book.Forfatter,
                            Genrer = string.Join(", ", book.Genrer),
                            book.PublikationsAar,
                            book.Udgiver,
                            book.ISBN,
                            book.AntalSider,
                            book.Kapitler
                        }).ToList()
                    };

                    // Set the data source for the DataGridView
                    booksList.DataSource = bookBindingList;

                    //Initialize possible filters in the GUI. Year, Author and Genre.
                    initializeFilters(boeger);
                    break;
                case "Tegneserie":
                    jsonFilePath = @"Database\Tegneserier.json";
                    jsonString = File.ReadAllText(jsonFilePath);

                    // Deserialize the JSON data to a List of Person objects
                    List<Tegneserie> tegneserier = JsonSerializer.Deserialize<List<Tegneserie>>(jsonString);

                    // Convert books to a binding list that the DataGridView can use
                    bookBindingList = new BindingSource
                    {
                        DataSource = tegneserier.Select(book => new
                        {
                            book.Titel,
                            book.Forfatter,
                            Genrer = string.Join(", ", book.Genrer),
                            book.PublikationsAar,
                            book.Udgiver,
                            book.ISBN,
                            book.Illustrator,
                        }).ToList()
                    };

                    // Set the data source for the DataGridView
                    booksList.DataSource = bookBindingList;

                    //Initialize possible filters in the GUI. Year, Author and Genre.
                    initializeFilters(tegneserier);
                    break;
                default:
                    MessageBox.Show("Der blev ikke valgt type");
                    break;
            }
        }

        private void initializeFilters(List<Tegneserie> tegneserier)
        {
            //Clear previous filters.
            clearAllFilters();

            foreach (Tegneserie tegneserie in tegneserier)
            {
                //Find possible year filters and add them to dropdown.
                if (yearDropdown.Items.Count == 0)
                {
                    yearDropdown.Items.Add(tegneserie.PublikationsAar.ToString());
                } else
                {
                    foreach (var item in yearDropdown.Items)
                    {
                        if (item.ToString().Equals(tegneserie.PublikationsAar.ToString()))
                        {
                            continue;
                        } else
                        {
                            yearDropdown.Items.Add(tegneserie.PublikationsAar.ToString());
                        }
                    }
                }

                //Find possible author filters and add them to dropdown
                if (authorDropdown.Items.Count == 0)
                {
                    authorDropdown.Items.Add(tegneserie.Forfatter.ToString());
                }
                else
                {
                    foreach (var item in authorDropdown.Items)
                    {
                        if (item.ToString().Equals(tegneserie.Forfatter.ToString()))
                        {
                            continue;
                        }
                        else
                        {
                            authorDropdown.Items.Add(tegneserie.Forfatter.ToString());
                        }
                    }
                }

                //Find possible genres and add them to dropdown

                foreach (string genre in tegneserie.Genrer)
                {
                    if (genreDropdown.Items.Count == 0)
                    {
                        genreDropdown.Items.Add(genre);
                    }
                    else
                    {
                        foreach (var item in genreDropdown.Items)
                        {
                            if (item.ToString().Equals(genre))
                            {
                                continue;
                            }
                            else
                            {
                                genreDropdown.Items.Add(genre);
                            }
                        }
                    }
                }
            }
        }

        private void initializeFilters(List<Bog> bøger)
        {
            //Clear previous filters.
            clearAllFilters();

            foreach (Bog bog in bøger)
            {
                //Find possible year filters and add them to dropdown.
                if (yearDropdown.Items.Count == 0)
                {
                    yearDropdown.Items.Add(bog.PublikationsAar.ToString());
                }
                else
                {
                    bool exists = false;
                    foreach (var item in yearDropdown.Items)
                    {
                        if (item.ToString().Equals(bog.PublikationsAar.ToString()))
                        {
                            exists = true;
                        }
                    }

                    if (exists)
                    {
                        continue;
                    } else
                    {
                        yearDropdown.Items.Add(bog.PublikationsAar.ToString());
                    }
                }

                //Find possible author filters and add them to dropdown
                if (authorDropdown.Items.Count == 0)
                {
                    authorDropdown.Items.Add(bog.Forfatter.ToString());
                }
                else
                {
                    bool exists = false;
                    foreach (var item in authorDropdown.Items)
                    {
                        if (item.ToString().Equals(bog.Forfatter.ToString()))
                        {
                            exists = true;
                        }
                    }

                    if (exists)
                    {
                        continue;
                    } else
                    {
                        authorDropdown.Items.Add(bog.Forfatter.ToString());
                    }
                }

                //Find possible genres and add them to dropdown
                foreach (string genre in bog.Genrer)
                {
                    if (genreDropdown.Items.Count == 0)
                    {
                        genreDropdown.Items.Add(genre);
                    }
                    else
                    {
                        bool exists = false;
                        foreach (var item in genreDropdown.Items)
                        {
                            if (item.ToString().Equals(genre))
                            {
                                exists = true;
                            }
                        }

                        if (exists)
                        {
                            continue;
                        } else
                        {
                            genreDropdown.Items.Add(genre);
                        }
                    }
                }
            }
        }

        private void initializeFilters(List<Lydbog> lydbøger)
        {
            //Clear previous filters.
            clearAllFilters();

            foreach (Lydbog bog in lydbøger)
            {
                //Find possible year filters and add them to dropdown.
                if (yearDropdown.Items.Count == 0)
                {
                    yearDropdown.Items.Add(bog.PublikationsAar.ToString());
                }
                else
                {
                    bool exists = false;
                    foreach (var item in yearDropdown.Items)
                    {
                        if (item.ToString().Equals(bog.PublikationsAar.ToString()))
                        {
                            exists = true;
                        }
                    }

                    if (exists)
                    {
                        continue;
                    } else
                    {
                        yearDropdown.Items.Add(bog.PublikationsAar.ToString());
                    }
                }

                //Find possible author filters and add them to dropdown
                if (authorDropdown.Items.Count == 0)
                {
                    authorDropdown.Items.Add(bog.Forfatter.ToString());
                }
                else
                {
                    bool exists = false;
                    foreach (var item in authorDropdown.Items)
                    {
                        if (item.ToString().Equals(bog.Forfatter.ToString()))
                        {
                            exists = true;
                        }
                    }

                    if (exists)
                    {
                        continue;
                    } else
                    {
                        authorDropdown.Items.Add(bog.Forfatter.ToString());
                    }
                }

                //Find possible genres and add them to dropdown
                foreach (string genre in bog.Genrer)
                {
                    
                    if (genreDropdown.Items.Count == 0)
                    {
                        genreDropdown.Items.Add(genre);
                    }
                    else
                    {
                        bool exists = false;
                        foreach (var item in genreDropdown.Items)
                        {
                            if (item.ToString().Equals(genre))
                            {
                                exists= true;
                            }
                        }

                        if (exists)
                        {
                            continue;
                        } else
                        {
                            genreDropdown.Items.Add(genre);
                        }
                    }
                }
            }
        }

        private void applyFilters(String filter)
        {
            if (filter == null) { MessageBox.Show("Du skal vælge et filter!!");}

            switch (typeDropdown.SelectedItem.ToString())
            {
                case "Lydbog":
                    List<Lydbog> Lydbøger = new List<Lydbog>();
                    
                    break;
                case "Bog":
                    break;
                case "Tegneserie":
                    break;
                default:
                    MessageBox.Show("Type ikke valgt!");
                    break;
            }
        }

        private void clearAllFilters()
        {
            yearDropdown.Items.Clear();
            authorDropdown.Items.Clear();
            genreDropdown.Items.Clear();
        }

        private void typeDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            initializeBooks(typeDropdown.SelectedItem.ToString() != null ? typeDropdown.SelectedItem.ToString() : null);
        }

        private void booksList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //This method listens for changes to the yearDropdown from the user. Meaning changes we make don't count, like filling
        //in data when initializing filters. Only user committed changes will count.
        private void yearDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Implement me!!
        }

        //This method listens for changes to the authorDropdown from the user. Meaning changes we make don't count, like filling
        //in data when initializing filters. Only user committed changes will count.
        private void authorDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Implement me!!
        }

        //This method listens for changes to the genrerDropdown from the user. Meaning changes we make don't count, like filling
        //in data when initializing filters. Only user committed changes will count.
        private void genreDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Implement me!!
        }

        public void Start()
        {
            if (!_running)
            {
                _running = true;
                _thread.Start();
                Console.WriteLine("Thread started.");
            }
        }

        public void Stop()
        {
            if (_running)
            {
                _running = false;
                _thread.Join();  // Wait for the thread to finish
                Console.WriteLine("Thread stopped.");
            }
        }

        private void Run()
        {
            Random random = new Random();
            while (_running)
            {
                Console.WriteLine("Thread is running...");
                Thread.Sleep((int)random.NextInt64(long.Parse("5000"), long.Parse("25000")));  // Simulate some wait time.

                Invoke((MethodInvoker)delegate
                {
                    switch (typeDropdown.SelectedItem.ToString())
                    {
                        case "Lydbog":
                            List<Lydbog> Lydbøger = new List<Lydbog>();

                            break;
                        case "Bog":
                            List<Bog> bøger = new List<Bog>();

                            break;
                        case "Tegneserie":
                            List<Tegneserie> tegneserier = new List<Tegneserie>();

                            foreach (DataGridViewRow row in booksList.Rows)
                            {
                                if (row.IsNewRow) continue;

                                Tegneserie tegneserie = new Tegneserie
                                {
                                    Titel = row.Cells["Titel"].Value.ToString(),
                                    Forfatter = row.Cells["Forfatter"].Value.ToString(),
                                    Genrer = row.Cells["Genrer"].Value.ToString().Split(',').Select(g => g.Trim()).ToList(),
                                    PublikationsAar = int.Parse(row.Cells["PublikationsAar"].Value.ToString()),
                                    Udgiver = row.Cells["Udgiver"].Value.ToString(),
                                    ISBN = row.Cells["ISBN"].Value.ToString(),
                                    Illustrator = row.Cells["Illustrator"].Value.ToString()
                                };

                                tegneserier.Add(tegneserie);
                            }

                            rentHistoryList = new BindingSource
                            {
                                DataSource = tegneserier.Select(book => new
                                {
                                    book.Titel,
                                    book.Forfatter,
                                    Genrer = string.Join(", ", book.Genrer),
                                    book.PublikationsAar,
                                    book.Udgiver,
                                    book.ISBN,
                                    book.Illustrator,
                                }).ToList()
                            };

                            // Set the data source for the DataGridView
                            booksList.DataSource = bookBindingList;

                            rent

                            tegneserier.ElementAt(random.Next(0, tegneserier.Count - 1));

                            break;
                        default:
                            MessageBox.Show("Type ikke valgt!");
                            break;
                    }

                    rentHistoryList.
                });
            }
        }
    }
}