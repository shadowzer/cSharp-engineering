using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Task2
{
    //Допустим, вы обнаружили, что не только транзакции в вашей программе обрабатываются схожим образом. Также обрабатываются заказы (OrderRequest и Order) и некоторые другие сущности.

    //Модифицируйте TransactionProcessor так, чтобы он мог работать с другими подобными классами.
    public abstract class TransactionProcessor<Request, Object>
    {
        public TransactionProcessor(Func<Request, bool> check, Func<Request, Object> register, Action<Object> save) 
        {
            Check = check;
            Register = register;
            Save = save;
        }

        public Object Process(Request request)
        {
            if (!Check(request))
                throw new ArgumentException();
            var result = Register(request);
            Save(result);
            return result;
        }

        Func<Request, bool> Check;
        Func<Request, Object> Register;
        Action<Object> Save;
    }
}
