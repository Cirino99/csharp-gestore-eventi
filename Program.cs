// See https://aka.ms/new-console-template for more information

Console.WriteLine("Creazione evento");
Console.WriteLine("Inserisci il nome");
string nome = Console.ReadLine();
Console.WriteLine("Inserisci la data in formato  gg/mm/yyyy");
string dataStringa = Console.ReadLine();
DateOnly data = DateOnly.Parse(dataStringa);
Console.WriteLine("Inserisci la capienza massima");
int capienza = Convert.ToInt32(Console.ReadLine());
try
{
    Evento evento = new Evento(nome, data, capienza);
    Console.WriteLine(evento.ToString());
    Console.WriteLine("Quanti posti vuoi prenotare?");
    int prenotazioni = Convert.ToInt32(Console.ReadLine());
    evento.PrenotaPosti(prenotazioni);
    bool disdici = true;
    do
    {
        Console.WriteLine("Vuoi disdire delle prenotazioni?");
        string risposta = Console.ReadLine();
        if(risposta == "si")
        {
            Console.WriteLine("Quanti posti vuoi disdire?");
            int cancellazioni = Convert.ToInt32(Console.ReadLine());
            evento.DisdiciPosti(cancellazioni);
        } else
        {
            Console.WriteLine("Ok va bene!");
            disdici = false;

        }
        Console.WriteLine("Numero di posti prenotati = " + evento.PostiPrenotati);
        Console.WriteLine("Numero di posti disponibili = " + (evento.CapienzaMassima - evento.PostiPrenotati));
    } while (disdici);
} catch(GestoreEventiException e)
{
    Console.WriteLine(e.ToString());
}
