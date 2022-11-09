// See https://aka.ms/new-console-template for more information

public class ProgrammaEventi
{
    private string _titolo;
    public string Titolo
    {
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
    List<Evento> eventi;
    public ProgrammaEventi(string titolo)
    {
        Titolo = titolo;
        eventi = new List<Evento>();
    }
    public void AggiungiEvento(Evento evento)
    {
        eventi.Add(evento);
    }
    public List<Evento> CercaEventi(DateOnly data)
    {
        List<Evento> eventiData = new List<Evento>();
        foreach (Evento evento in eventi)
        {
            if(evento.Data == data)
                eventiData.Add(evento);
        }
        return eventiData;
    }
    public static string StampaListaEventi(List<Evento> eventi)
    {
        if(eventi == null)
            throw new GestoreEventiException("Non sono stati trovati eventi");
        string stampa = "";
        foreach (Evento evento in eventi)
        {
            if(stampa == "")
                stampa = evento.ToString() + "\n";
            else
                stampa = stampa + evento.ToString() + "\n";
        }
        return stampa;
    }
    public int NumeroEventi()
    {
        return eventi.Count;
    }
    public void PulisciListaEventi()
    {
        eventi.Clear();
    }
    public override string ToString()
    {
        string stampa = Titolo + "\n";
        foreach (Evento evento in eventi)
        {
            stampa = stampa + "\t" + evento.ToString() + "\n";
        }
        return stampa;
    }
    public Evento CercaEvento(string titolo, DateOnly data)
    {
        foreach (Evento evento in eventi)
        {
            if (evento.Data == data && evento.Titolo == titolo)
                return evento;
        }
        return null;
    }
}
