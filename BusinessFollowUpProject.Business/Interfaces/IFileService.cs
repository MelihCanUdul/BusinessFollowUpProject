using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFollowUpProject.Business.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Geriye dönüş ve upload etmiş olduğu pdf dosyasının virtual pathini döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        string TransferPdf<T>(List<T> list) where T : class, new();
       /// <summary>
       /// Geriye excel verisini byte dizisi olarak döner.
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="list"></param>
       /// <returns></returns>
        byte[] TransferExcel<T>(List<T> list) where T : class, new();
    }
}
