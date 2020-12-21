CREATE DATABASE BookStore;
GO

use BookStore;
--CREATE TABLE UserB (
--    UserId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
--	UserName varchar(255) NOT NULL,
--	Email varchar(255) NOT NULL,
--	Password varchar(255) NOT NULL,
--	Phone  varchar(255) NOT NULL,
--	Address  varchar(255) NOT NULL
    
--);
--GO


CREATE TABLE OrderB (
    OrderId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserId int Not null,
    OrderDate date NOT NULL,
	OrderStatus varchar(255) not null, 
	TotalPrice int
);
GO 
CREATE TABLE BookType (
    BookTypeId  int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	BookTypeName varchar(255) NOT NULL,

);


GO 
CREATE TABLE Book (
    BookId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	BookName varchar(255) NOT NULL,
	BookImage  VARCHAR(255) not null,
	BookPrice int NOT NULL,
	isDeleted bit,
	
    
);
CREATE TABLE Book_BookType (
	
	
	BookId int FOREIGN KEY REFERENCES Book(BookId ),
	BookTypeId  int FOREIGN KEY REFERENCES BookType(BookTypeId),
	CONSTRAINT PK_Book_BookType PRIMARY KEY (BookId,BookTypeId)
	--FOREIGN KEY (BookId) REFERENCES Book(BookId), 
 --   FOREIGN KEY (OrderId) REFERENCES OrderB(OrderId),
	--UNIQUE (BookId, OrderId)
	
);



CREATE TABLE OrderB_Detail (
	
	Amount int NOT NULL,
	BookId int FOREIGN KEY REFERENCES Book(BookId ),
	OrderId  int FOREIGN KEY REFERENCES OrderB(OrderId),
	CONSTRAINT PK_OrderB_Detail PRIMARY KEY (BookId,OrderId)
	--FOREIGN KEY (BookId) REFERENCES Book(BookId), 
 --   FOREIGN KEY (OrderId) REFERENCES OrderB(OrderId),
	--UNIQUE (BookId, OrderId)
	
);


use BookStore;

SELECT * FROM BookType

delete Book_BookType; 
delete Book;


INSERT INTO Book (BookName, BookImage, BookPrice, isDeleted)
VALUES ('Cardinal', 'Tom B. Erichsen', 100,0);
INSERT INTO Book (BookName, BookImage, BookPrice, isDeleted)
VALUES ('Cardinal2', 'Tom B. Erichsen', 100,0);
INSERT INTO Book (BookName, BookImage, BookPrice, isDeleted)
VALUES ('Cardinal3', 'Tom B. Erichsen', 100,0);



INSERT INTO OrderB (UserId, OrderDate, OrderStatus, TotalPrice)
VALUES (1, '2020-12-19', 'dangxuli',1000);


INSERT INTO OrderB (UserId, OrderDate, OrderStatus, TotalPrice)
VALUES (2, '2020-12-19', 'damua',1000000);



INSERT INTO OrderB_Detail (Amount, BookId, OrderId)
VALUES (2, 2, 1);

INSERT INTO OrderB_Detail (Amount, BookId, OrderId)
VALUES (2, 1, 1);


