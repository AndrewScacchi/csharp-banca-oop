// Banca Class

//La banca è caratterizzata da
//un nome
//un insieme di clienti (una lista)
//un insieme di prestiti concessi ai clienti (una lista)
public class Banca
{
    public string Nome { get; set; }
    List<Cliente> Clienti { get; set; }
    List<Prestito> Prestiti { get; set; }

    //constructor
    public Banca(string Nome)
    {
        Nome = Nome;
        Clienti = new List<Cliente>();
        Prestiti = new List<Prestito>();
        Cliente Cliente1 = new Cliente("Andrea", "Scacchi", "NDRSCC4235263755", 2500);
        Clienti.Add(Cliente1);

        var dateNow = DateOnly.FromDateTime(DateTime.Now);
        Prestito Prestito1 = new Prestito(20000, 1, dateNow, Cliente1);
        Prestito Prestito2 = new Prestito(20000, 1, dateNow, Cliente1);
        Prestiti.Add(Prestito2);
        Prestiti.Add(Prestito1);

    }

    //methods
    public bool AggiungiCliente(string nome, string cognome, string codiceFiscale, int stipendio)
    {

        if (
            nome == null || nome == "" ||
            cognome == null || cognome == "" ||
            codiceFiscale == null || codiceFiscale == "" ||
            stipendio < 0
            )
        {
            return false;
        }

        Cliente esistente = RicercaCliente(codiceFiscale);

        //se il cliente esiste l'istanza sarà diversa dal null
        if (esistente != null)
            return false;

        Cliente cliente = new Cliente(nome, cognome, codiceFiscale, stipendio);
        Clienti.Add(cliente);

        return true;
    }

    public Cliente RicercaCliente(string codiceFiscale)
    {

        foreach (Cliente cliente in Clienti)
        {
            if (cliente.CodiceFiscale == codiceFiscale)
                return cliente;
        }

        return null;
    }
    public Cliente ModificaCliente(string nome, string cognome, string codiceFiscale, int stipendio, string nuovoCF)
    {
        Cliente cliente = RicercaCliente(codiceFiscale);

        if (cliente.CodiceFiscale != "")
        {
            if (codiceFiscale == nuovoCF)
                cliente.CodiceFiscale = codiceFiscale;
            else
                cliente.CodiceFiscale = nuovoCF;

            cliente.Stipendio = stipendio;
            cliente.Nome = nome;
            cliente.Cognome = cognome;

            return cliente;
        }
        else
        {
            return null;

        }


    }
    public List<Prestito> RicercaPrestito(string codiceFiscale)
    {
        List<Prestito> trovati = new List<Prestito>();

        foreach (Prestito item in Prestiti)
        {
            if (item.Intestatario.CodiceFiscale == codiceFiscale)
            {
                trovati.Add(item);
            }
        }
        return trovati;

    }

    public int AmmontareTotalePrestitiCliente(string codiceFiscale)
    {

        List<Prestito> prestitiUtente = RicercaPrestito(codiceFiscale);

        return prestitiUtente.Count;
    }

    public int RateMancantiCliente(string codiceFiscale)
    {
        int rateMancanti = 0;
        List<Prestito> prestiti = RicercaPrestito(codiceFiscale);
        foreach (Prestito item in prestiti)
        {
            DateTime oggi = DateOnly.FromDateTime(DateTime.Now).ToDateTime(TimeOnly.Parse("10:00 PM"));
            DateTime fine = item.Fine.ToDateTime(TimeOnly.Parse("10:00 PM"));
            rateMancanti = fine.Subtract(oggi).Days / 30;

            item.RateMancanti();
        }
        return rateMancanti;

    }

    public void AggiungiPrestito(Prestito nuovoPrestito)
    {
        Prestiti.Add(nuovoPrestito);
        Console.WriteLine("{1}: {0}", nuovoPrestito, nuovoPrestito.GetType().ToString());
    }

}

