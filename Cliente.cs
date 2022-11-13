// Cliente class
// I clienti sono caratterizzati da
//nome,
//cognome,
//codice fiscale
//stipendio
public class Cliente
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string CodiceFiscale { get; set; }
    public int Stipendio { get; set; }

    //constructor
    public Cliente(string nome, string cognome, string codiceFiscale, int stipendio)
    {
        Nome = nome;
        Cognome = cognome;
        CodiceFiscale = codiceFiscale;
        Stipendio = stipendio;
    }

    //toString
    public override string ToString()
    {
        return "Utente: "+ Nome +" "+  Cognome + "Codice fiscale: " + CodiceFiscale + "Stipendio: " + Stipendio;
    }
}