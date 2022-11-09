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
} catch(GestoreEventiException e)
{
    Console.WriteLine(e.ToString());
}
