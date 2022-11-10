// See https://aka.ms/new-console-template for more information

public static class GestioneFile
{
    public static void NuovaEsportazione(List<Evento> eventi)
    {
        string path = "C:\\Users\\Simone\\Documents\\Boolean\\Experis\\csharp-gestore-eventi\\programmaEventi.csv";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        StreamWriter file = File.CreateText(path);
        try
        {
            file.WriteLine("titolo;data;relatore;prezzo;capienza massima;posti prenotati");
            foreach(Evento evento in eventi)
            {
                string riga = evento.ToCsv();
                if (evento.GetType().ToString() == "Evento")
                    riga += ";null;0";
                riga += ";" + evento.CapienzaMassima + ";" + evento.PostiPrenotati;
                file.WriteLine(riga);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            file.Close();
        }
    }
    public static List<Evento> NuovaImportazione()
    {
        List<Evento> eventi = new List<Evento>();
        string path = "C:\\Users\\Simone\\Documents\\Boolean\\Experis\\csharp-gestore-eventi\\programmaEventi.csv";
        StreamReader file = File.OpenText(path);
        try
        {
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
                            string titolo = info[0];
                            DateOnly data = DateOnly.Parse(info[1]);
                            int capienzaMassima = Convert.ToInt32(info[4]);
                            int postiPrenotati = Convert.ToInt32(info[5]);
                            Evento evento = new Evento(titolo,data,capienzaMassima);
                            evento.PrenotaPosti(postiPrenotati);
                            eventi.Add(evento);
                        } else
                        {
                            string titolo = info[0];
                            DateOnly data = DateOnly.Parse(info[1]);
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
        file.Close();
        return eventi;
    }
}