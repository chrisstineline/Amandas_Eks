using System.Text.Json;
using System;
using Amanda_Eks.models;
using static System.Reflection.Metadata.BlobBuilder;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;

// <-- Comment, single line 



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
                    bool exists = false;
                    foreach (var item in yearDropdown.Items)
                    {
                        if (item.ToString().Equals(tegneserie.PublikationsAar.ToString()))
                        {
                            exists = true;
                        }
                    }

                    if (exists)
                    {
                        continue;
                    }
                    else
                    {
                        yearDropdown.Items.Add(tegneserie.PublikationsAar.ToString());
                    }
                }

                //Find possible author filters and add them to dropdown
                if (authorDropdown.Items.Count == 0)
                {
                    authorDropdown.Items.Add(tegneserie.Forfatter.ToString());
                }
                else
                {
                    bool exists = false;
                    foreach (var item in authorDropdown.Items)
                    {
                        if (item.ToString().Equals(tegneserie.Forfatter.ToString()))
                        {
                            exists = true;
                        }
                    }

                    if (exists)
                    {
                        continue;
                    } else
                    {
                        authorDropdown.Items.Add(tegneserie.Forfatter.ToString());
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
                            genreDropdown.Items.Add(genre);
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
                // I.e. --> Hver individuel forfatter listes -- Flere bøger kan have samme forfatter, men vi laver en sort på forfatter output 
                // til listen med: 
                // bool exists

                // Alternativt kunne man jo lave en string match, men det ville blive indviklet, der f.eks. ikke  er et forfatternavn på en bog, men en titel, forlag eller
                // ISBN. 


                // Koden er genbrugt bare med dropdown på Genre og publikationsår. Fordelen i det, er at vi ikke skal tænke på de forskellige datatyper, da det kun er indholdet af 
                // et datafelt der skal matches, ikke dens datatype.
                // Derfor behøves der IKKE laves ny type-specifik kode til int, string, referencer (hyperlinks), tid osv osv

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

        // Hvilken type medie der kan vælges, og et default mode --> 
        // Vi kan nemt tilføje filtre, f.eks. Online publikation, Faglitteratur, Avis 


        private void applyFilters(String filter)
        {
            if (filter == null) { MessageBox.Show("Du skal vælge et filter!!");}

            switch (typeDropdown.SelectedItem.ToString())
            {
                case "Lydbog":
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


        // Nedestående kode er er logikken bag knapperne, der giver brugeren mulighed for at filtrere og vælge fra listerne

        private void clearAllFilters()
        {
            yearDropdown.Items.Clear();
            authorDropdown.Items.Clear();
            genreDropdown.Items.Clear();
        }

        private void typeDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            initializeBooks(typeDropdown.SelectedItem.ToString() != null ? typeDropdown.SelectedItem.ToString() : null);
            Start();

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

        // Threading --> 
        // Når programmet startes, startes der en tråd i baggrunden. Tråden er sat til at simulere en udlåning af et medie. 
        // Der udlånes baseret på en random class, hvorpå det skrives til vinduet brugeren kigger på. 
        // Når der laves en random udlåning, kan brugeren af programmet set det. Det skrives også til en ny liste, der ved lukning af programmet 
        // producerer et JSON dokument, Udlånte, baseret på dato. 


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
                Thread.Sleep((int)random.NextInt64(long.Parse("5000"), long.Parse("10000")));  // Simulate some wait time between rents.

                if (!_running) break;

                Invoke((MethodInvoker)delegate
                {
                    switch (typeDropdown.SelectedItem.ToString() != null ? typeDropdown.SelectedItem.ToString() : null)
                    {
                        case "Lydbog":
                            List<Lydbog> lydboeger = new List<Lydbog>();
                            List<Lydbog> udlåntelydboeger = new List<Lydbog>();
                            Lydbog lydbogTemp = new Lydbog();
                            Random randomlydBook = new Random();

                            foreach (DataGridViewRow row in booksList.Rows)
                            {
                                if (row.IsNewRow) continue;

                                Lydbog bog = new Lydbog
                                {
                                    Titel = row.Cells["Titel"].Value.ToString(),
                                    Forfatter = row.Cells["Forfatter"].Value.ToString(),
                                    Genrer = row.Cells["Genrer"].Value.ToString().Split(',').Select(g => g.Trim()).ToList(),
                                    PublikationsAar = int.Parse(row.Cells["PublikationsAar"].Value.ToString()),
                                    Udgiver = row.Cells["Udgiver"].Value.ToString(),
                                    ISBN = row.Cells["ISBN"].Value.ToString()
                                };

                                lydboeger.Add(bog);
                            }

                            if (rentHistoryList.RowCount > 0)
                            {
                                foreach (DataGridViewRow row in rentHistoryList.Rows)
                                {
                                    if (row.IsNewRow) continue;

                                    Lydbog bog = new Lydbog
                                    {
                                        Titel = row.Cells["Titel"].Value.ToString(),
                                        Forfatter = row.Cells["Forfatter"].Value.ToString(),
                                        Genrer = row.Cells["Genrer"].Value.ToString().Split(',').Select(g => g.Trim()).ToList(),
                                        PublikationsAar = int.Parse(row.Cells["PublikationsAar"].Value.ToString()),
                                        Udgiver = row.Cells["Udgiver"].Value.ToString(),
                                        ISBN = row.Cells["ISBN"].Value.ToString()
                                    };

                                    udlåntelydboeger.Add(bog);
                                }
                            }

                            lydbogTemp = lydboeger.ElementAt((int)random.NextInt64(0, lydboeger.Count - 1));
                            udlåntelydboeger.Add(lydbogTemp); //tilføj til udlånt

                            BindingSource rentHistoryBindingSource = new BindingSource
                            {
                                DataSource = udlåntelydboeger.Select(book => new
                                {
                                    book.Titel,
                                    book.Forfatter,
                                    Genrer = string.Join(", ", book.Genrer),
                                    book.PublikationsAar,
                                    book.Udgiver,
                                    book.ISBN,
                                }).ToList()
                            };

                            rentHistoryList.DataSource = rentHistoryBindingSource;
                            break;
                        case "Bog":
                            List<Bog> boeger = new List<Bog>();
                            List<Bog> udlånteboeger = new List<Bog>();
                            Bog bogTemp = new Bog();
                            Random randomBook = new Random();

                            foreach (DataGridViewRow row in booksList.Rows)
                            {
                                if (row.IsNewRow) continue;

                                Bog bog = new Bog
                                {
                                    Titel = row.Cells["Titel"].Value.ToString(),
                                    Forfatter = row.Cells["Forfatter"].Value.ToString(),
                                    Genrer = row.Cells["Genrer"].Value.ToString().Split(',').Select(g => g.Trim()).ToList(),
                                    PublikationsAar = int.Parse(row.Cells["PublikationsAar"].Value.ToString()),
                                    Udgiver = row.Cells["Udgiver"].Value.ToString(),
                                    ISBN = row.Cells["ISBN"].Value.ToString()
                                };

                                boeger.Add(bog);
                            }

                            if (rentHistoryList.RowCount > 0)
                            {
                                foreach (DataGridViewRow row in rentHistoryList.Rows)
                                {
                                    if (row.IsNewRow) continue;

                                    Bog bog = new Bog
                                    {
                                        Titel = row.Cells["Titel"].Value.ToString(),
                                        Forfatter = row.Cells["Forfatter"].Value.ToString(),
                                        Genrer = row.Cells["Genrer"].Value.ToString().Split(',').Select(g => g.Trim()).ToList(),
                                        PublikationsAar = int.Parse(row.Cells["PublikationsAar"].Value.ToString()),
                                        Udgiver = row.Cells["Udgiver"].Value.ToString(),
                                        ISBN = row.Cells["ISBN"].Value.ToString()
                                    };

                                    udlånteboeger.Add(bog);
                                }
                            }

                            bogTemp = boeger.ElementAt((int)random.NextInt64(0, boeger.Count - 1));
                            udlånteboeger.Add(bogTemp); //tilføj til udlånt

                            BindingSource rentHistoryBoegerBindingSource = new BindingSource
                            {
                                DataSource = udlånteboeger.Select(book => new
                                {
                                    book.Titel,
                                    book.Forfatter,
                                    Genrer = string.Join(", ", book.Genrer),
                                    book.PublikationsAar,
                                    book.Udgiver,
                                    book.ISBN,
                                }).ToList()
                            };

                            rentHistoryList.DataSource = rentHistoryBoegerBindingSource;

                            break;
                        case "Tegneserie":
                            List<Tegneserie> tegneserier = new List<Tegneserie>();
                            List<Tegneserie> udlånteTegneserier = new List<Tegneserie>();
                            Tegneserie tegneserieTemp = new Tegneserie();
                            Random randomTegneserie = new Random();

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

                            if (rentHistoryList.RowCount > 0)
                            {
                                foreach (DataGridViewRow row in rentHistoryList.Rows)
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

                                    udlånteTegneserier.Add(tegneserie);
                                }
                            }

                            tegneserieTemp = tegneserier.ElementAt((int)random.NextInt64(0, tegneserier.Count - 1));
                            udlånteTegneserier.Add(tegneserieTemp); //tilføj til udlånt

                            BindingSource rentHistoryTegneserierBindingSource = new BindingSource
                            {
                                DataSource = udlånteTegneserier.Select(book => new
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

                            rentHistoryList.DataSource = rentHistoryTegneserierBindingSource;

                            break;
                        default:
                            MessageBox.Show("Type ikke valgt!");
                            break;
                    }

                });
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<Publikation> pubs = new List<Publikation>();

            _running = false;

            if (rentHistoryList.RowCount > 0)
            {
                foreach (DataGridViewRow row in rentHistoryList.Rows)
                {
                    if (row.IsNewRow) continue;

                    Publikation pub = new Publikation
                    {
                        Titel = row.Cells["Titel"].Value.ToString(),
                        Forfatter = row.Cells["Forfatter"].Value.ToString(),
                        Genrer = row.Cells["Genrer"].Value.ToString().Split(',').Select(g => g.Trim()).ToList(),
                        PublikationsAar = int.Parse(row.Cells["PublikationsAar"].Value.ToString()),
                        Udgiver = row.Cells["Udgiver"].Value.ToString(),
                        ISBN = row.Cells["ISBN"].Value.ToString()
                    };

                    pubs.Add(pub);
                }
            }

            var json = JsonSerializer.Serialize(pubs);
            File.WriteAllText("backupAfUdlånteBoeger.json", json);
        }
    }
}