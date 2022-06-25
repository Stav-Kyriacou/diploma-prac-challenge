IF OBJECT_ID('Treatment') IS NOT NULL
DROP TABLE Treatment
GO

IF OBJECT_ID('Procedure') IS NOT NULL
DROP TABLE [Procedure]
GO

IF OBJECT_ID('Pet') IS NOT NULL
DROP TABLE Pet
GO

IF OBJECT_ID('Owner') IS NOT NULL
DROP TABLE [Owner]
GO



CREATE TABLE [Owner]
(
    OwnerID INT NOT NULL,
    Surname NVARCHAR(50) NOT NULL,
    Firstname NVARCHAR(50) NOT NULL,
    Phone INT NOT NULL,
    PRIMARY KEY (OwnerID)
);
GO

CREATE TABLE [Procedure]
(
    ProcedureID INT NOT NULL,
    [Description] NVARCHAR(200) NOT NULL,
    Price FLOAT NOT NULL,
    PRIMARY KEY (ProcedureID)
);
GO

CREATE TABLE Pet
(
    OwnerID INT NOT NULL,
    PetID INT NOT NULL,
    PetName NVARCHAR(50) NOT NULL,
    [Type] NVARCHAR(50) NOT NULL,
    PRIMARY KEY (PetID),
    FOREIGN KEY (OwnerID) REFERENCES [Owner] (OwnerID)
);
GO

CREATE TABLE Treatment
(
    OwnerID INT NOT NULL,
    TreatmentID INT NOT NULL,
    PetID INT NOT NULL,
    ProcedureID INT NOT NULL,
    [Date] DATE NOT NULL,
    Notes NVARCHAR(200) NOT NULL,
    Payment FLOAT NOT NULL,
    PRIMARY KEY (TreatmentID),
    FOREIGN KEY (OwnerID) REFERENCES [Owner] (OwnerID),
    FOREIGN KEY (PetID) REFERENCES Pet (PetID),
    FOREIGN KEY (ProcedureID) REFERENCES [Procedure] (ProcedureID)
);
GO

INSERT INTO [Owner]
    (OwnerID, Surname, Firstname, Phone)
VALUES
    (1, 'Sinatra', 'Frank', 400111222),
    (2, 'Ellington', 'Duke', 400222333),
    (3, 'Fitzgerald', 'Ella', 400333444);

INSERT INTO [Procedure]
    (ProcedureID, [Description], Price)
VALUES
    (01, 'Rabies Vaccination', 24.00),
    (10, 'Examine and Treat Wound', 30.00),
    (05, 'Heart Worm Test', 25.00),
    (08, 'Tetnus Vaccination', 17.00);

INSERT INTO Pet
    (OwnerID, PetID, PetName, [Type])
VALUES
    (1, 1, 'Buster', 'Dog'),
    (1, 2, 'Fluffy', 'Cat'),
    (2, 3, 'Stew', 'Rabbit'),
    (3, 4, 'Buster', 'Echidna');

INSERT Treatment
    (TreatmentID, OwnerID, PetID, ProcedureID, [Date], Notes, Payment)
VALUES
    (1, 1, 1, 01, '2017-06-20', 'Routine Vaccination', 22.00),
    (2, 1, 1, 01, '2018-05-15', 'Booster Shot', 24.00),
    (3, 1, 2, 10, '2018-05-10', 'Wounds sustained in apparent cat fight.', 30.00),
    (4, 2, 3, 10, '2018-05-10', 'Wounds sustained during attempt to cook the stew.', 30.00),
    (5, 3, 4, 08, '2017-06-20', 'Stepped on a Rusty Nail', 17.00 ),
    (6, 3, 4, 01, '2017-06-20', 'Routine Vaccination', 22.00 );