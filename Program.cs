using SpotifyConsole;
using System.Collections.Generic;
using System.Linq.Expressions;

Nummer song1 = new Nummer(1, "HDMI", "BONES", "Rotten", "2014", 30.40);
Nummer song2 = new Nummer(2, "Bob marley", "Three Little Birds", "Exodus", "1977", 30.40);
Nummer song3 = new Nummer(3, "Ava Max", "Sweet but Psycho", "Heaven & Hell", "2020", 30.40);
Nummer song4 = new Nummer(4, "Ericdoa", "Fantasize", "Fantasize", "2021", 30.40);
Nummer song5 = new Nummer(5, "Pop Smoke", "Mood Swings", "Shoot for the Stars, Aim for the Moon", "2019", 30.40);

PlayList Liam = new PlayList(1, "Weekend");
PlayList Bob = new PlayList(2, "Carnaval");

Liam.AddSongs(song1, song2, song3, song4, song5);

List<PlayList> playlists = new List<PlayList>();

playlists.Add(Liam);
playlists.Add(Bob);

Console.WriteLine("<================================================>");
Console.WriteLine("Welkom bij Liam's Spotify Console aplicatie");
Console.WriteLine("1. Play Nummer\n\r" +
    "2. Speellijst zien\n\r" +
    "3. Vriendlijst zien\n\r" +
    "4. Album's zien\n\r" +
    "0. exit");
Console.WriteLine("<================================================>");

Console.WriteLine("Voer een [cijfer] in: ");
int userInput = Convert.ToInt32(Console.ReadLine());

switch (userInput)
{
    case 1:
        PlayNummer();
        break;
    case 2:
        ShowPlayList(playlists);
        break;
    case 3:
        ShowFriendList();
        break;
    case 4:
        ShowAlbumList();
        break;
    case 0:
        break;
}

static void PlayNummer()
{
    //
}

static void ShowPlayList(List<PlayList> playlists)
{
    Console.Clear();
    Console.WriteLine("<================================================>");
    Console.WriteLine("Playlists:");

    //List<PlayList> playlists
    foreach (PlayList playlist in playlists)
    {
        Console.WriteLine("{0}. {1}", playlist.Id, playlist.Name);
    }

    Console.WriteLine("<================================================>");
    Console.WriteLine("PlayList action's:\n\r" +
        "1. Add PlayList\n\r" +
        "2. Remove PlayList\n\r" +
        "3. Select PlayList\n\r" +
        "4. Exit");

    Console.WriteLine("Voer een [cijfer] in: ");
    int userInput = Convert.ToInt32(Console.ReadLine());

    switch (userInput)
    {
        case 1:
            AddPlayList(playlists);
            break;
        case 2:
            RemovePlayList(playlists);
            break;
        case 3:
            SelectPlaylist(playlists);
            break;
        case 4:
            break;
    }

    static void RemovePlayList(List<PlayList> playlists)
    {
        Console.WriteLine("Select the PlayList Id to Remove:");
        int playlistId = Convert.ToInt32(Console.ReadLine());

        PlayList playlistToRemove = playlists.Find(playlist => playlist.Id == playlistId);

        if (playlistToRemove != null)
        {
            playlists.Remove(playlistToRemove);
            Console.WriteLine("PlayList removed successfully.");
        }

        else
        {
            Console.WriteLine("No PlayList found with the given Id.");
        }
        Console.WriteLine("<================================================>");
        Console.WriteLine("Remaining PlayLists:");
        foreach (PlayList playlist in playlists)
        {
            Console.WriteLine("{0}. {1}", playlist.Id, playlist.Name);
        }
    }

    static void AddPlayList(List<PlayList> playlists)
    {
        Console.WriteLine("Enter the name of the new PlayList:");
        string name = Console.ReadLine();

        PlayList newPlayList = new PlayList(playlists.Count + 1, name);
        playlists.Add(newPlayList);

        Console.WriteLine("PlayList added successfully!");
        Console.WriteLine("<================================================>");
        Console.WriteLine("Remaining PlayLists:");
        foreach (PlayList playlist in playlists)
        {
            Console.WriteLine("{0}. {1}", playlist.Id, playlist.Name);
        }
    }

    static void SelectPlaylist(List<PlayList> playlists)
    {
        Console.WriteLine("Select a PlayList:");
        foreach (PlayList playlist in playlists)
        {
            Console.WriteLine("{0}. {1}", playlist.Id, playlist.Name);
        }

        int userInput = Convert.ToInt32(Console.ReadLine());

        PlayList selectedPlaylist = playlists.FirstOrDefault(p => p.Id == userInput);

        if (selectedPlaylist != null)
        {
            Console.WriteLine("<================================================>");
            Console.WriteLine("PlayList: {0}", selectedPlaylist.Name);
            Console.WriteLine("Songs:");

            foreach (Nummer song in selectedPlaylist.Nummers)
            {
                Console.WriteLine("{0}. {1} - {2} ({3})", song.Id, song.Artist, song.Title, song.Album);
            }

            Console.WriteLine("<================================================>");
        }
        else
        {
            Console.WriteLine("Invalid selection. Please try again.");
        }
    }
}

static void ShowFriendList()
{
    //
}

static void ShowAlbumList()
{
    //
}