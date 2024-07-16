Create DataBase OnlineShop;
GO

use OnlineShop;
GO


CREATE TABLE Brands (
	b_id UNIQUEIDENTIFIER NOT NULL,
	b_name varchar(50) NOT NULL,

	CONSTRAINT PK_Brand_Id PRIMARY KEY (b_id), 
);

CREATE TABLE Rackets(
	r_id UNIQUEIDENTIFIER NOT NULL,
	r_name varchar(50) NOT NULL,
	r_brand UNIQUEIDENTIFIER ,
	r_price decimal(5,2) NOT NULL,
	r_image_url varchar(500) NOT NULL,

	CONSTRAINT PK_Racket_Id PRIMARY KEY (r_id), 
	CONSTRAINT CK_Racket_Price CHECK(r_price > 0),
	CONSTRAINT FK_Brands_To_Rackets FOREIGN KEY (r_brand)  REFERENCES BRANDS (b_id)
);

Create Table Images (
	id UNIQUEIDENTIFIER NOT NULL,
	image_url varchar(500) NOT NULL
);
