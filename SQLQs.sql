SELECT Library.PlayerID, Player.Name, Library.GameID, Game.Title
FROM Library
JOIN Player ON Library.PlayerID = Player.PlayerID
JOIN Game ON Library.GameID = Game.GameID;

