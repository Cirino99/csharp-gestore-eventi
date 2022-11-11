// See https://aka.ms/new-console-template for more information

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
                throw new GestoreEventiException("Il nome dell'evento non può essere vuoto");
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
            if (value < DateOnly.FromDateTime(DateTime.Now))
                throw new GestoreEventiException("La data deve essere già passata");
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
            if(value <= 0)
                throw new GestoreEventiException("La capienza massima deve essere maggiore di 0");
            _capienzaMassima = value;
        }
    }
    public int PostiPrenotati { get; private set; }
    public Evento(string titolo, DateOnly data, int capienzaMassima)
    {
        Titolo = titolo;
        Data = data;
        CapienzaMassima = capienzaMassima;
        PostiPrenotati = 0;
    }
    public void PrenotaPosti(int numero)
    {
        if (Data < DateOnly.FromDateTime(DateTime.Now))
            throw new GestoreEventiException("Non puoi prenotare posti di un evento già passato");
        if (CapienzaMassima < PostiPrenotati + numero)
            throw new GestoreEventiException("Non ci sono abbastanza posti disponibili");
        PostiPrenotati += numero;
    }
    public void DisdiciPosti(int numero)
    {
        if (Data < DateOnly.FromDateTime(DateTime.Now))
            throw new GestoreEventiException("Non puoi disdire prenotazioni di un evento già passato");
        if (PostiPrenotati - numero < 0)
            throw new GestoreEventiException("Non ci sono abbastanza prenotazioni da disdire");
        PostiPrenotati -= numero;
    }
    public override string ToString()
    {
        return Data + " - " + Titolo;
    }
    public virtual string ToCsv()
    {
        return Titolo + ";" + Data;
    }
}