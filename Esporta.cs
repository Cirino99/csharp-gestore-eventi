// See https://aka.ms/new-console-template for more information

using System.IO;
using System.Text;

public static class GestioneFile
{
    public static void NuovaEsportazione(List<Evento> eventi)
    {
        string path = "C:\\Users\\Simone\\Documents\\Boolean\\Experis\\csharp-gestore-eventi\\programmaEventi.csv";
        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            StreamWriter file = File.CreateText(path);
            file.WriteLine("data,titolo,relatore,prezzo,capienza massima,posti prenotati");
            foreach(Evento evento in eventi)
            {
                string riga = evento.ToString();
                riga = riga.Replace('-', ';');
                if (evento.GetType().ToString() == "Evento")
                    riga += ";null;0";
                riga += ";" + evento.CapienzaMassima + ";" + evento.PostiPrenotati;
                file.WriteLine(riga);
            }
            file.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public static List<Evento> NuovaImportazione()
    {
        List<Evento> eventi = new List<Evento>();
        string path = "C:\\Users\\Simone\\Documents\\Boolean\\Experis\\csharp-gestore-eventi\\programmaEventi.csv";
        try
        {
            StreamReader file = File.OpenText(path);
            file.ReadLine();
            while (!file.EndOfStream)
            {
                try
                {
                    string riga = file.ReadLine();
                    string[] info = riga.Split(";");
                    if (info.Length == 6)
                    {
                        if (info[2] == "null")
                        {
                            string titolo = info[1];
                            DateOnly data = DateOnly.Parse(info[0]);
                            int capienzaMassima = Convert.ToInt32(info[4]);
                            int postiPrenotati = Convert.ToInt32(info[5]);
                            Evento evento = new Evento(titolo,data,capienzaMassima);
                            evento.PrenotaPosti(postiPrenotati);
                            eventi.Add(evento);
                        } else
                        {
                            string titolo = info[1];
                            DateOnly data = DateOnly.Parse(info[0]);
                            string relatore = info[2];
                            double prezzo = Convert.ToDouble(info[3]);
                            int capienzaMassima = Convert.ToInt32(info[4]);
                            int postiPrenotati = Convert.ToInt32(info[5]);
                            Conferenza conferenza = new Conferenza(titolo, data, capienzaMassima, relatore, prezzo);
                            conferenza.PrenotaPosti(postiPrenotati);
                            eventi.Add(conferenza);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return eventi;
    }
}