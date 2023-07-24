namespace ConsoleApp
{
    internal class Queries
    {
        //Get All - No Stored Procedure
        public static void GetOffers(SqlConnection conn)
        {
            var sqlSelectAllOffers = "SELECT * FROM Offers";
            var offers = conn.Query<Offer>(sqlSelectAllOffers);

            foreach (Offer offer in offers)
            {
                Console.WriteLine(
                    offer.CheckInDate.ToString("dd MMMM, yyyy") + " " +
                    offer.StayDurationNights.ToString() + " " +
                    offer.PersonCombination + " " +
                    offer.Service_Code + " " +
                    offer.Price.ToString() + " " +
                    offer.PricePerAdult.ToString() + " " +
                    offer.PricePerChild.ToString() + " " +
                    offer.StrikePrice.ToString() + " " +
                    offer.StrikePricePerAdult.ToString() + " " +
                    offer.StrikePricePerChild.ToString() + " " +
                    offer.ShowStrikePrice.ToString() + " " +
                    offer.LastUpdated.ToString("dd MMMM, yyyy")
                    );
            }
            Console.ReadLine();
        }

        //GetById - Execute Stored Procedure
        public static void GetOfferById(SqlConnection conn)
        {
            Console.WriteLine("Enter Id: ");
            string inputId;
            inputId = Console.ReadLine();

            //Set up DynamicParameters object to pass parameters  
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", inputId);

            //Execute stored procedure and map the returned result to a Offer object  
            var offer = conn.QuerySingleOrDefault<Offer>("SP_Offers_GetOfferById", parameters, commandType: CommandType.StoredProcedure);

            Console.WriteLine(
               offer.CheckInDate.ToString("dd MMMM, yyyy") + " " +
               offer.StayDurationNights.ToString() + " " +
               offer.PersonCombination + " " +
               offer.Service_Code + " " +
               offer.Price.ToString() + " " +
               offer.PricePerAdult.ToString() + " " +
               offer.PricePerChild.ToString() + " " +
               offer.StrikePrice.ToString() + " " +
               offer.StrikePricePerAdult.ToString() + " " +
               offer.StrikePricePerChild.ToString() + " " +
               offer.ShowStrikePrice.ToString() + " " +
               offer.LastUpdated.ToString("dd MMMM, yyyy")
               );

            Console.ReadLine();
        }

        //OLD - not used
        //public static void SaveOffer(Offer offer, SqlConnection conn)
        //{
        //    var sqlCommand = new SqlCommand("SP_Offers_Save", conn);

        //    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

        //    sqlCommand.Parameters.AddWithValue("@CheckInDate", offer.CheckInDate);
        //    sqlCommand.Parameters.AddWithValue("@StayDurationNights", offer.StayDurationNights);
        //    sqlCommand.Parameters.AddWithValue("@PersonCombination", offer.PersonCombination);
        //    sqlCommand.Parameters.AddWithValue("@Service_Code", offer.Service_Code);
        //    sqlCommand.Parameters.AddWithValue("@Price", offer.Price);
        //    sqlCommand.Parameters.AddWithValue("@PricePerAdult", offer.PricePerAdult);
        //    sqlCommand.Parameters.AddWithValue("@PricePerChild", offer.PricePerChild);
        //    sqlCommand.Parameters.AddWithValue("@StrikePrice", offer.StrikePrice);
        //    sqlCommand.Parameters.AddWithValue("@StrikePricePerAdult", offer.StrikePricePerAdult);
        //    sqlCommand.Parameters.AddWithValue("@StrikePricePerChild", offer.StrikePricePerChild);
        //    sqlCommand.Parameters.AddWithValue("@ShowStrikePrice", offer.ShowStrikePrice);
        //    sqlCommand.Parameters.AddWithValue("@LastUpdated", offer.LastUpdated);

        //    sqlCommand.ExecuteNonQuery();
        //}


        public static void GenerateOffers(SqlConnection conn)
        {
            {

                var saveOffer = "SP_Offers_Save";

                string[] serviceCodes = { "HRO - ROLEIIS - MCL", "HRO - ROLEIIS - FBA", "HRO - ROLEIIS - FBB", "HRO - ROLEIIS - FBA - H", "HRO - ROLEIIS - FBC", "HRO - ROLEIIS - FFI - H", "HRO - ROVIEIS - MVE", "HRO - ROVIEIS - MVE - H", "HRO - ROVIEIS - FFH - H", "HRO - RONURIS - MVE", "HRO - RONURIS - MNE", "HRO - ROHENIS - MPR - 2SZ", "HRO - ROHENIS - MPR - 2SZ - H", "HRO - ROHENIS - MPR", "HRO - ROHENIS - MPR - H", "HRO - ROHENIS - LON", "HRO - ROHENIS - LJA", "HRO - ROHAMIS - MNE", "HRO - ROHAMIS - MNE - H", "HRO - ROLACIS - MVE", "HRO - ROHAMIS - MVE", "HRO - ROHAMIS - MVE - H", "HRO - ROLACIS - MJU", "HRO - ROLACIS - MVE - H", "HRO - ROLACIS - MPA", "HRO - ROLACIS - FFA", "HRO - ROLACIS - FFA - H", "HRO - RORUGIS - MVE", "HRO - RORUGIS - FFH", "HRO - ROLACIS - FFB", "HRO - ROBURIS - MEX", "HRO - ROBURIS - MEX - M", "HRO - RODORIS - MCL", "HRO - RODURIS - MVE - H", "HRO - RODURIS - MPR", "HRO - ROECKIS - MEX", "HRO - ROELBIS - LON", "HRO - ROELBIS - LJA", "HRO - ROESCIS - MPR - 2SZ", "HRO - ROESSIS - MMA", "HRO - ROESSIS - MMA - H", "HRO - ROFRIIS - MCL", "HRO - ROFRIIS - MCL - H", "HRO - ROHUNIS - FFH", "HRO - ROHUNIS - FFH - H", "HRO - ROKISIS - MCL", "HRO - ROOYTIS - MEX", "HRO - ROTOSIS - MEX", "HRO - ROTOSIS - MEX - M", "HRO - ROWALIS - MVE", "HRO - ROWALIS - MVE - H", "HRO - ROWALIS - MCL", "HRO - ROWINIS - LAM", "HRO - ROWINIS - FFH" };

                foreach (string serviceCode in serviceCodes)
                {
                    Random rnd = new Random();

                    DateTime RandomDay() // Generates a date from today to the next year 
                    {
                        DateTime end = new DateTime(2024, 1, 1);
                        int range = (end - DateTime.Today).Days;
                        return end.AddDays(rnd.Next(range));
                    }
                    string checkInDate = RandomDay().ToString();


                    int stayDurationNights = new Random().Next(1, 11); // Generates a number between 1 and 10

                    int nrOfAdults = new Random().Next(1, 5); // Generates a number between 1 and 4
                    int nrOfChildren = new Random().Next(0, 5); // Generates a number between 0 and 4        
                    string personCombination = nrOfAdults + "A" + nrOfChildren + "C";

                    int priceForOneAdult = new Random().Next(50, 201); // Generates a number between 50 and 200                   
                    int pricePerAdult = nrOfAdults * priceForOneAdult;
                    int pricePerChild = (priceForOneAdult / 2) * nrOfChildren;
                    int price = (pricePerAdult + pricePerChild) * stayDurationNights;

                    int showStrikePrice = new Random().Next(0, 2); // Generates a number between 0 and 1 

                    int strikePrice;
                    int strikePriceForOneAdult;
                    int strikePricePerAdult;
                    int strikePricePerChild;

                    if (showStrikePrice == 0)
                    {
                        strikePrice = 0;
                        strikePricePerAdult = 0;
                        strikePricePerChild = 0;
                    }
                    else
                    {
                        strikePriceForOneAdult = new Random().Next(50, priceForOneAdult + 1); // Generates a number between 50 and priceForOneAdult
                        strikePricePerAdult = nrOfAdults * strikePriceForOneAdult;
                        strikePricePerChild = (strikePriceForOneAdult / 2) * nrOfChildren;
                        strikePrice = (strikePricePerAdult + strikePricePerChild) * stayDurationNights;
                    }

                    conn.Execute(saveOffer,
                    new
                    {
                        CheckInDate = checkInDate,
                        StayDurationNights = stayDurationNights,
                        PersonCombination = personCombination,
                        Service_Code = serviceCode,
                        Price = price,
                        PricePerAdult = pricePerAdult,
                        PricePerChild = pricePerChild,
                        StrikePrice = strikePrice,
                        StrikePricePerAdult = strikePricePerAdult,
                        StrikePricePerChild = strikePricePerChild,
                        ShowStrikePrice = showStrikePrice,
                        LastUpdated = DateTime.Today.ToString()
                    },
                    commandType: CommandType.StoredProcedure);
                }
                Console.WriteLine("New dummy data added to the database.");
            }
        }

        //GetByService - Execute Stored Procedure
        public static void GetOfferByService(SqlConnection conn)
        {
            Console.WriteLine("Enter Service code: ");
            string serviceCode;
            serviceCode = Console.ReadLine();

            //Set up DynamicParameters object to pass parameters  
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("service_code", serviceCode);

            //Execute stored procedure and map the returned result to a Offer object  
            var offer = conn.QuerySingleOrDefault<Offer>("SP_Offers_GetOfferByService", parameters, commandType: CommandType.StoredProcedure);

            Console.WriteLine("Reading record: \n");

            Console.WriteLine(
               offer.CheckInDate.ToString("dd MMMM, yyyy") + " " +
               offer.StayDurationNights.ToString() + " " +
               offer.PersonCombination + " " +
               offer.Service_Code + " " +
               offer.Price.ToString() + " " +
               offer.PricePerAdult.ToString() + " " +
               offer.PricePerChild.ToString() + " " +
               offer.StrikePrice.ToString() + " " +
               offer.StrikePricePerAdult.ToString() + " " +
               offer.StrikePricePerChild.ToString() + " " +
               offer.ShowStrikePrice.ToString() + " " +
               offer.LastUpdated.ToString("dd MMMM, yyyy")
               );
               
               Console.ReadLine();     
        }

    }
}
