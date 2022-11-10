// See https://aka.ms/new-console-template for more information

public class Conferenza : Evento
{
    private string _relatore;
    public string Relatore
    {
        get
        {
            return _relatore;
        }
        set
        {
            if (value == null || value == "")
                throw new GestoreEventiException("Il nome del relatore non può essere vuoto");
            _relatore = value;
        }
    }
    private double _prezzo;
    public double Prezzo
    {
        get
        {
            return _prezzo;
        }
        private set
        {
            if (value < 0)
                throw new GestoreEventiException("Il prezzo deve essere maggiore/uguale di 0");
            _prezzo = value;
        }
    }
    public Conferenza(string titolo, DateOnly data, int capienzaMassima, string relatore, double prezzo) : base(titolo, data, capienzaMassima)
    {
        Relatore = relatore;
        Prezzo = prezzo;
    }
    public override string ToString()
    {
        return Data + " - " + Titolo + " - " + Relatore + " - " + Prezzo.ToString("0.00") + "$";
    }
    public override string ToCsv()
    {
        return Titolo + ";" + Data + ";" + Relatore + ";" + Prezzo.ToString("0.00");
    }
}