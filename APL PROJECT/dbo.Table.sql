CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Description NVARCHAR(255),
    Price DECIMAL(10,2),
    Category NVARCHAR(100),
    ImagePath NVARCHAR(255)
);

