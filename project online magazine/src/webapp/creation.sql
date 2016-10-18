CREATE TABLE formation
(
  refform varchar(3) PRIMARY KEY,
  libelform varchar(15)
);
CREATE TABLE theme
(
  reftheme varchar(3) PRIMARY KEY,
  libeltheme varchar(20)
);
CREATE TABLE news
(
  refnews varchar(3) PRIMARY KEY,
  titre varchar(20),
  dateParu date,
  corps varchar(20),
  refForm varchar(3),
  refTheme varchar(3),
  lien varchar(30),
  enligne integer(11) default 0,
  dateFin date
);


CREATE TABLE [dbo].[formation] (
	[refform] [varchar] (3) COLLATE Arabic_CI_AS NOT NULL ,
	[libelform] [varchar] (15) COLLATE Arabic_CI_AS NULL 
);

CREATE TABLE [dbo].[theme] (
	[reftheme] [varchar] (3) COLLATE Arabic_CI_AS NOT NULL ,
	[libeltheme] [varchar] (20) COLLATE Arabic_CI_AS NULL 
) ;

