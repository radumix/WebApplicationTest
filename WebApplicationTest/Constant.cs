namespace WebApplicationTest
{
    public static class Constant
    {
        public static bool hasTransaction = false;
        public static bool transactionSuccessful = false;
        public static string SuccessMessage = "Transaction Successful!";
        public static string ErrorMessage = "Transaction Failed";

        public static readonly string AddCustomer = "add_customer_sp"; 
        public static readonly string GetCustomer = "get_customer_sp";
        public static readonly string GetCustomerById = "get_customer_by_id_sp";
        public static readonly string UpdateCustomer = "update_customer_sp";
        public static readonly string DeleteCustomerById = "delete_customer_by_id_sp";

    }
}
