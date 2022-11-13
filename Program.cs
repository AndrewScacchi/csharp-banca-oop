//Oggi cerchiamo di migliorare un pochino l’approccio nella costruzione di un codice ad oggetti, ben suddiviso tra diverse responsabilità. 
//Il program.cs si occuperà
//quindi di gestire tutti i console.writeline/readline mentre le classi di dominio del nostro progetto devono occuparsi solo della logica applicativa
//e fare dei controlli dei dati quando questi violano qualche logica.
//
//Esempio, quando un cliente non può chiedere più prestiti? quale entità potrebbe occuparsi di questo controllo?
//Non dimentichiamoci però che abbiamo aggiunto la keyword static, quale parametro di quale entità potrebbe essere trasformato in STATIC così come abbiamo visto negli esempi?
//
//Consegna:
//Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una banca concede ai propri clienti.
//
//La banca è caratterizzata da
//un nome
//un insieme di clienti (una lista)
//un insieme di prestiti concessi ai clienti (una lista)
//
//I clienti sono caratterizzati da
//nome,
//cognome,
//codice fiscale
//stipendio
//
//I prestiti sono caratterizzati da
//ID
//intestatario del prestito (il cliente),
//un ammontare,
//una rata,
//una data inizio,
//una data fine.
//
//Per la banca deve essere possibile:
//aggiungere, modificare e ricercare un cliente.
//aggiungere un prestito.
//effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
//sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.
//sapere, dato il codice fiscale di un cliente, quante rate rimangono da pagare alla data odierna.
//Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere.
//
//Bonus:
//visualizzare per ogni cliente, la situazione dei suoi prestiti in formato tabellare.

Banca intesa = new Banca("Intesa san Paolo");

Console.WriteLine("Sistema amministrazione banca " + intesa.Nome);

//aggiunta di un prestito
// 1. chiedo all'utente di cercare il cliente su cui si vuole creare un prestito

//inizio programma scelta utente
Console.WriteLine("---");
Console.WriteLine("Premi 1 per creare un nuovo prestito");
Console.WriteLine("Premi 2 per aggiungere un'utente");
Console.WriteLine("Premi 3 per modificare un utente");
Console.WriteLine("Premi 4 per cercare un utente");
Console.WriteLine("Premi 5 per vedere quante rate rimangono ad estinguere un prestito");
Console.WriteLine("Premi 6 per stampare un prospetto riassuntivo di un cliente");
Console.WriteLine("Premi 7 per stampare un prospetto riassuntivo di un prestito");
Console.WriteLine("---");



int sceltaUser = Convert.ToInt32(Console.ReadLine());

