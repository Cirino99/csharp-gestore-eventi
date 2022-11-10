// See https://aka.ms/new-console-template for more information

Console.WriteLine("Inserisci il nome del tuo programma di eventi:");
string nomeProgramma = Console.ReadLine();
int numeroEventi = NumeroUtente("inserisci il numero di eventi da inserire:");
ProgrammaEventi programma = new ProgrammaEventi(nomeProgramma);
for(int i=1; i<=numeroEventi; i++)
{
    Console.WriteLine();
    string tipo = SceltaEventoConferenza();
    if (tipo == "evento")
        CreaEvento(i);
    else
        CreaConferenza(i);
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
                DateOnly data = DataUtente("Inserisci una data con cui cercare gli eventi (gg/mm/yyyy)");
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
            DateOnly data2 = DataUtente("Inserisci la data dell'evento (gg/mm/yyyy)");
            Evento evento = programma.CercaEvento(nomeEvento, data2);
            AggiungiPrenotazione(evento);
            break;
        case "5":
            Console.WriteLine("Inserisci il nome dell'evento");
            string nomeEvento2 = Console.ReadLine();
            DateOnly data3 = DataUtente("Inserisci la data dell'evento (gg/mm/yyyy)");
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
        DateOnly data = DataUtente("Inserisci la data dell'evento (gg/mm/yyyy)");
        int capienza = NumeroUtente("Inserisci il numero di posti totali:");
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

void CreaConferenza(int numero)
{
    bool successo = false;
    do
    {
        Console.WriteLine("Inserisci il nome della " + numero + "° conferenza:");
        string nome = Console.ReadLine();
        DateOnly data = DataUtente("Inserisci la data dell'evento (gg/mm/yyyy)");
        int capienza = NumeroUtente("Inserisci il numero di posti totali:");
        Console.WriteLine("Inserisci il nome del relatore:");
        string relatore = Console.ReadLine();
        double prezzo = DoubleUtente("Inserisci il prezzo del biglietto:");
        try
        {
            Conferenza conferenza = new Conferenza(nome, data, capienza,relatore,prezzo);
            programma.AggiungiEvento(conferenza);
            successo = true;
        }
        catch (GestoreEventiException e)
        {
            Console.WriteLine(e.Message);
        }
    } while (!successo);
}

void AggiungiPrenotazione(Evento evento)
{
    try
    {
        Console.WriteLine("Numero di posti disponibili = " + (evento.CapienzaMassima - evento.PostiPrenotati));
        int prenotazioni = NumeroUtente("Quanti posti vuoi prenotare?");
        evento.PrenotaPosti(prenotazioni);
    }
    catch (GestoreEventiException e)
    {
        Console.WriteLine(e.Message);
    }
    catch (NullReferenceException e)
    {
        Console.WriteLine(e.Message);
    }
}

void EliminaPrenotazione(Evento evento)
{
    try
    {
        Console.WriteLine("numero di posti prenotati = " + evento.PostiPrenotati);
        int cancellazioni = NumeroUtente("Quanti posti vuoi disdire?");
        evento.DisdiciPosti(cancellazioni);
    }
    catch (GestoreEventiException e)
    {
        Console.WriteLine(e.Message);
    }
}

DateOnly DataUtente(string message)
{
    bool succes = false;
    DateOnly data;
    do
    {
        try
        {
            Console.WriteLine(message);
            string dataStringa = Console.ReadLine();
            data = DateOnly.Parse(dataStringa);
            succes = true;
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    } while (!succes);
    return data;
}

int NumeroUtente(string message)
{
    bool succes = false;
    int numero = 0;
    do
    {
        try
        {
            Console.WriteLine(message);
            numero = Convert.ToInt32(Console.ReadLine());
            succes = true;
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    } while (!succes);
    return numero;
}

double DoubleUtente(string message)
{
    bool succes = false;
    double numero = 0;
    do
    {
        try
        {
            Console.WriteLine(message);
            numero = Convert.ToDouble(Console.ReadLine());
            succes = true;
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    } while (!succes);
    return numero;
}

string SceltaEventoConferenza()
{
    Console.WriteLine("Vuoi inserire un evento o una conferenza?");
    string tipo = Console.ReadLine();
    return tipo;
}