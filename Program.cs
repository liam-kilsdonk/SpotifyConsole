﻿using SpotifyConsole;
using System.Collections.Generic;
using System.Linq.Expressions;

Nummer song1 = new Nummer(1, "HDMI", "BONES", "Rotten", "2014", 300);
Nummer song2 = new Nummer(2, "Bob marley", "Three Little Birds", "Exodus", "1977", 100);
Nummer song3 = new Nummer(3, "Ava Max", "Sweet but Psycho", "Heaven & Hell", "2020", 300);
Nummer song4 = new Nummer(4, "Ericdoa", "Fantasize", "Fantasize", "2021", 300);
Nummer song5 = new Nummer(5, "Pop Smoke", "Mood Swings", "Shoot for the Stars, Aim for the Moon", "2019", 300);

PlayList Liam = new PlayList(1, "Weekend");
PlayList Bob = new PlayList(2, "Carnaval");

Liam.AddSongs(song1, song2, song3, song4, song5);

List<PlayList> playlists = new List<PlayList>();

playlists.Add(Liam);
playlists.Add(Bob);

List<FriendList> friend = new List<FriendList>();

FriendList friend1 = new FriendList(1, "Daan");
FriendList friend2 = new FriendList(2, "Amber");
FriendList friend3 = new FriendList(3, "Tijn");

friend.Add(friend1);
friend.Add(friend2);
friend.Add(friend3);

List<Album> albums = new List<Album>();

Album album1 = new Album(1, "Hey ya", "Outkast");
Album album2 = new Album(2, "Only you", "The Platters");

albums.Add(album1);
albums.Add(album2);

bool running = true;

while (running)
{
    //Console.Clear();
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
            Console.Clear();
            PlayNummer(playlists);
            break;
        case 2:
            Console.Clear();
            ShowPlayList(playlists);
            break;
        case 3:
            Console.Clear();
            ShowFriendList(friend);
            break;
        case 4:
            Console.Clear();
            ShowAlbumList(albums);
            break;
        case 0:
            running = false;
            break;
        default:
            Console.WriteLine("Ongeldige invoer. Voer een geldige optie in.");
            break;
    }
}

static void NowPlaying(Nummer song)
{
    Console.Write("Now playing: {0} - {1} [", song.Artist, song.Title);
    int progressBarWidth = Console.WindowWidth - 50; // width of the progress bar
    int duration = song.Duration; // get the duration of the selected song
    Console.WriteLine("Druk `P` in om te pauzeren en verder te gaan.");
    for (int i = 0; i <= duration; i++)
    {
        Console.Write("=");
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        Console.Write("=");

        // check for pause input
        while (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.P)
            {
                Console.WriteLine("\nPaused. Press any key to continue.");
                Console.ReadKey();
            }
        }

        Thread.Sleep(duration / progressBarWidth);
    }
    Console.WriteLine("]");
}