if (sceltaUser == 1)
{

    Console.WriteLine("Creazione di un nuovo prestito");
    Console.WriteLine();
    Console.WriteLine("Inserisci il codice fiscale:");
    string codiceFiscale = Console.ReadLine();

    Cliente clienteEsistente = intesa.RicercaCliente(codiceFiscale);

    if (clienteEsistente == null)
    {
        Console.WriteLine("errore: Cliente non trovato!");
    }
    else
    {
        var dateNow = DateOnly.FromDateTime(DateTime.Now);

        Console.WriteLine("Ammontare del prestito: ");
        int ammontarePrestito = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Valore rata: ");
        int rataPrestito = Convert.ToInt32(Console.ReadLine());

        int rate = ammontarePrestito / rataPrestito;
        Console.WriteLine("Numero rate: " + rate);
        DateOnly finePrestito = dateNow.AddMonths(rate);
        Prestito nuovoPrestito = new Prestito(ammontarePrestito, rataPrestito, dateNow, finePrestito, clienteEsistente);

        intesa.AggiungiPrestito(nuovoPrestito);
        Cliente cliente = intesa.RicercaCliente(codiceFiscale);

    }
}
else if (sceltaUser == 2)
{
    Console.WriteLine("Inserisci il codice fiscale:");
    string codiceFiscale = Console.ReadLine();
    Console.WriteLine("Inserisci il nome:");
    string nome = Console.ReadLine();
    Console.WriteLine("Inserisci il cognome:");
    string cognome = Console.ReadLine();
    Console.WriteLine("Inserisci lo stipendio:");
    int stipendio = Convert.ToInt32(Console.ReadLine());
    bool aggiunta = intesa.AggiungiCliente(nome, cognome, codiceFiscale, stipendio);
    if (aggiunta)
        Console.WriteLine("Utente inserito");
    else
        Console.WriteLine("Errore durante l'inserimento");
}
else if (sceltaUser == 3)
{

    Console.WriteLine("Inserisci il codice fiscale per la ricerca nel database:");
    string codiceFiscale = Console.ReadLine();
    Cliente cliente = intesa.RicercaCliente(codiceFiscale);
    if (cliente == null)
        Console.WriteLine("Utente non trovato");
    else
    {
        Console.WriteLine("Ora ti chiederò tutti i dati del utente");
        Console.WriteLine("Inserisci il nome:");
        string nome = Console.ReadLine();
        Console.WriteLine("Inserisci il cognome:");
        string cognome = Console.ReadLine();
        Console.WriteLine("Inserisci lo stipendio:");
        int stipendio = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Inserisci il codice fiscale:");
        string nuovoCF = Console.ReadLine();
        Cliente modifica = intesa.ModificaCliente(nome, cognome, codiceFiscale, stipendio, nuovoCF);
        if (modifica != null)
            Console.WriteLine("Utente modificato per il codice fiscale: " + modifica.CodiceFiscale);
        else
            Console.WriteLine("Errore durante la modifica");
    }
}
else if (sceltaUser == 4)
{
    Console.WriteLine("Inserisci il codice fiscale:");
    string codiceFiscale = Console.ReadLine();
    Cliente cliente = intesa.RicercaCliente(codiceFiscale);
    if (cliente != null)
    {
        Console.WriteLine("Utente trovato");
        Console.WriteLine("Nome: " + cliente.Nome);
        Console.WriteLine("Cognome: " + cliente.Cognome);
        Console.WriteLine("Stipendio: " + cliente.Stipendio);
        Console.WriteLine("Codice fiscale: " + cliente.CodiceFiscale);
        Console.WriteLine("Prestiti richiesti: " + intesa.AmmontareTotalePrestitiCliente(codiceFiscale));
    }
    else
        Console.WriteLine("Utente non trovato");

}
else if (sceltaUser == 5)
{
    Console.WriteLine("Inserisci il codice fiscale:");
    string codiceFiscale = Console.ReadLine();
    //Cliente cliente = intesa.RicercaCliente(codiceFiscale);
    List<Prestito> prestiti = intesa.RicercaPrestito(codiceFiscale);
    foreach (Prestito item in prestiti)
    {
        Console.WriteLine("{0}", item.ToString());

    }
    //Console.WriteLine(Convert.ToInt32(intesa.RateMancantiCliente(codiceFiscale)));


}
else if (sceltaUser == 6)
{
    Console.WriteLine("Inserisci il codice fiscale:");
    string codiceFiscale = Console.ReadLine();
    Cliente cliente = intesa.RicercaCliente(codiceFiscale);
    if (cliente != null)
    {
        Console.WriteLine("{0}", cliente);
    }
}
else if (sceltaUser == 7)
{
    Console.WriteLine("Inserisci il codice fiscale dell'utente di cui cercare i prestiti:");
    string codiceFiscale = Console.ReadLine();
    List<Prestito> prestito = intesa.RicercaPrestito(codiceFiscale);

    if (prestito != null)
    {
        foreach (Prestito item in prestito)
        {
            Console.WriteLine("{0}", item);

        }
    }
}
else
{
    Console.WriteLine("Scelta errata");
}