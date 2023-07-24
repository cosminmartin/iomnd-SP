CREATE PROCEDURE SP_Offers_Save
(
    @CheckInDate as datetime,
	@StayDurationNights as int,
	@PersonCombination as VARCHAR(256),
	@Service_Code as VARCHAR(256),
	@Price as DECIMAL(10,2),
	@PricePerAdult as DECIMAL(10,2),
	@PricePerChild as DECIMAL(10,2),
	@StrikePrice as DECIMAL(10,2),
	@StrikePricePerAdult as DECIMAL(10,2),
	@StrikePricePerChild as DECIMAL(10,2),
	@ShowStrikePrice as bit,
	@LastUpdated as datetime
)

AS
BEGIN TRAN
BEGIN
	INSERT INTO Offers 
	(
	CheckInDate,
	StayDurationNights,
	PersonCombination,
	Service_Code,
	Price,
	PricePerAdult,
	PricePerChild,
	StrikePrice,
	StrikePricePerAdult,
	StrikePricePerChild,
	ShowStrikePrice,
	LastUpdated
	)

	VALUES
	(
	@CheckInDate,
	@StayDurationNights,
	@PersonCombination,
	@Service_Code,
	@Price,
	@PricePerAdult,
	@PricePerChild,
	@StrikePrice,
	@StrikePricePerAdult,
	@StrikePricePerChild,
	@ShowStrikePrice,
	@LastUpdated
	)
END
COMMIT TRAN