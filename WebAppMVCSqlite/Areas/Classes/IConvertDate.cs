using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVCSqlite.Areas.Classes
{
    public interface IConvertDate
    {
        DateTime ConvertShamsiToMiladi(string Date);
        string ConvertMiladiToShamsi(DateTime Date);
        string ConvertMiladiToShamsi(DateTime Date, string Format);
        string ShamsiDateTimeNow();
    }
}
