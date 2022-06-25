IF OBJECT_ID('CountBy1') IS NOT NULL
    DROP SEQUENCE Count.CountBy1;

IF OBJECT_ID('Count') IS NOT NULL
    DROP SCHEMA Count;
GO

Create SCHEMA Count;
GO

CREATE SEQUENCE Count.CountBy1
    Start WITH 10
    INCREMENT BY 1;
GO

------------------------------------------------------------
--------------------------ADD OWNER-------------------------
------------------------------------------------------------

IF OBJECT_ID('ADD_OWNER') IS NOT NULL
    DROP PROCEDURE ADD_OWNER
GO

CREATE PROCEDURE ADD_OWNER
    @pOwnerID INT OUTPUT,
    @pSurname NVARCHAR(50),
    @pFirstname NVARCHAR(50),
    @pPhone INT
AS
BEGIN
    DECLARE @ID BIGINT;
    SET @ID = NEXT VALUE FOR Count.CountBy1;
    SET @pOwnerID = @ID
    BEGIN TRY
        INSERT INTO [Owner]
        (OwnerID, Surname, Firstname, Phone)
    VALUES
        (@ID, @pSurname, @pFirstname, @pPhone)
    END TRY
    BEGIN CATCH
    END CATCH

    RETURN @pOwnerID
END
GO

------------------------------------------------------------
--------------------------ADD PET---------------------------
------------------------------------------------------------
IF OBJECT_ID('ADD_PET') IS NOT NULL
    DROP PROCEDURE ADD_PET
GO

CREATE PROCEDURE ADD_PET
    @pOwnerID INT,
    @pPetName NVARCHAR(50),
    @pType NVARCHAR(50)
AS
BEGIN
    DECLARE @ID BIGINT;
    SET @ID = NEXT VALUE FOR Count.CountBy1;
    BEGIN TRY
        INSERT INTO Pet
        (OwnerID, PetID, PetName, [Type])
    VALUES
        (@pOwnerID, @ID, @pPetName, @pType)
    END TRY
    BEGIN CATCH
    END CATCH
END
GO

------------------------------------------------------------
--------------------------ADD TREATMENT---------------------
------------------------------------------------------------
IF OBJECT_ID('ADD_TREATMENT') IS NOT NULL
    DROP PROCEDURE ADD_TREATMENT
GO

CREATE PROCEDURE ADD_TREATMENT
    @pOwnerID INT,
    @pPetID INT,
    @pProcedureID INT,
    @pDate DATE,
    @pNotes NVARCHAR(200),
    @pPayment FLOAT
AS
BEGIN
    DECLARE @ID BIGINT;
    SET @ID = NEXT VALUE FOR Count.CountBy1;
    BEGIN TRY
        INSERT Treatment
        (TreatmentID, OwnerID, PetID, ProcedureID, [Date], Notes, Payment)
    VALUES
        (@ID, @pOwnerID, @pPetID, @pProcedureID, @pDate, @pNotes, @pPayment)
    END TRY
    BEGIN CATCH
    END CATCH
END
GO
