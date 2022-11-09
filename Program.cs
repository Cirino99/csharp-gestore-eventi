// See https://aka.ms/new-console-template for more information
using csharp_gestore_eventi.Exception;

Console.WriteLine("Hello, World!");

public class Evento
{
    private string _titolo;
    public string Titolo { 
        get
        {
            return _titolo;
        }
        set
        {
            if (value == null || value == "")
                throw new GestoreEventiException("Il nome passato è vuoto");
            _titolo = value;
        }
    }
    private DateOnly _data;
    public DateOnly Data {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
        }
    }
    private int _capienzaMassima;
    public int CapienzaMassima {
        get
        {
            return _capienzaMassima;
        }
        private set
        {
            _capienzaMassima = value;
        }
    }
    public int PostiPrenotati { get; private set; }
    public Evento(string titolo, string data, int capienzaMassima)
    {

    }
}