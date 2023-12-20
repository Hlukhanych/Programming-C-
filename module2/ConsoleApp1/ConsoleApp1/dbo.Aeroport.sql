CREATE TABLE [dbo].[Aeroport] (
    [Id]             INT           NOT NULL,
    [numberOfRace]   INT           NULL,
    [placeOfArivale] NVARCHAR (50) NULL,
    [numberOfSeats]  INT           NULL,
    [flightTime]     INT      NULL,
    [priceOfTicket]  INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

