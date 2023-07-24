CREATE TABLE Offers (
	ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID() NOT NULL,
	CheckInDate datetime DEFAULT GETDATE() NOT NULL,
	StayDurationNights int,
	PersonCombination VARCHAR(256),
	Service_Code VARCHAR(256),
	Price DECIMAL(10,2),
	PricePerAdult DECIMAL(10,2),
	PricePerChild DECIMAL(10,2),
	StrikePrice DECIMAL(10,2),
	StrikePricePerAdult DECIMAL(10,2),
	StrikePricePerChild DECIMAL(10,2),
	ShowStrikePrice bit,
	LastUpdated datetime DEFAULT GETDATE() NOT NULL
)
GO