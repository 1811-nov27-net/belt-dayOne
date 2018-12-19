SELECT * FROM dbo.Movie;

SELECT * FROM dbo.CastMember;

INSERT INTO dbo.CastMember(Name, MovieId) VALUES (
'Harrison Ford', 
(SELECT Id FROM dbo.Movie WHERE Title = 'Star Wars'));