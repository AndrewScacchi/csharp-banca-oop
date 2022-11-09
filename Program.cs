//Oggi cerchiamo di migliorare un pochino l’approccio nella costruzione di un codice ad oggetti, ben suddiviso tra diverse responsabilità. Il program.cs si occuperà quindi di gestire tutti i console.writeline/readline mentre le classi di dominio del nostro progetto devono occuparsi solo della logica applicativa e fare dei controlli dei dati quando questi violano qualche logica.
//
//Esempio, quando un cliente non può chiedere più prestiti? quale entità potrebbe occuparsi di questo controllo?
//
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
//
//Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere.
//
//Bonus:
//visualizzare per ogni cliente, la situazione dei suoi prestiti in formato tabellare.