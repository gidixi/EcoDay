using GiornoSmaltimento.Helpers;

namespace GiornoSmaltimento
{
    public partial class MainPage : ContentPage
    {
        public string ImageSourceParameter { get; set; }

        public MainPage()
        {
            InitializeComponent();
            ImageSourceParameter = "";
            CosaSmaltire();
            this.BindingContext = this;
        }

        private void CosaSmaltire()
        {
            var rifiuti = new Smaltimento();

            DateTime oggi = DateTime.Now;
            DayOfWeek giornoSettimana = oggi.DayOfWeek;

            if (rifiuti.kv[giornoSettimana].Any())
            {
                //Console.WriteLine($"Oggi, devi buttare: ");
                foreach (var rifiuto in rifiuti.kv[giornoSettimana])
                {
                    //Console.Write(rifiuto);
                    lblSmaltimento.Text += rifiuto + " ";

                    switch (rifiuto)
                    {
                        case "Carta":
                            UpdateImage("carta.png");
                            break;
                        case "Plastica":
                            UpdateImage("plastica.png");
                            break;
                        case "Organico":
                            UpdateImage("organico.png");
                            break;
                        case "Vetro":
                            UpdateImage("vetro.png");
                            break;
                        case "Indifferenziato":
                            UpdateImage("indifferenziato.png");
                            break;
                        default:
                            break;
                    }

                }
            }
            else
            {
                lblSmaltimento.Text = "Oggi non è prevista la raccolta di rifiuti.";
            }

            SemanticScreenReader.Announce(lblSmaltimento.Text);

        }

        private void UpdateImage(string newImageSource)
        {
            ImageSourceParameter = newImageSource;
            OnPropertyChanged(nameof(ImageSourceParameter)); // Notifica che la proprietà è cambiata
        }
    }

}
