// See https://aka.ms/new-console-template for more information

using System.Text;

public static class Esporta
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
                riga = riga.Replace(',', '.');
                riga = riga.Replace('-', ',');
                if (evento.GetType().ToString() == "Evento")
                    riga += ",null,0";
                riga += "," + evento.CapienzaMassima + "," + evento.PostiPrenotati;
                file.WriteLine(riga);
            }
            file.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}