SELECT Game.Title, Game.GameID FROM Game
INNER JOIN Library ON Library.GameID = Game.GameID
WHERE Library.PlayerID = 1;