static void PlayNummer(List<PlayList> playlists)
{
    Console.Clear();
    Console.WriteLine("<================================================>");

    //List<PlayList> playlists

    foreach (PlayList song in playlists)
    {
        Console.WriteLine("PlayList: {0}. {1}", song.Id, song.Name);

        foreach (Nummer x in song.Nummers)
        {
            Console.WriteLine(x.Title);
        }
    }

    Console.WriteLine("<================================================>");
    Console.WriteLine("Song's action's:\n\r" +
        "1. Shuffle Song's\n\r" +
        "2. Select Song's\n\r" +
        "3. Add Song's\n\r" +
        "4. Remove Song's\n\r" +
        "5. Exit");

    Console.WriteLine("Voer een [cijfer] in: ");
    int userInput = Convert.ToInt32(Console.ReadLine());

    switch (userInput)
    {
        case 1:
            Console.Clear();
            Shuffle(playlists);
            break;
        case 2:
            Console.Clear();
            SelectSong(playlists);
            break;
        case 3:
            Console.Clear();
            AddSong(playlists);
            break;
        case 4:
            Console.Clear();
            RemoveSong(playlists);
            break;
        case 5:
            break;
    }

    static void Shuffle(List<PlayList> playlists)
    {
        Random rnd = new Random();

        foreach (PlayList song in playlists)
        {
            //Console.WriteLine("PlayList: {0}. {1}", song.Id, song.Name);

            foreach (Nummer x in song.Nummers)
            {
                int index = rnd.Next(song.Nummers.Count);
                Nummer randomNummer = song.Nummers[index];
                Console.WriteLine(randomNummer.Title);
                NowPlaying(randomNummer);
                break;
            }
        }
    }

    static void SelectSong(List<PlayList> playlists)
    {
        Console.Clear();
        Console.WriteLine("<================================================>");
        foreach (PlayList playlist in playlists)
        {
            Console.WriteLine("Playlist: {0}. {1}", playlist.Id, playlist.Name);

            foreach (Nummer song in playlist.Nummers)
            {
                Console.WriteLine("{0}. {1}", song.Id, song.Title);
            }

            Console.WriteLine("<================================================>");

            Console.Write("Kies een nummer: ");
            int selectedSongId = int.Parse(Console.ReadLine());

            Nummer selectedSong = playlist.Nummers.FirstOrDefault(x => x.Id == selectedSongId);

            if (selectedSong != null)
            {
                NowPlaying(selectedSong);
                break;
            }
            else
            {
                Console.WriteLine("Ongeldig nummer. Probeer het opnieuw.");
            }
        }
    }

    static void AddSong(List<PlayList> playlists)
    {
        Console.WriteLine("Select a playlist to add the song to:");
        foreach (var playlist in playlists)
        {
            Console.WriteLine("{0}. {1}", playlist.Id, playlist.Name);
        }
        Console.Write("Enter the number of the playlist: ");
        int playlistNumber = int.Parse(Console.ReadLine());

        PlayList playlistToAddSong = playlists.FirstOrDefault(p => p.Id == playlistNumber);
        if (playlistToAddSong != null)
        {
            Console.Write("Enter the title of the song: ");
            string title = Console.ReadLine();
            Console.Write("Enter the artist of the song: ");
            string artist = Console.ReadLine();
            Console.Write("Enter the duration of the song (in seconds): ");
            int duration = int.Parse(Console.ReadLine());

            Nummer newSong = new Nummer(title, artist, duration);
            playlistToAddSong.AddSongs(newSong);
            Console.WriteLine("Song added to playlist {0}!", playlistToAddSong.Name);
        }
        else
        {
            Console.WriteLine("Invalid playlist number!");
        }
    }

    static void RemoveSong(List<PlayList> playlists)
    {
        Console.WriteLine("Select a playlist to remove the song from:");
        foreach (var playlist in playlists)
        {
            Console.WriteLine("{0}. {1}", playlist.Id, playlist.Name);
        }
        Console.Write("Enter the number of the playlist: ");
        int playlistNumber = int.Parse(Console.ReadLine());

        if (playlists.Any(p => p.Id == playlistNumber))
        {
            Console.Write("Enter the title of the song to remove: ");
            string title = Console.ReadLine();

            var playlistToRemoveFrom = playlists.First(p => p.Id == playlistNumber);
            var songToRemove = playlistToRemoveFrom.Nummers.FirstOrDefault(s => s.Title == title);

            if (songToRemove != null)
            {
                playlistToRemoveFrom.Nummers.Remove(songToRemove);
                Console.WriteLine("Song '{0}' removed from playlist '{1}'", title, playlistToRemoveFrom.Name);
            }
            else
            {
                Console.WriteLine("Song '{0}' not found in playlist '{1}'", title, playlistToRemoveFrom.Name);
            }
        }
        else
        {
            Console.WriteLine("Invalid playlist number!");
        }
    }
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
            Console.Clear();
            AddPlayList(playlists);
            break;
        case 2:
            Console.Clear();
            RemovePlayList(playlists);
            break;
        case 3:
            Console.Clear();
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

static void ShowFriendList(List<FriendList> friendLists)
{
    Console.Clear();
    Console.WriteLine("<================================================>");
    Console.WriteLine("FriendList:");

    Console.WriteLine("List of Friends:");
    foreach (var friendList in friendLists)
    {
        Console.WriteLine("- {0}", friendList.Name);
    }

    Console.WriteLine("<================================================>");
    Console.WriteLine("FriendList action's:\n\r" +
        "1. Add FriendList\n\r" +
        "2. Remove FriendList\n\r" +
        "3. Exit");

    Console.WriteLine("Voer een [cijfer] in: ");
    int userInput = Convert.ToInt32(Console.ReadLine());

    switch (userInput)
    {
        case 1:
            Console.Clear();
            AddFriend(friendLists);
            break;
        case 2:
            Console.Clear();
            RemoveFriend(friendLists);
            break;
        case 3:
            break;
    }

    static void RemoveFriend(List<FriendList> friendLists)
    {
        Console.Write("Enter the name of the friend to remove: ");
        string friendName = Console.ReadLine();

        var friendToRemove = friendLists.FirstOrDefault(f => f.Name == friendName);

        if (friendToRemove != null)
        {
            friendLists.Remove(friendToRemove);
            Console.WriteLine("Friend '{0}' removed from friend list.", friendName);
        }
        else
        {
            Console.WriteLine("Friend '{0}' not found in friend list.", friendName);
        }
    }

    static void AddFriend(List<FriendList> friendLists)
    {
        Console.Write("Enter the name of the friend to add: ");
        string friendName = Console.ReadLine();

        var friendToAdd = new FriendList(friendLists.Count + 1, friendName);

        friendLists.Add(friendToAdd);
        Console.WriteLine("Friend '{0}' added to friend list.", friendName);
    }

    static void ComparePlayList()
    {
        //
    }
}

static void ShowAlbumList(List<Album> albums)
{
    Console.Clear();
    Console.WriteLine("<================================================>");
    Console.WriteLine("Album List:");

    foreach (var album in albums)
    {
        Console.WriteLine("- {0} by {1}", album.Title, album.Artist);
    }

    Console.WriteLine("<================================================>");
    Console.WriteLine("AlbumList action's:\n\r" +
        "1. Add AlbumList\n\r" +
        "2. Remove AlbumList\n\r" +
        "3. Exit");

    Console.WriteLine("Voer een [cijfer] in: ");
    int userInput = Convert.ToInt32(Console.ReadLine());

    switch (userInput)
    {
        case 1:
            Console.Clear();
            AddAlbum(albums);
            break;
        case 2:
            Console.Clear();
            RemoveAlbum(albums);
            break;
        case 3:
            break;
    }

    static void AddAlbum(List<Album> albums)
    {
        Console.WriteLine("Enter the title of the album:");
        string title = Console.ReadLine();
        Console.WriteLine("Enter the name of the artist:");
        string artist = Console.ReadLine();

        Album newAlbum = new Album(albums.Count + 1, title, artist);
        albums.Add(newAlbum);

        Console.WriteLine("Album '{0}' by '{1}' added to list", title, artist);
    }

    static void RemoveAlbum(List<Album> albums)
    {
        Console.WriteLine("Enter the title of the album to remove:");
        string title = Console.ReadLine();

        var albumToRemove = albums.FirstOrDefault(a => a.Title == title);

        if (albumToRemove != null)
        {
            albums.Remove(albumToRemove);
            Console.WriteLine("Album '{0}' removed from list", title);
        }
        else
        {
            Console.WriteLine("Album '{0}' not found in list", title);
        }
    }
}