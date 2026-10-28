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
            int id = 5;
            await WorkWithUserJson( id,service);
        }
        public static  async Task WorkWithUsersJson(IUserJsonService service,CancellationToken ct = default)
        {
            var result = await service.GetAllAsync(ct);
            
            DispalyEntities(result);
        }
        public static async Task WorkWithUserJson(int id,IUserJsonService service, CancellationToken ct = default)
        {
            if(id < 0)
            {
                throw new ArgumentException("Id can not be negative");
            }
            var user = await service.GetByIdAsync(id, ct);
            Console.WriteLine(user);
        }
        private static void DispalyEntities<T>(IReadOnlyCollection<T> entity) where T : class => entity.ToList().ForEach(t => Console.WriteLine(t));



    }

    
}
