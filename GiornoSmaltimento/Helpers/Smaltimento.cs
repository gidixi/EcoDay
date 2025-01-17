using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiornoSmaltimento.Helpers
{
    public class Smaltimento
    {
        private DateTime oggi = DateTime.Now;
        private DayOfWeek giornoSettimana = DateTime.Now.DayOfWeek;
        public Dictionary<DayOfWeek, List<string>> kv { get; set; }
        public Smaltimento()
        {
            kv = new Dictionary<DayOfWeek, List<string>>();

            Add(DayOfWeek.Monday, new List<string> { "Carta", "Cartone" });
            Add(DayOfWeek.Tuesday, new List<string> { "Organico" });
            Add(DayOfWeek.Wednesday, new List<string> { "Plastica" });
            Add(DayOfWeek.Thursday, new List<string> { "Organico" });
            Add(DayOfWeek.Friday, new List<string> { "Indifferenziato" });
            Add(DayOfWeek.Saturday, new List<string> { });
            Add(DayOfWeek.Sunday, new List<string> { "Organico" });

            UpdateVenerdi();

        }

        private void Add(DayOfWeek Giorno, List<string> Rifiuti)
        {
            kv.Add(Giorno, Rifiuti);
        }

        private void Update(DayOfWeek Giorno, string Rifiuto)
        {
            kv[Giorno].Add(Rifiuto);
        }

        private void UpdateVenerdi()
        {

            int settimanaDelMese = (oggi.Day + 6) / 7;

            if (giornoSettimana == DayOfWeek.Thursday)
            {
                if (settimanaDelMese == 1 || settimanaDelMese == 3 || settimanaDelMese == 5)
                {
                    Update(DayOfWeek.Thursday, "Vetro");
                }
                if (settimanaDelMese == 2 || settimanaDelMese == 4)
                {
                    Update(DayOfWeek.Thursday, "Metalli");
                }
            }
        }

    }
}
