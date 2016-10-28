using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Task1
{
    public class TransactionRequest { }
    public class Transaction { }

    public abstract class TransactionProcessor
    {
        public TransactionProcessor(Func<TransactionRequest, bool> check, Func<TransactionRequest, Transaction> register, Action<Transaction> save) 
        {
            Check = check;
            Register = register;
            Save = save;
        }

        public Transaction Process(TransactionRequest request)
        {
            if (!Check(request))
                throw new ArgumentException();
            var result = Register(request);
            Save(result);
            return result;
        }

        //protected abstract bool Check(TransactionRequest request);
        Func<TransactionRequest, bool> Check;
        //protected abstract Transaction Register(TransactionRequest request);
        Func<TransactionRequest, Transaction> Register;
        //protected abstract void Save(Transaction transaction);
        Action<Transaction> Save;
    }
}
