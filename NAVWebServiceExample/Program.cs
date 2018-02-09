using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAVWebServiceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Inbound Transaction Web Service 
            var inboundTransactionService = new ws_Inbound_Transactions.ws_Inbound_Transactions_Service();
            inboundTransactionService.UseDefaultCredentials = true;

            // Create Inbound Transaction Record
            var inboundTransaction = new ws_Inbound_Transactions.ws_Inbound_Transactions();

            inboundTransaction.ExampleBoolean = true;
            inboundTransaction.ExampleBooleanSpecified = true;
            inboundTransaction.ExampleInteger = 150;
            inboundTransaction.ExampleIntegerSpecified = true;
            inboundTransaction.ExampleString = "Example String";
            inboundTransaction.ExampleDate = DateTime.Today;
            inboundTransaction.ExampleDateSpecified = true;
            inboundTransaction.ExampleDecimal = 1.50M;
            inboundTransaction.ExampleDecimalSpecified = true;
            inboundTransaction.ExampleEnum = ws_Inbound_Transactions.ExampleEnum.Enum0;
            inboundTransaction.ExampleEnumSpecified = true;

            inboundTransactionService.Create(ref inboundTransaction);

            // Update Inbound Transaction Record
            inboundTransaction.ExampleBoolean = false;
            inboundTransaction.ExampleBooleanSpecified = true;
            inboundTransaction.ExampleEnum = ws_Inbound_Transactions.ExampleEnum.Enum1;
            inboundTransaction.ExampleEnumSpecified = true;

            inboundTransactionService.Update(ref inboundTransaction);

            // Read Inbound Transaction Record
            var inboundTransaction2 = inboundTransactionService.Read(3); // "3" begin the Primary Key of the record

            // Read Multiple Inbound Transaction Records
            var inboundTransactionFilter = new List<ws_Inbound_Transactions.ws_Inbound_Transactions_Filter>();
            inboundTransactionFilter.Add(new ws_Inbound_Transactions.ws_Inbound_Transactions_Filter() { Field = ws_Inbound_Transactions.ws_Inbound_Transactions_Fields.ExampleString, Criteria = "Example String 2" });
            inboundTransactionFilter.Add(new ws_Inbound_Transactions.ws_Inbound_Transactions_Filter() { Field = ws_Inbound_Transactions.ws_Inbound_Transactions_Fields.ExampleEnum, Criteria = ws_Inbound_Transactions.ExampleEnum.Enum2.ToString() });

            var inboundTransactions = inboundTransactionService.ReadMultiple(inboundTransactionFilter.ToArray(), null, 0);

            foreach (var inboundTransaction3 in inboundTransactions)
            {
                // Do something
            }
        }
    }
}
