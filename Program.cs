using SpotifyConsole;

Console.WriteLine("<================================================>");
Console.WriteLine("Welkom bij Liam's Spotify Console aplicatie");
Console.WriteLine("1. Play Nummer\n\r" +
    "2. Add/Remove nummers\n\r" +
    "3. Speellijst zien\n\r" +
    "4. Add/remove Speellijst \n\r" +
    "5. Vriendlijst zien\n\r" +
    "6. Add/remove Vrijdlijst\n\r" +
    "0. exit");
Console.WriteLine("<================================================>");

Console.WriteLine("Voer een [cijfer] in: ");
int userInput = Convert.ToInt32(Console.ReadLine());

switch (userInput)
{
    case 1:
        test();
        break;
    case 0:
        break;
}

static void test()
{

    Nummer song1 = new Nummer(1, "HDMI", "BONES", "Rotten", "2014", 30.40);
    Nummer song2 = new Nummer(2, "Bob marley", "shunshine", "roken", "2002", 30.40);

    List<Nummer> song = new List<Nummer>();

    PlayList Liam = new PlayList(1, "Weekend");

    Liam.AddSongs(song1);
    Liam.AddSongs(song2);
}