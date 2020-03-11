CREATE TABLE video(
idVideo int primary key,
titulo varchar (100),
repro int,
url varchar(100)

)
	CREATE PROCEDURE sp_video_insertar
         @idVideo int,
		 @titulo varchar (100),
		 @repro int,
		 @url varchar (100)
	as
	begin
	   INSERT INTO video
	   Values (@idVideo,@titulo,@repro,@url)
	end

	EXEC sp_video_insertar 1,'video',1,'x'

	select * from video

	CREATE PROCEDURE sp_video_actualizar
	@idVideo int,
		 @titulo varchar (100),
		 @repro int,
		 @url varchar (100)
	as
	begin
	UPDATE video SET titulo=@titulo,repro=@repro, url=@url where idVideo=@idVideo
	END

EXEC sp_video_actualizar 2,'k',1,'x'