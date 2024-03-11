using Fractural.Tasks;

namespace FarewellToFate;

public interface IAsyncStartable
{
    GDTask StartAsync();
}