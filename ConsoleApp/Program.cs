namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConsoleApp.Properties.Settings.SQLDatabase"].ConnectionString);

            //Thread mainThread = Thread.CurrentThread;

            //Thread thread1 = new Thread();
            //Thread thread2 = new Thread();

            //Get All - No Stored Procedure
            //using (conn)
            //{
            //    conn.Open();
            //    Queries.GetOffers(conn);
            //}

            //using (conn)
            //{
            //    conn.Open();

            //    //GetById - Execute Stored Procedure
            //    //Queries.GetOfferById(conn);
            //}

            //using (conn)
            //{
            //    conn.Open();

            //    //GetByService - Execute Stored Procedure
            //    //Queries.GetOfferByService(conn);
            //}


            using (conn)
            {
                conn.Open();

                Queries.GenerateOffers(conn);
            }       
        }
    }
}