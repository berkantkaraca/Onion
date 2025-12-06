using System;
using System.Threading.Tasks;

namespace Project.Bll.ErrorHandling
{
    public static class ExceptionHandler
    {
        // Void dönen sync metotlar için 
        public static void Execute(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                throw new Exception($"İşlem sırasında bir hata oluştu: {ex.Message}", ex);
            }
        }

        // Dönüş tipi olan sync metotlar için
        public static T Execute<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                throw new Exception($"İşlem sırasında bir hata oluştu: {ex.Message}", ex);
            }
        }

        // Void dönen async metotlar için
        public static async Task ExecuteAsync(Func<Task> func)
        {
            try
            {
                await func();
            }
            catch (Exception ex)
            {
                throw new Exception($"İşlem sırasında bir hata oluştu: {ex.Message}", ex);
            }
        }

        // Dönüş tipi olan async metotlar için
        public static async Task<T> ExecuteAsync<T>(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                throw new Exception($"İşlem sırasında bir hata oluştu: {ex.Message}", ex);
            }
        }
    }
}
