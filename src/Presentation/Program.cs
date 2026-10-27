using Application.Interfaces;
using Application.Services;
using Domain.Entities;
namespace Presentation
{
    public class Program
    {
     
        static async Task Main(string[] args)
        {
            var service = new UserJsonService();
            await WorkWithUsersJson(service);
        }
        public static  async Task WorkWithUsersJson(IUserJsonService service,CancellationToken ct = default)
        {
            var result = await service.GetAllAsync(ct);
            DispalyEntities(result);
        }
        private static void DispalyEntities<T>(IReadOnlyCollection<T> entity) where T : class => entity.ToList().ForEach(t => Console.WriteLine(t));



    }

    
}
