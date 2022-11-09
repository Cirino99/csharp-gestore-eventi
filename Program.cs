// See https://aka.ms/new-console-template for more information

Console.WriteLine("Inserisci il nome del tuo programma di eventi:");
string nomeProgramma = Console.ReadLine();
Console.WriteLine("inserisci il numero di eventi da inserire:");
int numeroEventi = Convert.ToInt32(Console.ReadLine());
ProgrammaEventi programma = new ProgrammaEventi(nomeProgramma);
for(int i=1; i<=numeroEventi; i++)
{
    Console.WriteLine();
    CreaEvento(i);
}
bool esci = true;
do
{
    Console.WriteLine();
    Console.WriteLine("1) Stampa il numero di eventi presenti nel vostro programma eventi");
    Console.WriteLine("2) Stampa la lista di eventi inseriti nel vostro programma");
    Console.WriteLine("3) Stampa eventi in una data specifica");
    Console.WriteLine("4) Aggiungi prenotazione ad un evento");
    Console.WriteLine("5) Elimina prenotazione ad un evento");
    Console.WriteLine("6) Eliminate tutti gli eventi ed esci");
    string scelta = Console.ReadLine();
    switch (scelta)
    {
        case "1":
            Console.WriteLine("Il numero di eventi in programma è: " + programma.NumeroEventi());
            break;
        case "2":
            Console.WriteLine("Ecco il tuo programma di eventi: ");
            Console.WriteLine(programma.ToString());
            break;
        case "3":
            try
            {
                Console.WriteLine("Inserisci una data con cui cercare gli eventi (gg/mm/yyyy)");
                string dataStringa = Console.ReadLine();
                DateOnly data = DateOnly.Parse(dataStringa);
                List<Evento> eventi = programma.CercaEventi(data);
                Console.WriteLine(ProgrammaEventi.StampaListaEventi(eventi));
            }
            catch (GestoreEventiException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "4":
            Console.WriteLine("Inserisci il nome dell'evento");
            string nomeEvento = Console.ReadLine();
            Console.WriteLine("Inserisci la data dell'evento (gg/mm/yyyy)");
            string dataStringa2 = Console.ReadLine();
            DateOnly data2 = DateOnly.Parse(dataStringa2);
            Evento evento = programma.CercaEvento(nomeEvento, data2);
            AggiungiPrenotazione(evento);
            break;
        case "5":
            Console.WriteLine("Inserisci il nome dell'evento");
            string nomeEvento2 = Console.ReadLine();
            Console.WriteLine("Inserisci la data dell'evento (gg/mm/yyyy)");
            string dataStringa3 = Console.ReadLine();
            DateOnly data3 = DateOnly.Parse(dataStringa3);
            Evento evento2 = programma.CercaEvento(nomeEvento2, data3);
            EliminaPrenotazione(evento2);
            break;
        default:
            programma.PulisciListaEventi();
            esci = false;
            break;
    }
} while (esci);


void CreaEvento(int numero)
{
    bool successo = false;
    do {
        Console.WriteLine("Inserisci il nome del " + numero + "° evento:");
        string nome = Console.ReadLine();
        Console.WriteLine("Inserisci la data dell'evento (gg/mm/yyyy)");
        string dataStringa = Console.ReadLine();
        DateOnly data = DateOnly.Parse(dataStringa);
        Console.WriteLine("Inserisci il numero di posti totali:");
        int capienza = Convert.ToInt32(Console.ReadLine());
        try
        {
            Evento evento = new Evento(nome, data, capienza);
            programma.AggiungiEvento(evento);
            successo = true;
        }
        catch (GestoreEventiException e)
        {
            Console.WriteLine(e.Message);
        }
    } while(!successo);
}

void AggiungiPrenotazione(Evento evento)
{
    try
    {
        Console.WriteLine("Numero di posti disponibili = " + (evento.CapienzaMassima - evento.PostiPrenotati));
        Console.WriteLine("Quanti posti vuoi prenotare?");
        int prenotazioni = Convert.ToInt32(Console.ReadLine());
        evento.PrenotaPosti(prenotazioni);
    }
    catch (GestoreEventiException e)
    {
        Console.WriteLine(e.Message);
    }
}

void EliminaPrenotazione(Evento evento)
{
    try
    {
        Console.WriteLine("numero di posti prenotati = " + evento.PostiPrenotati);
        Console.WriteLine("Quanti posti vuoi disdire?");
        int cancellazioni = Convert.ToInt32(Console.ReadLine());
        evento.DisdiciPosti(cancellazioni);
    }
    catch (GestoreEventiException e)
    {
        Console.WriteLine(e.Message);
    }
}